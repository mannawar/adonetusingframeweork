<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sqlcommandbuilder.aspx.cs" Inherits="webappsqldatareader.Sqlcommandbuilder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="font-family: Arial">
        <table border="1">
            <tr>
                <td>Student ID
                </td>
                <td>
                    <asp:TextBox ID="txtStudentID" runat="server"></asp:TextBox>
                    <asp:Button ID="btnGetStudent" runat="server" Text="Load"
                        OnClick="btnGetStudent_Click" />
                </td>
            </tr>
            <tr>
                <td>Name
                </td>
                <td>
                    <asp:TextBox ID="txtStudentName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Gender
                </td>
                <td>
                    <asp:DropDownList ID="ddlGender" runat="server">
                        <asp:ListItem Text="Select Gender" Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Male" Value="Male"></asp:ListItem>

                        <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Total Marks
                </td>
                <td>
                    <asp:TextBox ID="txtTotalMarks" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnUpdate" runat="server" Text="Update"
                        OnClick="btnUpdate_Click" />
                    <asp:Label ID="lblStatus" runat="server" Font-Bold="true">
                    </asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td>
                    <b>Insert</b>
                </td>
                <td>
                    <asp:Label ID="lblInsert" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Update</b>
                </td>
                <td>
                    <asp:Label ID="lblUpdate" runat="server"></asp:Label>

                </td>
            </tr>
             <tr>
                <td>
                    <b>Delete</b>
                </td>
                <td>
                    <asp:Label ID="lblDelete" runat="server"></asp:Label>

                </td>
            </tr>
        </table>
    </div>
</asp:Content>
