<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="CapstoneProject.UserDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    Here we see the users account details

    <p>
        Roles:
        <asp:BulletedList ID="roleList" runat="server">

        </asp:BulletedList>
    </p>

    <p>
        shares accessible:
        <asp:Table ID="shareTable" runat="server">

        </asp:Table>
    </p>

    <p>
        group membership:
        <asp:BulletedList ID="membershipList" runat="server">

        </asp:BulletedList>
    </p>


    <asp:Label ID="display1" runat="server"></asp:Label>
    <asp:Label ID="display2" runat="server"></asp:Label>


</asp:Content>
