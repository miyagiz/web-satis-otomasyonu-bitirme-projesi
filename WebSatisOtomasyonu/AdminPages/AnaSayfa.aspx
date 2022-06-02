<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/users.Master" AutoEventWireup="true" CodeBehind="AnaSayfa.aspx.cs" Inherits="WebSatisOtomasyonu.UserPage.AnaSayfa" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="../Style/AnaSayfa.css" rel="stylesheet" />

    <style type="text/css">
        .baslik {
            background-color: #191a27;
            color: #FFFFFF;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 24px;
            text-align: center;
            border-radius: 20px;
        }

        .buttonarti {
            width: 50px;
            border-radius: 30px;
            background-color: #808080;
            border-color: white;
            height: 30px;
            vertical-align: bottom;
        }

        .auto-style6 {
            width: 100%;
            height: 20px;
            line-height: 20px;
        }

        .auto-style1 {
            font-family: Arial, Helvetica, sans-serif;
            width: 150px;
        }

        .btnEkle {
            border-radius: 20px;
            height: 30px;
            width: 50px;
            background-color: orange;
            border-color: #FFFFFF;
        }

        .eklemeResimleri {
            line-height: 30px;
            vertical-align: top;
        }

        .auto-style7 {
            height: 500px;
            width: 200px;
            float: left;
        }

        .auto-style13 {
            float: left;
            height: 175px;
            width: 400px;
        }

        .auto-style14 {
            width: 100%;
            height: 140px;
        }

        .auto-style15 {
            width: 316px;
        }

        .auto-style16 {
            color: #FFFFFF;
            font-size: xx-large;
            font-family: Arial, Helvetica, sans-serif;
            margin-right:30px;
        }

        .auto-style17 {
            height: 454px;
        }

        .auto-style18 {
            background-color: #191a27;
            color: #FFFFFF;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 20px;
            text-align: center;
            border-radius: 20px;
        }

        .auto-style19 {
            color: #FFFFFF;
            font-size: 20px;
            font-family: Arial, Helvetica, sans-serif;
            margin-left: 50px;
            text-decoration: none;
        }



        .auto-style20 {
            width: 200px;
        }
        .auto-style21 {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <strong>
        <asp:Label ID="lblOturum" runat="server" CssClass="auto-style6" Visible="False"></asp:Label>
    </strong>
    <div style="height: 700px; width: 1400px">
        <div style="margin-left: 15px; margin-top: 10px" class="auto-style7">
            <div class="baslik">
                ≡
                Hızlı İşlemler
            </div>
            <div id="hizliMenu" style="border: thin solid #FFFFFF; margin-top: 10px;" class="auto-style17">
                <ul>
                    <li><a href="UrunEkle.aspx"><span class="">Ürün Bilgisi Ekle</span></a></li>
                    <li><a href="Urunler.aspx"><span class="">Ürün Bilgilerini Görüntüle</span></a></li>
                    <li><a href="KategoriEkle.aspx"><span class="">Kategori Ekle</span></a></li>
                    <li><a href="KategoriGuncelle.aspx"><span class="">Kategori Güncelle</span></a></li>
                    <li><a href="KategoriSil.aspx"><span class="">Kategori Sil</span></a></li>
                    <li><a href="TransferYap.aspx"><span class="">Transfer Yap</span></a></li>
                    <li><a href="TedarikciEkle.aspx"><span class="">Tedarikçi Bilgisi Ekle</span></a></li>
                    <li><a href="TedarikciGuncelle.aspx"><span class="">Tedarikçi Bilgisi Güncelle</span></a></li>
                    <li><a href="TedarikciSil.aspx"><span class="">Tedarikçi Bilgisi Sil</span></a></li>
                    <li><a href="Renkler.aspx"><span class="">Renkler</span></a></li>
                    <li><a href="Bedenler.aspx"><span class="">Bedenler</span></a></li>
                    <li><a href="Subeler.aspx"><span class="">Şube Bilgileri</span></a></li>
                    <li><a href="Kasiyerler.aspx"><span class="">Kasiyer Bilgileri</span></a></li>
                </ul>
            </div>
        </div>
        <div style="margin-left: 150px; margin-top: 10px;" class="auto-style13">
            <div class="auto-style18">
                Depodaki Toplam Ürün Sayısı 
            </div>
            <div style="background-color: #383b50; border-radius: 20px; height: 140px; margin-top: 10px">


                <table class="auto-style14">
                    <tr>
                        <td class="auto-style15">
                            <asp:Image ID="imgToplamUrunSayisi" runat="server" ImageUrl="~/pics/polo-shirt-128.png" Style="margin-left: 20px" />
                        </td>
                        <td class="auto-style21">
                            <strong>
                                <asp:Label ID="lblToplamUrunSayisi" runat="server" CssClass="auto-style16"></asp:Label>
                            </strong>
                        </td>
                    </tr>
                </table>


            </div>
        </div>

        <div style="margin-left: 150px; margin-top: 10px;" class="auto-style13">
            <div class="auto-style18">
                Aktif Çalışılan Tedarikçi Sayısı
            </div>
            <div style="background-color: #383b50; border-radius: 20px; height: 140px; margin-top: 10px">


                <table class="auto-style14">
                    <tr>
                        <td class="auto-style15">
                            <asp:Image ID="imgTedarikciSayisi" runat="server" ImageUrl="~/pics/shop-128.png" Style="margin-left: 20px" />
                        </td>
                        <td class="auto-style21">
                            <strong>
                                <asp:Label ID="lblTedarikciSayisi" runat="server" CssClass="auto-style16"></asp:Label>
                            </strong>
                        </td>
                    </tr>
                </table>


            </div>
        </div>

        <div style="margin-left: 150px; margin-top: 50px;" class="auto-style13">
            <div class="auto-style18">
                Adedi Kritik Seviyede Olan Ürünler
                Listesi
            </div>
            <div style="background-color: #383b50; border-radius: 20px; height: 140px; margin-top: 10px">
                <table class="auto-style14">
                    <tr>
                        <td class="auto-style20">
                            <asp:Image ID="imgKritikUrunListesi" runat="server" ImageUrl="~/pics/warning128.png" Style="margin-left: 20px" />
                        </td>
                        <td>
                            <a href="KritikAdet.aspx">
                                <strong>
                                    <asp:Label ID="lblKritikListesi" runat="server" CssClass="auto-style19">Görüntüle &gt;&gt;&gt;</asp:Label>
                                </strong>
                            </a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>


        <div style="margin-left: 150px; margin-top: 50px;" class="auto-style13">
            <div class="auto-style18">
                Tükenmiş Olan Ürünler Listesi</div>
            <div style="background-color: #383b50; border-radius: 20px; height: 140px; margin-top: 10px">


                <table class="auto-style14">
                    <tr>
                        <td class="auto-style20">
                            <asp:Image ID="imgFinish" runat="server" ImageUrl="~/pics/finish128.png" Style="margin-left: 20px" BorderStyle="None" />
                        </td>
                        <td>
                            <a href="TukenmisUrunListesi.aspx">
                                <strong>
                                    <asp:Label ID="lblTukenmisListesi" runat="server" CssClass="auto-style19">Görüntüle &gt;&gt;&gt;</asp:Label>
                                </strong>
                            </a>
                        </td>
                    </tr>
                </table>


            </div>
        </div>


        <div style="margin-left: 150px; margin-top: 50px;" class="auto-style13">
            <div class="auto-style18">
                Silinmiş Ürünlerin Listesi</div>
            <div style="background-color: #383b50; border-radius: 20px; height: 140px; margin-top: 10px">


                <table class="auto-style14">
                    <tr>
                        <td class="auto-style20">
                            <asp:Image ID="imgSilinmisUrunler" runat="server" ImageUrl="~/pics/delete128.png" Style="margin-left: 20px" />
                        </td>
                        <td>
                            <a href="SilinmisUrunlerListesi.aspx">
                                <strong>
                                    <asp:Label ID="lblSilinmisUrunler" runat="server" CssClass="auto-style19">Görüntüle &gt;&gt;&gt;</asp:Label>
                                </strong>
                            </a>
                        </td>
                    </tr>
                </table>


            </div>
        </div>

        <div style="margin-left: 150px; margin-top: 50px;" class="auto-style13">
            <div class="auto-style18">
                Toplam Kategori Sayısı</div>
            <div style="background-color: #383b50; border-radius: 20px; height: 140px; margin-top: 10px">


                <table class="auto-style14">
                    <tr>
                        <td class="auto-style20">
                            <asp:Image ID="imgCategories" runat="server" ImageUrl="~/pics/menu128.png" Style="margin-left: 20px" />
                        </td>
                        <td class="auto-style21">
                            <strong>
                                <asp:Label ID="lblKategoriSayisi" runat="server" CssClass="auto-style16"></asp:Label>
                            </strong>
                        </td>
                    </tr>
                </table>


            </div>
        </div>
    </div>
</asp:Content>
