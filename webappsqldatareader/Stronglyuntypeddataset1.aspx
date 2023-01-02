<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Stronglyuntypeddataset1.aspx.cs" Inherits="webappsqldatareader.Stronglytypeddataset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" style="font-family:Arial">

    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click"/>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>

</asp:Content>
