<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Disconnecteddataaccess.aspx.cs" Inherits="webappsqldatareader.Disconnecteddataaccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="font-family: Arial">
        <asp:Button ID="btnGetDataFromDB" runat="server" Text="Get Data from Database" 
            onclick="btnGetDataFromDB_Click" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"            
            DataKeyNames="ID" onrowediting="GridView1_RowEditing" 
            onrowcancelingedit="GridView1_RowCancelingEdit" 
            onrowdeleting="GridView1_RowDeleting" 
            onrowupdating="GridView1_RowUpdating">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" 
                    SortExpression="Gender" />
                <asp:BoundField DataField="TotalMarks" HeaderText="TotalMarks" 
                    SortExpression="TotalMarks" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnUpdateDatabaseTable" runat="server" 
            Text="Update Database Table" onclick="btnUpdateDatabaseTable_Click" />
            <asp:Label ID="lblStatus" runat="server"></asp:Label>
    </div>

</asp:Content>
