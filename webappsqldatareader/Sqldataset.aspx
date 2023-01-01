<%@ Page Title="Sql DataSet" Language="C#" AutoEventWireup="true" 
  MasterPageFile="~/Site.Master"
  CodeBehind="Sqldataset.aspx.cs" Inherits="webappsqldatareader.Sqldataset" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <br />
        <asp:GridView ID="ProductGridView" runat="server"></asp:GridView>
        <br />
        <asp:GridView ID="ProductCategoryGridView" runat="server"></asp:GridView>
</asp:Content>
