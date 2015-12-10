<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="JoinCompForm.aspx.cs" Inherits="CapstoneProject.JoinCompForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend>Join Computer to Domain</legend>
        <div>
            <label>First Name</label>
            <div>
                <input name="firstNameBox" type="text">
            </div>
        </div>
        <div>
            <label>Last Name</label>
            <div>
                <input name="lastnamebox" type="text">
            </div>
        </div>
        <div>
            <label>Email Address</label>
            <div>
                <input name="emailBox" type="text">
            </div>
        </div>
        <div>
            <label>Building Name</label>
            <div>
                <input name="emailBox" type="text">
            </div>
        </div>
        <div>
            <label>Department</label>
            <div>
                <input name="emailBox" type="text">
            </div>
        </div>
        v        <div>
            <label>Computer Names</label>
            <div>
                <textarea name="reasonBox">Desired computer names (optional)."</textarea>
            </div>
        </div>
        <div>
            <label>Nature of Request</label>
            <div>
                <textarea name="reasonBox">Please enter the reason for and nature of the account you are requesting.</textarea>
            </div>
        </div>
        <div>
            <label>Complete Form</label>
            <div>
                <button name="submitButton">Submit</button>
            </div>
        </div>
    </fieldset>
</asp:Content>
