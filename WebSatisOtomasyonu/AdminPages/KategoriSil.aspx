<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/users.Master" AutoEventWireup="true" CodeBehind="KategoriSil.aspx.cs" Inherits="WebSatisOtomasyonu.UserPage.KategoriSil" %>

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

        .auto-style26 {
            text-align: center;
            width: 47px;
        }

        .auto-style30 {
            text-align: center;
            width: 300px;
        }

        .auto-style34 {
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
            width: 51px;
        }

        .auto-style36 {
            width: 309px;
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style37 {
            width: 304px;
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style39 {
            width: 356px;
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
        .auto-style41 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="baslik">
        <strong>KATEGORİLER</strong>
        <div style="width: 100px; float: right">
            <asp:Button ID="btnKategoriSilAc" runat="server" Text="+" CssClass="buttonarti" OnClick="btnKategoriSilAc_Click" />
        </div>
        <asp:Label ID="lblOturum" runat="server" Visible="False"></asp:Label>
    </div>
    <div style="height: 20px"></div>
    <asp:Panel ID="Panel1" runat="server" Height="100%">
        <div style="height: 30px; width: 1050px; margin: auto">
            <div style="width: 170px; height: 30px; border-radius: 20px;">
                <asp:TextBox ID="tboxSearch" runat="server" CssClass="tboxSearch" TextMode="Search" Width="95px"></asp:TextBox>
                &nbsp;<asp:Button ID="btnAra" runat="server" CssClass="btnEkle" OnClick="btnAra_Click" Text="Ara..." />
            </div>
        </div>
        <div style="height: 20px" class="auto-style41">
            <asp:Label ID="lblUyari" runat="server" CssClass="auto-style9"></asp:Label>
        </div>
        <div style="height: 20px"></div>

        <div style="width: 1050px; margin: auto; height: 25px; background-color: #808080; border-radius: 20px;">
            <table class="auto-style6">
                <tr>
                    <td class="auto-style7" style="border-right-style: solid; border-right-width: medium; border-right-color: #FFFFFF;"><strong>Kategori</strong></td>
                    <td class="auto-style39" style="border-right-style: solid; border-right-width: medium; border-right-color: #FFFFFF"><strong>Cinsiyet&nbsp;&nbsp;&nbsp;&nbsp; </strong>
                        <asp:DropDownList ID="ddListCinsiyetFiltre" runat="server" CssClass="tboxCinsiyetGetir" AutoPostBack="True" OnSelectedIndexChanged="ddListCinsiyet_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td class="auto-style7" style="border-right-style: solid; border-right-width: medium; border-right-color: #FFFFFF"><strong>Ürün Adedi</strong></td>
                    <td class="auto-style34"><strong>Sil</strong></td>
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
                                        <td class="auto-style37" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <asp:Label ID="lblKategori" runat="server" CssClass="auto-style9" Text='<%# Eval("kategori_detay") %>'></asp:Label>
                                        </td>
                                        <td class="auto-style36" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <asp:Label ID="lblCinsiyet" runat="server" CssClass="auto-style9" Text='<%# Eval("cinsiyet_detay") %>'></asp:Label>
                                        </td>
                                        <td class="auto-style30" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <asp:Label ID="lblAdet" runat="server" CssClass="auto-style9" Text='<%# Eval("kategori_adet") %>'></asp:Label>
                                        </td>
                                        <td class="auto-style26" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <a href="KategoriSil.aspx?kategoriid=<%#Eval("kategori_id")%>&islemsil=sil">
                                                <asp:Image ID="Image2" runat="server" Height="16px" ImageUrl="~/pics/delete.png" Width="16px" />
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
