<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/users.Master" AutoEventWireup="true" CodeBehind="Subeler.aspx.cs" Inherits="WebSatisOtomasyonu.UserPage.Subeler" %>

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

        .auto-style9 {
            color: #FFFFFF;
            font-size: large;
        }

        .auto-style1 {
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style10 {
            width: 100%;
        }

        .auto-style12 {
            font-size: large;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style13 {
            margin-left: 0px;
        }

        .btnEkle {
            border-radius: 20px;
            height: 30px;
            width: 50px;
            background-color: orange;
            border-color: #FFFFFF;
        }

        .auto-style14 {
            width: 125px;
            text-align: right;
        }

        .auto-style17 {
            color: #FFFFFF;
            font-size: large;
            text-align: center;
        }

        .auto-style21 {
            width: 357px;
            color: #FFFFFF;
            font-size: large;
            text-align: right;
        }

        .eklemeResimleri {
            line-height: 30px;
            vertical-align: top;
        }

        .auto-style23 {
            width: 250px;
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style24 {
            width: 260px;
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style25 {
            width: 230px;
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style26 {
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
            width: 182px;
        }

        .auto-style32 {
            text-align: center;
        }

        .auto-style33 {
            color: #FFFFFF;
            font-family: Arial, Helvetica, sans-serif;
            font-size: large;
        }

        .auto-style34 {
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
            width: 100px;
        }

        .auto-style36 {
            width: 205px;
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style37 {
            width: 203px;
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style38 {
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
            width: 175px;
        }

        .auto-style39 {
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
            width: 93px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="baslik">
        <strong>ŞUBE BİLGİSİ</strong>
        <div style="width: 100px; float: right">
            <asp:Button ID="btnSubeBilgisiAc" runat="server" Text="+" CssClass="buttonarti" OnClick="btnSubeBilgisiAc_Click" />
        </div>
        <asp:Label ID="lblOturum" runat="server" Visible="False"></asp:Label>
    </div>
    <div style="height: 30px"></div>
    <div style="height: 30px" class="auto-style32">
        <strong>
            <asp:Image ID="imgUyari" runat="server" Height="16px" ImageUrl="~/pics/warningYellow.png" Width="16px" />
            &nbsp;</strong><asp:Label ID="lblUyari" runat="server" CssClass="auto-style33"></asp:Label>
    </div>
    <div style="height: 30px"></div>
    <asp:Panel ID="Panel1" runat="server" Height="100%">
        <div style="width: 1050px; margin: auto; height: 25px; background-color: #808080; border-radius: 20px;">
            <table class="auto-style6">
                <tr>
                    <td class="auto-style23" style="border-right-style: solid; border-right-width: medium; border-right-color: #FFFFFF"><strong>Şube Adı</strong></td>
                    <td class="auto-style24" style="border-right-style: solid; border-right-width: medium; border-right-color: #FFFFFF"><strong>Şube Adres</strong></td>
                    <td class="auto-style25" style="border-right-style: solid; border-right-width: medium; border-right-color: #FFFFFF"><strong>Şube Telefon No</strong></td>
                    <td class="auto-style25" style="border-right-style: solid; border-right-width: medium; border-right-color: #FFFFFF"><strong>Ürünler</strong></td>
                    <td class="auto-style26" style="border-right-style: solid; border-right-width: medium; border-right-color: #FFFFFF"><strong>Güncelle</strong></td>
                    <td class="auto-style34"><strong>Sil</strong></td>
                </tr>
            </table>
        </div>
        <div style="height: 100%">
            <div style="width: 1400px">
                <asp:DataList ID="DataList1" runat="server">
                    <ItemTemplate>
                        <div style="width: 1400px">
                            <div style="width: 1050px; margin: auto; height: 100%">
                                <table class="auto-style6">
                                    <tr>
                                        <td class="auto-style25" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <asp:Label ID="lblSubeAd" runat="server" CssClass="auto-style9" Text='<%# Eval("sube_ad") %>'></asp:Label>
                                        </td>
                                        <td class="auto-style25" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <asp:Label ID="lblSubeAdres" runat="server" CssClass="auto-style9" Text='<%# Eval("sube_adres") %>'></asp:Label>
                                        </td>
                                        <td class="auto-style37" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <asp:Label ID="lblSubeTelNo" runat="server" CssClass="auto-style9" Text='<%# Eval("sube_telefon_no") %>'></asp:Label>
                                        </td>
                                        <td class="auto-style36" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <a href="SubelerdekiUrunler.aspx?subeid=<%#Eval("sube_id")%>">
                                                <asp:Image ID="imgUrunler" runat="server" Height="16px" ImageUrl="~/pics/list.png" Width="16px" />
                                            </a>
                                        </td>
                                        <td class="auto-style38" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <a href="SubeGuncelleDetay.aspx?subeid=<%#Eval("sube_id")%>">
                                                <asp:Image ID="imgGuncelle" runat="server" Height="16px" ImageUrl="~/pics/edit.png" Width="16px" />
                                            </a>
                                        </td>
                                        <td class="auto-style39" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <a href='Subeler.aspx?subeid=<%#Eval("sube_id")%>&amp;islemsil=sil'>
                                                <asp:Image ID="imgSil" runat="server" Height="16px" ImageUrl="~/pics/delete.png" Width="16px" />
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
    <div class="baslik">
        <strong>ŞUBE EKLE</strong>
        <div style="width: 100px; float: right">
            <asp:Button ID="btnSubeBilgisiKapat" runat="server" Text="+" CssClass="buttonarti" OnClick="btnSubeBilgisiKapat_Click" />
        </div>
    </div>
    <div style="height: 30px"></div>
    <asp:Panel ID="Panel2" runat="server">
        <div style="height: 30px"></div>
        <div style="width: 1400px">
            <div style="width: 700px; margin: auto">
                <table class="auto-style10">
                    <tr>
                        <td class="auto-style17" colspan="2">
                            <asp:Image ID="imgBasarisiz" runat="server" Height="16px" ImageUrl="~/pics/warning.png" Width="16px" CssClass="eklemeResimleri" />
                            <asp:Image ID="imgBasarili" runat="server" Height="16px" ImageUrl="~/pics/approval.png" Width="16px" CssClass="eklemeResimleri" />
                            <asp:Label ID="lblMesaj" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17" colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style21"><strong>
                            <asp:Label ID="lblSubeAd" runat="server" CssClass="auto-style12" Text="Şube Adı :"></asp:Label>
                        </strong></td>
                        <td>
                            <asp:TextBox ID="tboxSubeAd" runat="server" CssClass="auto-style13" Width="200px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style21"><strong>
                            <asp:Label ID="lblSubeAdres" runat="server" CssClass="auto-style12" Text="Şube Adres :"></asp:Label>
                        </strong></td>
                        <td>
                            <asp:TextBox ID="tboxSubeAdres" runat="server" CssClass="auto-style13" Width="200px" Height="100px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style21"><strong>
                            <asp:Label ID="lblSubeTelNo" runat="server" CssClass="auto-style12" Text="Şube İletişim Numarası :"></asp:Label>
                        </strong></td>
                        <td>
                            <asp:TextBox ID="tboxSubeTelNo" runat="server" CssClass="auto-style13" Width="200px"></asp:TextBox>


                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style21">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style21">&nbsp;</td>
                        <td>
                            <table class="auto-style10">
                                <tr>
                                    <td class="auto-style14">
                                        <a href="Bedenler.aspx">
                                            <asp:Button ID="btnSubeEkle" runat="server" CssClass="btnEkle" Font-Bold="True" Text="EKLE" OnClick="btnSubeEkle_Click" /></a>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>

</asp:Content>



