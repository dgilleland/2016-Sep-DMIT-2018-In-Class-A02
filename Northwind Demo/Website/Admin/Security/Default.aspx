<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Security_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row jumbotron">
        <h1>Site Administration</h1>
    </div>
    <div class="row">
        <div class="col-md-8">
            <h2>Users</h2>
        </div>
        <div class="col-md-4">
            <h2>Roles</h2>
            <asp:ListView ID="RoleListView" runat="server"
                 ItemType="Microsoft.AspNet.Identity.EntityFramework.IdentityRole">
                <LayoutTemplate>
                    <div class="row">
                        <div class="col-sm-4 bg-info">Action</div>
                        <div class="col-sm-8 bg-info">Role</div>
                    </div>
                    <div runat="server" id="itemPlaceholder"></div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="row">
                        <div class="col-sm-4"></div>
                        <div class="col-sm-8"><%# Item.Name %></div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>

