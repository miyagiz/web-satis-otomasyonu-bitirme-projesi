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
    public partial class KategoriGuncelleDetay : System.Web.UI.Page
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




            try
            {
                if (Page.IsPostBack == false)
                {
                    cinsiyetleriGetir();

                    id = Request.QueryString["kategoriid"];

                    SqlCommand komut = new SqlCommand()
                    {
                        Connection = bgl.baglanti(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "spIdGoreKategoriBilgileriniGetir"
                    };

                    SqlParameter kateId = new SqlParameter("@p1", SqlDbType.SmallInt);

                    kateId.Value = id;

                    komut.Parameters.Add(kateId);
                    
                    SqlDataReader oku = komut.ExecuteReader();

                    while (oku.Read())
                    {
                        tboxKategoriAd.Text = oku[0].ToString();
                        ddListCinsiyet.SelectedValue = oku[1].ToString(); ;
                    }
                    bgl.baglanti().Close();
                    SqlConnection.ClearPool(bgl.baglanti());
                }
            }
            catch
            {

                Response.Redirect("KategoriGuncelle.aspx");
            }






        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spKategoriBilgisiGuncelleme"
            };

            SqlParameter kategoriAd = new SqlParameter("@p1", SqlDbType.VarChar);
            SqlParameter cinsiyet = new SqlParameter("@p1", SqlDbType.SmallInt);
            SqlParameter kategoriId = new SqlParameter("@p1", SqlDbType.SmallInt);

            kategoriAd.Value = tboxKategoriAd.Text;
            cinsiyet.Value = ddListCinsiyet.SelectedValue;
            kategoriId.Value = id;

            komut.Parameters.Add(kategoriAd);
            komut.Parameters.Add(cinsiyet);
            komut.Parameters.Add(kategoriId);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());

            Response.Redirect("KategoriGuncelle.aspx");
        }


        public void cinsiyetleriGetir()
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spCinsiyetleriGetir"
            };
            SqlDataReader oku = komut.ExecuteReader();

            ddListCinsiyet.DataTextField = "cinsiyet_detay";
            ddListCinsiyet.DataValueField = "cinsiyet_id";

            ddListCinsiyet.DataSource = oku;
            ddListCinsiyet.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }
    }
}