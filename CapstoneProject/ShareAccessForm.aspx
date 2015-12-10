<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="ShareAccessForm.aspx.cs" Inherits="CapstoneProject.ShareAccessForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset class="blk-transparent-background">
      <legend class="white-text">File Share Request</legend>
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="firstNameBox">First Name</label>
                                      <input class="form-control" name="firstNameBox" type="text" />
                </div>
                <div class="form-group">
                    <label for="lastnamebox">Last Name</label>
                        <input class="form-control" name="lastnamebox" type="text" />
                </div>
                <div class="form-group">
                    <label for="emailBox">Email Address</label>
                        <input class="form-control" name="emailBox" type="text" /> 
                </div>
            </div>
            <div class=" col-md-6">
                <div class="form-group">
                    <label for="emailBox">Share Name</label>
                        <input class="form-control" name="emailBox" type="text" />
                </div>
                <div class="form-group">
                    <label for="shareSize">Gb</label>
                        <input class="form-control" name="shareSize" type="text" />
                    </div>
                    <div>
                        <label>
                            <input type="checkbox" name="checkboxes" value="2" />
                            Bitlocker Encryption?
                        </label>
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
