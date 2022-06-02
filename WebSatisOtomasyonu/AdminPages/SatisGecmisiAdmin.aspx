<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/users.Master" AutoEventWireup="true" CodeBehind="SatisGecmisiAdmin.aspx.cs" Inherits="WebSatisOtomasyonu.AdminPages.SatisGecmisiAdmin" %>

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

        .tboxSearch {
            border-radius: 20px;
            height: 27px;
            overflow: hidden;
            text-align: center;
            vertical-align: top;
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

        .auto-style75 {
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            width: 85px;
        }

        .auto-style76 {
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
            width: 85px;
        }

        .auto-style77 {
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            width: 40px;
        }

        .auto-style78 {
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
            width: 40px;
        }

        .auto-style79 {
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            width: 101px;
        }

        .auto-style80 {
            width: 100%;
            height: 303px;
        }

        .auto-style81 {
            width: 934px;
        }

        .auto-style83 {
            height: 305px;
        }

        .auto-style84 {
            color: #FFFFFF;
        }

        .auto-style85 {
            text-align: right;
            font-family: Arial, Helvetica, sans-serif;
            width: 50px;
        }

        .auto-style86 {
            width: 650px;
            text-align: center;
        }
        .aralikButonu{
            width:250px;
            height:30px;
            border-radius:20px;
            background-color:mediumpurple;
            border:1px solid gray;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="baslik">
        <strong>lSATIŞ GEÇMİŞİ</strong>
        <asp:Label ID="lblOturum" runat="server" Visible="False"></asp:Label>
    </div>
    <div style="height: 400px">
        <div style="height: 20px"></div>
        <div style="height: 30px" class="auto-style1">
            <strong>
                <asp:Label ID="lblSube" runat="server" CssClass="auto-style73" Text="Şube Seçiniz : " Style="color: #FFFFFF; font-size: x-large"></asp:Label>
            </strong>
            <asp:DropDownList ID="ddListSubeler" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddListSubeler_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div style="height: 30px" class="auto-style1">

            <asp:Button CssClass="aralikButonu" ID="btnAralik" runat="server" Text="Tarih Aralığı Seçmek İçin Tıklayınız..." OnClick="btnAralik_Click" />

        </div>
        <div style="margin-left: 50px; margin-right: 50px;" class="auto-style83">

            <table class="auto-style80">
                <tr>
                    <td class="auto-style81"><strong>
                        <asp:Label ID="lblFiltre" runat="server" CssClass="auto-style73" Text="Filtre :" Style="color: #FFFFFF; font-size: x-large"></asp:Label>
                    </strong>
                        <asp:DropDownList ID="ddListFiltre" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:TextBox ID="tboxSearch" runat="server" CssClass="tboxSearch" TextMode="Search" Width="95px"></asp:TextBox>
                        <asp:Button ID="btnAra" runat="server" CssClass="btnEkle" Text="Ara..." OnClick="btnAra_Click" />
                        &nbsp;&nbsp;</td>
                    <td class="auto-style81">
                        <span class="auto-style84"><strong>
                            <asp:Label ID="lblBaslangic" runat="server" Text="Başlangıç Tarihi :"></asp:Label>
                        </strong></span>
                        <asp:Calendar ID="clnTakvimBaslangic" runat="server" Width="350px" OnSelectionChanged="clnTakvimBaslangic_SelectionChanged" BackColor="White" BorderColor="Black" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth">
                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                            <DayStyle Width="14%" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#6699FF" ForeColor="White" />
                            <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                            <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                            <TodayDayStyle BackColor="#CCCC99" />
                        </asp:Calendar>
                    </td>
                    <td class="auto-style81">
                        <span class="auto-style84"><strong>
                            <asp:Label ID="lblBitis" runat="server" Text="Bitiş Tarihi :"></asp:Label>
                        </strong></span>
                        <asp:Calendar ID="clnTakvimBitis" runat="server" Width="350px" OnSelectionChanged="clnTakvimBitis_SelectionChanged" BackColor="White" BorderColor="Black" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth">
                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                            <DayStyle Width="14%" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#6699FF" ForeColor="White" />
                            <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                            <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                            <TodayDayStyle BackColor="#CCCC99" />
                        </asp:Calendar>
                    </td>
                    <td>
                        <span class="auto-style84"><strong>
                            <asp:Label ID="lblTarih" runat="server" Text="Tarih Seçiniz :"></asp:Label>
                        </strong></span>
                        <asp:Calendar ID="clnTakvim1" runat="server" Width="350px" OnSelectionChanged="clnTakvim1_SelectionChanged" BackColor="White" BorderColor="Black" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth">
                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                            <DayStyle Width="14%" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#6699FF" ForeColor="White" />
                            <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                            <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                            <TodayDayStyle BackColor="#CCCC99" />
                        </asp:Calendar>
                    </td>
                </tr>
            </table>
        </div>

        <br />
    </div>
    <asp:Panel ID="Panel1" runat="server" Height="100%">
        <div style="width: 1300px; margin: auto; height: 25px; background-color: #808080; border-radius: 20px;">
            <table class="auto-style6">
                <tr>
                    <td class="auto-style49" style="border-right-style: solid; border-right-width: thin; border-right-color: #FFFFFF"><strong>Ürün Kod</strong></td>
                    <td class="auto-style51" style="border-right-style: solid; border-right-width: thin; border-right-color: #FFFFFF"><strong>Ürün Ad</strong></td>
                    <td class="auto-style77" style="border-right-style: solid; border-right-width: thin; border-right-color: #FFFFFF"><strong>Adet</strong></td>
                    <td class="auto-style53" style="border-right-style: solid; border-right-width: thin; border-right-color: #FFFFFF"><strong>Cinsiyet</strong></td>
                    <td class="auto-style53" style="border-right-style: solid; border-right-width: thin; border-right-color: #FFFFFF"><strong>Renk</strong></td>
                    <td class="auto-style54" style="border-right-style: solid; border-right-width: thin; border-right-color: #FFFFFF"><strong>Beden</strong></td>
                    <td class="auto-style56" style="border-right-style: solid; border-right-width: thin; border-right-color: #FFFFFF"><strong>Kategori</strong></td>
                    <td class="auto-style54" style="border-right-style: solid; border-right-width: thin; border-right-color: #FFFFFF"><strong>Fiyat</strong></td>
                    <td class="auto-style75" style="border-right-style: solid; border-right-width: thin; border-right-color: #FFFFFF"><strong>Ödeme Şekli</strong></td>
                    <td class="auto-style75" style="border-right-style: solid; border-right-width: thin; border-right-color: #FFFFFF"><strong>Kasiyer Ad</strong></td>
                    <td class="auto-style75" style="border-right-style: solid; border-right-width: thin; border-right-color: #FFFFFF"><strong>Kasiyer Soyad</strong></td>
                    <td class="auto-style79"><strong>İşlem Tarihi</strong></td>
                </tr>
            </table>
        </div>
        <div style="width: 1300px; margin: auto">
            <asp:DataList ID="DataList1" runat="server" Width="1300px">
                <ItemTemplate>
                    <table class="auto-style45">
                        <tr>
                            <td class="auto-style47" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                <asp:Label ID="lblUrunKod" runat="server" CssClass="auto-style46" Text='<%# Eval("urun_kod") %>'></asp:Label>
                            </td>
                            <td class="auto-style48" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                <asp:Label ID="lblUrunAd" runat="server" CssClass="auto-style46" Text='<%# Eval("urun_ad") %>'></asp:Label>
                            </td>
                            <td class="auto-style78" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                <asp:Label ID="lblUrunAdet" runat="server" CssClass="auto-style46" Text='<%# Eval("urun_adet") %>'></asp:Label>
                            </td>
                            <td class="auto-style52" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                <asp:Label ID="lblCinsiyet" runat="server" CssClass="auto-style46" Text='<%# Eval("urun_cinsiyet") %>'></asp:Label>
                            </td>
                            <td class="auto-style52" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                <asp:Label ID="lblRenk" runat="server" CssClass="auto-style46" Text='<%# Eval("urun_renk") %>'></asp:Label>
                            </td>
                            <td class="auto-style55" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                <asp:Label ID="lblBeden" runat="server" CssClass="auto-style46" Text='<%# Eval("urun_beden") %>'></asp:Label>
                            </td>
                            <td class="auto-style57" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                <asp:Label ID="lblKategori" runat="server" CssClass="auto-style46" Text='<%# Eval("urun_kategori") %>'></asp:Label>
                            </td>
                            <td class="auto-style85" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                <asp:Label ID="lblFiyat" runat="server" CssClass="auto-style46" Text='<%# Eval("urun_tutar") %>'></asp:Label>
                                <span class="auto-style84">₺</span></td>
                            <td class="auto-style76" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                <asp:Label ID="lblOdeme" runat="server" CssClass="auto-style46" Text='<%# Eval("odeme_sekli") %>'></asp:Label>
                            </td>
                            <td class="auto-style76" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                <asp:Label ID="lblKasiyerAd" runat="server" CssClass="auto-style46" Text='<%# Eval("kasiyer_ad") %>'></asp:Label>
                            </td>
                            <td class="auto-style76" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                <asp:Label ID="lblKasiyerSoyad" runat="server" CssClass="auto-style46" Text='<%# Eval("kasiyer_soyad") %>'></asp:Label>
                            </td>
                            <td class="auto-style57" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                <asp:Label ID="lblIslemTarihi" runat="server" CssClass="auto-style46" Text='<%# Eval("islem_tarihi") %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>

        <div style="height: 50px"></div>
        <div style="margin-left: 50px; margin-right: 50px; background-color: #808080; border-radius: 20px;" class="auto-style74">
            <table class="auto-style45">
                <tr>
                    <td class="auto-style86"><strong>Satılan Toplam Ürün Adedi :
                        <asp:Label ID="lblToplamAdet" runat="server">0</asp:Label>
                    </strong></td>
                    <td class="auto-style1" style="border-right-style: solid; border-left-style: solid; border-left-width: thin; border-right-width: thin; border-right-color: #FFFFFF; border-left-color: #FFFFFF"><strong>Toplam Satış :
                        <asp:Label ID="lblToplamSatis" runat="server">0</asp:Label>
                        ₺</strong></td>
                </tr>
            </table>
        </div>
        <div style="height: 50px"></div>
    </asp:Panel>
</asp:Content>
