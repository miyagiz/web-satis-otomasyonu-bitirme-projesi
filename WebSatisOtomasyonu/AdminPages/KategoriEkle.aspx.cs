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
    public partial class KategoriEkle : System.Web.UI.Page
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

            kategorileriGetir();



            if (Page.IsPostBack == false)
            {
                //Cinsiyetleri Getirme
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



            if (Page.IsPostBack == false)
            {
                //Cinsiyet Filtresi İçin Getirme
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
                //Beden Grupları
                SqlCommand komut3 = new SqlCommand()
                {
                    Connection = bgl.baglanti(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spBedenGruplariGetir"
                };
                SqlDataReader oku3 = komut3.ExecuteReader();

                ddListKategoriBedenGrup.DataTextField = "beden_grubu_metin";
                ddListKategoriBedenGrup.DataValueField = "beden_grubu_id";

                ddListKategoriBedenGrup.DataSource = oku3;
                ddListKategoriBedenGrup.DataBind();
                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());
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

        protected void btnKategoriEkleAc_Click(object sender, EventArgs e)
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

        protected void btnKategoriEkle_Click(object sender, EventArgs e)
        {
            if (tboxKategori.Text != "")
            {
                SqlCommand komut = new SqlCommand()
                {
                    Connection = bgl.baglanti(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spKategoriBilgisiEkle"
                };

                SqlParameter kategoriDetay = new SqlParameter("@p1", SqlDbType.VarChar);
                SqlParameter cinsiyetId = new SqlParameter("@p2", SqlDbType.SmallInt);
                SqlParameter bedenGrubuId = new SqlParameter("@p3", SqlDbType.SmallInt);

                kategoriDetay.Value = tboxKategori.Text;
                cinsiyetId.Value = ddListCinsiyet.SelectedValue;
                bedenGrubuId.Value = ddListKategoriBedenGrup.SelectedValue;

                komut.Parameters.Add(kategoriDetay);
                komut.Parameters.Add(cinsiyetId);
                komut.Parameters.Add(bedenGrubuId);

                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());

                //Butona Bastıktan Sonra Listenin Yeni Halinin Gelmesi İçin
                kategorileriGetir();

                //TextBox Silinmesi İçin
                tboxKategori.Text = "";

                imgBasarili.Visible = true;
                lblMesaj.Text = "Kategori Başarıyla Eklenmiştir...";
                Response.AppendHeader("Refresh", "3;url=KategoriEkle.aspx");
            }
            else if (tboxKategori.Text == "")
            {
                imgBasarisiz.Visible = true;
                lblMesaj.Text = "Lütfen Kategori Adını Boş Bırakmayınız...";
            }





        }

        public void kategorileriGetir()
        {
            SqlCommand komut2 = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spKategoriBilgileriniGetir"
            };

            SqlDataReader oku2 = komut2.ExecuteReader();

            dListKategoriler.DataSource = oku2;
            dListKategoriler.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }

        public void siralama()
        {
            SqlCommand komut2 = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spKategoriBilgileriniSiralama"
            };

            SqlDataReader oku2 = komut2.ExecuteReader();

            dListKategoriler.DataSource = oku2;
            dListKategoriler.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }

        protected void imgSirala_Click(object sender, ImageClickEventArgs e)
        {
            siralama();
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
    }
}