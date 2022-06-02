<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/users.Master" AutoEventWireup="true" CodeBehind="Renkler.aspx.cs" Inherits="WebSatisOtomasyonu.UserPage.Renkler" %>

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

        .auto-style15 {
            font-family: Arial, Helvetica, sans-serif;
            text-align: center;
            width: 600px;
        }

        .auto-style17 {
            color: #FFFFFF;
            font-size: large;
            text-align: center;
        }

        .eklemeResimleri {
            line-height: 30px;
            vertical-align: top;
        }
        .auto-style18 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="baslik">
        <strong>RENKLER</strong>
        <div style="width: 100px; float: right">
            <asp:Button ID="btnRenklerAc" runat="server" Text="+" CssClass="buttonarti" OnClick="btnRenklerAc_Click" />
        </div>
        <asp:Label ID="lblOturum" runat="server" Visible="False"></asp:Label>
    </div>
    <div style="height: 30px"></div>
    <div style="height: 30px" class="auto-style18">
                            <asp:Label ID="lblUyari" runat="server" CssClass="auto-style9"></asp:Label>
                        </div>
    <asp:Panel ID="Panel1" runat="server" Height="100%">
        <div style="width: 700px; margin: auto; height: 25px; background-color: #808080; border-radius: 20px;">
            <table class="auto-style6">
                <tr>
                    <td class="auto-style15" style="border-right-style: solid; border-right-width: medium; border-right-color: #FFFFFF"><strong>Renk</strong></td>
                    <td class="auto-style1"><strong>Sil</strong></td>
                </tr>
            </table>
        </div>
        <div style="height: 100%">

            <div style="width: 1400px">
                <asp:DataList ID="DataList1" runat="server">
                    <ItemTemplate>
                        <div style="width: 1400px">
                            <div style="width: 700px; margin: auto; height: 100%">
                                <table class="auto-style6">
                                    <tr>
                                        <td class="auto-style15" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <asp:Label ID="lblRenk" runat="server" CssClass="auto-style9" Text='<%# Eval("renk_metin") %>'></asp:Label>
                                        </td>
                                        <td class="auto-style1" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <a href="Renkler.aspx?renkid=<%#Eval("renk_id")%>&islem=sil">
                                                <asp:Image ID="imgRenkSil" runat="server" Height="16px" ImageUrl="~/pics/delete.png" Width="16px" /></a>
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
        <strong>RENK EKLE</strong>
        <div style="width: 100px; float: right">
            <asp:Button ID="btnRenkEkleAc" runat="server" Text="+" CssClass="buttonarti" OnClick="btnRenkEkleAc_Click" />
        </div>
    </div>
    
    <asp:Panel ID="Panel2" runat="server">
        <div style="height: 50px"></div>
        <div style="width: 1400px">
            <div style="width: 700px; margin: auto">
                <table class="auto-style10">
                    <tr>
                        <td class="auto-style17" colspan="2">
                            <asp:Image ID="imgBasarisiz" runat="server" CssClass="eklemeResimleri" Height="16px" ImageUrl="~/pics/warning.png" Width="16px" />
                            <asp:Image ID="imgBasarili" runat="server" CssClass="eklemeResimleri" Height="16px" ImageUrl="~/pics/approval.png" Width="16px" />
                            <asp:Label ID="lblMesaj" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style11"><strong>
                            <asp:Label ID="lblRenkAd" runat="server" CssClass="auto-style12" Text="Renk Ad :"></asp:Label>
                        </strong></td>
                        <td>
                            <asp:TextBox ID="tboxRenkAd" runat="server" CssClass="auto-style13" Width="125px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style11">&nbsp;</td>
                        <td>
                            <table class="auto-style10">
                                <tr>
                                    <td class="auto-style14">
                                        <asp:Button ID="btnEkle" runat="server" CssClass="btnEkle" Font-Bold="True" Text="EKLE" OnClick="btnEkle_Click" />
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
