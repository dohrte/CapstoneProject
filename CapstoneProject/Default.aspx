<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CapstoneProject.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel BackColor="#FFCC00" Height="70px" runat="server" Bordercolor="#FFCC00" BorderStyle="Solid" HorizontalAlign="Right">
        <asp:Label ID="namelabel" runat="server" Font-Size="XX-Large">UTS Web Application</asp:Label> <br/>
        <asp:Label ID="secondname" runat="server" Font-Size="Large" ForeColor="Black">Share Manager</asp:Label>
    </asp:Panel>
    <asp:Panel BackColor="Black" BorderColor="Black" BorderStyle="Solid" Height="10px" runat="server"></asp:Panel>
  <asp:Label ID="helloMsg" runat="server" />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Page1" />
    <br />
    <br />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Page2" />
</asp:Content>
