<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/users.Master" AutoEventWireup="true" CodeBehind="Kasiyerler.aspx.cs" Inherits="WebSatisOtomasyonu.UserPage.Kasiyerler" %>

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
            width: 150px;
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
            width: 349px;
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style25 {
            width: 474px;
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style32 {
            width: 169px;
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style35 {
            width: 219px;
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style36 {
            width: 186px;
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style37 {
            width: 184px;
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style38 {
            width: 180px;
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<a href="Kasiyerler.aspx?kasiyerid=<%#Eval("kasiyer_id")%>&islemsil=sil">--%><%--<a href="Kasiyerler.aspx?kasiyerid=<%#Eval("kasiyer_id")%>&islemsil=sil">--%>

    <div class="baslik">
        <strong>KASİYER BİLGİSİ</strong>
        <div style="width: 100px; float: right">
            <asp:Button ID="btnKasiyerBilgisiAc" runat="server" Text="+" CssClass="buttonarti" OnClick="btnKasiyerBilgisiAc_Click" />
        </div>
        <asp:Label ID="lblOturum" runat="server" Visible="False"></asp:Label>
    </div>
    <div style="height: 30px"></div>
    <asp:Panel ID="Panel1" runat="server" Height="100%">
        <div style="width: 1050px; margin: auto; height: 25px; background-color: #808080; border-radius: 20px;">
            <table class="auto-style6">
                <tr>
                    <td class="auto-style7" style="border-right-style: solid; border-right-width: medium; border-right-color: #FFFFFF"><strong>İsim</strong></td>
                    <td class="auto-style25" style="border-right-style: solid; border-right-width: medium; border-right-color: #FFFFFF"><strong>Bağlı Şube Ad</strong></td>
                    <td class="auto-style7" style="border-right-style: solid; border-right-width: medium; border-right-color: #FFFFFF"><strong>İletişim Numarası</strong></td>
                    <td class="auto-style7" style="border-right-style: solid; border-right-width: medium; border-right-color: #FFFFFF"><strong>Kullanıcı Adı</strong></td>
                    <td class="auto-style7" style="border-right-style: solid; border-right-width: medium; border-right-color: #FFFFFF"><strong>Güncelle</strong></td>
                    <td class="auto-style23"><strong>Sil</strong></td>
                </tr>
            </table>
        </div>
        <div style="height: 100%">
            <div style="width: 1400px">
                <asp:DataList ID="DataList1" runat="server" OnSelectedIndexChanged="DataList1_SelectedIndexChanged">
                    <ItemTemplate>
                        <div style="width: 1400px">
                            <div style="width: 1050px; margin: auto; height: 100%">
                                <table class="auto-style6">
                                    <tr>
                                        <td class="auto-style32" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <asp:Label ID="lblKasiyerAd" runat="server" CssClass="auto-style9" Text='<%# Eval("kasiyer_ad") %>'></asp:Label>
                                        </td>
                                        <td class="auto-style35" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <asp:Label ID="lblKasiyerBagliSube" runat="server" CssClass="auto-style9" Text='<%# Eval("sube_ad") %>'></asp:Label>
                                        </td>
                                        <td class="auto-style38" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <asp:Label ID="lblKasiyerTelNo" runat="server" CssClass="auto-style9" Text='<%# Eval("kasiyer_iletisim_no") %>'></asp:Label>
                                        </td>
                                        <td class="auto-style37" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <asp:Label ID="lblKullaniciAdi" runat="server" CssClass="auto-style9" Text='<%# Eval("kasiyer_kullanici_adi") %>'></asp:Label>
                                        </td>
                                        <td class="auto-style36" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <a href="KasiyerGuncelleDetay.aspx?kasiyerid=<%#Eval("kasiyer_id")%>">
                                                <asp:Image ID="imgKasiyerGuncelle" runat="server" Height="16px" ImageUrl="~/pics/edit.png" Width="16px" />
                                            </a>
                                        </td>
                                        <td class="auto-style1" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <a href="Kasiyerler.aspx?kasiyerid=<%#Eval("kasiyer_id")%>&islemsil=sil">
                                                <asp:Image ID="imgKasiyerSil" runat="server" Height="16px" ImageUrl="~/pics/delete.png" Width="16px" />
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
        <strong>KASİYER EKLE </strong>
        <div style="width: 100px; float: right">
            <strong>
                <asp:Button ID="btnBedenEkleAc" runat="server" Text="+" CssClass="buttonarti" />
            </strong>
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
                            <asp:Label ID="lblKasiyerAd" runat="server" CssClass="auto-style12" Text="Kasiyer Ad :"></asp:Label>
                        </strong></td>
                        <td>
                            <asp:TextBox ID="tboxKasiyerAd" runat="server" CssClass="auto-style13" Width="230px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style21"><strong>
                            <asp:Label ID="lblKasiyerSoyad" runat="server" CssClass="auto-style12" Text="Kasiyer Soyad :"></asp:Label>
                        </strong></td>
                        <td>
                            <asp:TextBox ID="tboxKasiyerSoyad" runat="server" CssClass="auto-style13" Width="230px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style21"><strong>
                            <asp:Label ID="lblBagliSubeAd" runat="server" CssClass="auto-style12" Text="Bağlı Şube Ad :"></asp:Label>
                        </strong></td>
                        <td>
                            <asp:DropDownList ID="ddListSubeler" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style21"><strong>
                            <asp:Label ID="lblTelNo" runat="server" CssClass="auto-style12" Text="İletişim Numarası :"></asp:Label>
                        </strong></td>
                        <td>
                            <asp:TextBox ID="tboxTelNo" runat="server" CssClass="auto-style13" Width="230px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style21"><strong>
                            <asp:Label ID="lblKullaniciAdi" runat="server" CssClass="auto-style12" Text="Kullanıcı Adı :"></asp:Label>
                        </strong></td>
                        <td>
                            <asp:TextBox ID="tboxKullaniciAdi" runat="server" CssClass="auto-style13" Width="230px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style21"><strong>
                            <asp:Label ID="lblSifre" runat="server" CssClass="auto-style12" Text="Şifre :"></asp:Label>
                        </strong></td>
                        <td>
                            <asp:TextBox ID="tboxSifre" runat="server" CssClass="auto-style13" Width="230px"></asp:TextBox>
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
                                            <asp:Button ID="btnKasiyerEkle" runat="server" CssClass="btnEkle" Font-Bold="True" Text="EKLE" OnClick="btnKasiyerEkle_Click" /></a>
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
    <div style="height: 50px"></div>
</asp:Content>
