﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OperateSQL;

using System.Configuration;

namespace GenScripts
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			edServer.Text = ConfigurationManager.AppSettings["ServerName"];
			edBD.Text = ConfigurationManager.AppSettings["DBName"];
			//edServer.Text = ConfigurationManager.ConnectionStrings["GenScripts.Properties.Settings.ServerName"].ConnectionString;
			//edBD.Text = ConfigurationManager.ConnectionStrings["GenScripts.Properties.Settings.DBName"].ConnectionString;
			//edServer.Text = ConfigurationManager.AppSettings.Get("ServerName");
			//edBD.Text = ConfigurationManager.AppSettings["GenScripts.Properties.Settings.DBName"].ToString();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ClassOperate myServer = new ClassOperate();
			ClassOperate.ServerName = edServer.Text;
			ClassOperate.DBName = edBD.Text; 
			ClassOperate.ULogin = edLogin.Text; // @"sa";
			ClassOperate.Psw = edPsw.Text; // @"123456";
			ClassOperate.WinAuth = cbAuth.Checked;

			ClassOperate.doTables = cbTables.Checked;
			ClassOperate.doViews = cbViews.Checked;
			ClassOperate.doProcs = cbProcs.Checked;
			ClassOperate.doFuncs = cbFuncs.Checked;
			myServer.DoIt();
		}

		private void edServer_TextChanged(object sender, EventArgs e)
		{

		}

	}
}
