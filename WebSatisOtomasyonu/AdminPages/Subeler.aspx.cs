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
    public partial class Subeler : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();
        string id = "";
        string islem = "";
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

            id = Request.QueryString["subeid"];
            islem = Request.QueryString["islemsil"];

            imgUyari.Visible = false;
            imgBasarili.Visible = false;
            imgBasarisiz.Visible = false;

            subeleriGetir();

            if (islem == "sil")
            {
                SqlCommand komut = new SqlCommand()
                {
                    Connection = bgl.baglanti(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spBuSubedeUrunVarMi"
                };

                SqlParameter subeId = new SqlParameter("@p1",SqlDbType.SmallInt);
                subeId.Value = id;
                komut.Parameters.Add(subeId);

                int gelenSonuc = Convert.ToInt32(komut.ExecuteScalar());
                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());

                if (gelenSonuc==0)
                {
                    SqlCommand komut2 = new SqlCommand()
                    {
                        Connection = bgl.baglanti(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "spSubeBilgisiSilme"
                    };

                    SqlParameter subeId2 = new SqlParameter("@p1", SqlDbType.SmallInt);

                    subeId2.Value = id;

                    komut2.Parameters.Add(subeId2);

                    komut2.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    SqlConnection.ClearPool(bgl.baglanti());

                    lblUyari.Text = "Şube Bilgisi Başarıyla Silinmiştir.";
                }
                else
                {
                    lblUyari.Text = "Bu Şubede Ürün Bulunduğundan Dolayı Şube Bilgisi Silinemedi!";
                }


                

                subeleriGetir();

            }
        }

        protected void btnSubeBilgisiAc_Click(object sender, EventArgs e)
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

        protected void btnSubeEkle_Click(object sender, EventArgs e)
        {
            if (tboxSubeAd.Text != "" && tboxSubeAdres.Text != "" && tboxSubeTelNo.Text != "")
            {
                SqlCommand komut = new SqlCommand()
                {
                    Connection = bgl.baglanti(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spSubeBilgisiEkleme"
                };

                SqlParameter subeAd = new SqlParameter("@p1", SqlDbType.NVarChar);
                SqlParameter subeAdres = new SqlParameter("@p2", SqlDbType.NVarChar);
                SqlParameter subeTelNo = new SqlParameter("@p3", SqlDbType.NVarChar);

                subeAd.Value = tboxSubeAd.Text;
                subeAdres.Value = tboxSubeAdres.Text;
                subeTelNo.Value = tboxSubeTelNo.Text;

                komut.Parameters.Add(subeAd);
                komut.Parameters.Add(subeAdres);
                komut.Parameters.Add(subeTelNo);

                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());

                //Listenin Yeni Hali İçin
                subeleriGetir();

                //Textboxların Temizlenmesi İçin
                tboxSubeAd.Text = "";
                tboxSubeAdres.Text = "";
                tboxSubeTelNo.Text = "";

                //Başarılı Mesajı
                lblMesaj.Text = "Sube Bilgisi Başarıyla Eklenmiştir.";
                imgBasarili.Visible = true;
                Response.AppendHeader("Refresh", "3;url=Subeler.aspx");


            }
            else
            {
                //Başarısız Mesajı
                lblMesaj.Text = "Lütfen Boş Alan Bırakmayınız...";
                imgBasarisiz.Visible = true;
            }



        }

        protected void btnSubeBilgisiKapat_Click(object sender, EventArgs e)
        {
            if (Panel2.Visible == false)
            {
                Panel2.Visible = true;
            }
            else if (Panel2.Visible == true)
            {
                Panel2.Visible = false;
                lblMesaj.Text = "";
            }
        }

        public void subeleriGetir()
        {

            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spSubeleriGetir"
            };
            SqlDataReader oku = komut.ExecuteReader();

            DataList1.DataSource = oku;
            DataList1.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }


    }
}