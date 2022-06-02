using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Configuration;

namespace WebSatisOtomasyonu.UserPage
{
    public partial class AnaSayfa : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblOturum.Visible = false;
            try
            {
                lblOturum.Text = Session["adminGirisi"].ToString();
            }
            catch
            {
                Response.Redirect("LoginScreenAdmin.aspx");
            }

            SqlCommand urunSayisi = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spUrunlerSayfasindakiToplamaIslemi"
            };
            SqlDataReader oku = urunSayisi.ExecuteReader();

            while (oku.Read())
            {
                lblToplamUrunSayisi.Text = oku[0].ToString();
            }
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());



            SqlCommand tedarikciSayisi = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spCalisilanTedarikciSayisi"
            };
            SqlDataReader oku2 = tedarikciSayisi.ExecuteReader();

            while (oku2.Read())
            {
                lblTedarikciSayisi.Text = oku2[0].ToString();
            }
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());


            SqlCommand kategoriSayisi = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spToplamAktifKategoriSayisi"
            };
            SqlDataReader oku3 = kategoriSayisi.ExecuteReader();

            while (oku3.Read())
            {
                lblKategoriSayisi.Text = oku3[0].ToString();
            }
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());


        }
    }
}