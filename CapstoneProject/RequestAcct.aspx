<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="RequestAcct.aspx.cs" Inherits="CapstoneProject.RequestAcct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset>
        <legend>Capstone Domain Account Request</legend>
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
            <label>Supervisor</label>
            <div>
                <div>
                    <span>Supervisor</span>
                    <input name="supervisorBox" type="text">
                </div>
                <p>help</p>
            </div>
        </div>


        <div>
            <label>Account Type</label>
            <div>
                <div>
                    <label>
                        <input type="checkbox" name="checkboxes" value="1">
                        Generic User
                    </label>
                </div>
                <div>
                    <label>
                        <input type="checkbox" name="checkboxes" value="2">
                        Staff Member
                    </label>
                </div>
                <div>
                    <label>
                        <input type="checkbox" name="checkboxes" value="">
                        Faculty Member
                    </label>
                </div>
                <div>
                    <label>
                        <input type="checkbox" name="checkboxes" value="">
                        Technician (Helpdesk)
                    </label>
                </div>
                <div>
                    <label>
                        <input type="checkbox" name="checkboxes" value="">
                        Technician (Other)
                    </label>
                </div>
                <div>
                    <label>
                        <input type="checkbox" name="checkboxes" value="">
                        Systems Administrator
                    </label>
                </div>
            </div>
        </div>


        <div>
            <label>Additional Group Memberships</label>
            <div>
                <div>
                    <span>
                        <input type="checkbox">
                    </span>
                    <input name="ExtraGroupscheckbox" type="text">
                </div>
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
