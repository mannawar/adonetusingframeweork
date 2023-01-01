<%@ Page Title="Sql Data Adapter" Language="C#" AutoEventWireup="true" 
  MasterPageFile="~/Site.Master"
  CodeBehind="Sqldataadapter.aspx.cs" Inherits="webappsqldatareader.Sqldataadapter" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Get Product" OnClick="Button1_Click"/><br />
    <asp:GridView ID="GridView" runat="server"></asp:GridView>
 
</asp:Content>
