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
    public partial class SubeGuncelleDetay : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();
        string id = "";
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

            try
            {


                if (Page.IsPostBack == false)
                {


                    SqlCommand komut = new SqlCommand()
                    {
                        Connection = bgl.baglanti(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "spSubeIdyeGoreSubeleriBilgisiGetir"
                    };

                    SqlParameter subeId = new SqlParameter("@p1", SqlDbType.SmallInt);

                    subeId.Value = id;

                    komut.Parameters.Add(subeId);

                    SqlDataReader oku = komut.ExecuteReader();


                    while (oku.Read())
                    {
                        tboxSubeAd.Text = oku[1].ToString();
                        tboxSubeAdres.Text = oku[2].ToString();
                        tboxSubeTelNo.Text = oku[3].ToString();
                    }
                    bgl.baglanti().Close();
                    SqlConnection.ClearPool(bgl.baglanti());
                }
            }
            catch
            {

                Response.Redirect("Subeler.aspx");

            }
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spSubeIdyeGoreSubeBilgisiGuncelle"
            };

            SqlParameter subeAd = new SqlParameter("@p1", SqlDbType.NVarChar);
            SqlParameter subeAdres = new SqlParameter("@p2", SqlDbType.NVarChar);
            SqlParameter subeTelNo = new SqlParameter("@p3", SqlDbType.NVarChar);
            SqlParameter subeId = new SqlParameter("@p4", SqlDbType.SmallInt);

            subeAd.Value = tboxSubeAd.Text;
            subeAdres.Value = tboxSubeAdres.Text;
            subeTelNo.Value = tboxSubeTelNo.Text;
            subeId.Value = id;

            komut.Parameters.Add(subeAd);
            komut.Parameters.Add(subeAdres);
            komut.Parameters.Add(subeTelNo);
            komut.Parameters.Add(subeId);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());

            Response.Redirect("Subeler.aspx");
        }
    }
}