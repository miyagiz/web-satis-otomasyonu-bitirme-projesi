<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/users.Master" AutoEventWireup="true" CodeBehind="Bedenler.aspx.cs" Inherits="WebSatisOtomasyonu.UserPage.Bedenler" %>

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

        .eklemeResimleri{
            line-height:30px;
            vertical-align:top;
        }
        .auto-style22 {
            width: 349px;
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style23 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="baslik">
        <strong>BEDENLER</strong>
        <div style="width: 100px; float: right">
            <asp:Button ID="btnBedenlerAc" runat="server" Text="+" CssClass="buttonarti" OnClick="btnBedenlerAc_Click" />
        </div>
        <asp:Label ID="lblOturum" runat="server" Visible="False"></asp:Label>
    </div>
    <div style="height: 30px"></div>
    <div style="height: 30px" class="auto-style23">
                            <asp:Label ID="lblUyari" runat="server" CssClass="auto-style9"></asp:Label>
                        </div>
    <asp:Panel ID="Panel1" runat="server" Height="100%">
        <div style="width: 1050px; margin: auto; height: 25px; background-color: #808080; border-radius: 20px;">
            <table class="auto-style6">
                <tr>
                    <td class="auto-style7" style="border-right-style: solid; border-right-width: medium; border-right-color: #FFFFFF"><strong>Beden Kısaltma</strong></td>
                    <td class="auto-style22" style="border-right-style: solid; border-right-width: medium; border-right-color: #FFFFFF"><strong>Beden</strong></td>
                    <td class="auto-style1"><strong>Sil</strong></td>
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
                                        <td class="auto-style7" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <asp:Label ID="lblBedenKisaltma" runat="server" CssClass="auto-style9" Text='<%# Eval("beden_kisaltma") %>'></asp:Label>
                                        </td>
                                        <td class="auto-style7" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <asp:Label ID="lblBeden" runat="server" CssClass="auto-style9" Text='<%# Eval("beden_metin") %>'></asp:Label>
                                        </td>
                                        <td class="auto-style1" style="border-bottom-style: solid; border-bottom-width: thin; border-bottom-color: #FFFFFF">
                                            <a href="Bedenler.aspx?bedenid=<%#Eval("beden_id")%>&islemsil=sil">
                                                <asp:Image ID="imgBedenSil" runat="server" Height="16px" ImageUrl="~/pics/delete.png" Width="16px" />
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
        <strong>BEDEN EKLE</strong>
        <div style="width: 100px; float: right">
            <asp:Button ID="btnBedenEkleAc" runat="server" Text="+" CssClass="buttonarti" OnClick="btnBedenEkleAc_Click" />
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
                            <asp:Image ID="imgBasarisiz" runat="server" Height="16px" ImageUrl="~/pics/warning.png" Width="16px" CssClass="eklemeResimleri"/>
                            <asp:Image ID="imgBasarili" runat="server" Height="16px" ImageUrl="~/pics/approval.png" Width="16px" CssClass="eklemeResimleri"/>
                            <asp:Label ID="lblMesaj" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17" colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style21"><strong>
                            <asp:Label ID="lblBedenGrup" runat="server" CssClass="auto-style12" Text="Beden Grubu :"></asp:Label>
                            </strong></td>
                        <td>
                            <asp:DropDownList ID="ddListBedenGrup" runat="server" Width="150px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style21"><strong>
                            <asp:Label ID="lblBedenKisaltma0" runat="server" CssClass="auto-style12" Text="Beden Kısaltma :"></asp:Label>
                            </strong></td>
                        <td>
                            <asp:TextBox ID="tboxBedenKisaltma" runat="server" CssClass="auto-style13" Width="125px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style21"><strong>
                            <asp:Label ID="lblBeden" runat="server" CssClass="auto-style12" Text="Beden :"></asp:Label>
                        </strong></td>
                        <td>
                            <asp:TextBox ID="tboxBeden" runat="server" CssClass="auto-style13" Width="125px"></asp:TextBox>
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
                                            <asp:Button ID="btnBedenEkle" runat="server" CssClass="btnEkle" Font-Bold="True" Text="EKLE" OnClick="btnBedenEkle_Click" /></a>
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
    <div class="baslik">
        <strong>BEDEN GRUBU EKLE</strong>
        <div style="width: 100px; float: right">
            <asp:Button ID="Button1" runat="server" Text="+" CssClass="buttonarti" OnClick="Button1_Click" />
        </div>
    </div>
    <div style="height: 30px"></div>
    <asp:Panel ID="Panel3" runat="server">
        <div style="height: 30px"></div>
        <div style="width: 1400px">
            <div style="width: 700px; margin: auto">
                <table class="auto-style10">
                    <tr>
                        <td class="auto-style17" colspan="2">
                            <asp:Image ID="Image1" runat="server" Height="16px" ImageUrl="~/pics/warning.png" Width="16px" CssClass="eklemeResimleri" Visible="False"/>
                            <asp:Image ID="Image2" runat="server" Height="16px" ImageUrl="~/pics/approval.png" Width="16px" CssClass="eklemeResimleri" Visible="False"/>
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style17" colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style21"><strong>
                            <asp:Label ID="Label3" runat="server" CssClass="auto-style12" Text="Beden Grubu Adı :"></asp:Label>
                            </strong></td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style13" Width="125px"></asp:TextBox>
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
                                            <asp:Button ID="btnBedenGrupEkle" runat="server" CssClass="btnEkle" Font-Bold="True" Text="EKLE" OnClick="btnBedenGrupEkle_Click" /></a>
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
