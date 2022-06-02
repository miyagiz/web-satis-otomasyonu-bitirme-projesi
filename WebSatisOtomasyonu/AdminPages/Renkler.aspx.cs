using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace WebSatisOtomasyonu.UserPage
{
    public partial class Renkler : System.Web.UI.Page
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





            imgBasarili.Visible = false;
            imgBasarisiz.Visible = false;

            if (!IsPostBack)
            {
                id = Request.QueryString["renkid"];
                islem = Request.QueryString["islem"];
            }

            if (islem == "sil")
            {
                SqlCommand komut = new SqlCommand()
                {
                    Connection = bgl.baglanti(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spBuRenkteUrunVarMi"
                };

                SqlParameter renkId = new SqlParameter("@p1", SqlDbType.SmallInt);

                renkId.Value = id;

                komut.Parameters.Add(renkId);

                byte gelenSonuc = Convert.ToByte(komut.ExecuteScalar());
                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());

                if (gelenSonuc == 0)
                {
                    SqlCommand komut2 = new SqlCommand()
                    {
                        Connection = bgl.baglanti(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "spRenkSilme"
                    };

                    SqlParameter renkId2 = new SqlParameter("@p1", SqlDbType.SmallInt);

                    renkId2.Value = id;

                    komut2.Parameters.Add(renkId2);

                    komut2.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    SqlConnection.ClearPool(bgl.baglanti());
                    Response.Redirect("Renkler.aspx");
                }
                else
                {
                    lblUyari.Text = "Bu Renkte Ürün Olduğu İçin Renk Bilgisi Silinemedi!";
                    Response.AppendHeader("Refresh", "3;url=Renkler.aspx");
                }
            }
            renkleriGetir();
        }

        protected void btnRenklerAc_Click(object sender, EventArgs e)
        {
            if (Panel1.Visible == false)
            {
                Panel1.Visible = true;
            }
            else if (Panel1.Visible == true)
            {
                Panel1.Visible = false;
            }

            if (imgBasarili.Visible == true)
            {
                imgBasarili.Visible = false;
            }

            if (imgBasarisiz.Visible == true)
            {
                imgBasarisiz.Visible = false;
            }

            if (lblMesaj.Text != "")
            {
                lblMesaj.Text = "";
            }

        }

        protected void btnRenkEkleAc_Click(object sender, EventArgs e)
        {
            if (Panel2.Visible == false)
            {
                Panel2.Visible = true;
            }
            else if (Panel2.Visible == true)
            {
                Panel2.Visible = false;
            }

            if (imgBasarili.Visible == true)
            {
                imgBasarili.Visible = false;
            }

            if (imgBasarisiz.Visible == true)
            {
                imgBasarisiz.Visible = false;
            }

            if (lblMesaj.Text != "")
            {
                lblMesaj.Text = "";
            }

        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {

            SqlCommand renkKontrol = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spRenkKontrol"
            };
            SqlParameter pRenk = new SqlParameter("pRenk", SqlDbType.VarChar);
            pRenk.Value = tboxRenkAd.Text;
            renkKontrol.Parameters.Add(pRenk);
            byte gelenSonuc = Convert.ToByte(renkKontrol.ExecuteScalar());
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());

            if (gelenSonuc == 0)
            {
                if (tboxRenkAd.Text != "")
                {
                    SqlCommand komut = new SqlCommand()
                    {
                        Connection = bgl.baglanti(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "spRenkEkleme"
                    };

                    SqlParameter renkId3 = new SqlParameter("@p1", SqlDbType.VarChar);

                    renkId3.Value = tboxRenkAd.Text;

                    komut.Parameters.Add(renkId3);

                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    SqlConnection.ClearPool(bgl.baglanti());

                    //Butona Bastıktan Sonra Listenin Yeni Halinin Gelmesi İçin
                    renkleriGetir();

                    //TextBox Silinmesi İçin
                    tboxRenkAd.Text = "";

                    //Başarıyla Eklenmiştir Mesajı
                    lblMesaj.Text = "Renk Başarıyla Eklenmiştir.";
                    Response.AppendHeader("Refresh", "3;url=Renkler.aspx");
                    imgBasarili.Visible = true;
                }
                else
                {
                    lblMesaj.Text = "Lütfen Renk Adını Boş Bırakmayınız...";
                    imgBasarisiz.Visible = true;
                }
            }
            else
            {
                imgBasarisiz.Visible = true;
                lblMesaj.Text = tboxRenkAd.Text + " Renk Zaten Eklenmiş Durumda...";
                Response.AppendHeader("Refresh", "3;url=Renkler.aspx");
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

            DataList1.DataSource = oku;
            DataList1.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }
    }
}