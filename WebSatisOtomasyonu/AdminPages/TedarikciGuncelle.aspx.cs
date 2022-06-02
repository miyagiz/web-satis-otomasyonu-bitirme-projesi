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
    public partial class TedarikciGuncelle : System.Web.UI.Page
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

            tedarikcileriGetir();
        }

        protected void btnAra_Click(object sender, EventArgs e)
        {
            if (tboxSearch.Text == "")
            {
                tedarikcileriGetir();

            }
            else
            {
                SqlCommand komut = new SqlCommand()
                {
                    Connection = bgl.baglanti(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spTedarikciSayfasiAramaIslemi"
                };

                SqlParameter keyword = new SqlParameter("@p1", SqlDbType.VarChar);

                keyword.Value = tboxSearch.Text;

                komut.Parameters.Add(keyword);

                SqlDataReader oku = komut.ExecuteReader();

                dListTedarikciler.DataSource = oku;
                dListTedarikciler.DataBind();
                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());
            }
        }

        protected void btnTedarikcileriAc_Click(object sender, EventArgs e)
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

        public void tedarikcileriGetir()
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spTedarikcileriGetir"
            };

            SqlDataReader oku = komut.ExecuteReader();
            dListTedarikciler.DataSource = oku;
            dListTedarikciler.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }
    }
}