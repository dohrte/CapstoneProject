<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="CapstoneProject.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    this will be the admin page
  <div>
    <ul class="nav nav-tabs color-gold">
    <li class="active"><a href="#message">Message of the Day</a></li>
    <li><a href="#comps">Manage Computers</a></li>
    <li><a href="#wiki">Wiki settings</a></li>
    </ul>
      <br />
    <div class="tab-content">
        <div class="tab-pane fade in active cent" id="message">
            <h5>Modify Message of the Day</h5>
            <div class="row">
            <div class="col-md-6">
                <label> New Message</label>
                <asp:TextBox ID="newMessage" runat="server"></asp:TextBox>
                <asp:button id="messageBtn" CssClass="color-gold" runat="server" Text="Publish Message" />
            </div>
            <div class="col-md-6">
                <label>Current Message</label>
                <asp:panel ID="messagePanel" runat="server"></asp:panel>
            </div>
        </div>
        </div>
        <div class="tab-pane fade" id="comps">
            <h5>Here you modify computers</h5>
             <div class="form-group">
                <label for="buildingDropList">Building:</label>
                <asp:DropDownList CssClass="form-control" ID="buildingDropList" runat="server"></asp:DropDownList>
                <asp:Table runat="server" ID="compTable"></asp:Table>   
             </div>
        </div>
        <div class="tab-pane fade" id="wiki">Wiki settings</div>
    </div>
  </div>
</asp:Content>
