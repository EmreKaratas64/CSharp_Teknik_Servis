<%@ Page Title="" Language="C#" MasterPageFile="~/Kullanici.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Teknik_Servis_Web.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .newStyle1 {
            font-family: "Century Gothic";
        }

        body{
            font-family: "Century Gothic";
        }

        .search-button{
            float: left;
            background: #2196F3;
            color: white;
            font-size: 14px;
            border: 1px solid grey;
            border-left: none;
            cursor: pointer;
            width: 78px;
            height: 26px;
            border-radius: 15px;
        }
        .search-button:hover{
            background: #0b7dda;
        }


    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="Label1" runat="server" Text="Ürün Seri No" Font-Bold="true" CssClass="newStyle1"></asp:Label>

    <br />
    <br />

    <asp:TextBox ID="TextBox1" runat="server" Height="28px" Width="400px" placeholder="Seri no giriniz..."></asp:TextBox>

    <br />
    <br />


    <asp:Button ID="Button1" runat="server" Text="Ara" class="search-button" OnClick="Button1_Click"/>


    <br />
    <br />

    <table class="table table-bordered"; style="margin-top: 15px">

        <tr>
            <th>TAKİP ID</th>
            <th>AÇIKLAMA</th>
            <th>TARİH</th>
            <th>ÜRÜN SERİ NO</th>
        </tr>

        <asp:Repeater ID="Repeater1" runat="server">

            <ItemTemplate>
            <tr>
                <td><%# Eval("TAKIPID") %></td>
                <td><%# Eval("ACIKLAMA") %></td>
                <td><%# Eval("TARIH") %></td>
                <td><%# Eval("SERINO") %></td>
            </tr>

                </ItemTemplate>

        </asp:Repeater>

    </table>


</asp:Content>
