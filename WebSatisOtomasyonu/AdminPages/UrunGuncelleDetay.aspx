<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/users.Master" AutoEventWireup="true" CodeBehind="UrunGuncelleDetay.aspx.cs" Inherits="WebSatisOtomasyonu.UserPage.UrunGuncelleDetay" %>

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
            font-size: large;
            text-align: center;
        }
        .auto-style15 {
            width: 124px;
            color: #FFFFFF;
        }
        .auto-style16 {
            color: #FFFFFF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 35px" class="baslik">
        <strong>&nbsp;ÜRÜN GÜNCELLE<asp:Label ID="lblOturum" runat="server" Visible="False"></asp:Label>
        </strong>
    </div>
    <div style="height: 50px"></div>
    <div style="height: 25px; background-color: #808080; border-radius: 20px; margin: auto; width: 1050px" class="auto-style14">
        <strong>
            <asp:Image ID="imgUyari" runat="server" Height="16px" ImageUrl="~/pics/warningYellow.png" Width="16px" CssClass="auto-style16" />
            &nbsp;<asp:Label ID="lblUyari2" runat="server" CssClass="auto-style15" Text="Güncelleme İşlemi Yapıldıktan Sonra Kategoriler Sayfasına Yönlendirileceksiniz..."></asp:Label>
        </strong>
    </div>
    <div style="height:20px"></div>
    <div style="margin: auto;" class="auto-style6">
        <table class="auto-style3">
            <tr>
                <td class="auto-style11" colspan="3">
                    <asp:Image ID="imgBasarisiz" runat="server" CssClass="eklemeResimleri" Height="16px" ImageUrl="~/pics/warning.png" Width="16px" />
                    <asp:Image ID="imgBasarili" runat="server" CssClass="eklemeResimleri" Height="16px" ImageUrl="~/pics/approval.png" Width="16px" />
                    <asp:Label ID="lblUyari" runat="server" CssClass="auto-style12"></asp:Label>
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
                    <asp:TextBox ID="tboxUrunAd" runat="server" Width="150px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Adet :</td>
                <td colspan="2">
                    <asp:TextBox ID="tboxUrunAdet" runat="server" TextMode="Number" Width="150px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Alış Fiyatı :</td>
                <td colspan="2">
                    <asp:TextBox ID="tboxUrunAlisFiyati" runat="server" Width="150px"></asp:TextBox>
                    <span class="auto-style10"><strong>(__,__₺)</strong></span></td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Satış Fiyatı :</td>
                <td colspan="2">
                    <asp:TextBox ID="tboxUrunSatisFiyati" runat="server" Width="150px"></asp:TextBox>
                    <span class="auto-style10"><strong>(__,__₺)</strong></span></td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Renk :</td>
                <td colspan="2">
                    <asp:DropDownList ID="ddListRenk" runat="server" Width="150px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Cinsiyet :</td>
                <td colspan="2">
                    <asp:DropDownList ID="ddListCinsiyet" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddListCinsiyet_SelectedIndexChanged" Width="150px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Kategori :</td>
                <td colspan="2">
                    <asp:DropDownList ID="ddListKategori" runat="server" Width="150px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Beden :</td>
                <td colspan="2">
                    <asp:DropDownList ID="ddListBeden" runat="server" Width="150px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Tedarikçi :</td>
                <td colspan="2">
                    <asp:DropDownList ID="ddListTedarikci" runat="server" Width="150px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style1" colspan="2">
                    <asp:Button ID="btnUrunGuncelle" runat="server" Text="Ürünü Güncelle" CssClass="btnEkle" Height="40px" OnClick="btnUrunGuncelle_Click" Width="100px" />
                </td>
            </tr>
        </table>
    </div>
    <div style="height: 50px"></div>
</asp:Content>
