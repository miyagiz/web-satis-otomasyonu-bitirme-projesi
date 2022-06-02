using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace WebSatisOtomasyonu.AdminPages
{
    public partial class KasiyerGuncelleDetay : System.Web.UI.Page
    {

        sqlsinif bgl = new sqlsinif();
        string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["kasiyerid"];

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

                subeleriGetir();

                SqlCommand komut = new SqlCommand()
                {
                    Connection = bgl.baglanti(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spKasiyerBilgileriniOtomatikDoldur"
                };

                SqlParameter kasiyerId2 = new SqlParameter("@p1", SqlDbType.Int);

                kasiyerId2.Value = id;

                komut.Parameters.Add(kasiyerId2);


                SqlDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    tboxKasiyerAd.Text = oku[1].ToString();
                    tboxKasiyerSoyad.Text = oku[2].ToString();
                    tboxKasiyerKullaniciAdi.Text = oku[3].ToString();
                    tboxKasiyerSifre.Text = oku[4].ToString();
                    tboxKasiyerTelNo.Text = oku[5].ToString();
                    ddListKasiyerSube.SelectedValue = oku[6].ToString();
                }
                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());
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

            ddListKasiyerSube.DataValueField = "sube_id";
            ddListKasiyerSube.DataTextField = "sube_ad";
            ddListKasiyerSube.DataSource = oku;
            ddListKasiyerSube.DataBind();

            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spKasiyerKullaniciAdiKontrol"
            };

            SqlParameter pKullaniciAdi = new SqlParameter("pKullaniciAdi", SqlDbType.VarChar);
            pKullaniciAdi.Value = tboxKasiyerKullaniciAdi.Text;
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
                    CommandText = "spKasiyerBilgisiGuncelle"
                };

                SqlParameter kullaniciAdi = new SqlParameter("@p1", SqlDbType.VarChar);
                SqlParameter kasiyerSifre = new SqlParameter("@p2", SqlDbType.VarChar);
                SqlParameter kasiyerAd = new SqlParameter("@p3", SqlDbType.VarChar);
                SqlParameter kasiyerSoyad = new SqlParameter("@p4", SqlDbType.VarChar);
                SqlParameter kasiyerTelNo = new SqlParameter("@p5", SqlDbType.VarChar);
                SqlParameter kasiyerSubeId = new SqlParameter("@p6", SqlDbType.SmallInt);
                SqlParameter kasiyerId = new SqlParameter("@p7", SqlDbType.Int);

                kullaniciAdi.Value = tboxKasiyerKullaniciAdi.Text;
                kasiyerSifre.Value = tboxKasiyerSifre.Text;
                kasiyerAd.Value = tboxKasiyerAd.Text;
                kasiyerSoyad.Value = tboxKasiyerSoyad.Text;
                kasiyerTelNo.Value = tboxKasiyerTelNo.Text;
                kasiyerSubeId.Value = ddListKasiyerSube.SelectedValue;
                kasiyerId.Value = id;

                komut.Parameters.Add(kullaniciAdi);
                komut.Parameters.Add(kasiyerSifre);
                komut.Parameters.Add(kasiyerAd);
                komut.Parameters.Add(kasiyerSoyad);
                komut.Parameters.Add(kasiyerTelNo);
                komut.Parameters.Add(kasiyerSubeId);
                komut.Parameters.Add(kasiyerId);

                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());

                Response.Redirect("Kasiyerler.aspx");
            }
            else
            {
                lblMsj.Text = "Bu Kullanıcı Adı Sistemde Zaten Kayıtlı : " + tboxKasiyerKullaniciAdi.Text;
            }



        }
    }
}