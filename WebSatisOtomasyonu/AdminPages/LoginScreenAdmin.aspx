<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginScreenAdmin.aspx.cs" Inherits="WebSatisOtomasyonu.UserPage.LoginScreenAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="../Style/deneme.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }

        .auto-style2 {
            width: 100%;
        }

        .auto-style4 {
            color: #FFFFFF;
            font-size: large;
            font-family: Arial, Helvetica, sans-serif;
        }

        .auto-style5 {
            text-align: left;
        }

        .auto-style6 {
            text-align: right;
            width: 220px;
        }

        .auto-style7 {
            text-align: center;
            width: 250px;
        }

        .auto-style8 {
            font-size: x-large;
            color: #FFFFFF;
            font-family: Arial, Helvetica, sans-serif;
        }

        .buttonGiris {
            border-radius: 20px;
            background-color: #808080;
        }

        .auto-style11 {
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="height: 100%; width: 500px; margin: auto; margin-top: 200px; background-color: #191a27; border-radius: 25px">
                <div style="height: 30px"></div>
                <div class="auto-style1">
                    <asp:Image ID="imgLogo" runat="server" ImageUrl="~/pics/logo.png " Height="117px" />
                </div>
                <div style="height: 20px"></div>
                <div style="margin-top: 20px">

                    <table class="auto-style2" id="tableGiris">
                        <tr>
                            <td class="auto-style7" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF;">
                                <asp:Panel ID="pnlYonetici" runat="server" CssClass="auto-style11">
                                    <a href="LoginScreenAdmin.aspx?&islem=admingirisi">
                                        <asp:Label ID="lblYoneticiGirisi" runat="server" CssClass="auto-style8" Text="Yönetici Girişi"></asp:Label>
                                    </a>
                                </asp:Panel>

                            </td>
                            <td class="auto-style1" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                <asp:Panel ID="pnlKasiyer" runat="server" CssClass="auto-style11">
                                    <a href="LoginScreenAdmin.aspx?&islem=kasagirisi">
                                        <asp:Label ID="lblKasiyerGirisi" runat="server" CssClass="auto-style8" Text="Kasiyer Girişi"></asp:Label>
                                    </a>
                                </asp:Panel>

                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1" colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1" colspan="2">&nbsp;</td>
                        </tr>
                    </table>

                </div>
                <div style="height: 30px" class="auto-style1">
                    <asp:Label ID="lblUyari" runat="server" CssClass="auto-style4"></asp:Label>
                </div>
                <div>

                    <table class="auto-style2">
                        <tr>
                            <td class="auto-style6">
                                <asp:Label ID="lblKullaniciAdi" runat="server" CssClass="auto-style8" Text="Kullanıcı Adı :"></asp:Label>
                            </td>
                            <td class="auto-style5">
                                <asp:TextBox ID="tboxKullaniciAdi" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style6">
                                <asp:Label ID="lblSifre" runat="server" CssClass="auto-style8" Text="Şifre :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="tboxSifre" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style6">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1" colspan="2">
                                <asp:Button ID="btnGirisYap" runat="server" Text="Giriş Yap" OnClick="btnGirisYap_Click" CssClass="buttonGiris" Height="33px" Width="104px" Font-Bold="True" Font-Italic="True" Font-Size="12pt" />
                            </td>
                        </tr>
                    </table>

                </div>
                <div style="height: 30px"></div>
            </div>


        </div>
    </form>

    <script>
        function renkDegistir() {
            var element = document.getElementById("pnlYonetici");
            element.style.backgroundColor = "black";
        }
    </script>
</body>
</html>
