<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/users.Master" AutoEventWireup="true" CodeBehind="TransferYap.aspx.cs" Inherits="WebSatisOtomasyonu.AdminPages.TransferYap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 100%;
            font-family:Arial, Helvetica, sans-serif;
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
            color: #FFFFFF;
            font-size: large;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style15 {
            color: #FFFFFF;
            font-size: 20px;
            width: 287px;
            text-align: right;
        }
        .auto-style16 {
            color: #FFFFFF;
            font-size: 20px;
            text-align: center;
        }
        .auto-style17 {
            font-size: x-large;
            color: #FFFFFF;
            text-decoration: underline;
        }
        .auto-style18 {
            color: #FFFFFF;
            font-size: 20px;
            width: 287px;
            text-align: right;
            height: 36px;
        }
        .auto-style19 {
            height: 36px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="baslik">
        <strong>TRANSFER YAP</strong>
        <asp:Label ID="lblOturum" runat="server" Visible="False"></asp:Label>
    </div>
    <div style="height: 20px"></div>
    <div style="height: 30px" class="auto-style1"><strong>
        <asp:Label ID="lblMesaj" runat="server" CssClass="auto-style17"></asp:Label>
        </strong></div>
    <div style="height: 20px"></div>
    <div style="float: right; width: 500px; margin-right: 100px">
        <div style="width: 500px; height: 25px; background-color: #808080; border-radius: 20px;" class="auto-style1">
            <strong>
                <asp:Label ID="Label1" runat="server" CssClass="auto-style14" Text="TRANSFER YAP"></asp:Label>
            </strong>
        </div>
        <div style="height: 20px"></div>
        <div style="" class="auto-style6">
            <table class="auto-style3">
                <tr>
                    <td class="auto-style16" colspan="2">
                        <asp:Image ID="imgBasarisizTransfer" runat="server" CssClass="eklemeResimleri" Height="16px" ImageUrl="~/pics/warning.png" Width="16px" />
                        <asp:Image ID="imgBasariliTransfer" runat="server" CssClass="eklemeResimleri" Height="16px" ImageUrl="~/pics/approval.png" Width="16px" />
                        <asp:Label ID="lblMesajTransfer" runat="server" CssClass="auto-style12"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style18">Transfer Edilecek Şube :</td>
                    <td class="auto-style19">
                        <asp:DropDownList ID="ddListSubeler" runat="server" EnableTheming="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">Transfer Edilecek Adet :</td>
                    <td>
                        <asp:TextBox ID="tboxTransferAdet" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style15">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style16" colspan="2">
                        <asp:Button ID="btnTransferEt" runat="server" Text="Transfer Et" CssClass="btnEkle" Height="40px" Width="100px" OnClick="btnTransferEt_Click" />
                    </td>
                </tr>
            </table>


        </div>

    </div>
    <div style="width: 600px; height: auto">
        <div style="width: 500px; margin-left: 100px; height: 25px; background-color: #808080; border-radius: 20px;" class="auto-style1">
            <strong>
                <asp:Label ID="lblUrunBilgileri" runat="server" CssClass="auto-style14" Text="ÜRÜN BİLGİLERİ"></asp:Label>
            </strong>
        </div>
        <div style="height: 20px"></div>
        <div style="margin-left: 100px" class="auto-style6">
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
                        <asp:TextBox ID="tboxUrunKodu" runat="server" TextMode="Number" Width="150px" MaxLength="4"></asp:TextBox>
                    </td>
                    <td class="auto-style13">&nbsp;<asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/pics/search.png" OnClick="imgSearch_Click" />
                    </td>
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
                        <asp:TextBox ID="tboxUrunAdet" runat="server" TextMode="Number" Width="150px" ReadOnly="True"></asp:TextBox>
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
                    <td class="auto-style4">Ürün Cinsiyet :</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddListCinsiyet" runat="server" Enabled="False" Width="150px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Ürün Kategori :</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddListKategori" runat="server" Width="150px" Enabled="False">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Ürün Renk :</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddListRenk" runat="server" Enabled="False" Width="150px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Ürün Beden :</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddListBeden" runat="server" Enabled="False" Width="150px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Ürün Tedarikçi :</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddListTedarikci" runat="server" Enabled="False" Width="150px">
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
                        &nbsp;</td>
                </tr>
            </table>

        </div>

    </div>













</asp:Content>
