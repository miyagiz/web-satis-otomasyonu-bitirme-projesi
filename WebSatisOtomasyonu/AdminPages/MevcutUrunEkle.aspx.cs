using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace WebSatisOtomasyonu.UserPage
{
    public partial class MevcutUrunEkle : System.Web.UI.Page
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


            id = Request.QueryString["urunid"];



            try
            {
                urunBilgileriniGetir();
            }
            catch
            {

                Response.Redirect("Urunler.aspx");
            }





            imgBasarili.Visible = false;
            imgBasarisiz.Visible = false;
        }



        public void textboxlariTemizle()
        {
            tboxBarkod.Text = "";
            tboxUrunAd.Text = "";
            tboxUrunAdet.Text = "";
            tboxUrunAlisFiyati.Text = "";
            tboxUrunSatisFiyati.Text = "";
            tboxUrunRenk.Text = "";
            tboxUrunBeden.Text = "";
            tboxUrunCinsiyet.Text = "";
            tboxUrunKategori.Text = "";
            tboxUrunTedarikci.Text = "";
        }

        public void labellariTemizle()
        {
            lblMsjBarkod.Text = "";
            lblMsjAdet.Text = "";
            lblUyariDevam.Text = "";
        }

        protected void btnAdetEkle_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tboxUrunAdet.Text) > 0)
            {
                SqlCommand komut = new SqlCommand()
                {
                    Connection = bgl.baglanti(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spMevcutUruneAdetEkleme"
                };

                SqlParameter adet = new SqlParameter("@p1", SqlDbType.Int);
                SqlParameter urunKodu = new SqlParameter("@p2", SqlDbType.NVarChar);

                adet.Value = Convert.ToInt32(tboxUrunAdet.Text);
                urunKodu.Value = tboxBarkod.Text;

                komut.Parameters.Add(adet);
                komut.Parameters.Add(urunKodu);

                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());




                imgBasarili.Visible = true;
                lblMsjBarkod.Text = tboxBarkod.Text;
                lblMsjAdet.Text = tboxUrunAdet.Text;
                lblUyari.Text = " Barkod Numaralı Ürüne ";
                lblUyariDevam.Text = " Adet Eklendi.";
                textboxlariTemizle();
                Response.AppendHeader("Refresh", "3;url=MevcutUrunEkle.aspx");
            }
            else
            {
                lblUyari.Text = "Lütfen Geçerli Bir Ürün Adedi Giriniz.";
            }


        }


        public void urunBilgileriniGetir()
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spUrunIdGoreUrunBilgileriniGetirme"
            };

            SqlParameter urunId = new SqlParameter("@p1", SqlDbType.SmallInt);

            urunId.Value = id;

            komut.Parameters.Add(urunId);

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                tboxBarkod.Text = oku[0].ToString();
                tboxUrunAd.Text = oku[1].ToString();
                tboxUrunAlisFiyati.Text = oku[2].ToString();
                tboxUrunSatisFiyati.Text = oku[3].ToString();
                tboxUrunKategori.Text = oku[4].ToString();
                tboxUrunCinsiyet.Text = oku[5].ToString();
                tboxUrunBeden.Text = oku[6].ToString();
                tboxUrunRenk.Text = oku[7].ToString();
                tboxUrunTedarikci.Text = oku[8].ToString();
            }
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }








    }
}