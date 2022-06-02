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
    public partial class TedarikciSil : System.Web.UI.Page
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
                id = Request.QueryString["tedarikciid"];
                islem = Request.QueryString["islem"];
            }

            if (islem == "sil")
            {
                SqlCommand komut = new SqlCommand()
                {
                    Connection = bgl.baglanti(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spBuTedarikcininUrunuVarMi"
                };

                SqlParameter tedarikciId = new SqlParameter("@p1", SqlDbType.SmallInt);

                tedarikciId.Value = id;

                komut.Parameters.Add(tedarikciId);

                byte gelenSonuc = Convert.ToByte(komut.ExecuteScalar());
                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());

                if (gelenSonuc == 0)
                {
                    SqlCommand komut2 = new SqlCommand()
                    {
                        Connection = bgl.baglanti(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "spTedarikciBilgisiSilmeIslemi"
                    };

                    SqlParameter tedarikciId2 = new SqlParameter("@p1", SqlDbType.SmallInt);

                    tedarikciId2.Value = id;

                    komut2.Parameters.Add(tedarikciId2);

                    komut2.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    SqlConnection.ClearPool(bgl.baglanti());
                    
                }
                else
                {
                    lblMesaj.Text = "Bu Tedarikçide Mevcut Ürün Olduğu İçin Tedarikçi Bilgisi Silinemedi!";
                    Response.AppendHeader("Refresh", "3;url=TedarikciSil.aspx");
                }


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
    }
}