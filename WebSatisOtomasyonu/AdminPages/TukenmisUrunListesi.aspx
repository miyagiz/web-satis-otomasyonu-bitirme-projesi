<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/users.Master" AutoEventWireup="true" CodeBehind="TukenmisUrunListesi.aspx.cs" Inherits="WebSatisOtomasyonu.AdminPages.TukenmisUrunListesi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .baslik {
            background-color: #191a27;
            color: #FFFFFF;
            font-family: sans-serif;
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
            width: 1300px;
            height: 25px;
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

        .auto-style45 {
            width: 100%;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style46 {
            color: #FFFFFF;
            font-size: 12px;
        }

        .auto-style47 {
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
            width: 70px;
        }

        .auto-style48 {
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
            width: 190px;
        }

        .auto-style49 {
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
            width: 70px;
            font-size: small;
        }

        .auto-style51 {
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            width: 190px;
        }

        .auto-style52 {
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
            width: 80px;
        }

        .auto-style53 {
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            width: 80px;
        }

        .auto-style54 {
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            width: 50px;
        }

        .auto-style55 {
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
            width: 50px;
        }

        .auto-style56 {
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            width: 100px;
        }

        .auto-style57 {
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
            width: 100px;
        }

        .auto-style58 {
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            width: 120px;
        }

        .auto-style59 {
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
            width: 120px;
        }

        .auto-style60 {
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
            width: 60px;
            font-size: small;
        }

        .auto-style61 {
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
            width: 60px;
        }

        .auto-style63 {
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
            width: 210px;
        }

        .auto-style65 {
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            width: 210px;
        }

        .auto-style68 {
            width: 265px;
            text-align: center;
        }

        .auto-style69 {
            width: 55px;
            text-align: center;
        }

        .auto-style71 {
            width: 85px;
            text-align: center;
        }

        .auto-style72 {
            width: 90px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="baslik">
        <strong>TÜKENMİŞ OLAN ÜRÜNLERİN BİLGİLERİ</strong>
        <div style="width: 100px; float: right">
        </div>
        <asp:Label ID="lblOturum" runat="server" Visible="False"></asp:Label>
    </div>
    <div style="height: 30px"></div>
    <asp:Panel ID="Panel1" runat="server" Height="100%">
        <div style="width: 1300px; margin: auto; height: 25px; background-color: #808080; border-radius: 20px;">
            <table class="auto-style6">
                <tr>
                    <td class="auto-style49" style="border-right-style: solid; border-right-width: thin; border-right-color: #FFFFFF"><strong>Ürün Kod</strong></td>
                    <td class="auto-style51" style="border-right-style: solid; border-right-width: thin; border-right-color: #FFFFFF"><strong>Ürün Ad</strong></td>
                    <td class="auto-style54" style="border-right-style: solid; border-right-width: thin; border-right-color: #FFFFFF"><strong>Adet</strong></td>
                    <td class="auto-style53" style="border-right-style: solid; border-right-width: thin; border-right-color: #FFFFFF"><strong>Alış Fiyatı</strong></td>
                    <td class="auto-style53" style="border-right-style: solid; border-right-width: thin; border-right-color: #FFFFFF"><strong>Satış Fiyatı</strong></td>
                    <td class="auto-style53" style="border-right-style: solid; border-right-width: thin; border-right-color: #FFFFFF"><strong>Renk</strong></td>
                    <td class="auto-style56" style="border-right-style: solid; border-right-width: thin; border-right-color: #FFFFFF"><strong>Cinsiyet</strong></td>
                    <td class="auto-style58" style="border-right-style: solid; border-right-width: thin; border-right-color: #FFFFFF"><strong>Kategori</strong></td>
                    <td class="auto-style60" style="border-right-style: solid; border-right-width: thin; border-right-color: #FFFFFF"><strong>Beden</strong></td>
                    <td class="auto-style65" style="border-right-style: solid; border-right-width: thin; border-right-color: #FFFFFF"><strong>Tedarikçi Ad</strong></td>
                    <td class="auto-style56"><strong>Adet Ekle</strong></td>
                </tr>
            </table>
        </div>
        <div style="width: 1300px; margin: auto">
            <asp:DataList ID="DataList1" runat="server" Width="1300px">
                <ItemTemplate>
                    <table class="auto-style45">
                        <tr>
                            <td class="auto-style47" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                <asp:Label ID="lblUrunKod" runat="server" CssClass="auto-style46" Text='<%# Eval("urun_barkod") %>'></asp:Label>
                            </td>
                            <td class="auto-style48" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                <asp:Label ID="lblUrunAd" runat="server" CssClass="auto-style46" Text='<%# Eval("urun_ad") %>'></asp:Label>
                            </td>
                            <td class="auto-style55" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                <asp:Label ID="lblUrunAdet" runat="server" CssClass="auto-style46" Text='<%# Eval("urun_adet") %>'></asp:Label>
                            </td>
                            <td class="auto-style52" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                <asp:Label ID="lblAlis" runat="server" CssClass="auto-style46" Text='<%# Eval("urun_alis_fiyati") %>'></asp:Label>
                                <asp:Label ID="Label13" runat="server" CssClass="auto-style46" Text="₺"></asp:Label>
                            </td>
                            <td class="auto-style52" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                <asp:Label ID="lblSatis" runat="server" CssClass="auto-style46" Text='<%# Eval("urun_satis_fiyati") %>'></asp:Label>
                                <asp:Label ID="Label14" runat="server" CssClass="auto-style46" Text="₺"></asp:Label>
                            </td>
                            <td class="auto-style52" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                <asp:Label ID="lblRenk" runat="server" CssClass="auto-style46" Text='<%# Eval("renk_metin") %>'></asp:Label>
                            </td>
                            <td class="auto-style57" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                <asp:Label ID="lblCinsiyet" runat="server" CssClass="auto-style46" Text='<%# Eval("cinsiyet_detay") %>'></asp:Label>
                            </td>
                            <td class="auto-style59" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                <asp:Label ID="lblKategori" runat="server" CssClass="auto-style46" Text='<%# Eval("kategori_detay") %>'></asp:Label>
                            </td>
                            <td class="auto-style61" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                <asp:Label ID="lblBeden" runat="server" CssClass="auto-style46" Text='<%# Eval("beden_kisaltma") %>'></asp:Label>
                            </td>
                            <td class="auto-style63" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                <asp:Label ID="lblTedarikciAd" runat="server" CssClass="auto-style46" Text='<%# Eval("tedarikci_ad") %>'></asp:Label>
                            </td>
                            <td class="auto-style57" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                <a href='MevcutUrunEkle.aspx?urunid=<%#Eval("urun_id")%>'>
                                    <asp:Image ID="imgAdd" runat="server" Height="16px" ImageUrl="~/pics/add.png" Width="16px" />
                                </a>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div style="height: 50px"></div>
        <div style="width: 550px; margin-left: 50px; height: 25px; background-color: #808080; border-radius: 20px;">
            <table class="auto-style45">
                <tr>
                    <td class="auto-style68"><strong>Toplam :</strong></td>
                    <td class="auto-style69" style="border-right-style: solid; border-left-style: solid; border-left-width: thin; border-right-width: thin; border-right-color: #FFFFFF; border-left-color: #FFFFFF"><strong>
                        <asp:Label ID="lblToplamAdet" runat="server">0</asp:Label>
                    </strong></td>
                    <td class="auto-style71"><strong>
                        <asp:Label ID="lblToplamAlisFiyati" runat="server">0</asp:Label>
                        ₺</strong></td>
                    <td class="auto-style72" style="border-right-style: solid; border-left-style: solid; border-left-width: thin; border-right-width: thin; border-right-color: #FFFFFF; border-left-color: #FFFFFF"><strong>
                        <asp:Label ID="lblToplamSatisFiyati" runat="server">0</asp:Label>
                        ₺</strong></td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
        <div style="height: 50px"></div>
    </asp:Panel>
</asp:Content>
