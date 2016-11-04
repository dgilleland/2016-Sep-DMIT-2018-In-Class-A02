<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManageSongs.aspx.cs" Inherits="Admin_ManageSongs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1 class="page-header">Manage Song Database</h1>

    <asp:ListView ID="SongListView" runat="server" DataSourceID="SongsDataSource" InsertItemPosition="LastItem"
        DataKeyNames="TrackID"
        ItemType="Chinook.Framework.Entities.Track">
        <EditItemTemplate>
            <div class="col-lg-4 col-md-6 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            <asp:TextBox Text='<%# Bind("Name") %>' runat="server" ID="NameTextBox" placeholder="Song Name" />
                            <span class="pull-right">
                                <asp:TextBox Text='<%# Bind("UnitPrice") %>' runat="server" ID="UnitPriceTextBox" TextMode="Number" placeholder="Unit Price" Width="70px" />
                            </span>
                        </h3>
                    </div>
                    <div class="panel-body" style="min-height:170px;">
                        Album:
                        <asp:DropDownList SelectedValue='<%# Bind("AlbumId") %>' runat="server" ID="AlbumIdDropDownList" DataSourceID="AlbumDataSource" DataTextField="DisplayText" DataValueField="DataValue" AppendDataBoundItems="true">
                            <asp:ListItem Value="">[no album]</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        Composer: <asp:TextBox Text='<%# Bind("Composer") %>' runat="server" ID="ComposerTextBox" placeholder="Composer" />
                        <br />
                        Running Time: <asp:TextBox Text='<%# BindItem.Milliseconds %>' runat="server" ID="MillisecondsTextBox" 
                     placeholder="Milliseconds" ToolTip="in milliseconds" /> ms
                        <br />
                        Genre: 
                        <asp:DropDownList SelectedValue='<%# Bind("GenreId") %>' runat="server" ID="GenreIdDropDownList" DataSourceID="GenreDataSource" DataTextField="DisplayText" DataValueField="DataValue" AppendDataBoundItems="true">
                            <asp:ListItem Value="">[unknown genre]</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        Media: 
                        <asp:DropDownList SelectedValue='<%# Bind("MediaTypeId") %>' runat="server" ID="MediaTypeIdDropDownList" DataSourceID="MediaTypeDataSource" DataTextField="DisplayText" DataValueField="DataValue"></asp:DropDownList>
                    </div>
                    <div class="panel-footer">
                        <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" />
                        <asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" />
                    </div>
                </div>
            </div>
                        
        </EditItemTemplate>
        <EmptyDataTemplate>
            <span>No data was returned.</span>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <div class="col-md-10">
                <asp:TextBox Text='<%# Bind("Name") %>' runat="server" ID="NameTextBox" placeholder="Song Name" />
                <asp:TextBox Text='<%# Bind("Composer") %>' runat="server" ID="ComposerTextBox" placeholder="Composer" />
                <asp:TextBox Text='<%# BindItem.Milliseconds %>' runat="server" ID="MillisecondsTextBox" 
                     placeholder="Milliseconds" />
                <asp:TextBox Text='<%# Bind("UnitPrice") %>' runat="server" ID="UnitPriceTextBox" placeholder="Unit Price" />
                <br />
                Album:
                <asp:DropDownList SelectedValue='<%# Bind("AlbumId") %>' runat="server" ID="AlbumIdDropDownList" DataSourceID="AlbumDataSource" DataTextField="DisplayText" DataValueField="DataValue" AppendDataBoundItems="true">
                    <asp:ListItem Value="">[no album]</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;
                Media Type:
                <asp:DropDownList SelectedValue='<%# Bind("MediaTypeId") %>' runat="server" ID="MediaTypeIdDropDownList" DataSourceID="MediaTypeDataSource" DataTextField="DisplayText" DataValueField="DataValue"></asp:DropDownList>
                &nbsp;&nbsp;&nbsp;
                Genre:
                <asp:DropDownList SelectedValue='<%# Bind("GenreId") %>' runat="server" ID="GenreIdDropDownList" DataSourceID="GenreDataSource" DataTextField="DisplayText" DataValueField="DataValue" AppendDataBoundItems="true">
                    <asp:ListItem Value="">[unknown genre]</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-2">
                <asp:Button runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" />
                <br />
                <asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" />
            </div>
        </InsertItemTemplate>
        <ItemTemplate>
            <div class="col-lg-4 col-md-6 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            <%# Item.Name %>
                            <span class="pull-right">
                                <%# Item.UnitPrice.ToString("C") %>
                            </span>
                        </h3>
                    </div>
                    <div class="panel-body" style="min-height:170px;">
                        <b title="Album Title"><%# Item.Album?.Title %></b>
                        <br />
                        Composer: <i><%# Item.Composer %></i>
                        <br />
                        Running Time: <%# ConvertMillisecondsToText(Item.Milliseconds) %>
                        <br />
                        Genre: <span class="badge"><%# Item.Genre?.Name %></span>
                        Media: <span class="badge"><%# Item.MediaType.Name %></span>
                    </div>
                    <div class="panel-footer">
                        <asp:Button runat="server" CommandName="Edit" Text="Edit" ID="EditButton" />
                        <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                    </div>
                </div>
            </div>
        </ItemTemplate>
        <LayoutTemplate>
            <div class="row" runat="server" id="itemPlaceholderContainer"><span runat="server" id="itemPlaceholder" /></div>
            <div class="row col-md-12">
                <asp:DataPager runat="server" ID="DataPager1" PageSize="6">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                        <asp:NumericPagerField></asp:NumericPagerField>
                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                    </Fields>
                </asp:DataPager>

            </div>
        </LayoutTemplate>
    </asp:ListView>

    <asp:ObjectDataSource runat="server" ID="SongsDataSource" DataObjectTypeName="Chinook.Framework.Entities.Track" DeleteMethod="DeleteTrack" InsertMethod="AddTrack" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAllTracks" TypeName="Chinook.Framework.BLL.AdminCRUD" UpdateMethod="UpdateTrack"></asp:ObjectDataSource>

    <asp:ObjectDataSource runat="server" ID="AlbumDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAlbumTitles" TypeName="Chinook.Framework.BLL.AdminCRUD"></asp:ObjectDataSource>

    <asp:ObjectDataSource runat="server" ID="GenreDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListGenres" TypeName="Chinook.Framework.BLL.AdminCRUD"></asp:ObjectDataSource>

    <asp:ObjectDataSource runat="server" ID="MediaTypeDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListMediaTypes" TypeName="Chinook.Framework.BLL.AdminCRUD"></asp:ObjectDataSource>
</asp:Content>

