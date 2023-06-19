<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="viewuser.aspx.cs" Inherits="WebApplication1.viewuser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
       .b{
           background-color:white;
       }

       </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
     <div class="b">
        <h3>List of user</h3>
         <asp:GridView ID="gvs"  OnPreRender="gvs_PreRender" ClientIDMode="Static" CssClass="table table-striped table-bordered"  style="background-color:aqua"
        runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#9900cc">

            <columns>
                <asp:ImageField DataImageUrlField="profile_image"
DataImageUrlFormatString="~/images/{0}"
HeaderText="Photo" SortExpression="Photo"
ControlStyle-Width="100" />

                <asp:TemplateField headertext="User Name">
                    <ItemTemplate>
                        <h5>
                            <%# Eval("username") %>
                        </h5>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:HyperLinkField HeaderText="User Name" DataTextField="username" DataNavigateUrlFields="user_id" DataNavigateUrlFormatString="detailsuser.aspx?id={0}"/>


                </columns>

            </asp:Gridview>
    </div>
</asp:Content>
