<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Staffing.aspx.cs" Inherits="Admin_Staffing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1 class="page-header">Staffing</h1>
    <div class="row">
        <asp:Repeater ID="StaffRepeater" runat="server" DataSourceID="StaffDataSource"
             ItemType="Northwind.Application.DataModels.StaffProfile">
            <ItemTemplate>
                <div class="col-md-4 col-lg-3 col-sm-6">
                    <div class="panel panel-default" style="min-height: 250px;">
                        <div class="panel-heading">
                        <h3 class="panel-title"><%# Item.JobTitle %><small class="pull-right"><%# $"Since <b>{Item.HireDate:MMM yyyy}</b>" %></small></h3>
                        </div>
                        <div class="panel-body">
                            <img src='<%# @"data:image/gif;base64," + Convert.ToBase64String(Item.CleanPhoto) %>'
                                 width="48" height="56" class="img-thumbnail pull-right" />
                            <p class="lead"><%# Item.Name %></p>
                            <b>Service Territories:</b><br />
                            <asp:Repeater runat="server" DataSource="<%# Item.Territories %>" ItemType="System.String">
                                <ItemTemplate><%# Item %></ItemTemplate>
                                <SeparatorTemplate>, </SeparatorTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <asp:ObjectDataSource runat="server" ID="StaffDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListStaff" TypeName="Northwind.Application.BLL.HumanResourcesController"></asp:ObjectDataSource>
</asp:Content>

