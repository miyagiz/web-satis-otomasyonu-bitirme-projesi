using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WebSatisOtomasyonu.UserPage
{
    public partial class UrunGuncelleDetay : System.Web.UI.Page
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
                if (Page.IsPostBack == false)
                {
                    renkleriGetir();
                    cinsiyetleriGetir();

                    bedenleriGetir();
                    tedarikcileriGetir();


                    imgBasarili.Visible = false;
                    imgBasarisiz.Visible = false;



                    SqlCommand komut = new SqlCommand()
                    {
                        Connection = bgl.baglanti(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "spUrunGuncelleDetaySayfasi"
                    };

                    SqlParameter urunId = new SqlParameter("@p1", SqlDbType.SmallInt);

                    urunId.Value = id;

                    komut.Parameters.Add(urunId);

                    SqlDataReader oku = komut.ExecuteReader();

                    while (oku.Read())
                    {
                        tboxBarkod.Text = oku[0].ToString();
                        tboxUrunAd.Text = oku[1].ToString();
                        tboxUrunAdet.Text = oku[2].ToString();
                        tboxUrunAlisFiyati.Text = oku[3].ToString();
                        tboxUrunSatisFiyati.Text = oku[4].ToString();
                        ddListRenk.SelectedValue = oku[7].ToString();
                        ddListCinsiyet.SelectedValue = oku[5].ToString();
                        ddListKategori.SelectedValue = oku[6].ToString();
                        ddListBeden.SelectedValue = oku[8].ToString();
                        ddListTedarikci.SelectedValue = oku[9].ToString();
                    }
                    bgl.baglanti().Close();
                    SqlConnection.ClearPool(bgl.baglanti());

                    kategorileriGetir();


                }
            }
            catch
            {

                Response.Redirect("Urunler.aspx");
            }



        }

        protected void btnUrunGuncelle_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(tboxUrunAlisFiyati.Text) < Convert.ToDecimal(tboxUrunSatisFiyati.Text))
            {
                if (tboxUrunAd.Text != "" && tboxUrunAdet.Text != "" && tboxUrunAlisFiyati.Text != "" && tboxUrunSatisFiyati.Text != "")
                {
                    SqlCommand komut = new SqlCommand()
                    {
                        Connection = bgl.baglanti(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "spUrunBilgisiGuncellemeIslemi"
                    };

                    SqlParameter urunKodu = new SqlParameter("@p1", SqlDbType.NVarChar);
                    SqlParameter urunAd = new SqlParameter("@p2", SqlDbType.VarChar);
                    SqlParameter alisFiyati = new SqlParameter("@p3", SqlDbType.Decimal);
                    SqlParameter satisFiyati = new SqlParameter("@p4", SqlDbType.Decimal);
                    SqlParameter renkId = new SqlParameter("@p5", SqlDbType.SmallInt);
                    SqlParameter bedenId = new SqlParameter("@p6", SqlDbType.SmallInt);
                    SqlParameter kategoriId = new SqlParameter("@p7", SqlDbType.SmallInt);
                    SqlParameter tedarikciId = new SqlParameter("@p8", SqlDbType.SmallInt);
                    SqlParameter cinsiyetId = new SqlParameter("@p9", SqlDbType.SmallInt);
                    SqlParameter urunId = new SqlParameter("@p10", SqlDbType.SmallInt);

                    urunKodu.Value = tboxBarkod.Text;
                    urunAd.Value = tboxUrunAd.Text;
                    alisFiyati.Value = Convert.ToDecimal(tboxUrunAlisFiyati.Text);
                    satisFiyati.Value = Convert.ToDecimal(tboxUrunSatisFiyati.Text);
                    renkId.Value = ddListRenk.SelectedValue;
                    bedenId.Value = ddListBeden.SelectedValue;
                    kategoriId.Value = ddListKategori.SelectedValue;
                    tedarikciId.Value = ddListTedarikci.SelectedValue;
                    cinsiyetId.Value = ddListCinsiyet.SelectedValue;
                    urunId.Value = id;

                    komut.Parameters.Add(urunKodu);
                    komut.Parameters.Add(urunAd);
                    komut.Parameters.Add(alisFiyati);
                    komut.Parameters.Add(satisFiyati);
                    komut.Parameters.Add(renkId);
                    komut.Parameters.Add(bedenId);
                    komut.Parameters.Add(kategoriId);
                    komut.Parameters.Add(tedarikciId);
                    komut.Parameters.Add(cinsiyetId);
                    komut.Parameters.Add(urunId);



                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    SqlConnection.ClearPool(bgl.baglanti());

                    Response.Redirect("Urunler.aspx");
                }
                else
                {
                    imgBasarisiz.Visible = true;
                    lblUyari.Text = "Lütfen Gerekli Tüm Alanları Doldurunuz!";
                }
            }
            else
            {
                imgBasarisiz.Visible = true;
                lblUyari.Text ="Ürünün Alış Fiyatı Satış Fiyatından Yüksek Veya Satış Fiyatına Eşit Olamaz!";
            }



        }

        public void renkleriGetir()
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spRenkleriGetir"
            };
            SqlDataReader oku = komut.ExecuteReader();

            ddListRenk.DataTextField = "renk_metin";
            ddListRenk.DataValueField = "renk_id";

            ddListRenk.DataSource = oku;
            ddListRenk.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
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

        public void kategorileriGetir()
        {


            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spCinsiyeteGoreKategoriGetirmeIslemi"
            };

            SqlParameter cinsiyetId = new SqlParameter("@p1", SqlDbType.SmallInt);

            cinsiyetId.Value = ddListCinsiyet.SelectedValue;

            komut.Parameters.Add(cinsiyetId);

            SqlDataReader oku = komut.ExecuteReader();

            ddListKategori.DataTextField = "kategori_detay";
            ddListKategori.DataValueField = "kategori_id";

            ddListKategori.DataSource = oku;
            ddListKategori.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }

        public void bedenleriGetir()
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spBedenleriGetir"
            };
            SqlDataReader oku = komut.ExecuteReader();

            ddListBeden.DataTextField = "beden_kisaltma";
            ddListBeden.DataValueField = "beden_id";

            ddListBeden.DataSource = oku;
            ddListBeden.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
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

            ddListTedarikci.DataTextField = "tedarikci_ad";
            ddListTedarikci.DataValueField = "tedarikci_id";

            ddListTedarikci.DataSource = oku;
            ddListTedarikci.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }

        protected void ddListCinsiyet_SelectedIndexChanged(object sender, EventArgs e)
        {
            kategorileriGetir();
        }
    }
}