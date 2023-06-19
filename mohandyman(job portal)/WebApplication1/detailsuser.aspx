<%@ Page Title="detailsuser" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="detailsuser.aspx.cs" Inherits="WebApplication1.detailsuser" %>
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
         <asp:ImageField DataImageUrlField="profile_image" 
                    DataImageUrlFormatString="~/images/{0}"
                   SortExpression="Picture" ControlStyle-Width="175"/>

             <asp:TemplateField>


                 <ItemTemplate>
                      </em></strong></h5>
                     <br />

                         <%# Eval("f_name") %>
                     <h5><strong><em>

                          </em></strong></h5>
                     <br />

                         <%# Eval("l_name") %>

                      </em></strong></h5>
                     <br />

                         <%# Eval("address") %>
                          </em></strong></h5>
                     <br />

                     <%# Eval("username") %>
                 </em></strong></h5>
                     <br />

                         <%# Eval("password") %>

                      </em></strong></h5>
                     <br />

                         <%# Eval("email") %>

                 </ItemTemplate>

             </asp:TemplateField>


           

            </Fields>
    </asp:DetailsView>

    </div>

</asp:Content>
