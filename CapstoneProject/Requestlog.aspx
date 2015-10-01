<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="Requestlog.aspx.cs" Inherits="CapstoneProject.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID ="logoP" Runat="server" BackColor="#FFCC00" Height="86px" HorizontalAlign="Right">
    <asp:Label ID ="title" Runat="server" Font-Size="XX-Large">UTS Web Application</asp:Label><br />
    <asp:Label ID ="Name" Runat="server" Font-Size="X-Large">Share Manager</asp:Label>
    </asp:Panel>
    <asp:Panel ID ="panel2" Height="20px" BackColor="black" Runat="server" BorderColor="Black"></asp:Panel><br />
    <asp:Label ID="label1" runat="server">First Name: </asp:Label>
    <asp:textbox ID="fName" runat="server" ></asp:textbox> <br />
    <asp:Label ID="label2" runat="server" >Last Name: </asp:Label>
    <asp:TextBox ID="lName" runat="server"></asp:TextBox><br /><br />
    <asp:Label ID ="label3" runat="server">Email : </asp:Label>
    <asp:textbox ID="Email" runat="server"></asp:textbox><br />
    <asp:Label ID="label4" runat="server">confirm</asp:Label>
    <asp:TextBox ID="cEmail" runat="server"></asp:TextBox><br>
    <asp:Label ID="RerrorLabel" runat="server" ForeColor="#ff3300"></asp:Label><br>
    <asp:Button ID="newAccountBtn" runat="server" Text="Register" OnClick="newAccountBtn_Click" >
    </asp:Button>
</asp:Content>
