<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="CapstoneProject.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManagerAdmin" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
    <%--<script type="text/javascript">
        function CloseModal() {
            //$('.modal').modal('hide');
            $('body').removeClass('modal-open');
            $('modal-backdrop').remove();
            return true;
        }
    </script>--%>

    <!-- Nav tabs -->
    <ul class="nav nav-tabs" role="tablist">
        <li role="presentation" class="active"><a href="#message" aria-controls="message" role="tab" data-toggle="tab">Message</a></li>
        <li role="presentation"><a href="#department" aria-controls="department" role="tab" data-toggle="tab">Department List</a></li>
        <li role="presentation"><a href="#building" aria-controls="building" role="tab" data-toggle="tab">Building List</a></li>
        <%--<li role="presentation"><a href="#settings" aria-controls="settings" role="tab" data-toggle="tab">Settings</a></li>--%>
    </ul>

    <!-- Tab panes -->
    <div class="tab-content">
        <div role="tabpanel" class="tab-pane blk-transparent-background active" id="message">

            <label>Current Message</label>
            <asp:Panel ID="curMsgPanel" runat="server">
                <%--<asp:Label ID="currentMessageLabel" runat="server"></asp:Label>--%>
            </asp:Panel>

            <div class="form-group">
                <label for="Textbox1">New Message</label>
                <asp:TextBox ID="Textbox1"
                    runat="server"
                    TextMode="MultiLine"
                    CssClass="form-control"
                    placeholder="Enter Message" />
                <asp:RequiredFieldValidator ID="msgRequiredFieldValidator"
                    runat="server"
                    ControlToValidate="Textbox1"
                    ErrorMessage="Please enter a message before publishing."
                    ForeColor="Red"
                    ValidationGroup="msgValidGroup" />
            </div>

            <div class="row">
                <div class="col-md-6">
                    <asp:RadioButtonList ID="mTypeRadioButtonList" CssClass="radio-table" runat="server">
                        <asp:ListItem Value="1">Message (green)</asp:ListItem>
                        <asp:ListItem Selected="True" Value="2">Info (blue)</asp:ListItem>
                        <asp:ListItem Value="3">Warning (yellow)</asp:ListItem>
                        <asp:ListItem Value="4">Danger (red)</asp:ListItem>
                    </asp:RadioButtonList>

                    <asp:Button ID="Button1"
                        runat="server"
                        CssClass="web-btn btn btn-primary"
                        OnClick="publishBtn_Click"
                        Text="Publish Message"
                        ValidationGroup="msgValidGroup" />
                </div>
                <div class="col-md-6">
                    <asp:UpdatePanel ID="cbPanel" runat="server">
                        <ContentTemplate>
                            <asp:CheckBox ID="showMotdCheckBox" runat="server"
                                CausesValidation="false"
                                AutoPostBack="true"
                                OnCheckedChanged="showMotdCheckBox_CheckedChanged" />
                            Show message on Home Page
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="showMotdCheckBox" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div role="tabpanel" class="tab-pane blk-transparent-background" id="department">

            <div class="panel panel-default">
                <div class="panel-body">
                    <asp:UpdatePanel ID="addDept" runat="server">
                        <ContentTemplate>
                            <div class="form-inline">
                                <div class="form-group">
                                    <label for="deptName">Add Department </label>
                                    <asp:TextBox ID="deptName" runat="server" CssClass="form-control" placeholder="Dept Name"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="deptAbbr">Department Abbreviation</label>
                                    <asp:TextBox ID="deptAbbr" runat="server" CssClass="form-control" placeholder="Dept Abbr"></asp:TextBox>
                                </div>
                                <asp:LinkButton ID="addDept_btn"
                                    CssClass="btn btn-success"
                                    runat="server"
                                    OnClick="addDept_btn_Click"
                                    ValidationGroup="AddDeptGroup">
                                    <span class="glyphicon glyphicon-plus-sign" aria-hidden="true"></span>
                                </asp:LinkButton>
                            </div>
                            <asp:RequiredFieldValidator ID="deptNameRequiredFieldValidator"
                                runat="server"
                                ControlToValidate="deptName"
                                ErrorMessage=" Please enter a Department Name."
                                ForeColor="Red"
                                Display="Dynamic"
                                ValidationGroup="AddDeptGroup" />
                            <asp:RequiredFieldValidator ID="deptAbbrRequiredFieldValidator"
                                runat="server"
                                ControlToValidate="deptAbbr"
                                ErrorMessage=" Please enter a Department Abbreviation."
                                ForeColor="Red"
                                Display="Dynamic"
                                ValidationGroup="AddDeptGroup" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

            <asp:UpdatePanel ID="deptTab" runat="server" UpdateMode="Always" ClientIDMode="AutoID">
                <ContentTemplate>
                    <asp:ListView ID="deptListView"
                        OnItemCommand="deptListView_ItemCommand"
                        runat="server">
                        <LayoutTemplate>
                            <table class="table table-hover">
                                <thead>
                                    <tr>
                                    <th>Name</th>
                                    <th>Abbr</th>
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
                                <td><%#Eval("DepartmentName") %></td>
                                <td><%#Eval("DepartmentAbbreviation") %></td>
                                <td>
                                    <a class="editLink" data-toggle="modal" data-target="#updateModal_<%#Eval("DepartmentName").ToString().Replace(" ","") %>">
                                        <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                    </a>
                                    &nbsp
                                    <a class="removeLink" data-toggle="modal" data-target="#removeModal_<%#Eval("DepartmentName").ToString().Replace(" ","") %>">
                                        <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>
                                    </a>
                                </td>
                            </tr>

                            <div class="modal fade" id="updateModal_<%#Eval("DepartmentName").ToString().Replace(" ","") %>" tabindex="-1" role="dialog" aria-labelledby="updateModalLabel">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            <h4 class="modal-title black-text">Update Entry: <%#Eval("DepartmentName") %></h4>
                                        </div>
                                        <div class="modal-body">
                                            <p class="black-text">
                                                <div class="form-group">
                                                    <label class="black-text" for="updateDeptName">Department Name:</label>
                                                    <asp:TextBox ID="updateDeptName"
                                                        runat="server"
                                                        CssClass="form-control"
                                                        Text='<%#Eval("DepartmentName") %>'
                                                        placeholder="New Name" />
                                                    <asp:RequiredFieldValidator ID="editDeptNameRequiredFieldValidator"
                                                        runat="server"
                                                        ControlToValidate="updateDeptName"
                                                        ErrorMessage=" Please enter a Department Name."
                                                        ForeColor="Red"
                                                        Display="Dynamic"
                                                        ValidationGroup="EditDeptGroup" />
                                                </div>
                                                <div class="form-group">
                                                    <label class="black-text" for="updateDeptAbbr">Department Addr:</label>
                                                    <asp:TextBox ID="updateDeptAbbr"
                                                        runat="server"
                                                        CssClass="form-control"
                                                        Text='<%#Eval("DepartmentAbbreviation") %>'
                                                        placeholder="New Abbr" />
                                                    <asp:RequiredFieldValidator ID="editDeptAbbrRequiredValidator"
                                                        runat="server"
                                                        ControlToValidate="updateDeptAbbr"
                                                        ErrorMessage=" Please enter a Building Name."
                                                        ForeColor="Red"
                                                        Display="Dynamic"
                                                        ValidationGroup="EditDeptGroup" />
                                                </div>

                                            </p>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="web-btn btn btn-default" data-dismiss="modal">Cancel</button>
                                            <%-- <button type="button" class="btn btn-primary">Save changes</button>--%>
                                            <asp:LinkButton ID="btnUpdateDept"
                                                runat="server"
                                                CssClass="btn btn-primary"
                                                CommandName="UpdateDept"
                                                CommandArgument='<%#Eval("DepartmentID") %>'
                                                OnClientClick="CloseModal()"
                                                ValidationGroup="EditDeptGroup">Save changes</asp:LinkButton>
                                        </div>
                                    </div>
                                    <!-- /.modal-content -->
                                </div>
                                <!-- /.modal-dialog -->
                            </div>
                            <!-- /.modal -->

                            <div class="modal fade" id="removeModal_<%#Eval("DepartmentName").ToString().Replace(" ","") %>" tabindex="-1" role="dialog" aria-labelledby="removeModalLabel">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            <h4 class="modal-title black-text">Remove Entry: <%#Eval("DepartmentName") %></h4>
                                        </div>
                                        <div class="modal-body">
                                            <p class="black-text">Are you sure you want to delete <%#Eval("DepartmentName") %> from the list of departments?</p>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                                            <%--<button type="button" class="btn btn-primary">Confirm</button>--%>
                                            <asp:LinkButton ID="btnRemoveDept"
                                                OnClientClick="CloseModal();"
                                                runat="server"
                                                CssClass="btn btn-danger"
                                                CommandName="RemoveDept"
                                                CommandArgument='<%#Eval("DepartmentID") %>'
                                                CausesValidation="false">Confirm</asp:LinkButton>
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
                    <asp:AsyncPostBackTrigger ControlID="deptListView" />
                </Triggers>
            </asp:UpdatePanel>

        </div>
        <div role="tabpanel" class="tab-pane blk-transparent-background" id="building">
            <asp:UpdatePanel ID="bldgAddPanel" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="form-inline">
                                        <div class="form-group">
                                            <label for="addBldgName">Add Building </label>
                                            <asp:TextBox ID="addBldgName" runat="server" CssClass="form-control" placeholder="Building Name"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label for="addBldgAbbr">Building Abbreviation </label>
                                            <asp:TextBox ID="addBldgAbbr" runat="server" CssClass="form-control" placeholder="Building Abbr"></asp:TextBox>
                                        </div>
                                        <asp:LinkButton ID="addBldg_btn"
                                            runat="server"
                                            CssClass="btn btn-success"
                                            OnClick="addBldg_btn_Click"
                                            ValidationGroup="AddBldgGroup">
                                                <span class="glyphicon glyphicon-plus-sign" aria-hidden="true"></span>
                                        </asp:LinkButton>
                                    </div>
                                    <asp:RequiredFieldValidator ID="addBldgNameValidator"
                                        runat="server"
                                        ControlToValidate="addBldgName"
                                        ErrorMessage=" Please enter a Building Name."
                                        ForeColor="Red"
                                        Display="Dynamic"
                                        ValidationGroup="AddBldgGroup" />
                                    <asp:RequiredFieldValidator ID="addBldgAbbrValidator"
                                        runat="server"
                                        ControlToValidate="addBldgAbbr"
                                        ErrorMessage=" Please enter a Building Abbreviation."
                                        ForeColor="Red"
                                        Display="Dynamic"
                                        ValidationGroup="AddBldgGroup" />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="addBldg_btn" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="addBldg_btn" />
                </Triggers>
            </asp:UpdatePanel>

            <asp:UpdatePanel ID="bldgTab" runat="server" UpdateMode="Always" ClientIDMode="AutoID">
                <ContentTemplate>
                    <asp:ListView ID="bldgListView"
                        OnItemCommand="bldgListView_ItemCommand"
                        runat="server">
                        <LayoutTemplate>
                            <table class="table table-hover">
                                <thead>
                                    <tr>
                                        <th>Name</th>
                                        <th>Abbr</th>
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
                                <td><%#Eval("BuildingName") %></td>
                                <td><%#Eval("BuildingAbbreviation") %></td>
                                <td>
                                    <a class="editLink" data-toggle="modal" data-target="#updateModal_<%#Eval("BuildingName").ToString().Replace(" ","") %>">
                                        <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                    </a>
                                    &nbsp
                                        <a class="removeLink" data-toggle="modal" data-target="#removeModal_<%#Eval("BuildingName").ToString().Replace(" ","") %>">
                                            <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>
                                        </a>
                                </td>
                            </tr>

                            <div class="modal fade" id="updateModal_<%#Eval("BuildingName").ToString().Replace(" ","") %>" tabindex="-1" role="dialog" aria-labelledby="updateModalLabel">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            <h4 class="modal-title black-text">Update Entry: <%#Eval("BuildingName") %></h4>
                                        </div>
                                        <div class="modal-body">
                                            <p class="black-text">
                                                <div class="form-group">
                                                    <label class="black-text" for="updateBldgName">Building Name: </label>
                                                    <asp:TextBox ID="updateBldgName"
                                                        runat="server"
                                                        CssClass="form-control"
                                                        Text='<%#Eval("BuildingName") %>'
                                                        placeholder="New Name" />
                                                    <asp:RequiredFieldValidator ID="editBldgNameValidator"
                                                        runat="server"
                                                        ControlToValidate="updateBldgName"
                                                        ErrorMessage=" Please enter a Building Name."
                                                        ForeColor="Red"
                                                        Display="Dynamic"
                                                        ValidationGroup="EditBldgGroup" />
                                                </div>
                                                <div class="form-group">
                                                    <label class="black-text" for="updateBldgAbbr">Building Abbr: </label>
                                                    <asp:TextBox ID="updateBldgAbbr"
                                                        runat="server"
                                                        CssClass="form-control"
                                                        Text='<%#Eval("BuildingAbbreviation") %>'
                                                        placeholder="New Abbr" />
                                                    <asp:RequiredFieldValidator ID="editBldgAbbrValidator"
                                                        runat="server"
                                                        ControlToValidate="updateBldgAbbr"
                                                        ErrorMessage=" Please enter a Building Abbreviation."
                                                        ForeColor="Red"
                                                        Display="Dynamic"
                                                        ValidationGroup="EditBldgGroup" />
                                                </div>
                                            </p>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                                            <%-- <button type="button" class="btn btn-primary">Save changes</button>--%>
                                            <asp:LinkButton ID="btnUpdateBldg"
                                                runat="server"
                                                CssClass="web-btn btn btn-primary"
                                                CommandName="UpdateBldg"
                                                CommandArgument='<%#Eval("BuildingID") %>'
                                                OnClientClick="CloseModal()"
                                                ValidationGroup="EditBldgGroup">Save changes</asp:LinkButton>
                                        </div>
                                    </div>
                                    <!-- /.modal-content -->
                                </div>
                                <!-- /.modal-dialog -->
                            </div>
                            <!-- /.modal -->

                            <div class="modal fade" id="removeModal_<%#Eval("BuildingName").ToString().Replace(" ","") %>" tabindex="-1" role="dialog" aria-labelledby="removeModalLabel">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            <h4 class="modal-title black-text">Remove Entry: <%#Eval("BuildingName") %></h4>
                                        </div>
                                        <div class="modal-body">
                                            <p class="black-text">Are you sure you want to delete <%#Eval("BuildingName") %> from the list of buildings?</p>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                                            <%--<button type="button" class="btn btn-primary">Confirm</button>--%>
                                            <asp:LinkButton ID="btnRemoveBldg"
                                                OnClientClick="CloseModal();"
                                                runat="server"
                                                CssClass="btn btn-danger"
                                                CommandName="RemoveBldg"
                                                CommandArgument='<%#Eval("BuildingID") %>'
                                                CausesValidation="false">Confirm</asp:LinkButton>

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
                    <asp:AsyncPostBackTrigger ControlID="bldgListView" />
                    <asp:AsyncPostBackTrigger ControlID="addBldg_btn" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
        <%--<div role="tabpanel" class="tab-pane" id="settings">...</div>--%>
    </div>
    </div>

</asp:Content>
