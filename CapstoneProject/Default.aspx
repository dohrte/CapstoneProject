<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CapstoneProject.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
  <asp:Label ID="helloMsg" runat="server" />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" CssClass="btn modal-gold" OnClick="Button1_Click" Text="Page1" />
    <br />
    <asp:Button ID="Button2" runat="server" CssClass="btn modal-gold" OnClick="Button2_Click" Text="Page2" />
    <br />
    <asp:Button ID="btnAdmin" runat="server" CssClass="btn modal-gold" OnClick="btnAdmin_Click" Text="Admin Page" />
    <br />
    <asp:Button ID="btnCreateComp" runat="server" CssClass="btn modal-gold" OnClick="btnCreateComp_Click" Text="Create Comp" />
    <br />
    <asp:Button ID="btnAcctDetail" runat="server" CssClass="btn modal-gold" Text="Acct Details" OnClick="btnAcctDetail_Click" />
</asp:Content>
