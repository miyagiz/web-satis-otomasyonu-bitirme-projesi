<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/users.Master" AutoEventWireup="true" CodeBehind="TedarikciSil.aspx.cs" Inherits="WebSatisOtomasyonu.UserPage.TedarikciSil" %>

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

        .auto-style15 {
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
            width: 280px;
        }

        .auto-style15 {
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
            width: 280px;
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
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
            width: 260px;
        }
        .auto-style20 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="baslik">
        <strong>TEDARİKÇİLER</strong>
        <div style="width: 100px; float: right">
            <asp:Button ID="btnTedarikcileriAc" runat="server" Text="+" CssClass="buttonarti" OnClick="btnTedarikcileriAc_Click" TabIndex="55" />
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
        <div style="height: 20px" class="auto-style20">
            <asp:Label ID="lblMesaj" runat="server" CssClass="auto-style9"></asp:Label>
        </div>
        <div style="height: 20px"></div>
        <div style="width: 1050px; margin: auto; height: 25px; background-color: #808080; border-radius: 20px;">
            <table class="auto-style6">
                <tr>
                    <td class="auto-style7" style="border-right-style: solid; border-right-width: medium; border-right-color: #FFFFFF"><strong>Tedarikçi</strong></td>
                    <td class="auto-style7" style="border-right-style: solid; border-right-width: medium; border-right-color: #FFFFFF"><strong>Adres</strong></td>
                    <td class="auto-style7" style="border-right-style: solid; border-right-width: medium; border-right-color: #FFFFFF"><strong>Telefon No</strong></td>
                    <td class="auto-style19" style="border-right-style: solid; border-right-width: medium; border-right-color: #FFFFFF"><strong>Ürün Adedi</strong></td>
                    <td class="auto-style19"><strong>Sil</strong></td>
                </tr>
            </table>
        </div>
        <div style="height: 100%">
            <div style="width: 1400px">
                <asp:DataList ID="dListTedarikciler" runat="server">
                    <ItemTemplate>
                        <div style="width: 1400px">
                            <div style="width: 1050px; margin: auto; height: 100%">
                                <table class="auto-style6">
                                    <tr>
                                        <td class="auto-style7" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <asp:Label ID="lblTedarikci" runat="server" CssClass="auto-style9" Text='<%# Eval("tedarikci_ad") %>'></asp:Label>
                                        </td>
                                        <td class="auto-style7" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <asp:Label ID="lblAdres" runat="server" CssClass="auto-style9" Text='<%# Eval("tedarikci_adres") %>'></asp:Label>
                                        </td>
                                        <td class="auto-style7" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <asp:Label ID="lblTelNo" runat="server" CssClass="auto-style9" Text='<%# Eval("tedarikci_telefon_no") %>'></asp:Label>
                                        </td>
                                        <td class="auto-style15" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <asp:Label ID="lblAdet" runat="server" CssClass="auto-style9" Text='<%# Eval("urun_adet") %>'></asp:Label>
                                        </td>
                                        <td class="auto-style15" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <a href="TedarikciSil.aspx?tedarikciid=<%#Eval("tedarikci_id")%>&islem=sil">
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
</asp:Content>
