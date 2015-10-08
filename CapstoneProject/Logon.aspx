<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="CapstoneProject.Logon" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel id="pnl1" CssClass="panel color-gold" runat="server" HorizontalAlign="Center">
        <asp:button ID="btnLogin" runat="server" cssclass="btn modal-gold btn-lg" data-toggle="modal" data-target="#loginPage" Text="Login"></asp:button>
        <asp:button id="btnForgot" runat="server" cssclass="btn modal-gold btn-lg" data-toggle="modal" data-target="#forgotPage" Text="Forgot Password"></asp:button>
        <asp:button id="btnRequest" runat="server" cssclass="btn modal-gold btn-lg" data-toggle="modal" data-target="#requestPage" Text="New Account"></asp:button>
    </asp:Panel>
    <asp:Panel ID="pnl2" CssClass="panel color-light" runat="server" HorizontalAlign="Center">
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
                <div class="item">	<img src="enter.jpg"  alt="Entrance"/>	</div>
                <div class="item">  <img src="bridge.png" alt="Bridge"/>   </div>
                <div class="item active">   <img src="computers.jpg" alt="Main"/>        </div>
				<div class="item">	<img src="Aerial.jpg" alt="Sky"/>	  </div>
				<div class="item">	<img src="iteration1.png" alt="Sky"/>	  </div>
				<div class="item">	<img src="iteration2.png" alt="Sky"/>	  </div>
				<div class="item">	<img src="iteration3.png" alt="Sky"/>	  </div>
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
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header modal-black">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h3 class="modal-title">Login to account</h3>
                    </div>
                    <div class="modal-body modal-gold">
                            <div class="form-group">
                                <label class="control-label">User Name</label>
                                <input id="userNameBox" name="userNameBox" type="text" placeholder="User Name" class="form-control input-md" required="" />
                                <label class="control-label" for="passwordBox">Password</label>
                                <input id="passwordBox" name="passwordBox" type="text" placeholder="Password" class="form-control input-md" required="" />
                            </div>
                    </div>
                    <div class="modal-footer modal-black">
                        <asp:button id="btnLoginlogin" cssclass="btn btn-success" data-toggle="label" data-target="#errorLabel" Text="Login" runat="server"></asp:button>
                        <asp:label id="errorLabel" cssclass="label" Text="eror" runat="server"></asp:label>
                        <asp:button id="btnCloselogin" cssclass="btn btn-default" data-dismiss="modal" Text="close" runat="server"></asp:button>
                    </div>
                </div>

            </div>
        </div> <!-- Close light panel-->
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
                                <input type="text" class="form-control" placeholder="User Name"/>
                            </div>
                            <div class="form-group">
                                <input type="email" class="form-control" placeholder="Email"/>
                            </div>
                    </div>
                    <div class="modal-footer modal-black">
                        <button type="button" class="btn btn-success" >Submit</button>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>

            </div>
        </div>
     </asp:Panel>
    <asp:Panel ID="pnl3" runat="server" cssclass="panel color-black" HorizontalAlign="center">
        <h4>About</h4><h5>Made for Senior Capstone Project</h5><h6> Eric Doherty, Sam Wright, Nick LaForge, Mark Darga</h6>
    </asp:Panel>
</asp:Content>
