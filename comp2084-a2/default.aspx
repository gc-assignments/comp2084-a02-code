<%@ Page Title="Dislike.me | Home" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="comp2084_a2._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center">Dislike.me</h1>
    <div class="row">
        <h2 class="text-center">
            <asp:Label ID="lblWarning" Text="You cannot post message, Sign Up or Log In first" runat="server" />
        </h2>
        <div class="col-md-8 col-md-offset-2">
            <div class="form-group">
                <asp:TextBox ID="txtMessage" runat="server" TextMode="multiline" CssClass="form-control" Rows="3" required="true" />
                <asp:RequiredFieldValidator ControlToValidate="txtMessage" runat="server" ErrorMessage="Please write your message" 
                    Display="Dynamic"  />
                <asp:RegularExpressionValidator runat="server" ErrorMessage="Max 300 characters" ControlToValidate="txtMessage"
                    Display="Dynamic" ValidationExpression="^([\S\s]{0,300})$" CssClass="label label-primary" />
            </div>
            <asp:Label ID="lblStatus" Text="" runat="server" CssClass="label label-primary" />
        </div>
        <div class="col-md-8 col-md-offset-2 text-center">
            <asp:Button ID="btnPost" Text="Post" runat="server" OnClick="btnPost_Click" CssClass="btn btn-warning" />
        </div>
    </div>
    <hr />
    <div class="row">
        <asp:GridView runat="server" ID="grdMessages" CssClass="table table-striped table-hover" AutoGenerateColumns="false" 
            GridLines="None" OnRowCommand="grdMessages_RowCommand"
            DataKeyNames="id">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" Visible="false" />
                <asp:BoundField DataField="message" HeaderText="Message" HeaderStyle-Width="60%" ItemStyle-Width="60%" />
                <asp:BoundField DataField="dislike_count" HeaderText="#Dislikes" />
                <asp:BoundField DataField="post_by" HeaderText="Posted By" />
                <asp:ButtonField HeaderText="Dislike" ControlStyle-CssClass="btn btn-primary" Text="Dislike" CommandName="DislikeMsg" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
