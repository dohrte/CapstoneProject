<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="CapstoneProject.UserDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel panel-default blk-transparent-background">
        <div class=" panel-body ">
            <div class="webappbtn">
                <p>
                Roles:
                <asp:BulletedList ID="roleList" runat="server">
                </asp:BulletedList>
                    </p>

                    <p>
                        shares accessible:
                <asp:Table ID="shareTable" runat="server">
                </asp:Table>
                    </p>

                    <p>
                        group membership:
                <asp:BulletedList ID="membershipList" runat="server">
                </asp:BulletedList>
            </p>
            </div>
        </div>
    </div>
</asp:Content>
