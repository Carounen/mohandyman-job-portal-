<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="searchby.aspx.cs" Inherits="WebApplication1.searchby" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">



     <asp:Label ID="Label1" runat="server" Text="Search product by category,location:"></asp:Label>


<asp:TextBox ID="txtprodid" runat="server"  OnTextChanged="txtmovieid_TextChanged" AutoPostBack="true"></asp:TextBox>


<asp:GridView ID="gvs" runat="server"></asp:GridView>





</asp:Content>
