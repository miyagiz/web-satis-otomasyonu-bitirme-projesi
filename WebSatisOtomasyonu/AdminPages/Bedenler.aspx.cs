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
    public partial class Bedenler : System.Web.UI.Page
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

            imgBasarili.Visible = false;
            imgBasarisiz.Visible = false;

            if (!IsPostBack)
            {
                islem = Request.QueryString["islemsil"];
                id = Request.QueryString["bedenid"];

                SqlCommand kmt = new SqlCommand()
                {
                    Connection = bgl.baglanti(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spBedenGruplariGetir"
                };

                SqlDataReader oku = kmt.ExecuteReader();

                ddListBedenGrup.DataTextField = "beden_grubu_metin";
                ddListBedenGrup.DataValueField = "beden_grubu_id";
                ddListBedenGrup.DataSource = oku;
                ddListBedenGrup.DataBind();
                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());



            }

            if (islem == "sil")
            {
                SqlCommand komut = new SqlCommand()
                {
                    Connection = bgl.baglanti(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spUrunlerdeBuBedendeUrunVarMi"
                };
                SqlParameter bedenId = new SqlParameter("@p1", SqlDbType.Int);
                bedenId.Value = id;
                komut.Parameters.Add(bedenId);


                byte gelenSonuc = Convert.ToByte(komut.ExecuteScalar());
                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());

                if (gelenSonuc == 0)
                {
                    SqlCommand komut2 = new SqlCommand()
                    {
                        Connection = bgl.baglanti(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "spBedenSil"
                    };
                    SqlParameter id2 = new SqlParameter("@p1", SqlDbType.Int);
                    id2.Value = id;
                    komut2.Parameters.Add(id2);



                    komut2.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    SqlConnection.ClearPool(bgl.baglanti());
                }
                else
                {
                    lblUyari.Text = "Bu Bedende Ürün Olduğu İçin Beden Silinemedi!";
                    Response.AppendHeader("Refresh", "3;url=Bedenler.aspx");
                }

            }

            bedenleriGetir();
        }

        protected void btnBedenlerAc_Click(object sender, EventArgs e)
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

        protected void btnBedenEkleAc_Click(object sender, EventArgs e)
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

        protected void btnBedenEkle_Click(object sender, EventArgs e)
        {
            if (tboxBeden.Text != "" & tboxBedenKisaltma.Text != "")
            {
                SqlCommand komut = new SqlCommand()
                {
                    Connection = bgl.baglanti(),
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spBedenEkle"
                };

                SqlParameter bedenKisaltma = new SqlParameter("@p1", SqlDbType.VarChar);
                SqlParameter bedenMetin = new SqlParameter("@p2", SqlDbType.VarChar);
                SqlParameter bedenGrup = new SqlParameter("@p3", SqlDbType.SmallInt);

                bedenKisaltma.Value = tboxBedenKisaltma.Text;
                bedenMetin.Value = tboxBeden.Text;
                bedenGrup.Value = ddListBedenGrup.SelectedValue;

                komut.Parameters.Add(bedenKisaltma);
                komut.Parameters.Add(bedenMetin);
                komut.Parameters.Add(bedenGrup);


                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                SqlConnection.ClearPool(bgl.baglanti());

                //Butona Bastıktan Sonra Listenin Yeni Halinin Gelmesi İçin
                bedenleriGetir();

                //TextBox Silinmesi İçin
                tboxBeden.Text = "";
                tboxBedenKisaltma.Text = "";

                //Başarıyla Eklenmiştir Mesajı
                lblMesaj.Text = "Beden Başarıyla Eklenmiştir.";
                imgBasarili.Visible = true;
                Response.AppendHeader("Refresh", "3;url=Bedenler.aspx");
            }
            else
            {
                lblMesaj.Text = "Lütfen Gerekli Alanları Boş Bırakmayınız...";
                imgBasarisiz.Visible = true;
            }
        }

        public void bedenleriGetir()
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spBedenleriGetir"
            };
            SqlDataReader oku = komut.ExecuteReader();

            DataList1.DataSource = oku;
            DataList1.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }

        protected void btnBedenGrupEkle_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand()
            {
                Connection=bgl.baglanti(),
                CommandType=CommandType.StoredProcedure,
                CommandText= "spBedenGrupEkle"
            };

            SqlParameter bedenGrubu = new SqlParameter("@p1", SqlDbType.VarChar);

            bedenGrubu.Value = TextBox1.Text;

            kmt.Parameters.Add(bedenGrubu);
            kmt.ExecuteNonQuery();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
            Image2.Visible = true;
            Label1.Text = "Beden Grubu Başarıyla Eklenmiştir";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Panel3.Visible == false)
            {
                Panel3.Visible = true;
            }
            else if (Panel3.Visible == true)
            {
                Panel3.Visible = false;
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



    }
}