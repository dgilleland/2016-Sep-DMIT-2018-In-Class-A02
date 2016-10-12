<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Security_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row jumbotron">
        <h1>Site Administration</h1>
    </div>
    <div class="row">
        <div class="col-md-8">
            <h2>Users</h2>
            <asp:ListView ID="UserListView" runat="server"
                 ItemType="Northwind.Application.Security.ApplicationUser">
                <LayoutTemplate>
                    <div class="row">
                        <div class="col-sm-3 bg-info h4">Action</div>
                        <div class="col-sm-3 bg-info h4">User Name</div>
                        <div class="col-sm-6 bg-info h4">Profile</div>
                    </div>
                    <div runat="server" id="itemPlaceholder"></div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="row">
                        <div class="col-sm-3"></div>
                        <div class="col-sm-3"><%# Item.UserName %></div>
                        <div class="col-sm-6"><%# Item.Email %></div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <div class="col-md-4">
            <h2>Roles</h2>
            <asp:ListView ID="RoleListView" runat="server" DataSourceID="RoleDataSource" 
                 InsertItemPosition="LastItem" DataKeyNames="RoleId" 
                 ItemType="Northwind.Application.RoleProfile">
                <EmptyDataTemplate>
                    <span>No security roles have been set up.</span>
                </EmptyDataTemplate>
                <LayoutTemplate>
                    <div class="row">
                        <div class="col-sm-4 bg-info h4">Action</div>
                        <div class="col-sm-8 bg-info h4">Role</div>
                    </div>
                    <div runat="server" id="itemPlaceholder"></div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="row">
                        <div class="col-sm-4"><asp:LinkButton runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" /></div>
                        <div class="col-sm-8">
                            <%# Item.RoleName %>
                            <small>
                                <asp:Repeater ID="RoleUserRepeater" runat="server"
                                     DataSource="<%# Item.UserNames %>" ItemType="System.String">
                                    <HeaderTemplate><br />UserNames: </HeaderTemplate>
                                    <ItemTemplate><%# Item %></ItemTemplate>
                                    <SeparatorTemplate>, </SeparatorTemplate>
                                </asp:Repeater>
                            </small>
                        </div>
                    </div>
                </ItemTemplate>
                <InsertItemTemplate>
                    <div class="row">
                        <div class="col-sm-4">
                            <asp:LinkButton runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" />
                            <asp:LinkButton runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" />
                        </div>
                        <div class="col-sm-8">
                            <asp:TextBox Text='<%# BindItem.RoleName %>' runat="server" ID="RoleNameTextBox" placeholder="Role Name" /><br />
                        </div>
                    </div>
                </InsertItemTemplate>
            </asp:ListView>

            <asp:ObjectDataSource runat="server" ID="RoleDataSource" DataObjectTypeName="Northwind.Application.RoleProfile" DeleteMethod="RemoveRole" InsertMethod="AddRole" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllRoles" TypeName="Northwind.Application.Security.RoleManager"></asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>

