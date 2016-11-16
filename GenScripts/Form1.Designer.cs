namespace GenScripts
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.button1 = new System.Windows.Forms.Button();
			this.cbTables = new System.Windows.Forms.CheckBox();
			this.cbViews = new System.Windows.Forms.CheckBox();
			this.cbProcs = new System.Windows.Forms.CheckBox();
			this.cbFuncs = new System.Windows.Forms.CheckBox();
			this.edServer = new System.Windows.Forms.TextBox();
			this.edPsw = new System.Windows.Forms.TextBox();
			this.edLogin = new System.Windows.Forms.TextBox();
			this.edBD = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cbAuth = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(126, 156);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Generate";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// cbTables
			// 
			this.cbTables.AutoSize = true;
			this.cbTables.Location = new System.Drawing.Point(240, 10);
			this.cbTables.Name = "cbTables";
			this.cbTables.Size = new System.Drawing.Size(71, 17);
			this.cbTables.TabIndex = 1;
			this.cbTables.Text = "Таблицы";
			this.cbTables.UseVisualStyleBackColor = true;
			// 
			// cbViews
			// 
			this.cbViews.AutoSize = true;
			this.cbViews.Location = new System.Drawing.Point(240, 33);
			this.cbViews.Name = "cbViews";
			this.cbViews.Size = new System.Drawing.Size(105, 17);
			this.cbViews.TabIndex = 2;
			this.cbViews.Text = "Представления";
			this.cbViews.UseVisualStyleBackColor = true;
			// 
			// cbProcs
			// 
			this.cbProcs.AutoSize = true;
			this.cbProcs.Checked = true;
			this.cbProcs.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbProcs.Location = new System.Drawing.Point(240, 56);
			this.cbProcs.Name = "cbProcs";
			this.cbProcs.Size = new System.Drawing.Size(83, 17);
			this.cbProcs.TabIndex = 3;
			this.cbProcs.Text = "Процедуры";
			this.cbProcs.UseVisualStyleBackColor = true;
			// 
			// cbFuncs
			// 
			this.cbFuncs.AutoSize = true;
			this.cbFuncs.Checked = true;
			this.cbFuncs.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbFuncs.Location = new System.Drawing.Point(240, 79);
			this.cbFuncs.Name = "cbFuncs";
			this.cbFuncs.Size = new System.Drawing.Size(72, 17);
			this.cbFuncs.TabIndex = 4;
			this.cbFuncs.Text = "Функции";
			this.cbFuncs.UseVisualStyleBackColor = true;
			// 
			// edServer
			// 
			this.edServer.Location = new System.Drawing.Point(101, 10);
			this.edServer.Name = "edServer";
			this.edServer.Size = new System.Drawing.Size(100, 20);
			this.edServer.TabIndex = 5;
			this.edServer.Text = "orvdserver";
			this.edServer.TextChanged += new System.EventHandler(this.edServer_TextChanged);
			// 
			// edPsw
			// 
			this.edPsw.Location = new System.Drawing.Point(101, 115);
			this.edPsw.Name = "edPsw";
			this.edPsw.PasswordChar = '*';
			this.edPsw.Size = new System.Drawing.Size(100, 20);
			this.edPsw.TabIndex = 8;
			this.edPsw.Text = "123456";
			// 
			// edLogin
			// 
			this.edLogin.Location = new System.Drawing.Point(101, 89);
			this.edLogin.Name = "edLogin";
			this.edLogin.Size = new System.Drawing.Size(100, 20);
			this.edLogin.TabIndex = 7;
			this.edLogin.Text = "sa";
			// 
			// edBD
			// 
			this.edBD.Location = new System.Drawing.Point(101, 36);
			this.edBD.Name = "edBD";
			this.edBD.Size = new System.Drawing.Size(100, 20);
			this.edBD.TabIndex = 6;
			this.edBD.Text = "PlanBaseCFn01";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(50, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Сервер";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(71, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(23, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "БД";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(56, 91);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Логин";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(49, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(45, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "Пароль";
			// 
			// cbAuth
			// 
			this.cbAuth.AutoSize = true;
			this.cbAuth.Location = new System.Drawing.Point(52, 66);
			this.cbAuth.Name = "cbAuth";
			this.cbAuth.Size = new System.Drawing.Size(157, 17);
			this.cbAuth.TabIndex = 13;
			this.cbAuth.Text = "Аутентификация Windows";
			this.cbAuth.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(353, 190);
			this.Controls.Add(this.cbAuth);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.edBD);
			this.Controls.Add(this.edLogin);
			this.Controls.Add(this.edPsw);
			this.Controls.Add(this.edServer);
			this.Controls.Add(this.cbFuncs);
			this.Controls.Add(this.cbProcs);
			this.Controls.Add(this.cbViews);
			this.Controls.Add(this.cbTables);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Генерация скриптов";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cbTables;
        private System.Windows.Forms.CheckBox cbViews;
        private System.Windows.Forms.CheckBox cbProcs;
        private System.Windows.Forms.CheckBox cbFuncs;
        private System.Windows.Forms.TextBox edServer;
        private System.Windows.Forms.TextBox edPsw;
        private System.Windows.Forms.TextBox edLogin;
        private System.Windows.Forms.TextBox edBD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbAuth;
    }
}

