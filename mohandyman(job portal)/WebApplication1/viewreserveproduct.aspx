<%@ Page Title="reserveproduct" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="viewreserveproduct.aspx.cs" Inherits="WebApplication1.viewreserveproduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
       .b{
           background-color:white;
       }

       </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">



      <div class="b">
        <h3>List of reserve product</h3>
        <asp:GridView
            ID="GrdView1"
            autogeneratecolumns="false"
             OnPageIndexChanging="GrdView1_PageIndexChanging1"
            allowpaging="true"
            pagesize="3"
            CellPadding="20"
            runat="server" >

            <columns>
              
               

                <asp:TemplateField headertext="Status">
                    <ItemTemplate>
                        <h5>
                            <%# Eval("Status") %>
                        </h5>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField headertext="Product name">
                    <ItemTemplate>
                        <h5>
                            <%# Eval("product_name") %>
                        </h5>
                    </ItemTemplate>
                </asp:TemplateField>



                <asp:TemplateField headertext="Access Date">
                    <ItemTemplate>
                        <h5>
                            <%# Eval("AccessDate") %>
                        </h5>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:ImageField DataImageUrlField="pictures"
DataImageUrlFormatString="~/images/{0}"
HeaderText="Photo" SortExpression="Photo"
ControlStyle-Width="100" />

                </columns>

            </asp:Gridview>
    </div>
    <br>



</asp:Content>
