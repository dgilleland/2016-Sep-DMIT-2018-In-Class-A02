<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Battle Stations</h1>
    </div>

    <div class="row">
        <div class="col-md-2">
            <h2>Federation</h2>
            <asp:GridView ID="GoodFleet" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanging="GoodFleet_SelectedIndexChanging"
                OnRowDeleting="GoodFleet_RowDeleting" ItemType="SpaceBattleEngine.Ship" ViewStateMode="Enabled">
                <Columns>
                    <asp:BoundField DataField="Registry" HeaderText="Registry" />
                    <asp:TemplateField HeaderText="Power" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Bind("Power") %>' ID="PowerReserve"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:CommandField ShowSelectButton="True" ShowDeleteButton="true" HeaderText="Add" SelectText="==&amp;gt;"></asp:CommandField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-md-8">
            <h2 class="text-center">Battle Zone</h2>
            <div class="row">
                <div class="col-md-6">
                    <asp:GridView ID="Federation" runat="server" ItemType="SpaceBattleEngine.Ship" AutoGenerateColumns="False" Caption="Green Battle Group">
                        <Columns>
                            <asp:BoundField DataField="Registry" HeaderText="Id"></asp:BoundField>
                            <asp:BoundField DataField="Power" HeaderText="Power"></asp:BoundField>
                            <asp:BoundField DataField="Shields" HeaderText="Shields"></asp:BoundField>
                            <asp:CheckBoxField DataField="Disabled" HeaderText="!!"></asp:CheckBoxField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="col-md-6">
                    <asp:GridView ID="Clingons" runat="server" ItemType="SpaceBattleEngine.Ship" AutoGenerateColumns="False" Caption="Red Battle Group">
                        <Columns>
                            <asp:BoundField DataField="Registry" HeaderText="Id"></asp:BoundField>
                            <asp:BoundField DataField="Power" HeaderText="Power"></asp:BoundField>
                            <asp:BoundField DataField="Sheilds" HeaderText="Sheilds"></asp:BoundField>
                            <asp:CheckBoxField DataField="Disabled" HeaderText="!!"></asp:CheckBoxField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <div class="col-md-2">
            <h2>Clingons</h2>
            <asp:GridView ID="BadFleet" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="BadFleet_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" HeaderText="Add" SelectText="&amp;lt;=="></asp:CommandField>
                    <asp:BoundField DataField="Registry" HeaderText="Registry" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="Power">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Bind("Power") %>' ID="EnergyLevel"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
