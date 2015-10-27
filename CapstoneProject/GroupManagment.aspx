<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="GroupManagment.aspx.cs" Inherits="CapstoneProject.GroupManagment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <asp:ScriptManager ID="ScriptManager1" runat="server">
      </asp:ScriptManager>
  <div class="col-md-6">
    <div class="panel panel-default">
      <div class="panel-heading">
        <h3 class="panel-title">Groups Managed</h3>
      </div>
      <div class="panel-body">
        <asp:ListBox ID="groupsListBox" runat="server" OnSelectedIndexChanged="groupsListBox_SelectedIndexChanged" AutoPostBack="false" OnInit="groupsListBox_Init"></asp:ListBox>
      </div>
    </div>
  </div>

  <div class="col-md-6">
    <div class="panel panel-default">
      <div class="panel-heading">
        <h3 class="panel-title">Group Details</h3>
      </div>
      <div class="panel-body">
        <asp:UpdatePanel ID="manageDetail" runat="server">
          <ContentTemplate>
            Shares acessible:
            <asp:Label ID="sharesAccesible" runat="server"></asp:Label>
            <br />
            Group Members:
            <asp:ListBox ID="memeberListBox" runat="server"></asp:ListBox>
          </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="addUser" runat="server">
          <ContentTemplate>
            Enter userid to add to access group:<br /> &nbsp;<asp:TextBox ID="addUserID_textBox" runat="server" placeholder="Userid to add" Width="208px"/>
            <br />
            <asp:Button ID="adUser_btn" runat="server" Text="Submit" OnClick="adUser_btn_Click"/>
          </ContentTemplate>
        </asp:UpdatePanel>
      </div>
    </div>

  </div>



</asp:Content>
