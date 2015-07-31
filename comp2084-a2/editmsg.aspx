<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="editmsg.aspx.cs" Inherits="comp2084_a2.editmsg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
            <div class="form-group">
                <asp:TextBox ID="txtNewMsg" runat="server" TextMode="multiline" CssClass="form-control" Rows="3" required="true" />
                <asp:RequiredFieldValidator ControlToValidate="txtNewMsg" runat="server" ErrorMessage="Please write your message" 
                    Display="Dynamic"  />
                <asp:RegularExpressionValidator runat="server" ErrorMessage="Max 300 characters" ControlToValidate="txtNewMsg"
                    Display="Dynamic" ValidationExpression="^([\S\s]{0,300})$" CssClass="label label-primary" />
            </div>
            <asp:Label ID="lblStatus" Text="" runat="server" CssClass="label label-primary" />
        </div>
        <div class="col-md-8 col-md-offset-2 text-center">
            <asp:Button ID="btnUpdate" Text="Update" runat="server" OnClick="btnUpdate_Click" CssClass="btn btn-success" />
        </div>
    </div>
</asp:Content>
