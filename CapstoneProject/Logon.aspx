<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="CapstoneProject.Logon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" BackColor="#FFCC00">
        <h1 class="text-right">UTS Web Application
            <br />
            <small>Share Manager</small></h1>
        <br />
    </asp:Panel>
    <asp:Panel ID="panel1" BackColor="Black" runat="server"></asp:Panel>
    <asp:Panel BackColor="#CCCCCC" runat="server" Style="text-align: center">
        <br />
        <asp:Label ID="Label2" runat="server">Username:</asp:Label>
        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label3" runat="server">Password:</asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox><br />
        <br />
            <asp:Button ID="btnLogin" runat="server" class="btn btn-primary" OnClick="Login_Click" Text="Login" />
            <br />
            <br />
            <asp:Button ID="btnRequestAccount" runat="server" Align="Right" class="btn btn-primary" OnClick="btnRequestAccount_Click" Text="Request an account" />
            <br />
            <br />
                <asp:Label ID="errorLabel" runat="server" ForeColor="#ff3300"></asp:Label>
    </asp:Panel>



<%--    <asp:Label ID="Label2" Runat="server" >Username:</asp:Label>
    <asp:TextBox ID="txtUsername" Runat="server" ></asp:TextBox><br>
    <asp:Label ID="Label3" Runat="server" >Password:</asp:Label>
    <asp:TextBox ID="txtPassword" Runat="server" TextMode="Password"></asp:TextBox><br>
    <asp:Button ID="btnLogin" Runat="server" Text="Login" OnClick="Login_Click" ></asp:Button><br>
    <asp:Label ID="errorLabel" Runat="server" ForeColor="#ff3300"></asp:Label><br>
    <asp:Button ID="btnRequestAccount" runat="server" Text="Request Account" OnClick="btnRequestAccount_Click" />--%>
</asp:Content>
