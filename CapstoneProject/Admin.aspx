<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="CapstoneProject.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="container-fluid adminP">
     <div class="panel-group">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                <a data-toggle="collapse" href="#collapse1">Modify Message of the Day</a>
                </h4>
            </div>
            <div id="collapse1" class="pannel-collapse collapse">
                <div class="panel-body txtbox-c">
                    <div class="col-md-4">
	                    <label>New Message</label>
                        <br />
	                    <asp:textbox id="Textbox1" mode="multiline" runat="server" placeholder="Type Message"/>
                        <br />
	                    <asp:button ID="Button1" runat="server" cssclass="btn btn-default modal-gold" Onclick="publishBtn_Click"  Text="Publish Message"></asp:button>
	                </div>
	                <div class="col-md-2 panel-transparent"></div>
	                    <div class="col-md-4">
                            <label>Current Message</label>
	                        <br />
                            <asp:label ID="Label1" runat="server"></asp:label>
                        </div>
	                </div>
	            </div>
            </div> 
        </div>

    <div class="panel-group">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                <a data-toggle="collapse" href="#collapse2">Manage Computer</a>
                </h4>
            </div>
            <div id="collapse2" class="pannel-collapse collapse">
                <div class="panel txtbox-c">
                    <h3>Manage Computer</h3>
                    <div class="form-group">
                        <label for="buildingDropList">Building:</label>
                        <asp:DropDownList CssClass="form-control" ID="buildingDropList" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
    </div>
        <div class="panel-group">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h4 class="panel-title">
                <a data-toggle="collapse" href="#collapse3">Wiki Controls</a>
                </h4>
            </div>
             <div id="collapse3" class="pannel-collapse collapse txtbox-c">
             <p>This is where the Wiki Controls wil go</p>
             </div>
        </div>
   </div>
</div>


</asp:Content>
