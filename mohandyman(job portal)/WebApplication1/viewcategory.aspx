<%@ Page Title="viewcat" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="viewcategory.aspx.cs" Inherits="WebApplication1.Scripts.viewcategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <style type="text/css">
        .floater {
            float: left;
            border: solid 1px white;
            padding: 5px;
            margin: 5px;
            background-color:aliceblue;
            
        }

        h1{
            color:green;
        }

     
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">


     <div class="floater">
        <h1>List of Categories: </h1>
        <asp:BulletedList
            ID="BulletedList1"
            runat="server">
        </asp:BulletedList>
    </div>


</asp:Content>
