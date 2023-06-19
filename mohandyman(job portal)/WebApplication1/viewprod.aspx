<%@ Page Title="viewprod" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="viewprod.aspx.cs" Inherits="WebApplication1.viewprod" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <style>
       .b{
           background-color:white;
       }

       </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">



    <div class="b">
        <h3>List of product</h3>
        <asp:GridView
            ID="GrdView1"
            autogeneratecolumns="false"
             OnPageIndexChanging="GrdView1_PageIndexChanging"
            allowpaging="true"
            pagesize="3"
            CellPadding="20"
            runat="server" >

            <columns>
                <asp:ImageField DataImageUrlField="pictures"
DataImageUrlFormatString="~/images/{0}"
HeaderText="Photo" SortExpression="Photo"
ControlStyle-Width="100" />

                <asp:TemplateField headertext="Product Name">
                    <ItemTemplate>
                        <h5>
                            <%# Eval("product_name") %>
                        </h5>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:HyperLinkField HeaderText="Product Name" DataTextField="product_name" DataNavigateUrlFields="product_id" DataNavigateUrlFormatString="details.aspx?id={0}"/>


                </columns>

            </asp:Gridview>
    </div>

    <br>
</asp:Content>
