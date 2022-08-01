﻿using CSharp_SQL_App.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_SQL_App {
    public partial class IstorijaPromenaForm : Form {
        private String uGuid { get;set;}
        
        public IstorijaPromenaForm(String uGuid) {
            InitializeComponent();
            this.uGuid = uGuid;
            fillChangeLogGrid();
        }
        private void IstorijaPromenaForm_Load(object sender, EventArgs e) {
            
        }

        public void fillChangeLogGrid() {
            DataTable dt;
            BindingSource bs;
            OleDbConnection myConnection;
            OleDbCommand command;
            myConnection = GetConnection();
            myConnection.Open();
            String query = "SELECT * FROM changeLog WHERE primaryKey = @uGuid";
            command = new OleDbCommand(query, myConnection);
            command.Parameters.AddWithValue("@uGuid", uGuid);
            dt = new DataTable();
            bs = new BindingSource();
            dt.Load(command.ExecuteReader());
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            myConnection.Close();
        }
        private OleDbConnection GetConnection() {
            return new OleDbConnection(Properties.Settings.Default.ugovoriConnectionString);
        }
    }
}
