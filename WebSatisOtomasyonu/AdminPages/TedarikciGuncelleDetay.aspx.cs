using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebSatisOtomasyonu.UserPage
{
    public partial class TedarikciGuncelleDetay : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();
        string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblOturum.Text = Session["adminGirisi"].ToString();

            }
            catch
            {

                Response.Redirect("LoginScreenAdmin.aspx");
                
            }

            id = Request.QueryString["tedarikciid"];

            try
            {
                if (Page.IsPostBack == false)
                {
                    SqlCommand komut = new SqlCommand()
                    {
                        Connection = bgl.baglanti(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "spTedarikciIdGoreTedarikciBilgileriGetir"
                    };

                    SqlParameter tedarikciId = new SqlParameter("@p1", SqlDbType.SmallInt);

                    tedarikciId.Value = id;

                    komut.Parameters.Add(tedarikciId);

                    SqlDataReader oku = komut.ExecuteReader();

                    while (oku.Read())
                    {
                        tboxTedarikciAd.Text = oku[0].ToString();
                        tboxAdres.Text = oku[1].ToString();
                        tboxTelNo.Text = oku[2].ToString();
                    }
                    bgl.baglanti().Close();
                    SqlConnection.ClearPool(bgl.baglanti());


                }
            }
            catch
            {
                Response.Redirect("TedarikciGuncelle.aspx");
            }


        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spTedarikciBilgisiGuncelle"
            };

            SqlParameter tedarikciAd = new SqlParameter("@p1", SqlDbType.VarChar);
            SqlParameter tedarikciAdres = new SqlParameter("@p2", SqlDbType.VarChar);
            SqlParameter tedarikciTelNo = new SqlParameter("@p3", SqlDbType.VarChar);
            SqlParameter tedarikciId2 = new SqlParameter("@p4", SqlDbType.SmallInt);

            tedarikciAd.Value = tboxTedarikciAd.Text;
            tedarikciAdres.Value = tboxAdres.Text;
            tedarikciTelNo.Value = tboxTelNo.Text;
            tedarikciId2.Value = id;

            komut.Parameters.Add(tedarikciAd);
            komut.Parameters.Add(tedarikciAdres);
            komut.Parameters.Add(tedarikciTelNo);
            komut.Parameters.Add(tedarikciId2);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());

            Response.Redirect("TedarikciGuncelle.aspx");
        }
    }
}