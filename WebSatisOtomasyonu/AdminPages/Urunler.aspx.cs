using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebSatisOtomasyonu.UserPage
{
    public partial class Urunler : System.Web.UI.Page
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

            if (Page.IsPostBack == false)
            {
                id = Request.QueryString["urunid"];
                islem = Request.QueryString["islem"];
            }



            


            if (islem == "sil")
            {
                //Ürünü Silme İşlemi
                SqlCommand komutSil = new SqlCommand()
                {
                    Connection = bgl.baglanti(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText= "spUrunlerSayfasindakiSilmeIslemi"

                };
                SqlParameter idDegeri = new SqlParameter("p1", SqlDbType.Int);
                idDegeri.Value = id;
                komutSil.Parameters.Add(idDegeri);
                komutSil.ExecuteNonQuery();

                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());

                Response.Redirect("Urunler.aspx");
            }

            verileriGetir();
        }



        
        public void verileriGetir()
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spUrunlerSayfasindakiVerileriGetir"
            };

            SqlDataReader oku = komut.ExecuteReader();
            DataList1.DataSource = oku;
            DataList1.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());


            SqlCommand komut2 = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spUrunlerSayfasindakiToplamaIslemi"
            };
            SqlDataReader oku2 = komut2.ExecuteReader();

            while (oku2.Read())
            {
                lblToplamAdet.Text = oku2[0].ToString();
                lblToplamAlisFiyati.Text = oku2[1].ToString();
                lblToplamSatisFiyati.Text = oku2[2].ToString();
            }
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }
    }
}