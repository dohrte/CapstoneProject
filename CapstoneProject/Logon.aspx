<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="CapstoneProject.Logon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel BackColor="#FFCC00" Height="70px" runat="server" Bordercolor="#FFCC00" BorderStyle="Solid" HorizontalAlign="Right">
        <asp:Label ID="namelabel" runat="server" Font-Size="XX-Large">UTS Web Application</asp:Label> <br/>
        <asp:Label ID="secondname" runat="server" Font-Size="Large" ForeColor="Black">Share Manager</asp:Label>
    </asp:Panel>
    <asp:Panel BackColor="Black" BorderColor="Black" BorderStyle="Solid" Height="10px" runat="server"></asp:Panel>
    <asp:Panel BackColor="#CCCCCC" runat="server">
     <asp:Label ID="Label2" Runat=server >Username:</asp:Label>
    <asp:TextBox ID=txtUsername Runat=server ></asp:TextBox><br>
    <asp:Label ID="Label3" Runat=server >Password:</asp:Label>
    <asp:TextBox ID="txtPassword" Runat=server TextMode=Password></asp:TextBox><br>
    <asp:Button ID="request" runat="server" align="right" Text="Request an account" Width="137px"></asp:button>
    <asp:Button ID="btnLogin" Runat=server Text="Login" OnClick="Login_Click"></asp:Button>
    <br>
    <asp:Label ID="errorLabel" Runat=server ForeColor=#ff3300></asp:Label><br>
    <asp:CheckBox ID=chkPersist Runat=server Text="Persist Cookie" />
    </asp:Button><br></asp:Panel>
</asp:Content>
