<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="CreateComp.aspx.cs" Inherits="CapstoneProject.CreateComp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-7">
        <div class="panel panel-default wh-transparent-background">
            <div class="panel-heading">
                <h3 class="panel-title">Complete to create a new computer object.</h3>
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <label for="buildingDropList">Building:</label>
                    <asp:DropDownList CssClass="form-control" ID="buildingDropList" runat="server"></asp:DropDownList>
                </div>

                <div class="form-group">
                    <label for="NumErrorLabel">Room Number:</label>
                    <asp:TextBox CssClass="form-control" ID="rmNum" runat="server" />
                    <asp:Label ID="NumErrorLabel" runat="server"></asp:Label>
                </div>

                <div class="form-group">
                    <label for="deptDropList">Department:</label>
                    <asp:DropDownList CssClass="form-control" ID="deptDropList" runat="server"></asp:DropDownList>
                </div>
                <asp:LinkButton CssClass="btn btn-success" ID="createButton" runat="server" OnClick="createButton_Click">Create</asp:LinkButton>
            </div>
        </div>
        
        <!-- Custom name panel -->
        <div class="panel panel-default wh-transparent-background">
            <div class="panel-heading">
                <h3 class="panel-title">Create a new computer object with custom name.</h3>
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <label for="compNameTextBox">Computer Name:</label>
                    <asp:TextBox CssClass="form-control" ID="compNameTextBox" runat="server" />
                    <asp:Label ID="cusNameErrLabel" runat="server"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="custDeptDropList">Department:</label>
                    <asp:DropDownList CssClass="form-control" ID="custDeptDropList" runat="server"></asp:DropDownList>
                </div>
                <asp:LinkButton CssClass="btn btn-success" ID="createCustomButton" runat="server" OnClick="createCustomButton_Click" >Create</asp:LinkButton>
            </div>
        </div>
        
        
    </div>
    <div class="col-md-5">
        <div class="panel panel-default wh-transparent-background">
            <div class="panel-heading">
                <h3 class="panel-title">Completed Actions</h3>
            </div>
            <div class="panel-body">
                <%--<asp:BulletedList ID="ActionList" runat="server" ></asp:BulletedList>--%>
                <ul class="alertListItems">
                    <asp:Label runat="server" ID="listItems"/>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>