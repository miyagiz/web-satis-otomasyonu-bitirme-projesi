using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace WebSatisOtomasyonu
{
    public class sqlsinif
    {
        public SqlConnection baglanti()
        {
            //Somee.com için DataBase Bağlantısı
            //SqlConnection baglan = new SqlConnection(@"workstation id=stokmrc.mssql.somee.com;packet size=4096;user id=r4zoq_SQLLogin_1;pwd=y2mbn5fuc7;data source=stokmrc.mssql.somee.com;persist security info=False;initial catalog=stokmrc");
            SqlConnection baglan = new SqlConnection(@"Data Source=MIRACPC\SQLEXPRESS; Initial Catalog = dbo_websatisotomasyonu; Integrated Security=True; uid=sa; pwd=1234");
            baglan.Open();
            return baglan;
        }
    }
}