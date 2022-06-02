using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace WebSatisOtomasyonu.UserPage
{
    public partial class Kasiyerler : System.Web.UI.Page
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

            if (IsPostBack == false)
            {

                kasiyerleriGetir();
                subeadGetir();
                id = Request.QueryString["kasiyerid"];
                islem = Request.QueryString["islemsil"];

            }

            imgBasarili.Visible = false;
            imgBasarisiz.Visible = false;
            lblMesaj.Text = "";

            if (islem == "sil")
            {
                SqlCommand komut = new SqlCommand()
                {
                    Connection = bgl.baglanti(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spKasiyerlerSayfasidankiSilmeIslemi"
                };
                SqlParameter kasiyerId = new SqlParameter("@p1", SqlDbType.Int);

                kasiyerId.Value = id;

                komut.Parameters.Add(kasiyerId);


                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());


                kasiyerleriGetir();
            }


        }

        protected void btnKasiyerBilgisiAc_Click(object sender, EventArgs e)
        {

        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void subeadGetir()
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spSubeleriGetir"
            };
            SqlDataReader oku = komut.ExecuteReader();

            ddListSubeler.DataTextField = "sube_ad";
            ddListSubeler.DataValueField = "sube_id";

            ddListSubeler.DataSource = oku;
            ddListSubeler.DataBind();

            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());

        }

        protected void btnKasiyerEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spKasiyerKullaniciAdiKontrol"
            };

            SqlParameter pKullaniciAdi = new SqlParameter("pKullaniciAdi", SqlDbType.VarChar);
            pKullaniciAdi.Value = tboxKullaniciAdi.Text;
            komut2.Parameters.Add(pKullaniciAdi);

            byte gelenSonuc = Convert.ToByte(komut2.ExecuteScalar());
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());

            if (gelenSonuc == 0)
            {
                SqlCommand komut = new SqlCommand()
                {
                    Connection = bgl.baglanti(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spKasiyerBilgisiEkleme"
                };

                SqlParameter kullaniciAdi = new SqlParameter("@p1", SqlDbType.VarChar);
                SqlParameter sifre = new SqlParameter("@p2", SqlDbType.VarChar);
                SqlParameter ad = new SqlParameter("@p3", SqlDbType.VarChar);
                SqlParameter soyad = new SqlParameter("@p4", SqlDbType.VarChar);
                SqlParameter telNo = new SqlParameter("@p5", SqlDbType.VarChar);
                SqlParameter subeId = new SqlParameter("@p6", SqlDbType.SmallInt);

                kullaniciAdi.Value = tboxKullaniciAdi.Text;
                sifre.Value = tboxSifre.Text;
                ad.Value = tboxKasiyerAd.Text;
                soyad.Value = tboxKasiyerSoyad.Text;
                telNo.Value = tboxTelNo.Text;
                subeId.Value = ddListSubeler.SelectedValue;

                komut.Parameters.Add(kullaniciAdi);
                komut.Parameters.Add(sifre);
                komut.Parameters.Add(ad);
                komut.Parameters.Add(soyad);
                komut.Parameters.Add(telNo);
                komut.Parameters.Add(subeId);

                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());

                imgBasarili.Visible = true;
                lblMesaj.Text = "Kasiyer Bilgisi Başarıyla Eklendi!";
                kasiyerleriGetir();
                Response.AppendHeader("Refresh", "3;url=Kasiyerler.aspx");
            }
            else
            {
                imgBasarisiz.Visible = true;
                lblMesaj.Text = "Bu Kullanıcı Adı Sistemde Zaten Kayıtlı!";
                Response.AppendHeader("Refresh", "3;url=Kasiyerler.aspx");
            }

            

        }

        public void kasiyerleriGetir()
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spKasiyerBilgileriniGetir"
            };

            SqlDataReader oku = komut.ExecuteReader();

            DataList1.DataSource = oku;
            DataList1.DataBind();

            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }
    }
}