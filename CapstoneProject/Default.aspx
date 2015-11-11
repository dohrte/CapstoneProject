<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CapstoneProject.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:Label ID="helloMsg" runat="server" />

    <div class="container">
        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading grey-panel-heading">
                    <h2 class="panel-title">Message of The Day</h2>
                    <div class="panel-body white-pb">
                        <p><asp:Label ID="msgOfTheDay" runat="server" /></p>
                    </div>
                </div>
            </div>
        </div>


    </div>
    <div class="container">
        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h2 class="panel-title">
                        <a data-toggle="collapse" href="#collapse1">Faculty Services</a>
                    </h2>
                </div>
                <div id="collapse1" class="pannel-collapse collapse">
                    <div class="panel-body">
                        <div class="btn-group">
                            <asp:Button ID="Button1" runat="server" CssClass="btn modal-gold" OnClick="btnGrpManagement_Click" Text="View Groups" />
                            <asp:Button ID="ButtonFacWiki" runat="server" CssClass="btn modal-gold" OnClick="btnCreateComp_Click" Text="Faculty Wiki" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="container">
        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" href="#collapse2">Technician Services</a>
                    </h4>
                </div>
                <div id="collapse2" class="pannel-collapse collapse">
                    <div class="panel-body">
                        <div class="btn-group">
                            <asp:Button ID="Button2" runat="server" CssClass="btn modal-gold" OnClick="Button2_Click" Text="Manage Groups" />
                            <asp:Button ID="btnCreateComp" runat="server" CssClass="btn modal-gold" OnClick="btnCreateComp_Click" Text="Create Comp" />
                            <asp:Button ID="ButtonTechWiki" runat="server" CssClass="btn modal-gold" OnClick="btnCreateComp_Click" Text="Technician Wiki" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="container">
        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title nick-panel-title">
                        <a data-toggle="collapse" href="#collapse3">Server Administration</a>
                    </h4>
                </div>
                <div id="collapse3" class="pannel-collapse collapse">
                    <div class="panel-body">
                        <div class="btn-group">
                            <asp:Button ID="btnAdmin" runat="server" CssClass="btn modal-gold" OnClick="btnAdmin_Click" Text="Admin Page" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <div class="container">
        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title nick-panel-title">
                        <a data-toggle="collapse" href="#collapse4">Account Details</a>
                    </h4>
                </div>
                <div id="collapse4" class="pannel-collapse collapse">
                    <div class="panel-body">
                        <div class="btn-group">
                            <asp:Button ID="Button4" runat="server" CssClass="btn modal-gold" Text="User Properties" OnClick="btnAcctDetail_Click" />
                            <asp:Button ID="Button3" runat="server" CssClass="btn modal-gold" Text="Page 1" OnClick="Button1_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>





</asp:Content>
