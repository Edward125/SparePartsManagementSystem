using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;
using SparePartsManagementSystem.Properties;
using System.Reflection;

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

            if (this.comboSkinList.Items.Count > 0)
                this.comboSkinList.SelectedIndex = 1;

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

            if (!Directory.Exists(p.SkinFolder))
                Directory.CreateDirectory(p.SkinFolder);
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




        private void loadSkinFile(ComboBox combobox)
        {
            string fileText = combobox.SelectedItem.ToString();
            switch (fileText)
            {
                case "MacOs":
                    if (downLoadFile(fileText))
                        this.skinEngine1.SkinFile = p.SkinFolder + @"\" + fileText;
                    else
                        this.skinEngine1.SkinFile = "";
                    break;
                case "DeepCyan":
                    if (downLoadFile(fileText))
                        this.skinEngine1.SkinFile = p.SkinFolder + @"\" + fileText;
                    else
                        this.skinEngine1.SkinFile = "";
                    break;
                case "SportsCyan":
                      if (downLoadFile(fileText))
                        this.skinEngine1.SkinFile = p.SkinFolder + @"\" + fileText;
                    else
                        this.skinEngine1.SkinFile = "";
                    break;

                default:
                    this.skinEngine1.SkinFile = "";
                    break;
            }

        }


        private bool downLoadFile(string fileName)
        {
            string skinFile = p.SkinFolder +@"\" + fileName ;
            if (!File.Exists(skinFile))
            {
                byte[] template = getFileBype(fileName);

                FileStream stream = new FileStream(skinFile, FileMode.Create);
                try
                {
                    stream.Write(template, 0, template.Length);
                    stream.Close();
                    stream.Dispose();
                    File.SetAttributes(skinFile, FileAttributes.Hidden);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Download skin file '" + fileName +"' fail," + ex.Message ,"Skin File Error",MessageBoxButtons.OK,MessageBoxIcon.Error );
                    return false;
                }     

            }
            return true;


        }

        private byte[] getFileBype(string filename)
        {

            if (filename == "MacOs")
            {
                return  Properties.Resources.MacOS;
            }
            else if (filename == "DeepCyan")
            {
                return   Properties.Resources.DeepCyan;
            }
            else 
            {
                return  Properties.Resources.SportsCyan;
            }  
        }


        #endregion

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void comboSkinList_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadSkinFile(comboSkinList);
        }


    }
}
