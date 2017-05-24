using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace SparePartsManagementSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            checkFolder();
            if (!checkDB())
                Environment.Exit(0);
        }







        #region local database


        /// <summary>
        /// check folder
        /// </summary>
        private void checkFolder()
        {
            if (!Directory.Exists(p.AppFolder))
                Directory.CreateDirectory(p.AppFolder);
        }



        /// <summary>
        /// check database,if not exits,create if
        /// </summary>
        private bool checkDB()
        {

            if (!File.Exists(p.AppLocalDB))
            {
                if (!createDB())
                    return false;
            }

            return true;
        }

        /// <summary>
        /// create a database with password
        /// </summary>
        private bool  createDB()
        {

            try
            {
                MessageBox.Show(p.localDbConnectionString);
               // SQLiteConnection.CreateFile(Global.AppDB);
                SQLiteConnection conn = new SQLiteConnection(p.localDbConnectionString);
                conn.Open();
                //conn.ChangePassword(p.DBPassword);
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show ("Create DB Fail." + ex.Message ,"Create DB Fail" ,MessageBoxButtons.OK,MessageBoxIcon.Error );
                return false;
              
            }
        }



        #endregion
    }
}
