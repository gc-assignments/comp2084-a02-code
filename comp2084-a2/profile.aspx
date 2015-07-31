<%@ Page Title="My Profile | Dislike.me" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="comp2084_a2.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <asp:Button ID="btnLogout" Text="Log Out" runat="server" CssClass="btn btn-default btn-lg btn-block"
                OnClick="btnLogout_Click" />
            <br />
            <div class="panel panel-default">
                <div class="panel-heading">Username</div>
                <div class="panel-body">
                    <h3>
                        <asp:Label ID="lblUsername" Text="Please Log In" runat="server" />
                    </h3>
                </div>
            </div>
        </div>
    </div>
    <hr />
    <div class="row">
        <asp:GridView runat="server" ID="grdUserMsg" CssClass="table table-striped table-hover" AutoGenerateColumns="false" 
            GridLines="None" DataKeyNames="id" OnRowDeleting="grdUserMsg_RowDeleting" >
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" Visible="false" />
                <asp:BoundField DataField="message" HeaderText="Message" HeaderStyle-Width="60%" ItemStyle-Width="60%" />
                <asp:BoundField DataField="dislike_count" HeaderText="#Dislikes" />
                <asp:HyperLinkField HeaderText="Edit" Text="Edit" DataNavigateUrlFields="id" ControlStyle-CssClass="btn btn-default"
                 DataNavigateUrlFormatString="editmsg.aspx?id={0}" />
                <asp:CommandField ShowDeleteButton="true" DeleteText="Delete" HeaderText="Delete"
                     ControlStyle-CssClass="btn btn-primary" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
