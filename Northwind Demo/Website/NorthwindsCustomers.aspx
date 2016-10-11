﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="NorthwindsCustomers.aspx.cs" Inherits="NorthwindsCustomers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Northwind Customers</h1>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="CustomerListDataSource" AllowPaging="True">
        <Columns>
            <asp:CommandField ShowSelectButton="True"></asp:CommandField>
            <asp:BoundField DataField="CustomerId" HeaderText="CustomerId" SortExpression="CustomerId"></asp:BoundField>
            <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName"></asp:BoundField>
            <asp:BoundField DataField="ContactName" HeaderText="ContactName" SortExpression="ContactName"></asp:BoundField>
            <asp:BoundField DataField="ContactTitle" HeaderText="ContactTitle" SortExpression="ContactTitle"></asp:BoundField>
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address"></asp:BoundField>
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City"></asp:BoundField>
            <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region"></asp:BoundField>
            <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country"></asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="CustomerListDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListCustomers" TypeName="Northwind.Application.BLL.SalesController"></asp:ObjectDataSource>

</asp:Content>
