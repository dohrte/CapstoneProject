<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="JoinCompForm.aspx.cs" Inherits="CapstoneProject.JoinCompForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset class="blk-transparent-background">
        <legend class="white-text"><span class="white-text">Join Computer to Domain</span></legend>
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label> First Name</label>
                    
                        <input class="form-control" name="firstNameBox" type="text" />
                   
                </div>
                <div class="form-group">
                    <label>Last Name</label>
                    
                        <input class="form-control" name="lastnamebox" type="text" />
                    
                </div>
                <div class="form-group">
                    <label>Email Address</label>
                    
                        <input class="form-control" name="emailBox" type="text" />
                    
                </div>
                <div class="form-group">
                    <label>Building Name</label>
                    
                        <input class="form-control" name="emailBox" type="text" />
                    
                </div>
            </div>
            <div class="col-md-6">
                
                <div class="form-group">
                    <label>Computer Names</label>
                    
                        <textarea class="form-control" name="reasonBox">Desired computer names (optional)."</textarea>
                    
                </div>
                <div class="form-group">
                    <label>Nature of Request</label>
                    
                        <textarea class="form-control" name="reasonBox">Please enter the reason for and nature of the account you are requesting.</textarea>
                    
                </div>
                <div>
                    <label>Complete Form</label>
                    <div>
                        <button class="btn btn-success" name="submitButton">Submit</button>
                    </div>
                </div>
            </div>
        </div>

    </fieldset>
</asp:Content>
