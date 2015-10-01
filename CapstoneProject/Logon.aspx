<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="CapstoneProject.Logon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:panel runat="server" BackColor="#FFCC00">
        <h1 class="text-right">UTS Web Application <br /> <small>Share Manager</small></h1><br />
    </asp:panel>
    <asp:Panel ID="panel1" BackColor="Black" runat="server"></asp:Panel>
    <asp:Panel BackColor="#CCCCCC" runat="server" style="text-align: center">
        <br />
     <asp:Label ID="Label2" Runat=server >Username: </asp:Label>
    <asp:TextBox ID=txtUsername Runat=server ></asp:TextBox><br>
    <asp:Label ID="Label3" Runat=server >Password: </asp:Label>
    <asp:TextBox ID="txtPassword" Runat=server TextMode=Password></asp:TextBox><br>
        <br>
        <asp:Button ID="btnLogin" Runat="server" class="btn btn-primary" OnClick="Login_Click" Text="Login" />
        <br />
        <br />
        <asp:Button ID="request" runat="server" Align="Right" class="btn btn-primary" OnClick="request_Click" Text="Request an account" />
        <br />
        <br>
        <asp:Label ID="errorLabel" Runat="server" ForeColor="#ff3300"></asp:Label>
        <br>
        </asp:button>
        <br>
        <br>
        <br>
        <br>
        <br></br>
        <br>
        <br></br>
        <br></br>
        <br></br>
        <br></br>
        </br>
        </br>
        </br>
        </br>
        </br>
        </br>
        </br>
        </br>
    </asp:Panel>
</asp:Content>
