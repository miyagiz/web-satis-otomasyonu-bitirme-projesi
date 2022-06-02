<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/users.Master" AutoEventWireup="true" CodeBehind="UrunEkle.aspx.cs" Inherits="WebSatisOtomasyonu.UserPage.UrunEkle" %>
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
        }      
        .auto-style6 {
            width: 500px;
        }
        .baslik{
            background-color:#191a27;
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
            font-family:Arial, Helvetica, sans-serif;
        }
    .auto-style11 {
        text-align: center;
        font-size: x-large;
        color: #FFFFFF;
        font-family: Arial, Helvetica, sans-serif;
            height: 40px;
        }
    .auto-style12 {
        font-size: large;
    }
        .auto-style13 {
            text-align: center;
            font-size: x-large;
            color: #FFFFFF;
            font-family: Arial, Helvetica, sans-serif;
            height: 30px;
        }
        .auto-style14 {
            font-size: medium;
            color: #339966;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height:35px" class="baslik"><strong>YENİ ÜRÜN EKLE<asp:Label ID="lblOturum" runat="server" Visible="False"></asp:Label>
        </strong></div>
    <div style="height:50px"></div>
    <div style="margin:auto;" class="auto-style6">
        <table class="auto-style3">
            <tr>
                <td class="auto-style11" colspan="2">
                            <asp:Image ID="imgBasarisiz" runat="server" CssClass="eklemeResimleri" Height="16px" ImageUrl="~/pics/warning.png" Width="16px" />
                            <asp:Image ID="imgBasarili" runat="server" CssClass="eklemeResimleri" Height="16px" ImageUrl="~/pics/approval.png" Width="16px" />
                            <asp:Label ID="lblUyari" runat="server" CssClass="auto-style12"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style13" colspan="2">
                    <asp:CheckBox ID="chbBilgilerSilinmesin" runat="server" CssClass="auto-style14" Text=" Ürün Eklendikten Sonra Bilgiler Sİlinmesin." />
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Kodu :</td>
                <td>
                    <asp:TextBox ID="tboxBarkod" runat="server" TextMode="Number" Width="150px" MaxLength="4" AutoPostBack="True" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">Ürün Ad :</td>
                <td class="auto-style8">
                    <asp:TextBox ID="tboxUrunAd" runat="server" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Adet :</td>
                <td>
                    <asp:TextBox ID="tboxUrunAdet" runat="server" TextMode="Number" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Alış Fiyatı :</td>
                <td>
                    <asp:TextBox ID="tboxUrunAlisFiyati" runat="server" Width="150px"></asp:TextBox>
                    <span class="auto-style10"><strong>&nbsp;(__,__₺)</strong></span></td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Satış Fiyatı :</td>
                <td>
                    <asp:TextBox ID="tboxUrunSatisFiyati" runat="server" Width="150px"></asp:TextBox>
                    <span class="auto-style10"><strong>&nbsp;(__,__₺)</strong></span></td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Renk :</td>
                <td>
                    <asp:DropDownList ID="ddListUrunRenk" runat="server" Width="150px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Cinsiyet :</td>
                <td>
                    <asp:DropDownList ID="ddListUrunCinsiyet" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddListUrunCinsiyet_SelectedIndexChanged" Width="150px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Kategori :</td>
                <td>
                    <asp:DropDownList ID="ddListUrunKategori" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddListUrunKategori_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Beden :</td>
                <td>
                    <asp:DropDownList ID="ddListUrunBeden" runat="server" Width="150px" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Ürün Tedarikçi :</td>
                <td>
                    <asp:DropDownList ID="ddListUrunTedarikci" runat="server" Width="150px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style1">
                    <asp:Button ID="btnUrunEkle" runat="server" Text="Ürün Ekle" CssClass="btnEkle" Height="40px" OnClick="Button1_Click" Width="100px" />
                </td>
            </tr>
        </table>
    </div>
    <div style="height: 50px"></div>

</asp:Content>
