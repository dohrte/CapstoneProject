<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="CapstoneProject.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManagerAdmin" runat="server" EnablePartialRendering="true" ></asp:ScriptManager>
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
            <div role="tabpanel" class="tab-pane active" id="message">

                <label>Current Message</label>
                <asp:Panel ID="curMsgPanel" runat="server">
                    <%--<asp:Label ID="currentMessageLabel" runat="server"></asp:Label>--%>
                </asp:Panel>
                
                <label>New Message</label>
                <asp:TextBox ID="Textbox1" mode="multiline" runat="server" placeholder="Type Message" />
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-default" OnClick="publishBtn_Click" Text="Publish Message"></asp:Button>

                <asp:RadioButtonList ID="mTypeRadioButtonList" runat="server">
                    <asp:ListItem Value="1">Message (green)</asp:ListItem>
                    <asp:ListItem Selected="True" Value="2">Info (blue)</asp:ListItem>
                    <asp:ListItem Value="3">Warning (yellow)</asp:ListItem>
                    <asp:ListItem Value="4">Danger (red)</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div role="tabpanel" class="tab-pane" id="department">
                <asp:UpdatePanel ID="deptTab" runat="server" UpdateMode="Conditional" ClientIDMode="AutoID">
                    <ContentTemplate>
                        <asp:ListView ID="deptListView" runat="server">
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
                                    <td>
                                        <asp:LinkButton ID="btnUpdateDept" runat="server" CommandName="UpdateDept" CommandArgument='<%#Eval("DepartmentName") %>' OnClick="btnUpdateDept_Click" CausesValidation="false"><span class="glyphicon glyphicon-pencil" aria-hidden="true"></span></asp:LinkButton>
                                        <asp:LinkButton ID="btnRemoveDept" runat="server" CommandName="RemoveDept" CommandArgument='<%#Eval("DepartmentName") %>' OnClientClick="return confirm('Are you sure you want to delete this item?')" OnClick="btnRemoveDept_Click" CausesValidation="false"><span class="glyphicon glyphicon-trash" aria-hidden="true"></span></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </ContentTemplate>

                </asp:UpdatePanel>
            </div>
            <div role="tabpanel" class="tab-pane" id="building">

            </div>
            <div role="tabpanel" class="tab-pane" id="settings">...</div>
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
