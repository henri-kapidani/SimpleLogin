<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/LoggedTemplate.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="SimpleLogin.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PlaceholderMain" runat="server">
   
    Username: <asp:TextBox ID="TxtUsername" runat="server"></asp:TextBox>
    <br />
    Password: <asp:TextBox ID="TxtPassword" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="BtnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
</asp:Content>
