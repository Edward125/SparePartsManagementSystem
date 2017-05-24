using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;


namespace SparePartsManagementSystem
{
    public  class p
    {
        #region 参数定义

        public static string AppFolder = Application.StartupPath + @"\SpareParts";
        public static string AppLocalDB = AppFolder + @"\SpareParts.db";
        public static string localDbConnectionString = "Data Source="  + AppLocalDB;





        #endregion


    }
}
