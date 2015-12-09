<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLayout.Master" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="CapstoneProject.UserDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .p {
            -webkit-text-stroke: 3px black;
        }
    </style>

    <div class="row">
        <div class="col-md-7">
            <div class="panel panel-default blk-transparent-background">
                <div class="panel-heading">
                    <h3 class="panel-title">Roles</h3>
                </div>
                <div class="panel-body">
                    <div class="white-text">
                        <asp:BulletedList ID="roleList" runat="server">
                        </asp:BulletedList>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-5">
            <div class="panel panel-default blk-transparent-background">
                <div class="panel-heading">
                    <h3 class="panel-title">Group Membership</h3>
                </div>
                <div class="panel-body">
                    <div class="white-text">
                        <asp:BulletedList ID="membershipList" runat="server" CssClass="white-text">
                        </asp:BulletedList>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default blk-transparent-background">
                <div class="panel-heading">
                    <h3 class="panel-title">Shares Accessible</h3>
                </div>
                <div class="panel-body">
                    <div class="white-text">
                        <%--<asp:Table ID="shareTable" runat="server" CssClass="white-text">
                    </asp:Table>--%>
                        <asp:ListView ID="shareListView" runat="server">
                            <LayoutTemplate>
                                <table class="table table-hover">
                                    <thead>
                                        <tr>
                                            <th>Share Name</th>
                                            <th>Permissions</th>
                                            <th>Group</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("shareName") %></td>
                                    <td><%#Eval("permissions") %></td>
                                    <td><%#Eval("grpName") %></td>
                                </tr>

                            </ItemTemplate>
                        </asp:ListView>
                        <asp:Label ID="noSharesMsg" runat="server" Visible="false" />
                    </div>
                </div>
            </div>
        </div>
    </div>


    <%--    <div class="panel panel-default blk-transparent-background">
        <div class=" panel-body ">
            <div class="webappbtn">
                <p>
                Roles:
                
                    </p>

                    <p>
                        shares accessible:
                
                    </p>

                    <p>
                        group membership:
                
            </p>
            </div>
        </div>
    </div>--%>
</asp:Content>
