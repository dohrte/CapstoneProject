<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CapstoneProject.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <%--<asp:Label ID="helloMsg" runat="server" />--%>

    <asp:Panel ID="msgOfTheDay" runat="server" />
    
    <div class="jumbotron main wh-transparent-background">
        <h2>You're In!</h2>
            <p>You have successfully signed into the application. You may select services on the left. Your user account can only see services you are authorized to utilize.</p>
            <p>Account permissions are granted by submiting an approved web form.</p>
    </div>
    
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


    <script>
        $('body').removeClass("master-body");
    </script>


</asp:Content>
