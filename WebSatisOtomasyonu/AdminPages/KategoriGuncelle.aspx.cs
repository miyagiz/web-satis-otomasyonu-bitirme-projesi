using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Threading;
using System.Data;


namespace WebSatisOtomasyonu.UserPage
{
    public partial class KategoriGuncelle : System.Web.UI.Page
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

            id = Request.QueryString["kategoriid"];



            kategorileriGetir();

            if (Page.IsPostBack == false)
            {
                SqlCommand komut2 = new SqlCommand()
                {
                    Connection = bgl.baglanti(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spCinsiyetleriGetir"
                };

                SqlDataReader oku2 = komut2.ExecuteReader();

                ddListCinsiyetFiltre.DataTextField = "cinsiyet_detay";
                ddListCinsiyetFiltre.DataValueField = "cinsiyet_id";

                ddListCinsiyetFiltre.DataSource = oku2;
                ddListCinsiyetFiltre.DataBind();
                ddListCinsiyetFiltre.Items.Add(new ListItem("Cinsiyet Seçiniz...", "T"));
                ddListCinsiyetFiltre.SelectedValue = "T";
                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());
            }






        }

        public void kategorileriGetir()
        {
            SqlCommand komut8 = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spKategoriBilgileriniGetir"
            };

            SqlDataReader oku8 = komut8.ExecuteReader();

            dListKategoriler.DataSource = oku8;
            dListKategoriler.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }

        protected void ddListCinsiyetFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cinsiyet = ddListCinsiyetFiltre.SelectedItem.Text;

            if (ddListCinsiyetFiltre.SelectedItem.Text == cinsiyet)
            {
                SqlCommand komut2 = new SqlCommand()
                {
                    Connection = bgl.baglanti(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spKategoriSayfasindaCinsiyetFiltre"
                };

                SqlParameter prCinsiyet = new SqlParameter("@p1", SqlDbType.VarChar);

                prCinsiyet.Value = cinsiyet;

                komut2.Parameters.Add(prCinsiyet);
                SqlDataReader oku2 = komut2.ExecuteReader();

                dListKategoriler.DataSource = oku2;
                dListKategoriler.DataBind();
                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());
            }

        }

        protected void btnAra_Click(object sender, EventArgs e)
        {
            if (tboxSearch.Text != "")
            {
                if (ddListCinsiyetFiltre.SelectedValue == "T")
                {
                    SqlCommand aramaKomutu = new SqlCommand()
                    {
                        Connection = bgl.baglanti(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "spKategoriSayfasindaArama2"
                    };

                    SqlParameter kelime = new SqlParameter("@p1", SqlDbType.VarChar);

                    kelime.Value = tboxSearch.Text;

                    aramaKomutu.Parameters.Add(kelime);

                    SqlDataReader oku = aramaKomutu.ExecuteReader();

                    dListKategoriler.DataSource = oku;
                    dListKategoriler.DataBind();

                    bgl.baglanti().Close();
                    SqlConnection.ClearPool(bgl.baglanti());
                }
                else
                {
                    SqlCommand aramaKomutu2 = new SqlCommand()
                    {
                        Connection = bgl.baglanti(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "spKategoriSayfasindaArama1"
                    };

                    SqlParameter kelime2 = new SqlParameter("@p1", SqlDbType.VarChar);
                    SqlParameter cinsiyetId2 = new SqlParameter("@p2", SqlDbType.SmallInt);

                    kelime2.Value = tboxSearch.Text;
                    cinsiyetId2.Value = ddListCinsiyetFiltre.SelectedValue;

                    aramaKomutu2.Parameters.Add(kelime2);
                    aramaKomutu2.Parameters.Add(cinsiyetId2);

                    SqlDataReader oku2 = aramaKomutu2.ExecuteReader();

                    dListKategoriler.DataSource = oku2;
                    dListKategoriler.DataBind();

                    bgl.baglanti().Close(); 
                    SqlConnection.ClearPool(bgl.baglanti());
                }
            }
            else
            {
                kategorileriGetir();
            }
        }

        protected void btnKategorileriAc_Click(object sender, EventArgs e)
        {
            if (Panel1.Visible == false)
            {
                Panel1.Visible = true;
            }
            else if (Panel1.Visible == true)
            {
                Panel1.Visible = false;
            }
        }






    }
}