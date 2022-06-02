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
    public partial class SatisGecmisi : System.Web.UI.Page
    {
        sqlsinif bgl = new sqlsinif();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblOturum.Text = Session["kasiyerGirisi"].ToString();
                kasiyerIdGetir();
                subeIdGoreSatisGecmisiVerileri();
            }
            catch
            {
                Response.Redirect("/AdminPages/LoginScreenAdmin.aspx");
            }

            if (!IsPostBack)
            {
                ddListFiltre.Items.Add(new ListItem("Ürün Kodu", "K"));
                ddListFiltre.Items.Add(new ListItem("Ürün Ad", "A"));
            }
        }

        public void kasiyerIdGetir()
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spKasiyerSubeIdGetir"
            };

            SqlParameter pKasiyerKullaniciAdi = new SqlParameter("pKasiyerKullaniciAdi", SqlDbType.VarChar);
            pKasiyerKullaniciAdi.Value = lblOturum.Text;
            komut.Parameters.Add(pKasiyerKullaniciAdi);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                lblKasiyerSubeID.Text = oku[0].ToString();
            }
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }


        public void subeIdGoreSatisGecmisiVerileri()
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spSubeIdGoreSatisGecmisiVerileri"
            };

            SqlParameter pKasiyerSubeId = new SqlParameter("pKasiyerSubeId", SqlDbType.SmallInt);

            pKasiyerSubeId.Value = Convert.ToInt32(lblKasiyerSubeID.Text);

            komut.Parameters.Add(pKasiyerSubeId);
            SqlDataReader oku = komut.ExecuteReader();
            DataList1.DataSource = oku;
            DataList1.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "calendar1_selectionChanged"
            };

            SqlParameter pDay = new SqlParameter("pDay", SqlDbType.SmallInt);
            SqlParameter pMonth = new SqlParameter("pMonth", SqlDbType.SmallInt);
            SqlParameter pYear = new SqlParameter("pYear", SqlDbType.SmallInt);

            pDay.Value = clnTakvim1.SelectedDate.Day.ToString();
            pMonth.Value = clnTakvim1.SelectedDate.Month.ToString();
            pYear.Value = clnTakvim1.SelectedDate.Year.ToString();

            komut.Parameters.Add(pDay);
            komut.Parameters.Add(pMonth);
            komut.Parameters.Add(pYear);


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
                        CommandText = "spBtnAraKise"
                    };

                    SqlParameter pMonth = new SqlParameter("pMonth", SqlDbType.Int);
                    SqlParameter pYear = new SqlParameter("pYear", SqlDbType.Int);
                    SqlParameter pDay = new SqlParameter("pDay", SqlDbType.Int);
                    SqlParameter pKeyword = new SqlParameter("pKeyword", SqlDbType.VarChar);

                    pMonth.Value = clnTakvim1.SelectedDate.Month;
                    pYear.Value = clnTakvim1.SelectedDate.Year;
                    pDay.Value = clnTakvim1.SelectedDate.Day;
                    pKeyword.Value = tboxSearch.Text.ToString();

                    komut.Parameters.Add(pMonth);
                    komut.Parameters.Add(pYear);
                    komut.Parameters.Add(pDay);
                    komut.Parameters.Add(pKeyword);


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
                        CommandText = "spBtnAraAise"
                    };

                    SqlParameter pMonth2 = new SqlParameter("pMonth", SqlDbType.Int);
                    SqlParameter pYear2 = new SqlParameter("pYear", SqlDbType.Int);
                    SqlParameter pDay2 = new SqlParameter("pDay", SqlDbType.Int);
                    SqlParameter pKeyword2 = new SqlParameter("pKeyword", SqlDbType.VarChar);

                    pMonth2.Value = clnTakvim1.SelectedDate.Month;
                    pYear2.Value = clnTakvim1.SelectedDate.Year;
                    pDay2.Value = clnTakvim1.SelectedDate.Day;
                    pKeyword2.Value = tboxSearch.Text.ToString();

                    komut2.Parameters.Add(pMonth2);
                    komut2.Parameters.Add(pYear2);
                    komut2.Parameters.Add(pDay2);
                    komut2.Parameters.Add(pKeyword2);


                    SqlDataReader oku2 = komut2.ExecuteReader();
                    DataList1.DataSource = oku2;
                    DataList1.DataBind();
                    bgl.baglanti().Close();
                    SqlConnection.ClearPool(bgl.baglanti());
                    break;

            }
        }
    }
}