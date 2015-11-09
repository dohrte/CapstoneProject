﻿<%@ Page Title="" Language="C#" MasterPageFile="~/LogonMaster.Master" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="CapstoneProject.Logon" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scrptManager1" runat="server"></asp:ScriptManager>
    <h4>Welcome to the UTS Share Management Web Application</h4>
    <h5>Please login or create an account to begin</h5>

    <div id="myCarousel" class="carousel slide" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
            <li data-target="#myCarousel" data-slide-to="3"></li>
            <li data-target="#myCarousel" data-slide-to="4"></li>
            <li data-target="#myCarousel" data-slide-to="5"></li>
            <li data-target="#myCarousel" data-slide-to="6"></li>
        </ol>

        <!-- Wrapper for slides -->
        <div class="carousel-inner" role="listbox">
            <div class="item">	<img src="images/comp-server-1.jpg"  alt="comps1" class="img"/>	</div>
            <div class="item">  <img src="images/comp-server-2.jpg" alt="comps2" class="img"/>   </div>
            <div class="item active">   <img src="images/computers.jpg" alt="Main"  class="img"/>        </div>
	        <div class="item">	<img src="images/iteration1.png" alt="it1" class="img"/>	  </div>
			<div class="item">	<img src="images/iteration2.png" alt="it2" class="img"/>	  </div>
			<div class="item">	<img src="images/iteration3.png" alt="it3" class="img"/>	  </div>
            <div class="item">	<img src="images/iteration4.jpg" alt="it4" class="img"/>	  </div>
            <div class="item">  <img src="images/iteration5.png" alt="it5" class="img"/>      </div>
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

    <div id="loginPage" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="logonUpdatePanel" runat="server">
                <ContentTemplate>
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header modal-black">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h3 class="modal-title">Login to account</h3>
                        </div>
                        <div class="modal-body modal-gold">
                            <asp:Panel ID="logonInputPanel" runat="server" DefaultButton="btnLogin">
                                <div class="form-group">
                                    <label class="control-label">User Name</label>
                                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control input-md" placeholder="User Name"></asp:TextBox>
                                    <label class="control-label" for="passwordBox">Password</label>
                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control input-md" placeholder="Password"></asp:TextBox>
                                </div>
                            </asp:Panel>
                        </div>
                        <div class="modal-footer modal-black">
                            <asp:Button ID="btnLogin" OnClick="Login_Click" CssClass="btn btn-success" data-toggle="label" data-target="#errorLabel" Text="Login" runat="server"></asp:Button>
                            <asp:Label ID="errorLabel" CssClass="label" Text="" runat="server"></asp:Label>
                            <asp:Button ID="btnCloselogin" CssClass="btn btn-default" data-dismiss="modal" Text="close" runat="server"></asp:Button>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <!-- Close light panel-->
    <div id="forgotPage" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content modal-black">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h3 class="modal-title">Reset Password</h3>
                </div>
                <div class="modal-body modal-gold">
                    <div class="form-group">
                        <input type="text" class="form-control" placeholder="User Name" />
                    </div>
                    <div class="form-group">
                        <input type="email" class="form-control" placeholder="Email" />
                    </div>
                </div>
                <div class="modal-footer modal-black">
                    <button type="button" class="btn btn-success">Submit</button>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>
    <%--</asp:Panel>--%>
    <asp:Panel ID="pnl3" runat="server" CssClass="panel color-black" HorizontalAlign="center">
        <h4>About</h4>
        <h5>Made for Senior Capstone Project</h5>
        <h6>Eric Doherty, Sam Wright, Nick LaForge, Mark Darga</h6>
    </asp:Panel>
</asp:Content>
