<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CapstoneProject.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <%--<asp:Label ID="helloMsg" runat="server" />--%>

    <asp:Panel ID="msgOfTheDay" runat="server" />

    <%-- <asp:Button ID="Button1" runat="server" CssClass="btn modal-gold" OnClick="btnGrpManagement_Click" Text="View Groups" />
    <asp:Button ID="ButtonFacWiki" runat="server" CssClass="btn modal-gold" OnClick="btnCreateComp_Click" Text="Faculty Wiki" />
    <asp:Button ID="Button2" runat="server" CssClass="btn modal-gold" OnClick="Button2_Click" Text="Manage Groups" />
    <asp:Button ID="btnCreateComp" runat="server" CssClass="btn modal-gold" OnClick="btnCreateComp_Click" Text="Create Comp" />
    <asp:Button ID="ButtonTechWiki" runat="server" CssClass="btn modal-gold" OnClick="btnCreateComp_Click" Text="Technician Wiki" />
    <asp:Button ID="Button4" runat="server" CssClass="btn modal-gold" Text="User Properties" OnClick="btnAcctDetail_Click" />
    <asp:Button ID="Button3" runat="server" CssClass="btn modal-gold" Text="Page 1" OnClick="Button1_Click" />
    <asp:Button ID="btnAdmin" runat="server" CssClass="btn modal-gold" OnClick="btnAdmin_Click" Text="Admin Page" />
    --%>


    <div id="myCarousel" class="carousel slide" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
            <li data-target="#myCarousel" data-slide-to="3"></li>
            <%--<li data-target="#myCarousel" data-slide-to="4"></li>
            <li data-target="#myCarousel" data-slide-to="5"></li>
            <li data-target="#myCarousel" data-slide-to="6"></li>--%>
        </ol>

        <!-- Wrapper for slides -->
        <div class="carousel-inner" role="listbox">
            <div class="item">
                <img src="images/tower-sky.jpg" class="img"/>
            </div>
            <div class="item">
                <img src="images/comp-server-2.jpg" alt="comps2" class="img" />
            </div>
            <div class="item active">
                <img src="images/computers.jpg" alt="Main" class="img" />
            </div>
            <div class="item">
                <img src="images/Meadow-Brook-Hall.jpg" class="img"/>
            </div>


        </div>

        <!-- Left and right controls -->
        <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>





</asp:Content>
