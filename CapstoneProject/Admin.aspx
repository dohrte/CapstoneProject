<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="CapstoneProject.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="jquery-1.11.3.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="tabs">
<div id="content">
	<ul id="tabs" class="nav nav-tabs color-gold" data-tabs="tabs">
		<li class="active"><a data-toggle="tab" href="#message">Message of the Day</a></li>
	<li><a data-toggle="tab" href="#comps">Manage Computers</a></li>
  <li><a data-toggle="tab" href="#wiki">Manage Wiki</a></li>
</ul>

<div class="tab-content">
  <div id="message" class="tab-pane fade in active">
    <h3>Modify Message of the Day</h3>
    <div class="row">
	<div class="col-md-4">
	<label>New Message</label>
	<input type="text" class="form-control" id="newMessage" placeholder="Message"/>
	 <button type="submit" class="btn btn-default">Publish Message</button>
	</div>
	<div class="col-md-2"></div>
	 <div class="col-md-4">
     <label>Current Message</label>
	 <p> <p>
     <label>This is the old message</label>
     </div>
	</div>
	</div>
	 
  <div id="comps" class="tab-pane">
    <h3>Menu 1</h3>
    <p>Some content in menu 1.</p>
  </div>
  <div id="wiki" class="tab-pane">
    <h3>Menu 2</h3>
    <p>Some content in menu 2.</p>
  </div>
</div>
</div>
</div> <!-- container -->
</asp:Content>
