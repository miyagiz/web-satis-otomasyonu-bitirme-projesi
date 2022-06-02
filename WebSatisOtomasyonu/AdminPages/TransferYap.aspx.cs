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
    public partial class TransferYap : System.Web.UI.Page
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


            imgBasarili.Visible = false;
            imgBasarisiz.Visible = false;
            imgBasariliTransfer.Visible = false;
            imgBasarisizTransfer.Visible = false;

            if (IsPostBack == false)
            {
                subeleriGetir();
                renkleriGetir();
                cinsiyetleriGetir();
                kategorileriGetir();
                bedenleriGetir();
                tedarikcileriGetir();
            }


        }

        protected void imgSearch_Click(object sender, ImageClickEventArgs e)
        {
            SqlCommand barkodKontrol = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spBarkodKontrol"
            };

            SqlParameter pBarkod = new SqlParameter("pBarkod", SqlDbType.VarChar);

            pBarkod.Value = tboxUrunKodu.Text;

            barkodKontrol.Parameters.Add(pBarkod);

            byte gelenSonuc = Convert.ToByte(barkodKontrol.ExecuteScalar());
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());


            if (tboxUrunKodu.Text != "")
            {
                if (gelenSonuc == 1)
                {
                    imgBasarili.Visible = true;
                    lblUyari.Text = "Ürün Koduna Ait Ürün Bulundu...";
                    lblMesajTransfer.Text = "";

                    SqlCommand komut = new SqlCommand()
                    {
                        Connection = bgl.baglanti(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "spTransferYapSayfasindaDogruUrunKoduGirisi"
                    };

                    SqlParameter urunKodu = new SqlParameter("@p1", SqlDbType.NVarChar);

                    urunKodu.Value = tboxUrunKodu.Text;

                    komut.Parameters.Add(urunKodu);

                    SqlDataReader oku = komut.ExecuteReader();

                    while (oku.Read())
                    {
                        tboxUrunAd.Text = oku[0].ToString();
                        tboxUrunAdet.Text = oku[1].ToString();
                        tboxUrunAlisFiyati.Text = oku[2].ToString();
                        tboxUrunSatisFiyati.Text = oku[3].ToString();
                        ddListCinsiyet.SelectedValue = oku[4].ToString();
                        ddListKategori.SelectedValue = oku[5].ToString();
                        ddListRenk.SelectedValue = oku[6].ToString();
                        ddListBeden.SelectedValue = oku[7].ToString();
                        ddListTedarikci.SelectedValue = oku[8].ToString();

                    }
                    bgl.baglanti().Close();
                    SqlConnection.ClearPool(bgl.baglanti());

                    lblMesaj.Text = "";
                }
                else
                {
                    textboxlariTemizle();
                    labellariTemizle();
                    imgBasarisiz.Visible = true;
                    lblUyari.Text = "Ürün Koduna Ait Ürün Bulunamadı...";
                }
            }
            else
            {
                textboxlariTemizle();
                labellariTemizle();
                imgBasarisiz.Visible = true;
                lblUyari.Text = "Lütfen Mevcut Ürünün Kodunu Giriniz...";
            }
        }


        protected void btnTransferEt_Click(object sender, EventArgs e)
        {
            SqlCommand urunKoduKontrol = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spBarkodKontrol"
            };

            SqlParameter pUrunKodu = new SqlParameter("pBarkod", SqlDbType.VarChar);

            pUrunKodu.Value = tboxUrunKodu.Text;

            urunKoduKontrol.Parameters.Add(pUrunKodu);

            byte gelenSonuc = Convert.ToByte(urunKoduKontrol.ExecuteScalar());
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());

            if (gelenSonuc == 1)
            {
                if (tboxTransferAdet.Text != "" && Convert.ToInt32(tboxTransferAdet.Text) != 0 && tboxUrunAdet.Text != "")
                {
                    //if (Convert.ToInt32(tboxTransferAdet.Text) <= Convert.ToInt32(tboxUrunAdet.Text))
                    //{
                    SqlCommand adetleriKarsilastir = new SqlCommand()
                    {
                        Connection = bgl.baglanti(),
                        CommandType = CommandType.StoredProcedure,
                        CommandText = "spTransferAdetKarsilastir"
                    };
                    SqlParameter deneme1 = new SqlParameter("pTransferAdet", SqlDbType.Int);
                    SqlParameter deneme2 = new SqlParameter("pUrunKod", SqlDbType.NVarChar);

                    deneme1.Value = Convert.ToInt32(tboxTransferAdet.Text);
                    deneme2.Value = tboxUrunKodu.Text;

                    adetleriKarsilastir.Parameters.Add(deneme1);
                    adetleriKarsilastir.Parameters.Add(deneme2);

                    int gelenDeneme = Convert.ToInt32(adetleriKarsilastir.ExecuteScalar());
                    bgl.baglanti().Close();
                    SqlConnection.ClearPool(bgl.baglanti());

                    if (gelenDeneme == 1)
                    {
                        SqlCommand transferlerdeUrunKoduKontrol = new SqlCommand()
                        {
                            Connection = bgl.baglanti(),
                            CommandType = CommandType.StoredProcedure,
                            CommandText = "spTransferlerdeUrunKoduKontrol"
                        };

                        SqlParameter pTransferUrunKodu = new SqlParameter("pUrunKodu", SqlDbType.VarChar);
                        SqlParameter pTransferSubeId = new SqlParameter("pSubeId", SqlDbType.SmallInt);


                        pTransferUrunKodu.Value = tboxUrunKodu.Text;
                        pTransferSubeId.Value = ddListSubeler.SelectedValue;


                        transferlerdeUrunKoduKontrol.Parameters.Add(pTransferUrunKodu);
                        transferlerdeUrunKoduKontrol.Parameters.Add(pTransferSubeId);

                        byte transferdenGelenSonuc = Convert.ToByte(transferlerdeUrunKoduKontrol.ExecuteScalar());

                        bgl.baglanti().Close();
                        SqlConnection.ClearPool(bgl.baglanti());



                        if (transferdenGelenSonuc == 0)
                        {
                            //yani transfer tablosunda bu barkodda ürün yok ve insert yapılacak
                            SqlCommand komut = new SqlCommand()
                            {
                                Connection = bgl.baglanti(),
                                CommandType = CommandType.StoredProcedure,
                                CommandText = "spTransferYapAdetEksiltme"
                            };

                            SqlParameter urunKodu = new SqlParameter("@p1", SqlDbType.NVarChar);
                            SqlParameter transferAdedi = new SqlParameter("@p2", SqlDbType.Int);

                            urunKodu.Value = tboxUrunKodu.Text;
                            transferAdedi.Value = Convert.ToInt32(tboxTransferAdet.Text);

                            komut.Parameters.Add(urunKodu);
                            komut.Parameters.Add(transferAdedi);

                            komut.ExecuteNonQuery();
                            bgl.baglanti().Close();
                            SqlConnection.ClearPool(bgl.baglanti());

                            tboxUrunAdet.Text = (Convert.ToInt32(tboxUrunAdet.Text) - Convert.ToInt32(tboxTransferAdet.Text)).ToString();

                            imgBasariliTransfer.Visible = true;
                            lblMesajTransfer.Text = "Transfer Başarıyla Yapılmıştır...";
                            lblUyari.Text = "";
                            Response.AppendHeader("Refresh", "3;url=TransferYap.aspx");

                            SqlCommand eklemeKomutu = new SqlCommand()
                            {
                                Connection = bgl.baglanti(),
                                CommandType = CommandType.StoredProcedure,
                                CommandText = "spTransferBilgileriniEkleme"
                            };

                            SqlParameter urunKodu2 = new SqlParameter("@p1", SqlDbType.NVarChar);
                            SqlParameter urunAd = new SqlParameter("@p2", SqlDbType.VarChar);
                            SqlParameter transferAdet = new SqlParameter("@p3", SqlDbType.Int);
                            SqlParameter alisFiyati = new SqlParameter("@p4", SqlDbType.Decimal);
                            SqlParameter satisFiyati = new SqlParameter("@p5", SqlDbType.Decimal);
                            SqlParameter renkId = new SqlParameter("@p6", SqlDbType.SmallInt);
                            SqlParameter bedenId = new SqlParameter("@p7", SqlDbType.SmallInt);
                            SqlParameter kategoriId = new SqlParameter("@p8", SqlDbType.SmallInt);
                            SqlParameter tedarikciId = new SqlParameter("@p9", SqlDbType.Int);
                            SqlParameter cinsiyetId = new SqlParameter("@p10", SqlDbType.SmallInt);
                            SqlParameter subeId = new SqlParameter("@p11", SqlDbType.SmallInt);

                            urunKodu2.Value = tboxUrunKodu.Text;
                            urunAd.Value = tboxUrunAd.Text;
                            transferAdet.Value = Convert.ToInt32(tboxTransferAdet.Text);
                            alisFiyati.Value = Convert.ToDecimal(tboxUrunAlisFiyati.Text);
                            satisFiyati.Value = Convert.ToDecimal(tboxUrunSatisFiyati.Text);
                            renkId.Value = ddListRenk.SelectedValue;
                            bedenId.Value = ddListBeden.SelectedValue;
                            kategoriId.Value = ddListKategori.SelectedValue;
                            tedarikciId.Value = ddListTedarikci.SelectedValue;
                            cinsiyetId.Value = ddListCinsiyet.SelectedValue;
                            subeId.Value = ddListSubeler.SelectedValue;

                            eklemeKomutu.Parameters.Add(urunKodu2);
                            eklemeKomutu.Parameters.Add(urunAd);
                            eklemeKomutu.Parameters.Add(transferAdet);
                            eklemeKomutu.Parameters.Add(alisFiyati);
                            eklemeKomutu.Parameters.Add(satisFiyati);
                            eklemeKomutu.Parameters.Add(renkId);
                            eklemeKomutu.Parameters.Add(bedenId);
                            eklemeKomutu.Parameters.Add(kategoriId);
                            eklemeKomutu.Parameters.Add(tedarikciId);
                            eklemeKomutu.Parameters.Add(cinsiyetId);
                            eklemeKomutu.Parameters.Add(subeId);


                            eklemeKomutu.ExecuteNonQuery();
                            bgl.baglanti().Close();
                            SqlConnection.ClearPool(bgl.baglanti());
                        }
                        else
                        {
                            //yani transfer tablosunda bu barkodda ürün var ve update yapılacak
                            SqlCommand komut = new SqlCommand()
                            {
                                Connection = bgl.baglanti(),
                                CommandType = CommandType.StoredProcedure,
                                CommandText = "spTransferYapAdetEksiltme"
                            };

                            SqlParameter urunKodu = new SqlParameter("@p1", SqlDbType.NVarChar);
                            SqlParameter transferAdedi = new SqlParameter("@p2", SqlDbType.Int);

                            urunKodu.Value = tboxUrunKodu.Text;
                            transferAdedi.Value = Convert.ToInt32(tboxTransferAdet.Text);

                            komut.Parameters.Add(urunKodu);
                            komut.Parameters.Add(transferAdedi);

                            komut.ExecuteNonQuery();
                            bgl.baglanti().Close();
                            SqlConnection.ClearPool(bgl.baglanti());

                            SqlCommand komut2 = new SqlCommand()
                            {
                                Connection = bgl.baglanti(),
                                CommandType = CommandType.StoredProcedure,
                                CommandText = "spTransferlerdeVarIse"
                            };

                            SqlParameter transferUrunKodu = new SqlParameter("@p1", SqlDbType.NVarChar);
                            SqlParameter transferUrunAdet = new SqlParameter("@p2", SqlDbType.Int);
                            SqlParameter transferSubeId = new SqlParameter("@p3", SqlDbType.SmallInt);

                            transferUrunKodu.Value = tboxUrunKodu.Text;
                            transferUrunAdet.Value = Convert.ToInt32(tboxTransferAdet.Text);
                            transferSubeId.Value = ddListSubeler.SelectedValue;

                            komut2.Parameters.Add(transferUrunKodu);
                            komut2.Parameters.Add(transferUrunAdet);
                            komut2.Parameters.Add(transferSubeId);

                            komut2.ExecuteNonQuery();
                            bgl.baglanti().Close();
                            SqlConnection.ClearPool(bgl.baglanti());

                            //int transferEdilenAdet = Convert.ToInt32(tboxTransferAdet.Text);
                            //int urunAdet = Convert.ToInt32(tboxUrunAd.Text);
                            //int kalanAdet = urunAdet - transferEdilenAdet;
                            //tboxUrunAdet.Text = kalanAdet.ToString();

                            tboxUrunAdet.Text = (Convert.ToInt32(tboxUrunAdet.Text) - Convert.ToInt32(tboxTransferAdet.Text)).ToString();

                            imgBasariliTransfer.Visible = true;
                            lblMesajTransfer.Text = "Transfer Başarıyla Yapılmıştır...";
                            lblUyari.Text = "";




                        }
                    }
                    else
                    {
                        imgBasarisizTransfer.Visible = true;
                        lblMesajTransfer.Text = "Transfer Edilecek Adet Mevcut Adetten Fazla Olamaz!";
                    }

                }
                else
                {
                    imgBasarisizTransfer.Visible = true;
                    lblMesajTransfer.Text = "Lütfen Transfer Edilecek Ürün Adedini Giriniz...";
                    lblUyari.Text = "";
                }
            }
            else
            {
                lblMesaj.Text = "Lütfen Geçerli Bir Ürün Kodu Girdikten Sonra Arama Butonuna Basınız";
                lblUyari.Text = "";
            }
            //bastığımızda ürün adet ne kadarsa urunler tablosundan silincek
            //ve transferler tablosuna yeri veri girişi yapılacak 
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

        public void renkleriGetir()
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spRenkleriGetir"
            };
            SqlDataReader oku = komut.ExecuteReader();

            ddListRenk.DataTextField = "renk_metin";
            ddListRenk.DataValueField = "renk_id";

            ddListRenk.DataSource = oku;
            ddListRenk.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }

        public void cinsiyetleriGetir()
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spCinsiyetleriGetir"
            };
            SqlDataReader oku = komut.ExecuteReader();

            ddListCinsiyet.DataTextField = "cinsiyet_detay";
            ddListCinsiyet.DataValueField = "cinsiyet_id";

            ddListCinsiyet.DataSource = oku;
            ddListCinsiyet.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }

        public void kategorileriGetir()
        {
            SqlCommand komut = new SqlCommand()
            {
                Connection = bgl.baglanti(),
                CommandType = CommandType.StoredProcedure,
                CommandText = "spKategorileriGetir"
            };
            SqlDataReader oku = komut.ExecuteReader();

            ddListKategori.DataTextField = "kategori_detay";
            ddListKategori.DataValueField = "kategori_id";

            ddListKategori.DataSource = oku;
            ddListKategori.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
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

            ddListBeden.DataTextField = "beden_kisaltma";
            ddListBeden.DataValueField = "beden_id";

            ddListBeden.DataSource = oku;
            ddListBeden.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
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

            ddListTedarikci.DataTextField = "tedarikci_ad";
            ddListTedarikci.DataValueField = "tedarikci_id";

            ddListTedarikci.DataSource = oku;
            ddListTedarikci.DataBind();
            bgl.baglanti().Close();
            SqlConnection.ClearPool(bgl.baglanti());
        }
        public void textboxlariTemizle()
        {
            tboxUrunKodu.Text = "";
            tboxUrunAd.Text = "";
            tboxUrunAdet.Text = "";
            tboxUrunAlisFiyati.Text = "";
            tboxUrunSatisFiyati.Text = "";
        }

        public void labellariTemizle()
        {
            lblMsjBarkod.Text = "";
            lblMsjAdet.Text = "";
            lblUyariDevam.Text = "";
        }


    }
}