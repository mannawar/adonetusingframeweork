<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sqltransactions.aspx.cs" Inherits="webappsqldatareader.Sqltransactions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="font-family: Arial">
<table border="1" style="background: brown; color: White">
    <tr>
        <td>
            <b>Account Number </b>
        </td>
        <td>
            <asp:Label ID="lblAccountNumber1" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblAccountNumber2" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <b>Customer Name </b>
        </td>
        <td>
            <asp:Label ID="lblName1" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblName2" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <b>Balance </b>
        </td>
        <td>
            <asp:Label ID="lblBalance1" runat="server"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblBalance2" runat="server"></asp:Label>
        </td>
    </tr>
</table>
<br />
<asp:Button ID="btnTransfer" runat="server"
            Text="Transfer $10 from Account A1 to Account A2"
            OnClick="btnTransfer_Click" />
<br />
<br />
<asp:Label ID="lblMessage" runat="server" Font-Bold="true"></asp:Label>
</div>
</asp:Content>
