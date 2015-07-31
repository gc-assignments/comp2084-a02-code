<%@ Page Title="Log In | Dislike.me" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="comp2084_a2.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <div class="form-group">
                <label for="txtUsername">Username</label>
                <asp:TextBox ID="txtUsername" runat="server" MaxLength="50" required="true" />
            </div>
            <div class="form-group">
                <label for="txtPassword">Password</label>
                <asp:TextBox ID="txtPassword" runat="server" MaxLength="999" required="true" TextMode="Password" />
            </div>
            <asp:Label ID="lblError" runat="server" CssClass="label label-primary" />
            <div class="form-group">
                <asp:Button ID="btnLogin" Text="Log In" runat="server" CssClass="btn btn-success pull-right" OnClick="btnLogin_Click" />
            </div>
        </div>
    </div>
</asp:Content>
