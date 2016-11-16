using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OperateSQL;

namespace GenScripts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassOperate myServer = new ClassOperate();
            //ClassOperate.ServerName = @"orvdserver";
            //ClassOperate.DBName = @"PlanBaseCFn01";
            ClassOperate.ServerName = edServer.Text;// @"orvdserver";
            ClassOperate.DBName = edBD.Text; // @"TestDS";
            ClassOperate.ULogin = edLogin.Text; // @"sa";
            ClassOperate.Psw = edPsw.Text; // @"123456";

            ClassOperate.doTables = cbTables.Checked;
            ClassOperate.doViews  = cbViews.Checked;
            ClassOperate.doProcs  = cbProcs.Checked;
            ClassOperate.doFuncs  = cbFuncs.Checked;
            myServer.DoIt();
        }

    }
}
