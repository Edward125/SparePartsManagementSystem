using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;


namespace SparePartsManagementSystem
{
    public  class Global
    {
        #region 参数定义

        public static string AppFolder = Application.StartupPath + @"\SpareParts";
        public static string AppDB = AppFolder + @"\SpareParts.db";
        public static string dbConnectionStringNoPassword = "Data Source=" + @"\" + @AppDB;
        public static string dbConnectionString = "Data Source=" + @"\" + @AppDB + ";password=" + @DBPassword;
        public static string DBPassword = "kd!@#)";




        #endregion


    }
}
