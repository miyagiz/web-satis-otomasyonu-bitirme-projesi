using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebSatisOtomasyonu.UserPages
{
    public partial class SubedekiUrunler : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();
        //string islem = "";
        string urunKodu = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblOturum.Text = Session["kasiyerGirisi"].ToString();
            }
            catch
            {
                Response.Redirect("/AdminPages/LoginScreenAdmin.aspx");
            }
            verileriGetir();

            if (!IsPostBack)
            {
                ddListFiltre.Items.Add(new ListItem("Ürün Kodu", "K"));
                ddListFiltre.Items.Add(new ListItem("Ürün Ad", "A"));
                ddListFiltre.Items.Add(new ListItem("Tedarikçi Ad", "T"));
                //islem = Request.QueryString["urunkodual"];
                urunKodu = Request.QueryString["urunkod"];
            }

            //if (islem == "kodSecildi")
            //{
            //    Session["urunKodu"] = urunKodu;
            //}
        }

        public void verileriGetir()
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spKasiyerBilgisineGoreUrunleriGetir_forUserPage"
            };

            SqlParameter pKasiyerKullaniciAdi = new SqlParameter("pKasiyerKullaniciAdi", SqlDbType.VarChar);

            pKasiyerKullaniciAdi.Value = lblOturum.Text;

            komut.Parameters.Add(pKasiyerKullaniciAdi);

            SqlDataReader oku = komut.ExecuteReader();
            DataList1.DataSource = oku;
            DataList1.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }

        protected void btnAra_Click(object sender, EventArgs e)
        {
            string filtre = ddListFiltre.SelectedValue;

            switch (filtre)
            {
                case "K":
                    SqlCommand komut = new SqlCommand()
                    {
                        Connection = bgl.baglanti(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "spSubedekiUrunlerK"
                    };
                    SqlParameter pKasiyerKullaniciAdi = new SqlParameter("pKasiyerKullaniciAdi", SqlDbType.VarChar);
                    SqlParameter pAlinanDeger = new SqlParameter("pAlinanDeger", SqlDbType.VarChar);

                    pKasiyerKullaniciAdi.Value = lblOturum.Text;
                    pAlinanDeger.Value = tboxSearch.Text;

                    komut.Parameters.Add(pKasiyerKullaniciAdi);
                    komut.Parameters.Add(pAlinanDeger);
                    
                    SqlDataReader oku = komut.ExecuteReader();
                    DataList1.DataSource = oku;
                    DataList1.DataBind();
                    bgl.baglanti().Close();
                    SqlConnection.ClearPool(bgl.baglanti());
                    break;
                case "A":
                    SqlCommand komut2 = new SqlCommand()
                    {
                        Connection = bgl.baglanti(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "spSubedekiUrunlerA"
                    };
                    SqlParameter pKasiyerKullaniciAdi2 = new SqlParameter("pKasiyerKullaniciAdi", SqlDbType.VarChar);
                    SqlParameter pAlinanDeger2 = new SqlParameter("pAlinanDeger", SqlDbType.VarChar);

                    pKasiyerKullaniciAdi2.Value = lblOturum.Text;
                    pAlinanDeger2.Value = tboxSearch.Text;

                    komut2.Parameters.Add(pKasiyerKullaniciAdi2);
                    komut2.Parameters.Add(pAlinanDeger2);

                    SqlDataReader oku2 = komut2.ExecuteReader();
                    DataList1.DataSource = oku2;
                    DataList1.DataBind();
                    bgl.baglanti().Close();
                    SqlConnection.ClearPool(bgl.baglanti());
                    break;
                case "T":
                    SqlCommand komut3 = new SqlCommand()
                    {
                        Connection = bgl.baglanti(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "spSubedekiUrunlerT"
                    };
                    SqlParameter pKasiyerKullaniciAdi3 = new SqlParameter("pKasiyerKullaniciAdi", SqlDbType.VarChar);
                    SqlParameter pAlinanDeger3 = new SqlParameter("pAlinanDeger", SqlDbType.VarChar);

                    pKasiyerKullaniciAdi3.Value = lblOturum.Text;
                    pAlinanDeger3.Value = tboxSearch.Text;

                    komut3.Parameters.Add(pKasiyerKullaniciAdi3);
                    komut3.Parameters.Add(pAlinanDeger3);

                    SqlDataReader oku3 = komut3.ExecuteReader();
                    DataList1.DataSource = oku3;
                    DataList1.DataBind();
                    bgl.baglanti().Close();
                    SqlConnection.ClearPool(bgl.baglanti());
                    break;
            }
        }

        protected void btnUrunKoduSec_Click(object sender, EventArgs e)
        {

        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}