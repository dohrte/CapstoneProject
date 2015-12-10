<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="ShareAccessForm.aspx.cs" Inherits="CapstoneProject.ShareAccessForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>


        <legend>File Shaer Request</legend>


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
            <label>Share Name</label>
            <div>
                <input name="emailBox" type="text">
            </div>
        </div>


        <div>
            <label>Gb</label>
            <div>
                <input name="shareSize" type="text">
            </div>
            <div>
                <label>
                    <input type="checkbox" name="checkboxes" value="2">
                    Bitlocker Encryption?
                </label>
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
