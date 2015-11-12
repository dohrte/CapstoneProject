<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="page1.aspx.cs" Inherits="CapstoneProject.page1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    your in page 1 

    this is for faculty only
    <br />
    <asp:TextBox ID="input" runat="server"></asp:TextBox>
        <asp:Button ID="submitBtn" runat="server" Text="submit" OnClick="submitBtn_Click" />
        <asp:Label ID="display" runat="server"></asp:Label>
</asp:Content>
