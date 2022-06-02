<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/users.Master" AutoEventWireup="true" CodeBehind="MevcutUrunEkle.aspx.cs" Inherits="WebSatisOtomasyonu.UserPage.MevcutUrunEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 100%;
        }

        .auto-style4 {
            text-align: right;
            font-size: x-large;
            color: #FFFFFF;
            font-family: Arial, Helvetica, sans-serif;
            width: 213px;
        }

        .auto-style6 {
            width: 500px;
        }

        .baslik {
            background-color: #191a27;
            color: #FFFFFF;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 24px;
            text-align: center;
            border-radius: 20px;
        }

        .auto-style7 {
            text-align: right;
            font-size: x-large;
            color: #FFFFFF;
            font-family: Arial, Helvetica, sans-serif;
            height: 26px;
            width: 213px;
        }

        .auto-style8 {
            height: 26px;
        }

        .btnEkle {
            border-radius: 20px;
            background-color: orange;
            border-color: #FFFFFF;
        }

        .auto-style10 {
            color: #FFFFFF;
            font-size: large;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style11 {
            text-align: center;
            font-size: x-large;
            color: #FFFFFF;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style12 {
            font-size: large;
        }

        .auto-style13 {
            width: 124px;
        }
        .auto-style14 {
            text-align: center;
            font-size: x-large;
            color: #FFFFFF;
            font-family: Arial, Helvetica, sans-serif;
            width: 213px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 35px" class="baslik">
        <strong>&nbsp;MEVCUT ÜRÜNE ADET EKLE<asp:Label ID="lblOturum" runat="server" Visible="False"></asp:Label>
        </strong>
    </div>
    <div style="height: 50px"></div>
    <div style="margin: auto;" class="auto-style6">
        <table class="auto-style3">
            <tr>
                <td class="auto-style11" colspan="3">
                    <asp:Image ID="imgBasarisiz" runat="server" CssClass="eklemeResimleri" Height="16px" ImageUrl="~/pics/warning.png" Width="16px" />
                    <asp:Image ID="imgBasarili" runat="server" CssClass="eklemeResimleri" Height="16px" ImageUrl="~/pics/approval.png" Width="16px" />
                    <asp:Label ID="lblMsjBarkod" runat="server" CssClass="auto-style12" Font-Italic="True" Font-Overline="False" Font-Underline="True"></asp:Label>
                    <asp:Label ID="lblUyari" runat="server" CssClass="auto-style12"></asp:Label>
                    <asp:Label ID="lblMsjAdet" runat="server" CssClass="auto-style12" Font-Italic="True" Font-Underline="True"></asp:Label>
                    <asp:Label ID="lblUyariDevam" runat="server" CssClass="auto-style12"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Kodu :</td>
                <td>
                    <asp:TextBox ID="tboxBarkod" runat="server" TextMode="Number" Width="150px" MaxLength="4" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="auto-style13">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">Ürün Ad :</td>
                <td class="auto-style8" colspan="2">
                    <asp:TextBox ID="tboxUrunAd" runat="server" Width="150px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Adet :</td>
                <td colspan="2">
                    <asp:TextBox ID="tboxUrunAdet" runat="server" TextMode="Number" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Alış Fiyatı :</td>
                <td colspan="2">
                    <asp:TextBox ID="tboxUrunAlisFiyati" runat="server" Width="150px" ReadOnly="True"></asp:TextBox>
                    <span class="auto-style10"><strong>(__,__₺)</strong></span></td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Satış Fiyatı :</td>
                <td colspan="2">
                    <asp:TextBox ID="tboxUrunSatisFiyati" runat="server" Width="150px" ReadOnly="True"></asp:TextBox>
                    <span class="auto-style10"><strong>(__,__₺)</strong></span></td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Renk :</td>
                <td colspan="2">
                    <asp:TextBox ID="tboxUrunRenk" runat="server" Width="150px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Cinsiyet :</td>
                <td colspan="2">
                    <asp:TextBox ID="tboxUrunCinsiyet" runat="server" Width="150px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Kategori :</td>
                <td colspan="2">
                    <asp:TextBox ID="tboxUrunKategori" runat="server" Width="150px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Beden :</td>
                <td colspan="2">
                    <asp:TextBox ID="tboxUrunBeden" runat="server" Width="150px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Tedarikçi :</td>
                <td colspan="2">
                    <asp:TextBox ID="tboxUrunTedarikci" runat="server" Width="150px" Height="100px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style14">
                    <a href="Urunler.aspx">
                    <asp:Image ID="imgGeri" runat="server" Height="64px" ImageUrl="~/pics/arrow128.png" Width="64px" /></a>
                    <br />
                    <asp:Label ID="lblGeri" runat="server" Text="Geri"></asp:Label>
                </td>
                <td class="auto-style1" colspan="2">
                    <asp:Button ID="btnAdetEkle" runat="server" Text="Adet Ekle" CssClass="btnEkle" Height="40px" OnClick="btnAdetEkle_Click" Width="100px" />
                </td>
            </tr>
        </table>
    </div>
    <div style="height: 50px"></div>
</asp:Content>
