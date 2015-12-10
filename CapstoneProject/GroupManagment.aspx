<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="GroupManagment.aspx.cs" Inherits="CapstoneProject.GroupManagment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ScriptManager>
    <div class="col-md-6">
        <div class="panel panel-default blk-transparent-background">
            <div class="panel-heading">
                <h3 class="panel-title">Groups Managed</h3>
            </div>
            <div class="panel-body">
                <div class="webappbtn">
                    <asp:UpdatePanel ID="gUpdatePanel" runat="server">
                        <ContentTemplate>
                            <%--<asp:ListBox ID="groupsListBox" runat="server" OnSelectedIndexChanged="groupsListBox_SelectedIndexChanged" OnInit="groupsListBox_Init" AutoPostBack="True"></asp:ListBox>--%>

                            <asp:ListView ID="groupsListView" runat="server" OnItemCommand="groupsListView_ItemCommand">
                                <LayoutTemplate>
                                    <table class="table table-hover">
                                        <thead>
                                            <tr>
                                                <th>Group Name</th>
                                                <th></th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                                        </tbody>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("groupName") %></td>
                                        <td>
                                            <asp:LinkButton ID="btnShowGrp" 
                                                runat="server" 
                                                CommandName="Show"
                                                 CommandArgument='<%#Eval("groupName") %>'
                                                 CausesValidation="false" ToolTip="Show Details">
                                               <span class="glyphicon glyphicon-th-list" aria-hidden="true"></span>
                                            </asp:LinkButton>
                                        </td>

                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="groupsListView" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>

    <div class="col-md-6">
        <asp:UpdatePanel ID="grpView" runat="server">
            <ContentTemplate>
                <div class="panel panel-default blk-transparent-background">
                    <div class="panel-heading">
                        <h3 class="panel-title">Group Details</h3>
                    </div>
                    <div class="panel-body">
                        <div class="webappbtn">
                            <asp:UpdatePanel ID="manageDetail" runat="server" UpdateMode="Always">
                                <ContentTemplate>
                                    <h4>
                                        <asp:Label ID="grpNameLbl" runat="server"></asp:Label></h4>
                                    <asp:ListView ID="sharesListView" runat="server">
                                        <LayoutTemplate>

                                            <table class="table">
                                                <tr>
                                                    <th>Share Name</th>
                                                    <th>Permissions</th>
                                                </tr>
                                                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                                            </table>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td><%#Eval("shareName") %></td>
                                                <td><%#Eval("perms") %></td>

                                            </tr>
                                        </ItemTemplate>

                                    </asp:ListView>

                                    <asp:UpdatePanel ID="addUser" runat="server" UpdateMode="Always">
                                        <ContentTemplate>
                                            <div class="form-inline">
                                                <div class="form-group">
                                                    <asp:TextBox ID="addUserID_textBox" runat="server" CssClass="form-control" placeholder="Userid to Add" Width="208px" />
                                                </div>
                                                <asp:LinkButton ID="adUser_btn" 
                                                    runat="server" 
                                                    CssClass="btn btn-success"
                                                     OnClick="adUser_btn_Click"
                                                    Tooltip="Add User">
                                                    <span class="glyphicon glyphicon-plus-sign" aria-hidden="true"></span>
                                                </asp:LinkButton>
                                            </div>
                                            <asp:RequiredFieldValidator ID="txtUsernameValidator"
                                                runat="server"
                                                ControlToValidate="addUserID_textBox"
                                                ErrorMessage="Please enter a valid UserID"
                                                ForeColor="Red"
                                                Display="Dynamic" />
                                            <asp:Label ID="addUser_Error" runat="server" ForeColor="Red" Visible="false" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="adUser_btn" />
                                        </Triggers>
                                    </asp:UpdatePanel>

                                    <%-- <asp:ListBox ID="memeberListBox" runat="server"></asp:ListBox>--%>
                                    <asp:ListView ID="memberListView"
                                        runat="server"
                                        OnItemCommand="memberListView_ItemCommand">
                                        <LayoutTemplate>

                                            <table class="table table-hover">
                                                <thead>
                                                    <tr>
                                                        <th>Name</th>
                                                        <th></th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                                                </tbody>

                                            </table>
                                        </LayoutTemplate>

                                        <ItemTemplate>
                                            <tr>
                                                <td><%#Eval("Name") %></td>
                                                <td>
                                                    <%--<asp:LinkButton ID="btnRemoveUser" runat="server" CommandName="Remove" CommandArgument='<%#Eval("Name") %>' CausesValidation="false"><span class="glyphicon glyphicon-minus-sign" aria-hidden="true"></span></asp:LinkButton></td>--%>
                                                    <a class="removeLink" data-toggle="modal" data-target="#removeModal_<%#Eval("Name").ToString().Replace(" ","") %>" title="Remove User">
                                                        <span class="glyphicon glyphicon-minus-sign" aria-hidden="true"></span>
                                                    </a>
                                            </tr>
                                            <div class="modal fade" id="removeModal_<%#Eval("Name").ToString().Replace(" ","") %>" tabindex="-1" role="dialog" aria-labelledby="removeModalLabel">
                                                <div class="modal-dialog">
                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                            <h4 class="modal-title black-text">Remove User: <%#Eval("Name") %></h4>
                                                        </div>
                                                        <div class="modal-body">
                                                            <p class="black-text">Are you sure you want to remove <%#Eval("Name") %> from this group?</p>
                                                        </div>
                                                        <div class="modal-footer">
                                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                                                            <%--<button type="button" class="btn btn-primary">Confirm</button>--%>
                                                            <asp:LinkButton ID="btnRemoveUser"
                                                                runat="server"
                                                                CssClass="btn btn-danger"
                                                                CommandName="Remove"
                                                                CommandArgument='<%#Eval("Name") %>'
                                                                OnClientClick="CloseModal()"
                                                                CausesValidation="false">
                                                    Confirm
                                                            </asp:LinkButton>
                                                        </div>
                                                    </div>
                                                    <!-- /.modal-content -->
                                                </div>
                                                <!-- /.modal-dialog -->
                                            </div>
                                            <!-- /.modal -->
                                        </ItemTemplate>
                                    </asp:ListView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="groupsListView" />
                                    <asp:AsyncPostBackTrigger ControlID="memberListView" />
                                    <asp:AsyncPostBackTrigger ControlID="sharesListView" />
                                    <asp:AsyncPostBackTrigger ControlID="adUser_btn" />

                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>



            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="groupsListView" />
            </Triggers>
        </asp:UpdatePanel>
    </div>


    <script type="text/javascript">
        function isInValid(oSrc, args) {

            var dataVal = "{ name: '" + args.Value + "'}";

            if (args.Value.length > 0) {
                $.ajax({
                    type: "POST",
                    url: "GroupManagment.aspx/newUserValidator_ServerValidate",
                    data: dataVal,
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (result) {
                        alert(result);
                    }
                })
            }
            else {
                args.IsValid = false;
            }

        }
    </script>
</asp:Content>
