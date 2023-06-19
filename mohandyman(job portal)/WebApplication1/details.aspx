<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="details.aspx.cs" Inherits="WebApplication1.details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    .b{
           background-color:white;
       }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">

    <div class="b">
 
    <asp:DetailsView ID="DetailsView1" AutoGenerateRows="false" runat="server">
        
        <Fields>
         <asp:ImageField DataImageUrlField="pictures" 
                    DataImageUrlFormatString="~/images/{0}"
                   SortExpression="Picture" ControlStyle-Width="175"/>

             <asp:TemplateField>


                 <ItemTemplate>
                     <h5><strong><em>

                     <%# Eval("product_name") %>
                 </em></strong></h5>
                     <br />

                         <%# Eval("description") %>

                 </ItemTemplate>

             </asp:TemplateField>


            <asp:ButtonField DataTextField="cost"  ControlStyle-CssClass="btn btn-outline-success"/>

            </Fields>
    </asp:DetailsView>

    </div>




</asp:Content>
