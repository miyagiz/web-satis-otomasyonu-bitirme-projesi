using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WebSatisOtomasyonu.UserPages
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();
        DataTable dt = new DataTable(); // sepeti tutacağımız bir datatable oluşturuyoruz
        string gelenUrunKodu = "";
        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                lblOturum.Text = Session["kasiyerGirisi"].ToString();
                kasiyerIdGetir();
            }
            catch
            {
                Response.Redirect("/AdminPages/LoginScreenAdmin.aspx");
            }
            SepetGetir();
            lblToplamTutar.Text = SepetToplam().ToString();
            tboxTutar.Text = SepetToplam().ToString() + " ₺";

            if (!IsPostBack)
            {
                gelenUrunKodu = Request.QueryString["urunkod"];
                tboxUrunKodu.Text = gelenUrunKodu;
            }
        }

        public void kasiyerIdGetir()
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spKasiyerIDGetir"
            };

            SqlParameter pKasiyerKullaniciAdi = new SqlParameter("pKasiyerKullaniciAdi", SqlDbType.VarChar);
            pKasiyerKullaniciAdi.Value = lblOturum.Text;
            komut.Parameters.Add(pKasiyerKullaniciAdi);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                lblKasiyerID.Text = oku[0].ToString();
            }
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }

        public void ekle()
        {
            if (HttpContext.Current.Session["sepet"] != null) //daha önceden sepet oluşturulmuş mu diye sessiona bakıyoruz
            {
                dt = (DataTable)HttpContext.Current.Session["sepet"]; //session varsa sessionu datatbale ye cast edip datatablemizi elde ediyoruz
            }
            else
            {
                dt.Columns.Add("Ürün Kodu");
                dt.Columns.Add("Ürün Adı");
                dt.Columns.Add("Adet");
                dt.Columns.Add("Satış Fiyatı");
                dt.Columns.Add("Renk");
                dt.Columns.Add("Cinsiyet");
                dt.Columns.Add("Kategori");
                dt.Columns.Add("Beden");
            }

            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spKasiyerBilgisineGoreUrunleriGetir_forUserPage2"
            };

            SqlParameter deneme = new SqlParameter("pKasiyerKullaniciAdi", SqlDbType.VarChar);
            SqlParameter deneme2 = new SqlParameter("pUrunKodu", SqlDbType.NVarChar);

            deneme.Value = lblOturum.Text;
            deneme2.Value = tboxUrunKodu.Text;

            komut.Parameters.Add(deneme);
            komut.Parameters.Add(deneme2);

            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                DataRow drow = dt.NewRow();
                drow["Ürün Kodu"] = oku[0].ToString();
                drow["Ürün Adı"] = oku[1].ToString();
                drow["Adet"] = "1";
                drow["Satış Fiyatı"] = oku[3].ToString();
                drow["Renk"] = oku[4].ToString();
                drow["Cinsiyet"] = oku[5].ToString();
                drow["Kategori"] = oku[6].ToString();
                drow["Beden"] = oku[7].ToString();

                dt.Rows.Add(drow);

                gvSepet.DataSource = dt;
                gvSepet.DataBind();
            }

            HttpContext.Current.Session["sepet"] = dt;
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());


        }

        protected void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spSepeteEklerkenUrunKoduKontrolu"
            };

            SqlParameter pKasiyerKullaniciAdi = new SqlParameter("pKasiyerKullaniciAdi", SqlDbType.VarChar);
            SqlParameter pUrunKodu = new SqlParameter("pUrunKodu", SqlDbType.NVarChar);

            pKasiyerKullaniciAdi.Value = lblOturum.Text;
            pUrunKodu.Value = tboxUrunKodu.Text;

            komut.Parameters.Add(pKasiyerKullaniciAdi);
            komut.Parameters.Add(pUrunKodu);

            byte gelenSonuc = Convert.ToByte(komut.ExecuteScalar());
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());

            if (gelenSonuc >= 1)
            {
                ekle();
                lblToplamTutar.Text = SepetToplam().ToString();
                tboxTutar.Text = SepetToplam().ToString() + " ₺";
                lblUyari2.Text = "";
            }
            else
            {
                lblUyari2.Text = "Ürün Kodu Bulunamadı!";
            }


        }

        public double SepetToplam()
        {
            double toplam = 0;//toplam değişkeni tanımlanıyor
            if (HttpContext.Current.Session["sepet"] != null)//sessiomn kontolü yapılıyor
            {
                DataTable dt = new DataTable();//tablo oluşturuluyor
                dt = (DataTable)HttpContext.Current.Session["sepet"];//sessiondaki sepet alınıyor tabloya aktarılıyor
                for (int i = 0; i < dt.Rows.Count; i++)//yine tablonun tüm alanlarında dönecek döngü başlatılıyor
                {
                    toplam += Convert.ToDouble(dt.Rows[i]["Satış Fiyatı"].ToString());//her satırdaki tutar miktarı toplam değişkenine aktarılıyor
                }
            }
            return toplam; //toplam değeri döndürülüyor.
        }

        private void SepetGetir()
        {

            if (Session["sepet"] != null)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)Session["sepet"];
                gvSepet.DataSource = dt.DefaultView;
                gvSepet.DataBind();

            }
        }

        protected void btnSubedekiUrunler_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UserPages/SubedekiUrunler.aspx");
        }

        protected void btnParaUstuHesapla_Click(object sender, EventArgs e)
        {
            if (tboxTahsilEdilenTutar.Text != "")
            {
                decimal a = Convert.ToDecimal(tboxTahsilEdilenTutar.Text);
                decimal b = Convert.ToDecimal(lblToplamTutar.Text);
                tboxParaUstu.Text = Convert.ToString(a - b) + " ₺";
                tboxTutar.Text = SepetToplam().ToString() + " ₺";
            }
        }

        protected void gvSepet_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);//Sil'e bastığımız satırın indexini aldı
            DataTable dt = (DataTable)Session["sepet"];
            dt.Rows[index].Delete();

            dt = (DataTable)Session["sepet"];
            gvSepet.DataSource = dt.DefaultView;
            gvSepet.DataBind();
            lblToplamTutar.Text = SepetToplam().ToString();
            tboxTutar.Text = SepetToplam().ToString() + " ₺";
        }

        protected void btnTemizle_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["sepet"] = null;
            Response.Redirect("/UserPages/AnaSayfa.aspx");
        }

        protected void btnNakitSatis_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(Convert.ToDecimal(lblToplamTutar.Text)) != 0)
            {
                SqlCommand komut = new SqlCommand()
                {
                    Connection = bgl.baglanti(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spSepetTutarveOdemeSekli"
                };

                SqlParameter pSepetTutari = new SqlParameter("pSepetTutari", SqlDbType.Decimal);
                SqlParameter pOdemeSekli = new SqlParameter("pOdemeSekli", SqlDbType.Char);

                pSepetTutari.Value = Convert.ToDecimal(lblToplamTutar.Text);
                pOdemeSekli.Value = "N";

                komut.Parameters.Add(pSepetTutari);
                komut.Parameters.Add(pOdemeSekli);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());


                DataTable dt = new DataTable();//tablo oluşturuluyor
                dt = (DataTable)HttpContext.Current.Session["sepet"];//sessiondaki sepet alınıyor tabloya aktarılıyor
                for (int i = 0; i < dt.Rows.Count; i++)//yine tablonun tüm alanlarında dönecek döngü başlatılıyor
                {
                    SqlCommand komut2 = new SqlCommand()
                    {
                        Connection = bgl.baglanti(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "spSatilanUrunlereEkle"
                    };

                    SqlParameter pUrunKod = new SqlParameter("pUrunKod", SqlDbType.NVarChar);
                    SqlParameter pUrunAd = new SqlParameter("pUrunAd", SqlDbType.VarChar);
                    SqlParameter pUrunAdet = new SqlParameter("pUrunAdet", SqlDbType.Int);
                    SqlParameter pUrunRenk = new SqlParameter("pUrunRenk", SqlDbType.VarChar);
                    SqlParameter pUrunBeden = new SqlParameter("pUrunBeden", SqlDbType.VarChar);
                    SqlParameter pUrunKategori = new SqlParameter("pUrunKategori", SqlDbType.VarChar);
                    SqlParameter pUrunCinsiyet = new SqlParameter("pUrunCinsiyet", SqlDbType.VarChar);
                    SqlParameter pUrunTutar = new SqlParameter("pUrunTutar", SqlDbType.Decimal);
                    SqlParameter pUrunKasiyerId = new SqlParameter("pUrunKasiyerId", SqlDbType.SmallInt);

                    pUrunKod.Value = dt.Rows[i]["Ürün Kodu"].ToString();
                    pUrunAd.Value = dt.Rows[i]["Ürün Adı"].ToString();
                    pUrunAdet.Value = Convert.ToInt32(dt.Rows[i]["Adet"]);
                    pUrunRenk.Value = dt.Rows[i]["Renk"].ToString();
                    pUrunBeden.Value = dt.Rows[i]["Beden"].ToString();
                    pUrunKategori.Value = dt.Rows[i]["Kategori"].ToString();
                    pUrunCinsiyet.Value = dt.Rows[i]["Cinsiyet"].ToString();
                    pUrunTutar.Value = Convert.ToDecimal(dt.Rows[i]["Satış Fiyatı"]);
                    pUrunKasiyerId.Value = Convert.ToInt32(lblKasiyerID.Text);

                    komut2.Parameters.Add(pUrunKod);
                    komut2.Parameters.Add(pUrunAd);
                    komut2.Parameters.Add(pUrunAdet);
                    komut2.Parameters.Add(pUrunRenk);
                    komut2.Parameters.Add(pUrunBeden);
                    komut2.Parameters.Add(pUrunKategori);
                    komut2.Parameters.Add(pUrunCinsiyet);
                    komut2.Parameters.Add(pUrunTutar);
                    komut2.Parameters.Add(pUrunKasiyerId);

                    komut2.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    SqlConnection.ClearPool(bgl.baglanti());

                    SqlCommand komut3 = new SqlCommand()
                    {
                        Connection = bgl.baglanti(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "spUrunSatisiAdetAzalt"
                    };

                    SqlParameter pUrunKodu = new SqlParameter("pUrunKodu", SqlDbType.NVarChar);

                    pUrunKodu.Value = dt.Rows[i]["Ürün Kodu"].ToString();

                    komut3.Parameters.Add(pUrunKodu);
                    komut3.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    SqlConnection.ClearPool(bgl.baglanti());

                }
                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());

                HttpContext.Current.Session["sepet"] = null;
                Response.Redirect("/UserPages/AnaSayfa.aspx");

            }
            else
            {
                lblUyari.Text = "Lütfen Sepete Ürün Ekleyiniz!";
            }
        }

        protected void btnKartSatis_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(lblToplamTutar.Text) != 0)
            {
                SqlCommand komut = new SqlCommand()
                {
                    Connection = bgl.baglanti(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spSepetTutarveOdemeSekli"
                };

                SqlParameter pSepetTutari = new SqlParameter("pSepetTutari", SqlDbType.Decimal);
                SqlParameter pOdemeSekli = new SqlParameter("pOdemeSekli", SqlDbType.Char);

                pSepetTutari.Value = Convert.ToDecimal(lblToplamTutar.Text);
                pOdemeSekli.Value = "K";

                komut.Parameters.Add(pSepetTutari);
                komut.Parameters.Add(pOdemeSekli);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());


                DataTable dt = new DataTable();//tablo oluşturuluyor
                dt = (DataTable)HttpContext.Current.Session["sepet"];//sessiondaki sepet alınıyor tabloya aktarılıyor
                for (int i = 0; i < dt.Rows.Count; i++)//yine tablonun tüm alanlarında dönecek döngü başlatılıyor
                {
                    SqlCommand komut2 = new SqlCommand()
                    {
                        Connection = bgl.baglanti(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "spSatilanUrunlereEkle"
                    };

                    SqlParameter pUrunKod = new SqlParameter("pUrunKod", SqlDbType.NVarChar);
                    SqlParameter pUrunAd = new SqlParameter("pUrunAd", SqlDbType.VarChar);
                    SqlParameter pUrunAdet = new SqlParameter("pUrunAdet", SqlDbType.Int);
                    SqlParameter pUrunRenk = new SqlParameter("pUrunRenk", SqlDbType.VarChar);
                    SqlParameter pUrunBeden = new SqlParameter("pUrunBeden", SqlDbType.VarChar);
                    SqlParameter pUrunKategori = new SqlParameter("pUrunKategori", SqlDbType.VarChar);
                    SqlParameter pUrunCinsiyet = new SqlParameter("pUrunCinsiyet", SqlDbType.VarChar);
                    SqlParameter pUrunTutar = new SqlParameter("pUrunTutar", SqlDbType.Decimal);
                    SqlParameter pUrunKasiyerId = new SqlParameter("pUrunKasiyerId", SqlDbType.SmallInt);

                    pUrunKod.Value = dt.Rows[i]["Ürün Kodu"].ToString();
                    pUrunAd.Value = dt.Rows[i]["Ürün Adı"].ToString();
                    pUrunAdet.Value = Convert.ToInt32(dt.Rows[i]["Adet"]);
                    pUrunRenk.Value = dt.Rows[i]["Renk"].ToString();
                    pUrunBeden.Value = dt.Rows[i]["Beden"].ToString();
                    pUrunKategori.Value = dt.Rows[i]["Kategori"].ToString();
                    pUrunCinsiyet.Value = dt.Rows[i]["Cinsiyet"].ToString();
                    pUrunTutar.Value = Convert.ToDecimal(dt.Rows[i]["Satış Fiyatı"]);
                    pUrunKasiyerId.Value = Convert.ToInt32(lblKasiyerID.Text);

                    komut2.Parameters.Add(pUrunKod);
                    komut2.Parameters.Add(pUrunAd);
                    komut2.Parameters.Add(pUrunAdet);
                    komut2.Parameters.Add(pUrunRenk);
                    komut2.Parameters.Add(pUrunBeden);
                    komut2.Parameters.Add(pUrunKategori);
                    komut2.Parameters.Add(pUrunCinsiyet);
                    komut2.Parameters.Add(pUrunTutar);
                    komut2.Parameters.Add(pUrunKasiyerId);

                    komut2.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    SqlConnection.ClearPool(bgl.baglanti());

                    SqlCommand komut3 = new SqlCommand()
                    {
                        Connection = bgl.baglanti(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "spUrunSatisiAdetAzalt"
                    };

                    SqlParameter pUrunKodu = new SqlParameter("pUrunKodu", SqlDbType.NVarChar);

                    pUrunKodu.Value = dt.Rows[i]["Ürün Kodu"].ToString();

                    komut3.Parameters.Add(pUrunKodu);
                    komut3.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    SqlConnection.ClearPool(bgl.baglanti());

                }
                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());

                HttpContext.Current.Session["sepet"] = null;
                Response.Redirect("/UserPages/AnaSayfa.aspx");

            }
            else
            {
                lblUyari.Text = "Lütfen Sepete Ürün Ekleyiniz!";
            }
        }


    }
}