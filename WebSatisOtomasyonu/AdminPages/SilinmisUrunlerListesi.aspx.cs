using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebSatisOtomasyonu.AdminPages
{
    public partial class SilinmisUrunlerListesi : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();
        string islem = "";
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

            if (Page.IsPostBack == false)
            {
                id = Request.QueryString["urunid"];
                islem = Request.QueryString["islem"];
            }

            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spSilinmisUrunlerIstatistik"
            };

            SqlDataReader oku = komut.ExecuteReader();
            DataList1.DataSource = oku;
            DataList1.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());

            if (islem == "aktifet")
            {
                SqlCommand komut2 = new SqlCommand()
                {
                    Connection = bgl.baglanti(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spUrunuAktifHaleGetirme"
                };

                SqlParameter urunId = new SqlParameter("@p1", SqlDbType.SmallInt);

                urunId.Value = id;

                komut2.Parameters.Add(urunId);

                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());
                Response.Redirect("SilinmisUrunlerListesi.aspx");
            }
        }
    }
}