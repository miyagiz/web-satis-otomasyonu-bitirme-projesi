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
    public partial class SatisGecmisiAdmin : System.Web.UI.Page
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
                Response.Redirect("/AdminPages/LoginScreenAdmin.aspx");
            }


            if (!IsPostBack)
            {
                subeleriGetir();
                subeIdGoreSatisGecmisiVerileri();
                ddListFiltre.Items.Add(new ListItem("Ürün Kodu", "K"));
                ddListFiltre.Items.Add(new ListItem("Ürün Ad", "A"));
                ddListFiltre.Items.Add(new ListItem("Kasiyer Ad", "I"));
                clnTakvimBaslangic.Visible = false;
                clnTakvimBitis.Visible = false;
                lblBaslangic.Visible = false;
                lblBitis.Visible = false;

            }
        }

        public void subeleriGetir()
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spSubeleriGetir"
            };
            SqlDataReader oku = komut.ExecuteReader();

            ddListSubeler.DataTextField = "sube_ad";
            ddListSubeler.DataValueField = "sube_id";

            ddListSubeler.DataSource = oku;
            ddListSubeler.DataBind();

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

            pKasiyerSubeId.Value = ddListSubeler.SelectedValue;

            komut.Parameters.Add(pKasiyerSubeId);
            SqlDataReader oku = komut.ExecuteReader();
            DataList1.DataSource = oku;
            DataList1.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());

            SqlCommand komut2 = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spSubeIdGoreSatisGecmisiToplam"
            };
            SqlParameter pKasiyerSubeId2 = new SqlParameter("pKasiyerSubeId", SqlDbType.SmallInt);

            pKasiyerSubeId2.Value = ddListSubeler.SelectedValue;

            komut2.Parameters.Add(pKasiyerSubeId2);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                lblToplamAdet.Text = oku2[1].ToString();
                lblToplamSatis.Text = oku2[0].ToString();
            }
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }

        protected void ddListSubeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            subeIdGoreSatisGecmisiVerileri();

        }

        protected void clnTakvim1_SelectionChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "calendar2_selectionChanged"
            };

            SqlParameter pDay = new SqlParameter("pDay", SqlDbType.SmallInt);
            SqlParameter pMonth = new SqlParameter("pMonth", SqlDbType.SmallInt);
            SqlParameter pYear = new SqlParameter("pYear", SqlDbType.SmallInt);
            SqlParameter pKasiyerSubeId = new SqlParameter("pKasiyerSubeId", SqlDbType.SmallInt);

            pDay.Value = clnTakvim1.SelectedDate.Day.ToString();
            pMonth.Value = clnTakvim1.SelectedDate.Month.ToString();
            pYear.Value = clnTakvim1.SelectedDate.Year.ToString();
            pKasiyerSubeId.Value = ddListSubeler.SelectedValue;

            komut.Parameters.Add(pDay);
            komut.Parameters.Add(pMonth);
            komut.Parameters.Add(pYear);
            komut.Parameters.Add(pKasiyerSubeId);


            SqlDataReader oku = komut.ExecuteReader();
            DataList1.DataSource = oku;
            DataList1.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());

            SqlCommand komut2 = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "calendar2_selectionChangedToplam"
            };

            SqlParameter pDay2 = new SqlParameter("pDay", SqlDbType.SmallInt);
            SqlParameter pMonth2 = new SqlParameter("pMonth", SqlDbType.SmallInt);
            SqlParameter pYear2 = new SqlParameter("pYear", SqlDbType.SmallInt);
            SqlParameter pKasiyerSubeId2 = new SqlParameter("pKasiyerSubeId", SqlDbType.SmallInt);

            pDay2.Value = clnTakvim1.SelectedDate.Day.ToString();
            pMonth2.Value = clnTakvim1.SelectedDate.Month.ToString();
            pYear2.Value = clnTakvim1.SelectedDate.Year.ToString();
            pKasiyerSubeId2.Value = ddListSubeler.SelectedValue;

            komut2.Parameters.Add(pDay2);
            komut2.Parameters.Add(pMonth2);
            komut2.Parameters.Add(pYear2);
            komut2.Parameters.Add(pKasiyerSubeId2);

            SqlDataReader oku2 = komut2.ExecuteReader();

            while (oku2.Read())
            {
                lblToplamAdet.Text = oku2[1].ToString();
                lblToplamSatis.Text = oku2[0].ToString();
            }
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
                        CommandText = "spBtnAraKiseAdmin"
                    };

                    SqlParameter pMonth = new SqlParameter("pMonth", SqlDbType.Int);
                    SqlParameter pYear = new SqlParameter("pYear", SqlDbType.Int);
                    SqlParameter pDay = new SqlParameter("pDay", SqlDbType.Int);
                    SqlParameter pKeyword = new SqlParameter("pKeyword", SqlDbType.VarChar);
                    SqlParameter pSubeId = new SqlParameter("pSubeId", SqlDbType.SmallInt);

                    pMonth.Value = clnTakvim1.SelectedDate.Month;
                    pYear.Value = clnTakvim1.SelectedDate.Year;
                    pDay.Value = clnTakvim1.SelectedDate.Day;
                    pKeyword.Value = tboxSearch.Text.ToString();
                    pSubeId.Value = ddListSubeler.SelectedValue;

                    komut.Parameters.Add(pMonth);
                    komut.Parameters.Add(pYear);
                    komut.Parameters.Add(pDay);
                    komut.Parameters.Add(pKeyword);
                    komut.Parameters.Add(pSubeId);


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
                        CommandText = "spBtnAraAiseAdmin"
                    };

                    SqlParameter pMonth2 = new SqlParameter("pMonth", SqlDbType.Int);
                    SqlParameter pYear2 = new SqlParameter("pYear", SqlDbType.Int);
                    SqlParameter pDay2 = new SqlParameter("pDay", SqlDbType.Int);
                    SqlParameter pKeyword2 = new SqlParameter("pKeyword", SqlDbType.VarChar);
                    SqlParameter pSubeId2 = new SqlParameter("pSubeId", SqlDbType.SmallInt);

                    pMonth2.Value = clnTakvim1.SelectedDate.Month;
                    pYear2.Value = clnTakvim1.SelectedDate.Year;
                    pDay2.Value = clnTakvim1.SelectedDate.Day;
                    pKeyword2.Value = tboxSearch.Text.ToString();
                    pSubeId2.Value = ddListSubeler.SelectedValue;

                    komut2.Parameters.Add(pMonth2);
                    komut2.Parameters.Add(pYear2);
                    komut2.Parameters.Add(pDay2);
                    komut2.Parameters.Add(pKeyword2);
                    komut2.Parameters.Add(pSubeId2);


                    SqlDataReader oku2 = komut2.ExecuteReader();
                    DataList1.DataSource = oku2;
                    DataList1.DataBind();
                    bgl.baglanti().Close();
                    SqlConnection.ClearPool(bgl.baglanti());



                    break;
                case "I":
                    SqlCommand komut3 = new SqlCommand()
                    {
                        Connection = bgl.baglanti(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "spBtnAraIiseAdmin"
                    };

                    SqlParameter pMonth3 = new SqlParameter("pMonth", SqlDbType.Int);
                    SqlParameter pYear3 = new SqlParameter("pYear", SqlDbType.Int);
                    SqlParameter pDay3 = new SqlParameter("pDay", SqlDbType.Int);
                    SqlParameter pKeyword3 = new SqlParameter("pKeyword", SqlDbType.VarChar);
                    SqlParameter pSubeId3 = new SqlParameter("pSubeId", SqlDbType.SmallInt);

                    pMonth3.Value = clnTakvim1.SelectedDate.Month;
                    pYear3.Value = clnTakvim1.SelectedDate.Year;
                    pDay3.Value = clnTakvim1.SelectedDate.Day;
                    pKeyword3.Value = tboxSearch.Text.ToString();
                    pSubeId3.Value = ddListSubeler.SelectedValue;

                    komut3.Parameters.Add(pMonth3);
                    komut3.Parameters.Add(pYear3);
                    komut3.Parameters.Add(pDay3);
                    komut3.Parameters.Add(pKeyword3);
                    komut3.Parameters.Add(pSubeId3);


                    SqlDataReader oku3 = komut3.ExecuteReader();
                    DataList1.DataSource = oku3;
                    DataList1.DataBind();
                    bgl.baglanti().Close();
                    SqlConnection.ClearPool(bgl.baglanti());
                    break;

            }
        }

        protected void btnAralik_Click(object sender, EventArgs e)
        {
            clnTakvim1.Visible = false;
            clnTakvimBaslangic.Visible = true;
            clnTakvimBitis.Visible = true;
            lblBaslangic.Visible = true;
            lblBitis.Visible = true;
            lblTarih.Visible = false;
        }



        protected void clnTakvimBitis_SelectionChanged(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "clnTakvimBaslangic_selectionChanged"
            };

            SqlParameter asd = new SqlParameter("@pDate1", SqlDbType.Date);
            SqlParameter asd2 = new SqlParameter("@pDate2", SqlDbType.Date);
            SqlParameter asd3 = new SqlParameter("@pSubeId", SqlDbType.SmallInt);

            asd.Value = clnTakvimBaslangic.SelectedDate.ToShortDateString();
            asd2.Value = clnTakvimBitis.SelectedDate.ToShortDateString();
            asd3.Value = ddListSubeler.SelectedValue;

            kmt.Parameters.Add(asd);
            kmt.Parameters.Add(asd2);
            kmt.Parameters.Add(asd3);

            SqlDataReader oku = kmt.ExecuteReader();
            DataList1.DataSource = oku;
            DataList1.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());


            SqlCommand komut2 = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "clnTakvimBaslangic_selectionChangedToplam"
            };

            SqlParameter pDate1 = new SqlParameter("@pDate1", SqlDbType.Date);
            SqlParameter pDate2 = new SqlParameter("@pDate2", SqlDbType.Date);
            SqlParameter pSubeId = new SqlParameter("@pSubeId", SqlDbType.SmallInt);

            pDate1.Value = clnTakvimBaslangic.SelectedDate.ToShortDateString();
            pDate2.Value = clnTakvimBitis.SelectedDate.ToShortDateString();
            pSubeId.Value = ddListSubeler.SelectedValue;

            komut2.Parameters.Add(pDate1);
            komut2.Parameters.Add(pDate2);
            komut2.Parameters.Add(pSubeId);

            SqlDataReader oku2 = komut2.ExecuteReader();

            while (oku2.Read())
            {
                lblToplamAdet.Text = oku2[1].ToString();
                lblToplamSatis.Text = oku2[0].ToString();
            }
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }

        protected void clnTakvimBaslangic_SelectionChanged(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "clnTakvimBaslangic_selectionChanged"
            };

            SqlParameter asd = new SqlParameter("@pDate1", SqlDbType.Date);
            SqlParameter asd2 = new SqlParameter("@pDate2", SqlDbType.Date);
            SqlParameter asd3 = new SqlParameter("@pSubeId", SqlDbType.SmallInt);

            asd.Value = clnTakvimBaslangic.SelectedDate.ToShortDateString();
            asd2.Value = clnTakvimBitis.SelectedDate.ToShortDateString();
            asd3.Value = ddListSubeler.SelectedValue;

            kmt.Parameters.Add(asd);
            kmt.Parameters.Add(asd2);
            kmt.Parameters.Add(asd3);

            SqlDataReader oku = kmt.ExecuteReader();
            DataList1.DataSource = oku;
            DataList1.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());

            //asdasddasasd
            SqlCommand komut2 = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "clnTakvimBaslangic_selectionChangedToplam"
            };

            SqlParameter pDate1 = new SqlParameter("@pDate1", SqlDbType.Date);
            SqlParameter pDate2 = new SqlParameter("@pDate2", SqlDbType.Date);
            SqlParameter pSubeId = new SqlParameter("@pSubeId", SqlDbType.SmallInt);

            pDate1.Value = clnTakvimBaslangic.SelectedDate.ToShortDateString();
            pDate2.Value = clnTakvimBitis.SelectedDate.ToShortDateString();
            pSubeId.Value = ddListSubeler.SelectedValue;

            komut2.Parameters.Add(pDate1);
            komut2.Parameters.Add(pDate2);
            komut2.Parameters.Add(pSubeId);

            SqlDataReader oku2 = komut2.ExecuteReader();

            while (oku2.Read())
            {
                lblToplamAdet.Text = oku2[1].ToString();
                lblToplamSatis.Text = oku2[0].ToString();
            }
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());

        }
    }
}