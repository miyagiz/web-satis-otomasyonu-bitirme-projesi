using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebSatisOtomasyonu.UserPage
{
    public partial class LoginScreenAdmin : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();
        string islem = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            islem = Request.QueryString["islem"];

            if (islem == "admingirisi")
            {

                pnlYonetici.BackColor = System.Drawing.Color.CornflowerBlue;

            }
            else if (islem == "kasagirisi")
            {

                pnlKasiyer.BackColor = System.Drawing.Color.CornflowerBlue;
            }
            else
            {
                pnlYonetici.BackColor = System.Drawing.Color.CornflowerBlue;
            }


        }

        protected void btnGirisYap_Click(object sender, EventArgs e)
        {
            if (islem == "admingirisi")
            {
                adminGirisi();
            }
            else if (islem == "kasagirisi")
            {
                kasiyerGirisi();
            }
            else
            {
                adminGirisi();
            }
        }

        public void adminGirisi()
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spKullaniciKontrol"
            };

            SqlParameter pKullaniciAdi = new SqlParameter("pKullaniciAdi", SqlDbType.VarChar);
            SqlParameter pSifre = new SqlParameter("pSifre", SqlDbType.VarChar);

            pKullaniciAdi.Value = tboxKullaniciAdi.Text;
            pSifre.Value = tboxSifre.Text;

            komut.Parameters.Add(pKullaniciAdi);
            komut.Parameters.Add(pSifre);


            byte gelenSonuc = Convert.ToByte(komut.ExecuteScalar());
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());

            if (gelenSonuc == 1)
            {
                Session["adminGirisi"] = tboxKullaniciAdi.Text;
                Session.Timeout = 30;
                Response.Redirect("AnaSayfa.aspx");
            }
            else
            {
                lblUyari.Text = "Kullanıcı Adı Veya Şifreniz Yanlış!";
            }
        }

        public void kasiyerGirisi()
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spKasiyerKontrol"
            };

            SqlParameter pKasiyerKullaniciAdi = new SqlParameter("pKasiyerKullaniciAdi", SqlDbType.VarChar);
            SqlParameter pKasiyerSifre = new SqlParameter("pKasiyerSifre", SqlDbType.VarChar);

            pKasiyerKullaniciAdi.Value = tboxKullaniciAdi.Text;
            pKasiyerSifre.Value = tboxSifre.Text;

            komut.Parameters.Add(pKasiyerKullaniciAdi);
            komut.Parameters.Add(pKasiyerSifre);


            byte gelenSonuc = Convert.ToByte(komut.ExecuteScalar());
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());

            if (gelenSonuc == 1)
            {
                Session["kasiyerGirisi"] = tboxKullaniciAdi.Text;
                Session.Timeout = 30;
                Response.Redirect("/UserPages/AnaSayfa.aspx");
            }
            else
            {
                lblUyari.Text = "Kullanıcı Adı Veya Şifreniz Yanlış!";
            }
        }
    }
}