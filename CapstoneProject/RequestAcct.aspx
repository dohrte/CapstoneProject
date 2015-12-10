<%@ Page Title="" Language="C#" MasterPageFile="~/LogonMaster.Master" AutoEventWireup="true" CodeBehind="RequestAcct.aspx.cs" Inherits="CapstoneProject.RequestAcct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        legend{
            font-family: Dauphin;
            color: #FFFFFF;
            font-size:x-large;
        }
        label{color:white;}
              
    </style>
  <asp:Panel ID="requestForm" runat="server" CssClass="blk-transparent-background">
  <fieldset>
             <legend>Capstone Domain Account Request</legend>
      <div class="row">
 <div class="col-md-6">
      
      
      <div class="form-group">
            <label for="fNameBox">First Name</label>
            <div>
                <asp:TextBox ID="fNameBox" CssClass="txtbox-c form-control" runat="server" /> 
            </div>
        </div>


        <div class="form-group">
            <label for="lNamebox">Last Name</label>
            <div>
                <asp:textbox runat="server" CssClass="txtbox-c form-control" ID="lNamebox" />
            </div>
        </div>


        <div class="form-group">
            <label>Email Address</label>
            <div onformchange="emailBox">
                <asp:TextBox runat="server" CssClass="txtbox-c form-control" ID="emailBox"/>
            </div>
        </div>


        <div class="form-group">
            <label for="supervisorBox">Supervisor</label>
            <div>
                <div>
                    <asp:TextBox runat="server" CssClass="txtbox-c form-control" ID="supervisorBox" />
                </div>
                
            </div>
        </div>
      </div>
       <div class="col-md-6">

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


        <div class="form-group">
            <label for="reasonBox">Nature of Request</label>
            <div>
                <asp:TextBox TextMode="MultiLine" ID="reasonBox" CssClass="txtbox-c form-control" runat="server" placeholder="Please enter the reason for and nature of the account you are requesting."></asp:TextBox>
            </div>
        </div>


        <div>
            <label>Complete Form</label>
            <div>
                <asp:button ID="requestSubmit" runat="server" CssClass="btn btn-success" Text="Submit" OnClick="requestSubmit_Click"></asp:button>
            </div>
        </div>
      </div>
      
      </div> 
    </fieldset>
    </asp:Panel>  
  <asp:Panel ID="messagePanel" runat="server">
    Your request has been submitted. You will recieve an email response within 24 hours.
  </asp:Panel>
</asp:Content>
