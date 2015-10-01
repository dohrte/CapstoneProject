<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="CapstoneProject.Logon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label2" Runat="server" >Username:</asp:Label>
    <asp:TextBox ID="txtUsername" Runat="server" ></asp:TextBox><br>
    <asp:Label ID="Label3" Runat="server" >Password:</asp:Label>
    <asp:TextBox ID="txtPassword" Runat="server" TextMode="Password"></asp:TextBox><br>
    <asp:Button ID="btnLogin" Runat="server" Text="Login" OnClick="Login_Click" ></asp:Button><br>
    <asp:Label ID="errorLabel" Runat="server" ForeColor="#ff3300"></asp:Label><br>
    <asp:Button ID="btnRequestAccount" runat="server" Text="Request Account" OnClick="btnRequestAccount_Click" />
</asp:Content>
