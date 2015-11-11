<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="RequestAcct.aspx.cs" Inherits="CapstoneProject.RequestAcct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <asp:Panel ID="requestForm" runat="server">
  
      
      
       <div class="container div-collapseForms">
        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title nick-panel-title">
                        <a data-toggle="collapse" href="#collapse5">Domain Account Request Form</a>
                    </h4>
                </div>
                <div id="collapse5" class="pannel-collapse collapse">
                    <div class="panel-body">
                        
      
       
        <div>
            <label>First Name</label>
            <div>
                <asp:TextBox ID="fNameBox" runat="server"/> 
            </div>
        </div>


        <div>
       
            <label>Last Name</label>
            <div>
                <asp:textbox runat="server" ID="lNamebox" />
            </div>
        </div>


        <div>
            <label>Email Address</label>
            <div>
                <asp:TextBox runat="server" ID="emailBox"/>
            </div>
        </div>


        <div>
            <label>Supervisor</label>
            <div>
                <div>
                    <asp:TextBox runat="server" ID="supervisorBox" />
                </div>
                <p>help</p>
            </div>
        </div>


        <div>
            <label>Account Type</label>
            <div>
                <div>
                    <label>
                      <asp:CheckBox id="checkbox1" runat="server"
                      AutoPostBack="false"
                      Text="Generic User"
                      TextAlign="Right"
                      />
                    </label>
                </div>
                <div>
                    <label>
                      <asp:CheckBox id="checkbox2" runat="server"
                      AutoPostBack="false"
                      Text="Staff Member"
                      TextAlign="Right"
                      />
                    </label>
                </div>
                <div>
                    <label>
                      <asp:CheckBox id="checkbox3" runat="server"
                      AutoPostBack="false"
                      Text="Faculty Member"
                      TextAlign="Right"
                      />
                   </label>
                </div>
                <div>
                    <label>
                      <asp:CheckBox id="checkbox4" runat="server"
                      AutoPostBack="false"
                      Text="Technician (Helpdesk)"
                      TextAlign="Right"
                      />
                    </label>
                </div>
                <div>
                    <label>
                      <asp:CheckBox id="checkbox5" runat="server"
                      AutoPostBack="false"
                      Text="Technician (Other)"
                      TextAlign="Right"
                      />
                    </label>
                </div>
                <div>
                    <label>
                      <asp:CheckBox id="checkbox6" runat="server"
                      AutoPostBack="false"
                      Text="Systems Administrator"
                      TextAlign="Right"
                      />
                    </label>
                </div>
            </div>
        </div>


        <%--<div>
            <label>Additional Group Memberships</label>
            <div>
                <div>
                    <span>
                        <asp:CheckBox id="checkbox7" runat="server"
                      AutoPostBack="false"
                      Text=""
                      TextAlign="Right"
                      />
                    </span>
                    <input name="ExtraGroupscheckbox" type="text">
                </div>
            </div>
        </div>--%>


        <div>
            <label>Nature of Request</label>
            <div>
                <asp:TextBox TextMode="MultiLine" ID="reasonBox" runat="server" placeholder="Please enter the reason for and nature of the account you are requesting."></asp:TextBox>
            </div>
        </div>


        <div>
            <label>Complete Form</label>
            <div>
                <asp:button ID="requestSubmit" runat="server" Text="Submit" OnClick="requestSubmit_Click"></asp:button>
            </div>
        </div>

    
                        </div>
                    </div>
                </div>
            </div>
          </div>
      
      
    </asp:Panel>  
  <asp:Panel ID="messagePanel" runat="server">
    Your request has been submitted. You will recieve an email response within 24 hours.
  </asp:Panel>

     <div class="container div-collapseForms">
        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title nick-panel-title">
                        <a data-toggle="collapse" href="#collapse6">File Share Request</a>
                    </h4>
                </div>
                <div id="collapse6" class="pannel-collapse collapse">
                    <div class="panel-body">
                       <p>Request form will go here</p>
                    </div>
                </div>
            </div>
        </div>
    </div>


        <div class="container div-collapseForms">
        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title nick-panel-title">
                        <a data-toggle="collapse" href="#collapse7">Password Change Request</a>
                    </h4>
                </div>
                <div id="collapse7" class="pannel-collapse collapse">
                    <div class="panel-body">
                       <p>Request form will go here</p>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
