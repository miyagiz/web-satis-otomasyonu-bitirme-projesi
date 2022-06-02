<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/users.Master" AutoEventWireup="true" CodeBehind="KategoriGuncelle.aspx.cs" Inherits="WebSatisOtomasyonu.UserPage.KategoriGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

        .auto-style7 {
            width: 350px;
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style9 {
            color: #FFFFFF;
            font-size: large;
        }

        .auto-style1 {
            font-family: Arial, Helvetica, sans-serif;
        }

        .btnEkle {
            border-radius: 20px;
            height: 30px;
            width: 50px;
            background-color: orange;
            border-color: #FFFFFF;
        }

        .auto-style10 {
            width: 100%;
        }

        .auto-style11 {
            width: 280px;
            color: #FFFFFF;
            font-size: large;
            text-align: right;
        }

        .auto-style12 {
            font-size: large;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style13 {
            margin-left: 0px;
        }

        .auto-style14 {
            width: 125px;
            text-align: right;
        }

        .auto-style17 {
            width: 30px;
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style18 {
            width: 320px;
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
        }

        .tboxSearch {
            border-radius: 20px;
            height: 27px;
            overflow: hidden;
            text-align: center;
            vertical-align: top;
        }

        .tboxCinsiyetGetir {
            border-radius: 20px;
            height: 20px;
            overflow: hidden;
            text-align: center;
            vertical-align: top;
        }

        .auto-style19 {
            border-radius: 20px;
            background-color: orange;
            border-color: #FFFFFF;
        }

        .auto-style20 {
            color: #FFFFFF;
        }
        .auto-style21 {
            width: 400px;
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style22 {
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
            width: 265px;
        }
        .auto-style23 {
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
            width: 90px;
        }
        .auto-style26 {
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
            width: 264px;
        }
        .auto-style27 {
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
            width: 85px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="baslik">
        <strong>KATEGORİLER</strong>
        <div style="width: 100px; float: right">
            <asp:Button ID="btnKategorileriAc" runat="server" Text="+" CssClass="buttonarti" OnClick="btnKategorileriAc_Click" />
        </div>
        <asp:Label ID="lblOturum" runat="server" Visible="False"></asp:Label>
    </div>
    <div style="height: 20px"></div>
    <asp:Panel ID="Panel1" runat="server" Height="100%">
        <div style="height: 30px; width: 1050px; margin: auto">
            <div style="width: 170px; height: 30px; border-radius: 20px;">
                <asp:TextBox ID="tboxSearch" runat="server" CssClass="tboxSearch" TextMode="Search" Width="95px"></asp:TextBox>
                &nbsp;<asp:Button ID="btnAra" runat="server" CssClass="btnEkle" Text="Ara..." OnClick="btnAra_Click" />
            </div>
        </div>

        <div style="height: 20px"></div>
        <div style="width: 1050px; margin: auto; height: 25px; background-color: #808080; border-radius: 20px;">
            <table class="auto-style6">
                <tr>
                    <td class="auto-style18"><strong>Kategori</strong></td>
                    <td class="auto-style17" style="border-right-style: solid; border-right-width: medium; border-right-color: #FFFFFF;">
                        <asp:ImageButton ID="imgSirala" runat="server" Height="16px" ImageUrl="~/pics/az.png" Width="16px" />
                    </td>
                    <td class="auto-style21" style="border-right-style: solid; border-right-width: medium; border-right-color: #FFFFFF"><strong>Cinsiyet&nbsp;&nbsp;&nbsp;&nbsp; </strong>
                        <asp:DropDownList ID="ddListCinsiyetFiltre" runat="server" CssClass="tboxCinsiyetGetir" AutoPostBack="True" OnSelectedIndexChanged="ddListCinsiyetFiltre_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style22" style="border-right-style: solid; border-right-width: medium; border-right-color: #FFFFFF"><strong>Ürün Adedi</strong></td>
                    <td class="auto-style27"><strong>Güncelle</strong></td>
                </tr>
            </table>
        </div>
        <div style="height: 100%">
            <div style="width: 1400px">
                <asp:DataList ID="dListKategoriler" runat="server">
                    <ItemTemplate>
                        <div style="width: 1400px">
                            <div style="width: 1050px; margin: auto; height: 100%">
                                <table class="auto-style6">
                                    <tr>
                                        <td class="auto-style7" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <asp:Label ID="lblKategori" runat="server" CssClass="auto-style9" Text='<%# Eval("kategori_detay") %>'></asp:Label>
                                        </td>
                                        <td class="auto-style21" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <asp:Label ID="lblCinsiyet" runat="server" CssClass="auto-style9" Text='<%# Eval("cinsiyet_detay") %>'></asp:Label>
                                        </td>
                                        <td class="auto-style22" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <asp:Label ID="lblAdet" runat="server" CssClass="auto-style9" Text='<%# Eval("kategori_adet") %>'></asp:Label>
                                        </td>
                                        <td class="auto-style23" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <a href="KategoriGuncelleDetay.aspx?kategoriid=<%#Eval("kategori_id")%>">
                                                <asp:Image ID="imgGuncelle" runat="server" Height="16px" ImageUrl="~/pics/edit.png" Width="16px" OnClick="imgGuncelle_Click" />
                                            </a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </asp:Panel>
    <div style="height: 50px"></div>
    
    
    
</asp:Content>
