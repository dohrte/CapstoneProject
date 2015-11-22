<%@ Page Title="" Language="C#" MasterPageFile="~/LogonMaster.Master" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="CapstoneProject.Logon" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scrptManager1" runat="server"></asp:ScriptManager>
   

 
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
  
</asp:Content>
