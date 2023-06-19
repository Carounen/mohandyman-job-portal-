<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="block.aspx.cs" Inherits="WebApplication1.block" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <style>
        #gvs {
            width: 100%;
        }

        th {
            background: #494e5d;
            color: white;
        }
        .b{
           background-color:white;
       }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">

    <div class="b">
     <div class="row">
        <div class="col-lg-12">
            <h2>Search and block active users:</h2>
        </div>
    </div>
    <asp:GridView ID="gvs" OnPreRender="gvs_PreRender" ClientIDMode="Static" CssClass="table table-striped table-bordered"  style="background-color:aqua"
        runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#9900cc">
        <Columns>
            <asp:BoundField DataField="f_name" HeaderText="First Name" />
            <asp:BoundField DataField="l_name" HeaderText="Last Name" />
            <asp:BoundField DataField="username" HeaderText="Username" />
            <asp:ImageField DataImageUrlField="profile_image" ControlStyle-Width="50"
                DataImageUrlFormatString="~/images/{0}" HeaderText="imageurl" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <%-- Assign the User_Id to the link button using the CommandArgument --%>
                    <asp:LinkButton ID="lnkblock" CssClass="btn btn-outline-warning"
                        runat="server" OnClick="lnkblock_Click" CommandArgument='<%# Eval("user_id") %>'>Block</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</div>
</asp:Content>
