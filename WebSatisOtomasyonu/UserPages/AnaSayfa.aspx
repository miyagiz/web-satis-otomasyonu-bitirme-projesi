<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/users2.Master" AutoEventWireup="true" CodeBehind="AnaSayfa.aspx.cs" Inherits="WebSatisOtomasyonu.UserPages.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .baslik {
            background-color: #191a27;
            color: #FFFFFF;
            font-family: sans-serif;
            font-size: 24px;
            text-align: center;
            line-height: 40px;
            vertical-align: middle;
            border-radius: 20px;
            height: 40px;
        }

        .buttonarti {
            width: 130px;
            border-radius: 30px;
            background-color: #808080;
            border-color: white;
            height: 30px;
            vertical-align: bottom;
            color: #FFFFFF;
            font-weight: bold;
        }
        
        .onayButonlari {
            border-radius: 20px;
            background-color: #FFFFFF;
            border-color: white;
            vertical-align: bottom;
            color: #000000;
            font-weight: bold;
            height: 30px;
            width: 200px;
        }


        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            height: 23px;
        }

        .auto-style3 {
            height: 50px;
        }

        .auto-style4 {
            height: 50px;
            width: 650px;
        }

        .auto-style5 {
            width: 100%;
            height: 50px;
        }

        .auto-style6 {
            width: 586px;
        }

        .auto-style8 {
            width: 130px;
        }

        .auto-style9 {
            width: 70px;
            text-align: left;
        }

        .tboxUrunKodu {
            border-radius: 30px;
            text-align:center;
            font-weight:bold;
        }

            .tboxUrunKodu::placeholder {
                text-align: center;
            }

        .subedekiUrunler {
            vertical-align: middle;
            line-height: 10px;
            font-weight: bold;
        }

        .auto-style10 {
            height: 21px;
        }

        .auto-style11 {
            height: 21px;
            width: 650px;
        }

        .auto-style12 {
            text-align: center;
            height: 50px;
            vertical-align: middle;
            line-height: 50px;
        }

        .auto-style14 {
            width: 650px;
        }

        .auto-style17 {
            width: 100%;
            height: 60px;
        }

        .auto-style18 {
            width: 325px;
            text-align: right;
        }

        

        .auto-style20 {
            text-align: left;
        }

        .auto-style21 {
            width: 600px;
            text-align: right;
        }
        .auto-style22 {
            
            color: #FFFFFF;
            font-size: large;
        }
        .auto-style23 {
            text-align: center;
        }
        .auto-style24 {
            height: 7px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="baslik">
        <strong>SATIŞ EKRANI</strong>
        <asp:Label ID="lblOturum" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lblKasiyerID" runat="server" Visible="False"></asp:Label>
    </div>
    <div style="height: 100%; margin-left: 50px; margin-right: 50px">
        <div style="height: 50px">
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">
                        <table class="auto-style5">
                            <tr>
                                <td class="auto-style8">
                                    <asp:TextBox placeholder="Ürün Kodu..." ID="tboxUrunKodu" runat="server" Height="30px" CssClass="tboxUrunKodu"></asp:TextBox></td>
                                <td class="auto-style9">
                                    <asp:Button ID="btnSubedekiUrunler" runat="server" Text="..." Height="30px" Width="35px" Class="subedekiUrunler" OnClick="btnSubedekiUrunler_Click" /></td>
                                <td>
                                    <asp:Button ID="btnSepeteEkle" runat="server" Text="Sepete Ekle" Height="30px" Class="buttonarti" OnClick="btnSepeteEkle_Click" /></td>
                            </tr>
                        </table>
                    </td>
                    <td class="auto-style3"></td>
                </tr>
            </table>
        </div>
        <div style="vertical-align:bottom;line-height:50px" class="auto-style24">
        <strong>
            <asp:Label ID="lblUyari2" runat="server" CssClass="auto-style22"></asp:Label>
        </strong>
        </div>
        <div style="height: 50px; border-bottom-style: solid; border-bottom-width: medium; border-bottom-color: #C0C0C0">
            <table class="auto-style5">
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td class="auto-style10">
                        <div style="height: 50px">
                            <div class="auto-style12" style="border-left-style: dashed; border-left-width: medium; border-left-color: #C0C0C0;">
                                <strong>
                                    <asp:Label ID="lblParaUstuHesapla" runat="server" CssClass="auto-style80" Text="Para Üstü Hesapla" Style="color: #FFFFFF; font-size: large"></asp:Label>
                                </strong>
                            </div>

                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div style="height: 60px">
            <table class="auto-style17">
                <tr>
                    <td class="auto-style14">

                        <strong>
                            <asp:Label ID="lblSepetToplami" runat="server" Text="Sepet Toplamı : " Style="color: #FFFFFF; font-size: x-large"></asp:Label>
                        </strong>

                        <asp:TextBox ID="tboxTutar" runat="server" Enabled="False" BackColor="White" Height="40px" Font-Size="30px" Font-Bold="true" Width="210px" ForeColor="Black" ></asp:TextBox>

                    </td>
                    <td class="auto-style18">
                        <strong>
                            <asp:Label ID="lblTahsilEdilenTutar" runat="server" Text="Tahsil Edilen Tutar : " Style="color: #FFFFFF; font-size: large"></asp:Label>
                        </strong>
                    </td>
                    <td class="auto-style8">

                        <asp:TextBox ID="tboxTahsilEdilenTutar" runat="server" Enabled="True" Height="25px" Font-Bold="true"></asp:TextBox>

                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;

                        <asp:Button ID="btnParaUstuHesapla" runat="server" Text="Hesapla" Height="30px" Width="75px" Class="buttonarti" OnClick="btnParaUstuHesapla_Click" />

                    </td>
                </tr>
            </table>
        </div>
        <div style="height: 60px">
            <table class="auto-style17">
                <tr>
                    <td class="auto-style14">
        <strong>
            <asp:Label ID="lblToplamTutar" runat="server" CssClass="auto-style2" Style="color: #FFFFFF" Visible="False"></asp:Label>
                        <br />
        </strong>
                    </td>
                    <td class="auto-style18">

                        <strong>
                            <asp:Label ID="lblParaUstu" runat="server" Text="Para Üstü : " Style="color: #FFFFFF; font-size: large"></asp:Label>
                        </strong>

                    </td>
                    <td>

                        <asp:TextBox ID="tboxParaUstu" runat="server" Enabled="False" BackColor="White" Height="25px" Font-Bold="true" ForeColor="Black"></asp:TextBox>

                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div style="height: 30px"></div>
    <div class="baslik">
        <table class="auto-style1">
            <tr>
                <td class="auto-style21">
                    <asp:Image ID="Image2" runat="server" Height="32px" ImageUrl="~/pics/shoping_basket.png" Width="32px" />
                </td>
                <td class="auto-style20">
                    <strong>ALIŞVERİŞ SEPETİ</strong>
                </td>
            </tr>
        </table>
    </div>
    <div style="height: 30px"></div>
    <div style="height: 30px" class="auto-style23">
        <strong>
            <asp:Label ID="lblUyari" runat="server" CssClass="auto-style22"></asp:Label>
        </strong>
                    </div>
    <div style="height: 30px"></div>
    <div style="height: 100%; width: 1300px; margin: auto; border-radius: 20px; text-align: center">
        <asp:GridView ID="gvSepet" runat="server" Width="1300px" CellPadding="3" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" BackColor="White" OnRowDeleting="gvSepet_RowDeleting">
            <Columns>
                <asp:CommandField ButtonType="Button" DeleteText="Sil" HeaderText="Ürün Sil" ShowDeleteButton="True" />
            </Columns>
            <EmptyDataTemplate>
                <table style="width: 1300px">
                    <tr>
                        <td class="auto-style74" style="border: thin solid #000000;"></td>
                        <td align="center" class="auto-style73" style="border-style: solid; border-width: thin; border-color: #000000; text-align: center; color: #FFFFFF"></td>
                        <td align="center" class="auto-style73" style="border-style: solid; border-width: thin; border-color: #000000; text-align: center"></td>
                        <td align="center" class="auto-style73" style="border-style: solid; border-width: thin; border-color: #000000; text-align: center"></td>
                        <td align="center" class="auto-style76" style="border: thin solid #000000; text-align: center"></td>
                        <td align="center" class="auto-style73" style="border-style: solid; border-width: thin; border-color: #000000; text-align: center">&nbsp;</td>
                        <td align="center" class="auto-style73" style="border-style: solid; border-width: thin; border-color: #000000; text-align: center"></td>
                        <td align="center" class="auto-style73" style="border-style: solid; border-width: thin; border-color: #000000; text-align: center"></td>
                        <td align="center" class="auto-style73" style="border-style: solid; border-width: thin; border-color: #000000; text-align: center"></td>
                        <td align="center" class="auto-style73" style="border-style: solid; border-width: thin; border-color: #000000; text-align: center">&nbsp;</td>
                    </tr>
                </table>
            </EmptyDataTemplate>

            <FooterStyle BackColor="#5D7B9D" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    </div>
    <div style="height: 30px"></div>
    <div style="height: 30px; margin-left: 50px; margin-right: 50px">

        <asp:Button CssClass="onayButonlari" ID="btnNakitSatis" runat="server" Text="NAKİT SATIŞ" OnClick="btnNakitSatis_Click" />
        <asp:Button CssClass="onayButonlari" ID="btnKartSatis" runat="server" Text="KREDİ KARTLI SATIŞ" OnClick="btnKartSatis_Click" />
        <asp:Button CssClass="onayButonlari" ID="btnTemizle" runat="server" Text="SEPETİ TEMİZLE" OnClick="btnTemizle_Click" />
    </div>
    <div style="height: 30px"></div>

</asp:Content>
