using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace WebSatisOtomasyonu.AdminPages
{
    public partial class SubelerdekiUrunler : System.Web.UI.Page
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
                if (Page.IsPostBack==false)
                {
                    verileriGetir();
                }
            }
            catch
            {
                Response.Redirect("Subeler.aspx");
            }
            verileriTopla();
        }


        public void verileriGetir()
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spSubelerdekiUrunleriGetir"
            };

            SqlParameter subeId = new SqlParameter("@p1", SqlDbType.SmallInt);

            subeId.Value = id;

            komut.Parameters.Add(subeId);

            SqlDataReader oku = komut.ExecuteReader();

            dListUrunler.DataSource = oku;
            dListUrunler.DataBind();

            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }
        
        public void verileriTopla()
        {
            SqlCommand komut2 = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spSubelerSayfasindakiToplamaIslemi"
            };

            SqlParameter toplamaIslemi = new SqlParameter("@p1",SqlDbType.SmallInt);

            toplamaIslemi.Value = id;

            komut2.Parameters.Add(toplamaIslemi);

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