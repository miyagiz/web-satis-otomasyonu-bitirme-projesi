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
    public partial class UrunEkle : System.Web.UI.Page
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


            if (Page.IsPostBack == false)
            {
                if (tboxBarkod.Text == null)
                {
                    tboxBarkod.Text = "100001";
                }
                ddListUrunKategori.Items.Add(new ListItem("Kategori Seçiniz...", "T"));
                ddListUrunKategori.SelectedValue = "T";

                ddListUrunBeden.Items.Add(new ListItem("Beden Seçiniz...", "T"));
                ddListUrunBeden.SelectedValue = "T";

                //bedenleriGetir();
                renkleriGetir();
                //kategorileriGetir();
                tedarikcileriGetir();
                cinsiyetleriGetir();
                eklenecekBarkoduGoster();
            }
        }


        protected void ddListUrunCinsiyet_SelectedIndexChanged(object sender, EventArgs e)
        {


            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spKategoriSayfasindaCinsiyetFiltre"
            };

            SqlParameter cinsiyet = new SqlParameter("@p1", SqlDbType.VarChar);

            cinsiyet.Value = ddListUrunCinsiyet.SelectedItem.Text;

            komut.Parameters.Add(cinsiyet);


            SqlDataReader oku = komut.ExecuteReader();

            ddListUrunKategori.DataTextField = "kategori_detay";
            ddListUrunKategori.DataValueField = "kategori_id";

            ddListUrunKategori.DataSource = oku;
            ddListUrunKategori.DataBind();


            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand barkodKontrolKomutu = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spBarkodKontrol"
            };
            SqlParameter pBarkod = new SqlParameter("pBarkod", SqlDbType.NVarChar);
            pBarkod.Value = tboxBarkod.Text;
            barkodKontrolKomutu.Parameters.Add(pBarkod);
            byte gelenSonuc = Convert.ToByte(barkodKontrolKomutu.ExecuteScalar());
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());

            if (gelenSonuc == 0)
            {
                if (tboxUrunAd.Text != "" && tboxUrunAdet.Text != "" && tboxUrunAlisFiyati.Text != "" && tboxUrunSatisFiyati.Text != "" && ddListUrunBeden.SelectedValue != "T" && ddListUrunCinsiyet.SelectedValue != "T" && ddListUrunKategori.SelectedValue != "T" && ddListUrunRenk.SelectedValue != "T" && ddListUrunTedarikci.SelectedValue != "T")
                {
                    if  (Convert.ToDecimal(tboxUrunAlisFiyati.Text) < Convert.ToDecimal(tboxUrunSatisFiyati.Text))
                    {
                        SqlCommand komut = new SqlCommand()
                        {
                            Connection = bgl.baglanti(),
                            CommandType = CommandType.StoredProcedure,
                            CommandText = "spUrunEklemeIslemi"
                        };

                        SqlParameter urunAd = new SqlParameter("@p1", SqlDbType.VarChar);
                        SqlParameter urunAdet = new SqlParameter("@p2", SqlDbType.Int);
                        SqlParameter alisFiyati = new SqlParameter("@p3", SqlDbType.Decimal);
                        SqlParameter satisFiyati = new SqlParameter("@p4", SqlDbType.Decimal);
                        SqlParameter renkId = new SqlParameter("@p5", SqlDbType.SmallInt);
                        SqlParameter bedenId = new SqlParameter("@p6", SqlDbType.SmallInt);
                        SqlParameter kategoriId = new SqlParameter("@p7", SqlDbType.SmallInt);
                        SqlParameter tedarikciId = new SqlParameter("@p8", SqlDbType.Int);
                        SqlParameter cinsiyetId = new SqlParameter("@p9", SqlDbType.SmallInt);

                        urunAd.Value = tboxUrunAd.Text;
                        urunAdet.Value = Convert.ToInt32(tboxUrunAdet.Text);
                        alisFiyati.Value = Convert.ToDecimal(tboxUrunAlisFiyati.Text);
                        satisFiyati.Value = Convert.ToDecimal(tboxUrunSatisFiyati.Text);
                        renkId.Value = ddListUrunRenk.SelectedValue;
                        bedenId.Value = ddListUrunBeden.SelectedValue;
                        kategoriId.Value = ddListUrunKategori.SelectedValue;
                        tedarikciId.Value = ddListUrunTedarikci.SelectedValue;
                        cinsiyetId.Value = ddListUrunCinsiyet.SelectedValue;

                        komut.Parameters.Add(urunAd);
                        komut.Parameters.Add(urunAdet);
                        komut.Parameters.Add(alisFiyati);
                        komut.Parameters.Add(satisFiyati);
                        komut.Parameters.Add(renkId);
                        komut.Parameters.Add(bedenId);
                        komut.Parameters.Add(kategoriId);
                        komut.Parameters.Add(tedarikciId);
                        komut.Parameters.Add(cinsiyetId);

                        komut.ExecuteNonQuery();

                        bgl.baglanti().Close();
                        SqlConnection.ClearPool(bgl.baglanti());

                        imgBasarili.Visible = true;
                        lblUyari.Text = "Ürün Başarıyla Eklendi...";
                        eklenecekBarkoduGoster();

                        if (chbBilgilerSilinmesin.Checked==false)
                        {
                            alanlarıTemizle();
                            ddListUrunBeden.SelectedValue = "T";
                            ddListUrunRenk.SelectedValue = "T";
                            ddListUrunCinsiyet.SelectedValue = "T";
                            ddListUrunTedarikci.SelectedValue = "T";
                            ddListUrunKategori.Items.Add(new ListItem("Kategori Seçiniz...", "T"));
                            ddListUrunKategori.SelectedValue = "T";
                        }
                    }
                    else
                    {
                        imgBasarisiz.Visible = true;
                        lblUyari.Text = "Ürünün Alış Fiyatı Satış Fiyatından Yüksek Veya Satış Fiyatına Eşit Olamaz!";
                    }
                }
                else
                {
                    imgBasarisiz.Visible = true;
                    
                    lblUyari.Text = "Lütfen Gerekli Tüm Alanları Doldurunuz";
                }
            }
            else
            {
                imgBasarisiz.Visible = true;
                lblUyari.Text = tboxBarkod.Text + " No'lu Ürün Kodunda Bir Ürün Kayıtlı.Lütfen Farklı Bir Ürün Kodu Giriniz...";
            }
        }

        public void eklenecekBarkoduGoster()
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spSiradakiUrunKodu"
            };

            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                tboxBarkod.Text = oku[0].ToString();
            }
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());


        }

        public void alanlarıTemizle()
        {
            tboxUrunAd.Text = "";
            tboxUrunAdet.Text = "";
            tboxUrunAlisFiyati.Text = "";
            tboxUrunSatisFiyati.Text = "";
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

            ddListUrunBeden.DataTextField = "beden_kisaltma";
            ddListUrunBeden.DataValueField = "beden_id";

            ddListUrunBeden.DataSource = oku;
            ddListUrunBeden.DataBind();

            ddListUrunBeden.Items.Add(new ListItem("Beden Seçiniz...", "T"));
            ddListUrunBeden.SelectedValue = "T";
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());

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

            ddListUrunRenk.DataTextField = "renk_metin";
            ddListUrunRenk.DataValueField = "renk_id";

            ddListUrunRenk.DataSource = oku;
            ddListUrunRenk.DataBind();

            ddListUrunRenk.Items.Add(new ListItem("Renk Seçiniz...", "T"));
            ddListUrunRenk.SelectedValue = "T";
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }

        public void kategorileriGetir()
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spKategorileriGetir"
            };
            SqlDataReader oku = komut.ExecuteReader();

            ddListUrunKategori.DataTextField = "kategori_detay";
            ddListUrunKategori.DataValueField = "kategori_id";

            ddListUrunKategori.DataSource = oku;
            ddListUrunKategori.DataBind();
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

            ddListUrunTedarikci.DataTextField = "tedarikci_ad";
            ddListUrunTedarikci.DataValueField = "tedarikci_id";

            ddListUrunTedarikci.DataSource = oku;
            ddListUrunTedarikci.DataBind();

            ddListUrunTedarikci.Items.Add(new ListItem("Tedarikçi Seçiniz...", "T"));
            ddListUrunTedarikci.SelectedValue = "T";
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

            ddListUrunCinsiyet.DataTextField = "cinsiyet_detay";
            ddListUrunCinsiyet.DataValueField = "cinsiyet_id";

            ddListUrunCinsiyet.DataSource = oku;
            ddListUrunCinsiyet.DataBind();

            ddListUrunCinsiyet.Items.Add(new ListItem("Cinsiyet Seçiniz...", "T"));
            ddListUrunCinsiyet.SelectedValue = "T";
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }

        protected void ddListUrunKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spKategoriSayfasindaBedenFiltre"
            };

            SqlParameter kategoriBedenGrupId = new SqlParameter("@p1", SqlDbType.SmallInt);

            kategoriBedenGrupId.Value = ddListUrunKategori.SelectedValue;

            komut.Parameters.Add(kategoriBedenGrupId);


            SqlDataReader oku = komut.ExecuteReader();

            ddListUrunBeden.DataTextField = "beden_kisaltma";
            ddListUrunBeden.DataValueField = "beden_id";

            ddListUrunBeden.DataSource = oku;
            ddListUrunBeden.DataBind();

            ddListUrunBeden.Items.Add(new ListItem("Beden Seçiniz...", "T"));
            ddListUrunBeden.SelectedValue = "T";
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }
    }
}