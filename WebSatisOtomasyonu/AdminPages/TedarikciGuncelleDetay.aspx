﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/users.Master" AutoEventWireup="true" CodeBehind="TedarikciGuncelleDetay.aspx.cs" Inherits="WebSatisOtomasyonu.UserPage.TedarikciGuncelleDetay" %>
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

        .auto-style11 {
            color: #FFFFFF;
            font-size: 20px;
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
            width: 525px;
            text-align: right;
        }
    .auto-style12 {
        text-align: center;
    }
    .auto-style13 {
        color: #FFFFFF;
        font-size: large;
    }
    .auto-style14 {
        border-radius: 20px;
        background-color: orange;
        border-color: #FFFFFF;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="baslik">
        <strong>TEDARİKÇİ BİLGİSİ GÜNCELLE</strong>
        <div style="width: 100px; float: right">
        </div>
        <asp:Label ID="lblOturum" runat="server" Visible="False"></asp:Label>
    </div>
    <div style="height: 70px"></div>
    <div style="height:25px; background-color: #808080; border-radius: 20px; margin:auto; width:1050px" class="auto-style12"><strong>
        <asp:Image ID="imgUyari" runat="server" Height="16px" ImageUrl="~/pics/warningYellow.png" Width="16px" />
        &nbsp;<asp:Label ID="lblUyari" runat="server" CssClass="auto-style13" Text="Güncelleme İşlemi Yapıldıktan Sonra Kategoriler Sayfasına Yönlendirileceksiniz..."></asp:Label>
        </strong>
    </div>
    <div style="height: 20px"></div>
    <div style="height: auto">
        <div style="width:1050px; margin:auto; height:500px;">
            <table class="auto-style10">
                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="lblTedarikciAd" runat="server" Text="Tedarikçi Ad :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tboxTedarikciAd" runat="server" TextMode="MultiLine" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="lblAdres" runat="server" Text="Adres :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tboxAdres" runat="server" Height="100px" TextMode="MultiLine" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        <asp:Label ID="lbliletisimNo" runat="server" Text="İletişim Numarası :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tboxTelNo" runat="server" MaxLength="11" TextMode="Phone" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnGuncelle" runat="server" Text="GÜNCELLE" OnClick="btnGuncelle_Click" CssClass="auto-style14" Height="30px" Width="132px" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
