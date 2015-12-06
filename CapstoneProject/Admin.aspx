<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="CapstoneProject.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManagerAdmin" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
    <script>
        function CloseModal() {
            $('.modal').modal('hide');
        }
    </script>
    <div>

        <!-- Nav tabs -->
        <ul class="nav nav-tabs" role="tablist">
            <li role="presentation" class="active"><a href="#message" aria-controls="message" role="tab" data-toggle="tab">Message</a></li>
            <li role="presentation"><a href="#department" aria-controls="department" role="tab" data-toggle="tab">Department List</a></li>
            <li role="presentation"><a href="#building" aria-controls="building" role="tab" data-toggle="tab">Building List</a></li>
            <li role="presentation"><a href="#settings" aria-controls="settings" role="tab" data-toggle="tab">Settings</a></li>
        </ul>

        <!-- Tab panes -->
        <div class="tab-content">
            <div role="tabpanel" class="tab-pane active adminMessage" id="message">

                <label>Current Message</label>
                <asp:Panel ID="curMsgPanel" runat="server">
                    <%--<asp:Label ID="currentMessageLabel" runat="server"></asp:Label>--%>
                </asp:Panel>

                <label>New Message</label>
                <asp:TextBox ID="Textbox1" CssClass="txtbox-c" mode="multiline" runat="server" placeholder="Type Message" />
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-default" OnClick="publishBtn_Click" Text="Publish Message"></asp:Button>

                <asp:RadioButtonList ID="mTypeRadioButtonList" runat="server">
                    <asp:ListItem Value="1">Message (green)</asp:ListItem>
                    <asp:ListItem Selected="True" Value="2">Info (blue)</asp:ListItem>
                    <asp:ListItem Value="3">Warning (yellow)</asp:ListItem>
                    <asp:ListItem Value="4">Danger (red)</asp:ListItem>
                </asp:RadioButtonList>
                <asp:UpdatePanel ID="cbPanel" runat="server">
                    <ContentTemplate>
                        <asp:CheckBox ID="showMotdCheckBox" runat="server"  
                            AutoPostBack="true"
                            OnCheckedChanged="showMotdCheckBox_CheckedChanged" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="showMotdCheckBox" />
                    </Triggers>
                </asp:UpdatePanel>
                
            </div>
            <div role="tabpanel" class="tab-pane adminComputer" id="department">

                <asp:UpdatePanel ID="addDept" runat="server">
                    <ContentTemplate>
                        Department Name<asp:TextBox ID="deptName" class="txtbox-c" runat="server"></asp:TextBox>
                        Department Abbreviation<asp:TextBox ID="deptAbbr" CssClass="txtbox-c" runat="server"></asp:TextBox>
                        <asp:Button CssClass="black-text" ID="addDept_btn" runat="server" Text="Add Dept" OnClick="addDept_btn_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="deptTab" runat="server" UpdateMode="Always" ClientIDMode="AutoID">
                    <ContentTemplate>
                        <asp:ListView ID="deptListView"
                            OnItemCommand="deptListView_ItemCommand"
                            runat="server"  
                            > 
                            <LayoutTemplate>
                                <table class="table">
                                    <tr>
                                        <th>Name</th>
                                        <th></th>
                                    </tr>
                                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("DepartmentName") %></td>
                                    <td><%#Eval("DepartmentAbbreviation") %></td>
                                    <td>
                                        <a class="" data-toggle="modal" data-target="#updateModal_<%#Eval("DepartmentName").ToString().Replace(" ","") %>">
                                            <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                        </a>
                                        <a class="" data-toggle="modal" data-target="#removeModal_<%#Eval("DepartmentName").ToString().Replace(" ","") %>">
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
                                                    <%#Eval("DepartmentName") %>
                                                    <asp:TextBox ID="updateDeptName" runat="server" Text='<%#Eval("DepartmentName") %>'/>
                                                    <asp:TextBox ID="updateDeptAbbr" runat="server" Text='<%#Eval("DepartmentAbbreviation") %>'  />
                                                </p>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                                               <%-- <button type="button" class="btn btn-primary">Save changes</button>--%>
                                                <asp:LinkButton ID="btnUpdateDept"
                                                    runat="server"
                                                    CssClass="btn btn-primary"
                                                    CommandName="UpdateDept"
                                                    CommandArgument='<%#Eval("DepartmentID") %>'
                                                    OnClientClick="CloseModal()"
                                                    >Save changes</asp:LinkButton>
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
                                                <p class="black-text">are you sure you want to delete <%#Eval("DepartmentName") %> from the list of buildings?</p>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                                                <%--<button type="button" class="btn btn-primary">Confirm</button>--%>
                                                <asp:LinkButton ID="btnRemoveDept" 
                                                    OnClientClick="CloseModal()"
                                                    runat="server"
                                                    CssClass="btn btn-danger"
                                                    CommandName="RemoveDept"
                                                    CommandArgument='<%#Eval("DepartmentID") %>'
                                                    >Confirm</asp:LinkButton>
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
            <div role="tabpanel" class="tab-pane adminSetting" id="building">
                <asp:UpdatePanel ID="bldgAddPanel" runat="server">
                    <ContentTemplate>
                        Department Name<asp:TextBox ID="addBldgName" runat="server" CssClass="txtbox-c"></asp:TextBox>
                        Department Abbreviation<asp:TextBox ID="addBldgAbbr" runat="server" CssClass="txtbox-c"></asp:TextBox>
                        <asp:Button CssClass="black-text" ID="addBldg_btn" runat="server" Text="Add Dept" OnClick="addBldg_btn_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="bldgTab" runat="server" UpdateMode="Always" ClientIDMode="AutoID">
                    <ContentTemplate>
                        <asp:ListView ID="bldgListView"
                            OnItemCommand="bldgListView_ItemCommand"
                            runat="server">
                            <LayoutTemplate>
                                <table class="table">
                                    <tr>
                                        <th>Name</th>
                                        <th></th>
                                    </tr>
                                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("BuildingName") %></td>
                                    <td><%#Eval("BuildingAbbreviation") %></td>
                                    <td>
                                        <a class="" data-toggle="modal" data-target="#updateModal_<%#Eval("BuildingName").ToString().Replace(" ","") %>">
                                            <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                        </a>
                                        <a class="" data-toggle="modal" data-target="#removeModal_<%#Eval("BuildingName").ToString().Replace(" ","") %>">
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
                                                    <%#Eval("BuildingName") %>
                                                    <asp:TextBox ID="updateBldgName" runat="server" Text='<%#Eval("BuildingName") %>' />
                                                    <asp:TextBox ID="updateBldgAbbr" runat="server" Text='<%#Eval("BuildingAbbreviation") %>' />
                                                </p>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                                                <%-- <button type="button" class="btn btn-primary">Save changes</button>--%>
                                                <asp:LinkButton ID="btnUpdateDept"
                                                    runat="server"
                                                    CssClass="btn btn-primary"
                                                    CommandName="UpdateBldg"
                                                    CommandArgument='<%#Eval("BuildingID") %>'
                                                    OnClientClick="CloseModal()">Save changes</asp:LinkButton>
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
                                                <p class="black-text">are you sure you want to delete <%#Eval("BuildingName") %> from the list of buildings?</p>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                                                <%--<button type="button" class="btn btn-primary">Confirm</button>--%>
                                                <asp:LinkButton ID="btnRemoveDept"
                                                    OnClientClick="CloseModal()"
                                                    runat="server"
                                                    CssClass="btn btn-danger"
                                                    CommandName="RemoveBldg"
                                                    CommandArgument='<%#Eval("BuildingID") %>'>Confirm</asp:LinkButton>
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
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <div role="tabpanel" class="tab-pane adminSetting" id="settings">...</div>
        </div>
    </div>



    <%--   <div class="container">
    <div class="panel-group">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                <a data-toggle="collapse" href="#collapse1">Modify Message of the Day</a>
                </h4>
            </div>
            <div id="collapse1" class="pannel-collapse collapse">
                <div class="panel-body">
                    <div class="col-md-4 color-black">
	                    <label>New Message</label>
                        <br />
	                    <asp:textbox id="Textbox1" mode="multiline" runat="server" placeholder="Type Message"/>
                        <br />
	                    <asp:button ID="Button1" runat="server" cssclass="btn btn-default" OnClick="publishBtn_Click" Text="Publish Message"></asp:button>
	                </div>
	                <div class="col-md-2"></div>
	                    <div class="col-md-4 color-black">
                            <label>Current Message</label>
	                        <br />
                            <asp:label ID="Label1" runat="server"></asp:label>
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
                <a data-toggle="collapse" href="#collapse2">Manage Computer</a>
                </h4>
            </div>
            <div id="collapse2" class="pannel-collapse collapse">
                <div class="panel color-gold">
                    <h3>Manage Computer</h3>
                    <div class="form-group">
                        <label for="buildingDropList">Building:</label>
                        <asp:DropDownList CssClass="form-control" ID="buildingDropList" runat="server"></asp:DropDownList>
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
                <a data-toggle="collapse" href="#collapse3">Wiki Controls</a>
                </h4>
            </div>
             <div id="collapse3" class="pannel-collapse collapse">
             <p>This is where the Wiki Controls wil go</p>
             </div>
        </div>
    </div>
</div>--%>
</asp:Content>
