using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Specialized;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Sdk.Sfc;

namespace OperateSQL
{
    public class ClassOperate
    {
        public static string ServerName;
        public static string DBName;
        public static string ULogin;
        public static string Psw;
        public static bool WinAuth;

        public static bool doTables;
        public static bool doViews;
        public static bool doProcs;
        public static bool doFuncs;

        static string newline = "\r\n";
        public void DoIt()
        {
            //Создается экземпляр сервера
            Server myServer = new Server(ServerName);
            //Аутентификация Windows (LoginSecure = true)
            myServer.ConnectionContext.LoginSecure = WinAuth;
            if (WinAuth == false)
            {
                myServer.ConnectionContext.Login = ULogin;
                myServer.ConnectionContext.Password = Psw;
            }
            //Открыть соединение
            myServer.ConnectionContext.Connect();
//            //Директория создается автоматически, с новой папкой на каждый день 
//            string dir = Application.StartupPath + @"\" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString(@"D2") + "_" + DateTime.Now.Day.ToString(@"D2");
            string dir = Application.StartupPath + @"\ActualSql";
            Directory.CreateDirectory(dir);
            //Генерация таблиц, описание ниже
            if (doTables) GenerateTableScript(myServer, dir);
            //Генерация процедур, описание ниже
            if (doProcs) GenerateProceduresScript(myServer, dir);
            //Генерация функций, описание ниже
            if (doFuncs) GenerateFuncScript(myServer, dir);
            //Генерация представлений, описание ниже
            if (doViews) GenerateViewScript(myServer, dir);
            //Закрыть соединение
            myServer.ConnectionContext.Disconnect();
            MessageBox.Show("Ok");
        }

        //Генерация скриптов для таблиц
        private static void GenerateTableScript(Server myServer, string path)
        {
            Directory.CreateDirectory(path + @"\Tables\");
            Directory.CreateDirectory(path + @"\Triggers\");
            string text = "";
            string trigtext = "";
            //Создаем экземпляр класса, который будет генерировать скрипты
            Scripter scripter = new Scripter(myServer);
            //Создаем экземпляр класса базы данных, "DBName" - название базы данных
            Database myAdventureWorks = myServer.Databases[DBName];
            //Создаем экземпляр класса настроек генерации скриптов
            ScriptingOptions scriptOptions = new ScriptingOptions();
            //Функциональность свойств у класса настроек генерации легко определяема
            //Не создавать скрипт с Drop
            scriptOptions.ScriptDrops = false;
            //Не включать скрипт с If Not Exists
            scriptOptions.IncludeIfNotExists = false;
            scriptOptions.Encoding = System.Text.Encoding.GetEncoding(1251);
            scriptOptions.DriAllConstraints = true;
            scriptOptions.DriAllKeys = true;
            scriptOptions.DriDefaults = true;
            scriptOptions.DriForeignKeys = true;
            scriptOptions.DriIndexes = true;
            scriptOptions.DriNonClustered = true;
            scriptOptions.DriPrimaryKey = true;
            scriptOptions.DriUniqueKeys = true;
            scriptOptions.ExtendedProperties = true;

            //Перебираем все таблицы
            foreach (Table myTable in myAdventureWorks.Tables) 
            {
                if (myTable.IsSystemObject) continue;                           
                //Получаем sql запрос на основание выбранных параметров
                StringCollection tableScripts = myTable.Script(scriptOptions);
                //Переменная для объединения строк 
                string newSql = "";
                //Объединяем строки
                foreach (string script in tableScripts)
                {
                    string line = script.Replace(@"SET ANSI_NULLS ON", newline + @"SET ANSI_NULLS ON");
                    newSql = newSql + line + newline;
                    text = text + line + newline;
                }
                //Записываем в файл скрипт создания таблицы
                File.WriteAllText(path + @"\Tables\TABLE [" + myTable.Owner + @"].[" + myTable.Name + @"].sql", newSql, System.Text.Encoding.GetEncoding(1251));

                foreach (Trigger myTrig in  myTable.Triggers) 
                {
                    if (myTrig.IsSystemObject) continue;
                    //Получаем sql запрос на основание выбранных параметров
                    StringCollection trigScripts = myTrig.Script(scriptOptions);
                    //Переменная для объединения строк 
                    string newSqlTrig = "";
                    //Объединяем строки
                    foreach (string trigscript in trigScripts)
                    {
                        string trline = trigscript.Replace(@"SET ANSI_NULLS ON", newline + @"SET ANSI_NULLS ON");
                        newSqlTrig = newSqlTrig + trline + newline;
                        trigtext = trigtext + trline + newline;
                    }
                    //Записываем в файл скрипт создания таблицы
                    File.WriteAllText(path + @"\Triggers\TRIGGER [dbo].[" + myTrig.Name + @"].sql", newSqlTrig, System.Text.Encoding.GetEncoding(1251));
                }
                //Записываем общие объединяющие файлы
            }
            //Записываем общие объединяющие файлы
            File.WriteAllText(path + @"\" + "AllTable.sql", text, System.Text.Encoding.GetEncoding(1251));
            File.WriteAllText(path + @"\" + "AllTriggers.sql", trigtext, System.Text.Encoding.GetEncoding(1251));

            //Вместе с таблицами генерить триггеры
            //GenerateTableTriggerScript( myServer, path);
        }

        //Генерация скриптов для табличных триггеров
        private static void GenerateTableTriggerScript(Server myServer, string path)
        {
            Directory.CreateDirectory(path + @"\Triggers\");
            string text = "";
            //Создаем экземпляр класса, который будет генерировать скрипты
            Scripter scripter = new Scripter(myServer);
            //Создаем экземпляр класса базы данных, "DBName" - название базы данных
            Database myAdventureWorks = myServer.Databases[DBName];
            //Создаем экземпляр класса настроек генерации скриптов
            ScriptingOptions scriptOptions = new ScriptingOptions();
            //Функциональность свойств у класса настроек генерации легко определяема
            //Не создавать скрипт с Drop
            scriptOptions.ScriptDrops = false;
            //Не включать скрипт с If Not Exists
            scriptOptions.IncludeIfNotExists = false;
            scriptOptions.Encoding = System.Text.Encoding.GetEncoding(1251);

            //Перебираем все таблицы
            foreach (Trigger myTrig in myAdventureWorks.Tables)
            {
                if (myTrig.IsSystemObject) continue;
                //Получаем sql запрос на основание выбранных параметров
                StringCollection trigScripts = myTrig.Script(scriptOptions);
                //Переменная для объединения строк 
                string newSql = "";
                //Объединяем строки
                foreach (string script in trigScripts)
                {
                    string line = script.Replace(@"SET ANSI_NULLS ON", newline + @"SET ANSI_NULLS ON");
                    newSql = newSql + line + newline;
                    text = text + line + newline;
                }
                //Записываем в файл скрипт создания таблицы
                File.WriteAllText(path + @"\Triggers\TRIGGER [dbo].[" + myTrig.Name + @"].sql", newSql, System.Text.Encoding.GetEncoding(1251));
            }
            //Записываем общие объединяющие файлы
            File.WriteAllText(path + @"\" + "AllTriggers.sql", text, System.Text.Encoding.GetEncoding(1251));
        }

        //Генерация скриптов для представлений
        private static void GenerateViewScript(Server myServer, string path)
        {
            Directory.CreateDirectory(path + @"\Views\");
            string text = "";
            Scripter scripter = new Scripter(myServer);
            Database myAdventureWorks = myServer.Databases[DBName];
            ScriptingOptions scriptOptions = new ScriptingOptions();
            scriptOptions.ScriptDrops = false;
            scriptOptions.IncludeIfNotExists = false;
            scriptOptions.Encoding = System.Text.Encoding.GetEncoding(1251);

            foreach (Microsoft.SqlServer.Management.Smo.View myView in myAdventureWorks.Views)
            {
                if (myView.IsSystemObject) continue;
                StringCollection ProcedureScripts = myView.Script(scriptOptions);
                string newSql = "";
                foreach (string script in ProcedureScripts)
                {
                    newSql = newSql + script + newline;
                    text = text + script + newline;
                }
                File.WriteAllText(path + @"\Views\" + myView.Name + ".sql", newSql, System.Text.Encoding.GetEncoding(1251));
            }
            File.WriteAllText(path + @"\" + "AllView.sql", text, System.Text.Encoding.GetEncoding(1251));
        }

        //Генерация скриптов для процедур
        private static void GenerateProceduresScript(Server myServer, string path)
        {
            Directory.CreateDirectory(path + @"\Procedures\");
            string text = "";
            Scripter scripter = new Scripter(myServer);
            Database myAdventureWorks = myServer.Databases[DBName];
            ScriptingOptions scriptOptions = new ScriptingOptions();
            scriptOptions.ScriptDrops = false;
            scriptOptions.IncludeIfNotExists = false;
            scriptOptions.ScriptBatchTerminator = true;
            scriptOptions.Encoding = System.Text.Encoding.GetEncoding(1251);

            /* scripter.Options.ScriptDrops = false;
            scripter.Options.IncludeIfNotExists = false;
            scripter.Options.ScriptBatchTerminator = true;
           // scripter.Options.ToFileOnly = true;
            scripter.Options.AnsiFile = true;
            scripter.Options.Encoding = System.Text.Encoding.ASCII;
             //scriptOptions.Encoding = System.Text.Encoding.UTF8;
            */
           
            foreach (StoredProcedure myProcedure in myAdventureWorks.StoredProcedures)
            {
                if (myProcedure.IsSystemObject) continue;
                StringCollection ProcedureScripts = myProcedure.Script(scriptOptions); ; //  scripter.Script(new Urn[] { myProcedure.Urn })    

                string newSql = "";
                foreach (string script in ProcedureScripts)
                {
                    char[] charsToTrim = { ' ', '\r', '\n' };
                    string line = script.Trim(charsToTrim);
                    line = line.Replace("CREATE PROCEDURE", "ALTER PROCEDURE");
                    line = line.Replace(@"SET ANSI_NULLS ON", @"SET ANSI_NULLS ON" + newline + @"GO");
                    line = line.Replace(@"SET QUOTED_IDENTIFIER ON", @"SET QUOTED_IDENTIFIER ON" + newline + @"GO");
                    newSql = newSql + line + newline;
                    text = text + line + newline;
                }
                newSql = newSql + @"GO" + newline;
                text = text + @"GO" + newline + newline;
                File.WriteAllText(path + @"\Procedures\PROCEDURE [" + myProcedure.Owner + @"].[" + myProcedure.Name + @"].sql", newSql, System.Text.Encoding.GetEncoding(1251));
            }
            File.WriteAllText(path + @"\" + @"AllProcedure.sql", text, System.Text.Encoding.GetEncoding(1251)); 
        }
        
        //Генерация скриптов для функций
        private static void GenerateFuncScript(Server myServer, string path)
        {
            Directory.CreateDirectory(path + @"\Functions\");
            string text = "";
            Scripter scripter = new Scripter(myServer);
            Database myAdventureWorks = myServer.Databases[DBName];
            ScriptingOptions scriptOptions = new ScriptingOptions();
            scriptOptions.ScriptDrops = false;
            scriptOptions.IncludeIfNotExists = false;
            scriptOptions.ScriptBatchTerminator = false;
            scriptOptions.AnsiFile = false;
            scriptOptions.Encoding = System.Text.Encoding.GetEncoding(1251);
            foreach (UserDefinedFunction myFunc in myAdventureWorks.UserDefinedFunctions)
            {
                if (myFunc.IsSystemObject) continue;
                StringCollection FuncScripts = myFunc.Script(scriptOptions);
                FuncScripts = myFunc.Script();
                string newSql = "";
                foreach (string script in FuncScripts)
                {
                    char[] charsToTrim = { ' ', '\r', '\n' };
                    string line = script.Trim(charsToTrim);
                    line = line.Replace("CREATE FUNCTION", "ALTER FUNCTION");
                    line = line.Replace("SET ANSI_NULLS ON", "SET ANSI_NULLS ON" + newline + @"GO");
                    line = line.Replace("SET QUOTED_IDENTIFIER ON", "SET QUOTED_IDENTIFIER ON" + newline + @"GO");
                    newSql = newSql + line + newline;
                    text = text + line + newline;
                }
                newSql = newSql + @"GO" + newline;
                text = text + @"GO" + newline + newline;
                File.WriteAllText(path + @"\Functions\FUNCTION [" + myFunc.Owner + "].[" + myFunc.Name + "].sql", newSql, System.Text.Encoding.GetEncoding(1251));
            }
            File.WriteAllText(path + @"\" + "AllFunctions.sql", text, System.Text.Encoding.GetEncoding(1251));
        }
    }
}
