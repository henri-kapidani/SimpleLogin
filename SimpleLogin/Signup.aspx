<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Template.Master" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="SimpleLogin.Signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PlaceholderContent" runat="server">
    <div class="mb-3">
      <label for="PlaceholderContent_TxtUsername" class="form-label">Username</label>
      <asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="mb-3">
      <label for="PlaceholderContent_TxtPassword" class="form-label">Password</label>
      <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
    </div>
    <asp:Button ID="BtnSignup" runat="server" Text="Signup" CssClass="btn btn-primary" OnClick="BtnSignup_Click"/>
</asp:Content>
