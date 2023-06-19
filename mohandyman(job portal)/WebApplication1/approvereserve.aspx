<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="approvereserve.aspx.cs" Inherits="WebApplication1.approvereserve" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    .b{
           background-color:white;
       }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <div class="b">
      <h2>Approve / Reject: </h2>

    <asp:GridView ID="gvs" OnPreRender="gvs_PreRender" style="background-color:aqua" ClientIDMode="Static" 
        CssClass="table table-striped table-bordered"
        runat="server" AutoGenerateColumns="false">
        <Columns>
             
            <asp:BoundField DataField="fname" HeaderText="First Name" />
            <asp:BoundField DataField="lname" HeaderText="Last Name" />
            <asp:BoundField DataField="uname" HeaderText="Username" />
            <asp:ImageField DataImageUrlField="image"
                DataImageUrlFormatString="~/images/{0}" ControlStyle-Width="100" HeaderText="Picture" />
            <asp:BoundField DataField="accdate" HeaderText="Request Date&Time" />
            <asp:BoundField DataField="pname" HeaderText="product name" />
            <asp:BoundField DataField="tumstatus" HeaderText="Access Status" />
            <asp:TemplateField HeaderText="Action">
                

                <ItemTemplate>
                    <%--store the movie id in the hiddenfield--%>
                    <asp:HiddenField ID="hidmov" runat="server" Value='<%# Eval("pid") %>' />
                    <%--store the user id in the LinkButtons--%>
                    <asp:LinkButton ID="lnkdeny" OnClick="lnkdeny_Click" CommandArgument='<%# Eval("user_id") %>' CssClass="btn btn-danger"
                        runat="server">Deny Access</asp:LinkButton><br />
                    <br />

                     <asp:HiddenField ID="himov" runat="server" Value='<%# Eval("pid") %>' />
                    <asp:LinkButton ID="lnkgrant" OnClick="lnkgrant_Click"  CommandArgument='<%# Eval("user_id") %>' CssClass="btn btn-success"
                        runat="server">Grant Access</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

        </div>
</asp:Content>
