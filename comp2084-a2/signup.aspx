<%@ Page Title="Sign Up | Dislike.me" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="comp2084_a2.signup" %>
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
            <div class="form-group">
                <label for="txtConfirm">Confirm Password</label>
                <asp:TextBox ID="txtConfirm" runat="server" MaxLength="999" required="true" TextMode="Password" />
                <asp:CompareValidator ControlToValidate="txtPassword" ControlToCompare="txtConfirm" runat="server" 
                    ErrorMessage="Password must match!" CssClass="label label-primary" Display="Dynamic" Operator="Equal" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnSignup" Text="Sign Up" runat="server" CssClass="btn btn-primary pull-right" OnClick="btnSignup_Click" />
            </div>
        </div>
    </div>
</asp:Content>
