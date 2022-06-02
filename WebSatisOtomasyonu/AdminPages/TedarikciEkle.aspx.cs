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
    public partial class TedarikciEkle : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();
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

            imgBasarili.Visible = false;
            imgBasarisiz.Visible = false;
            tedarikcileriGetir();
        }


        public void tedarikcileriGetir()
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spTedarikcileriGetir"
            };

            SqlDataReader oku = komut.ExecuteReader();
            dListTedarikciler.DataSource = oku;
            dListTedarikciler.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }

        protected void btnTedarikciEkle_Click(object sender, EventArgs e)
        {
            if (tboxAdres.Text != "" && tboxTedarikciAd.Text != "" && tboxTelNo.Text != "")
            {
                SqlCommand komut = new SqlCommand()
                {
                    Connection = bgl.baglanti(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spTedarikciBilgisiEkleme"
                };

                SqlParameter tedarikciAd = new SqlParameter("@p1", SqlDbType.VarChar);
                SqlParameter tedarikciAdres = new SqlParameter("@p2", SqlDbType.VarChar);
                SqlParameter tedarikciTelNo = new SqlParameter("@p3", SqlDbType.VarChar);

                tedarikciAd.Value = tboxTedarikciAd.Text;
                tedarikciAdres.Value = tboxAdres.Text;
                tedarikciTelNo.Value = tboxTelNo.Text;

                komut.Parameters.Add(tedarikciAd);
                komut.Parameters.Add(tedarikciAdres);
                komut.Parameters.Add(tedarikciTelNo);

                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());

                tedarikcileriGetir();


                tboxAdres.Text = "";
                tboxTedarikciAd.Text = "";
                tboxTelNo.Text = "";

                imgBasarili.Visible = true;
                lblMesaj.Text = "Tedarikçi Bilgisi Başarıyla Eklenmiştir...";
                Response.AppendHeader("Refresh", "3;url=TedarikciEkle.aspx");
            }
            else
            {
                imgBasarisiz.Visible = true;
                lblMesaj.Text = "Lütfen Gerekli Tüm Alanları Doldurunuz...";
            }

        }

        protected void btnTedarikcileriAc_Click(object sender, EventArgs e)
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

        protected void btnTedarikciEkleAc_Click(object sender, EventArgs e)
        {
            if (Panel2.Visible == false)
            {
                Panel2.Visible = true;
            }
            else if (Panel2.Visible == true)
            {
                Panel2.Visible = false;
            }
        }

        protected void btnAra_Click(object sender, EventArgs e)
        {
            if (tboxSearch.Text == "")
            {
                tedarikcileriGetir();

            }
            else
            {
                SqlCommand komut = new SqlCommand()
                {
                    Connection = bgl.baglanti(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spTedarikciSayfasiAramaIslemi"
                };

                SqlParameter aramaKeyword = new SqlParameter("@p1", SqlDbType.VarChar);

                aramaKeyword.Value = tboxSearch.Text;

                komut.Parameters.Add(aramaKeyword);

                SqlDataReader oku = komut.ExecuteReader();



                dListTedarikciler.DataSource = oku;
                dListTedarikciler.DataBind();
                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());
            }


        }
    }
}