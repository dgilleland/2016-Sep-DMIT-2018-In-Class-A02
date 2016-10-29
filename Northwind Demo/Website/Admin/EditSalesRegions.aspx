<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EditSalesRegions.aspx.cs" Inherits="Admin_EditSalesRegions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
        <div class="col-md-6">
            <h1>Regions</h1>
            <asp:ListView ID="RegionListView" runat="server"
                 DataSourceID="RegionsDataSource" DataKeyNames="RegionID"
                 InsertItemPosition="LastItem">
                <EditItemTemplate>
                    <div>
                        <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" />
                        <asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" />
                        <asp:TextBox Text='<%# Bind("RegionDescription") %>' runat="server" ID="RegionDescriptionTextBox" placeholder="Region Name" />
                    </div>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <div>No data was returned.</div>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <div class="bg-info">
                        <asp:Button runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" />
                        <asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" />
                        <asp:TextBox Text='<%# Bind("RegionDescription") %>' runat="server" ID="RegionDescriptionTextBox" placeholder="New Region Name" />
                        
                    </div>
                </InsertItemTemplate>
                <ItemTemplate>
                    <div>
                        <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                        <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                        <asp:Label Text='<%# Eval("RegionDescription") %>' runat="server" ID="RegionDescriptionLabel" />
                    </div>
                </ItemTemplate>
                <LayoutTemplate>
                    <div runat="server" id="itemPlaceholderContainer"><div runat="server" id="itemPlaceholder" /></div>
                </LayoutTemplate>
            </asp:ListView>
            <asp:ObjectDataSource runat="server" ID="RegionsDataSource" DataObjectTypeName="Northwind.Data.Entities.Region" DeleteMethod="DeleteRegion" InsertMethod="AddRegion" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllRegions" TypeName="Northwind.Application.BLL.HumanResourcesController" UpdateMethod="UpdateRegion"></asp:ObjectDataSource>
        </div>
        <div class="col-md-6">
            <h1>Territories</h1>
            <asp:ListView ID="TerritoryListView" runat="server"
                 DataSourceID="TerritoriesDataSource" DataKeyNames="TerritoryID"
                 ItemType="Northwind.Data.Entities.Territory"
                 InsertItemPosition="LastItem">
                <EditItemTemplate>
                    <tr>
                        <td>
                            <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# Bind("TerritoryDescription") %>' runat="server" ID="TerritoryDescriptionTextBox" /></td>
                        <td>
                            <asp:DropDownList ID="EditTerritoryRegionDropDown" runat="server" SelectedValue="<%# BindItem.RegionID %>" 
                                 DataSourceID="RegionsDataSource" AppendDataBoundItems="true"
                                 DataValueField="RegionID" DataTextField="RegionDescription">
                                <asp:ListItem Value="0">[Select a Region]</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr>
                        <td>
                            <asp:Button runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" />
                            <asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" />
                        </td>
                        <td>
                            <asp:TextBox Text='<%# BindItem.TerritoryDescription %>' runat="server" ID="TerritoryDescriptionTextBox" /></td>
                        <td>
                            <asp:DropDownList ID="InsertTerritoryRegionDropDown" runat="server" SelectedValue="<%# BindItem.RegionID %>" 
                                 DataSourceID="RegionsDataSource" AppendDataBoundItems="true"
                                 DataValueField="RegionID" DataTextField="RegionDescription">
                                <asp:ListItem Value="0">[Select a Region]</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                            <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                        </td>
                        <td>
                            <asp:Label Text='<%# Eval("TerritoryDescription") %>' runat="server" ID="TerritoryDescriptionLabel" /></td>
                        <td>
                            <asp:Label Text='<%# Item.Region.RegionDescription %>' runat="server" ID="RegionIDLabel" /></td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server" id="itemPlaceholderContainer" border="0">
                        <tr runat="server">
                            <th runat="server"></th>
                            <th runat="server">Territory</th>
                            <th runat="server">Region</th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                        <tr runat="server">
                            <td runat="server" colspan="3">
                                <hr />
                                <asp:DataPager runat="server" ID="DataPager1">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button"
                                             ShowFirstPageButton="True" ShowLastPageButton="True">
                                        </asp:NextPreviousPagerField>
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
            <asp:ObjectDataSource runat="server" ID="TerritoriesDataSource" DataObjectTypeName="Northwind.Data.Entities.Territory" DeleteMethod="DeleteTerritory" InsertMethod="AddTerritory" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllTerritories" TypeName="Northwind.Application.BLL.HumanResourcesController" UpdateMethod="UpdateTerritory"></asp:ObjectDataSource>
        </div>
    </div>
</asp:Content>

