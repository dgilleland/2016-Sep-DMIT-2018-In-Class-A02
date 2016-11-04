<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManageSongs.aspx.cs" Inherits="Admin_ManageSongs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1 class="page-header">Manage Song Database</h1>

    <asp:ListView ID="SongListView" runat="server" DataSourceID="SongsDataSource" InsertItemPosition="LastItem"
        DataKeyNames="TrackID"
        ItemType="Chinook.Framework.Entities.Track">
        <EditItemTemplate>
            <span>TrackId:
                <asp:TextBox Text='<%# Bind("TrackId") %>' runat="server" ID="TrackIdTextBox" />
                Name:
                <asp:TextBox Text='<%# Bind("Name") %>' runat="server" ID="NameTextBox" />
                AlbumId:
                <asp:TextBox Text='<%# Bind("AlbumId") %>' runat="server" ID="AlbumIdTextBox" />
                MediaTypeId:
                <asp:TextBox Text='<%# Bind("MediaTypeId") %>' runat="server" ID="MediaTypeIdTextBox" />
                GenreId:
                <asp:TextBox Text='<%# Bind("GenreId") %>' runat="server" ID="GenreIdTextBox" />
                Composer:
                <asp:TextBox Text='<%# Bind("Composer") %>' runat="server" ID="ComposerTextBox" />
                Milliseconds:
                <asp:TextBox Text='<%# Bind("Milliseconds") %>' runat="server" ID="MillisecondsTextBox" />
                Bytes:
                <asp:TextBox Text='<%# Bind("Bytes") %>' runat="server" ID="BytesTextBox" />
                UnitPrice:
                <asp:TextBox Text='<%# Bind("UnitPrice") %>' runat="server" ID="UnitPriceTextBox" />
                Album:
                <asp:TextBox Text='<%# Bind("Album") %>' runat="server" ID="AlbumTextBox" />
                Genre:
                <asp:TextBox Text='<%# Bind("Genre") %>' runat="server" ID="GenreTextBox" />
                InvoiceLines:
                <asp:TextBox Text='<%# Bind("InvoiceLines") %>' runat="server" ID="InvoiceLinesTextBox" />
                MediaType:
                <asp:TextBox Text='<%# Bind("MediaType") %>' runat="server" ID="MediaTypeTextBox" />
                Playlists:
                <asp:TextBox Text='<%# Bind("Playlists") %>' runat="server" ID="PlaylistsTextBox" />
                <asp:Button runat="server" CommandName="Update" Text="Update" ID="UpdateButton" /><asp:Button runat="server" CommandName="Cancel" Text="Cancel" ID="CancelButton" />
                        
            </span>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <span>No data was returned.</span>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <span>TrackId:
                <asp:TextBox Text='<%# Bind("TrackId") %>' runat="server" ID="TrackIdTextBox" />
                Name:
                <asp:TextBox Text='<%# Bind("Name") %>' runat="server" ID="NameTextBox" />
                AlbumId:
                <asp:TextBox Text='<%# Bind("AlbumId") %>' runat="server" ID="AlbumIdTextBox" />
                MediaTypeId:
                <asp:TextBox Text='<%# Bind("MediaTypeId") %>' runat="server" ID="MediaTypeIdTextBox" />
                GenreId:
                <asp:TextBox Text='<%# Bind("GenreId") %>' runat="server" ID="GenreIdTextBox" />
                Composer:
                <asp:TextBox Text='<%# Bind("Composer") %>' runat="server" ID="ComposerTextBox" />
                Milliseconds:
                <asp:TextBox Text='<%# Bind("Milliseconds") %>' runat="server" ID="MillisecondsTextBox" />
                Bytes:
                <asp:TextBox Text='<%# Bind("Bytes") %>' runat="server" ID="BytesTextBox" />
                UnitPrice:
                <asp:TextBox Text='<%# Bind("UnitPrice") %>' runat="server" ID="UnitPriceTextBox" />
                Album:
                <asp:TextBox Text='<%# Bind("Album") %>' runat="server" ID="AlbumTextBox" />
                Genre:
                <asp:TextBox Text='<%# Bind("Genre") %>' runat="server" ID="GenreTextBox" />
                InvoiceLines:
                <asp:TextBox Text='<%# Bind("InvoiceLines") %>' runat="server" ID="InvoiceLinesTextBox" />
                MediaType:
                <asp:TextBox Text='<%# Bind("MediaType") %>' runat="server" ID="MediaTypeTextBox" />
                Playlists:
                <asp:TextBox Text='<%# Bind("Playlists") %>' runat="server" ID="PlaylistsTextBox" />
                <asp:Button runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" /><asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" />
                        
            </span>
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
                    <div class="panel-body">
                        <b title="Album Title"><%# Item.Album.Title %></b>
                        <br />
                        Composer: <i><%# Item.Composer %></i>
                        <br />
                        Running Time: <%# ConvertMillisecondsToText(Item.Milliseconds) %>
                        <br />
                        Genre: <span class="badge"><%# Item.Genre.Name %></span>
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
            <div>
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
</asp:Content>

