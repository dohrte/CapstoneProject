<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="GroupManagment.aspx.cs" Inherits="CapstoneProject.GroupManagment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <div class="col-md-6">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Groups Managed</h3>
            </div>
            <div class="panel-body">
                <asp:UpdatePanel ID="gUpdatePanel" runat="server">
                    <ContentTemplate>
                        <asp:ListBox ID="groupsListBox" runat="server" OnSelectedIndexChanged="groupsListBox_SelectedIndexChanged" OnInit="groupsListBox_Init" AutoPostBack="True"></asp:ListBox>
                    </ContentTemplate>

                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <div class="col-md-6">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title">Group Details</h3>
            </div>
            <div class="panel-body">
                <asp:UpdatePanel ID="addUser" runat="server">
                    <ContentTemplate>
                        Enter userid to add to access group:<br />
                        <asp:TextBox ID="addUserID_textBox" runat="server" placeholder="Userid to add" Width="208px" />
                        <asp:RequiredFieldValidator ID="txtUsernameValidator"
                            runat="server"
                            ControlToValidate="addUserID_textBox"
                            ErrorMessage="Please enter a username."
                            ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Button ID="adUser_btn" runat="server" Text="Submit" OnClick="adUser_btn_Click" />
                        <asp:Label ID="addUser_Error" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                
                <asp:UpdatePanel ID="manageDetail" runat="server">
                    <ContentTemplate>
                        Shares acessible:
                            <asp:Label ID="sharesAccesible" runat="server"></asp:Label>
                        <br />
                        Group Members:
           <%-- <asp:ListBox ID="memeberListBox" runat="server"></asp:ListBox>--%>
                        <asp:ListView ID="memberListView" runat="server">
                            <LayoutTemplate>
                                <table class="table">
                                    <tr>
                                        <th>Name</th>
                                        <th>remove?</th>
                                    </tr>
                                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("Name") %></td>
                                    <td>
                                        <asp:LinkButton ID="btnRemoveUser" runat="server" CommandName="Remove" CommandArgument='<%#Eval("Name") %>' OnClick="btnRemoveUser_Click" CausesValidation="false">remove</asp:LinkButton></td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="groupsListBox" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>
        </div>

    </div>



</asp:Content>
