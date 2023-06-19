<%@ Page Title="manageuser" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="manageuser.aspx.cs" Inherits="WebApplication1.manageuser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .bbox{
            background-color:aliceblue;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <div class="bbox">
        <h4>Manage User</h4>
        <hr />
     <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label"></asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="user_id" Visible="false"
                    CssClass="form-control" />
            </div>
        </div>
        <div class="form-group row justify-content-center">
            <asp:Label runat="server" CssClass="col-md-2 col-form-label">User Name</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtuser"
                    CssClass="form-control" />
            </div>
        </div>
        <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label">Email</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtemail"
                    CssClass="form-control" />
            </div>
        </div>
       
     
              

        <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label">Profile picture</asp:Label>
            <div class="col-md-8">
                <asp:FileUpload ID="picture" runat="server" CssClass="" />
                <asp:Image ID="images" runat="server" Visible="true" Width="75"
                    Height="100" />
            </div>
        </div>



               
       
      
        <div class="form-group row justify-content-center">
            <div class="offset-md-2 col-md-8">
                
                <asp:Button runat="server" ID="btnupdate" OnClick="btnupdate_Click"  Text="Update User"
                    Visible="false" CssClass="btn btn-block btn-outline-primary" />
                <asp:Button runat="server" ID="btndelete" OnClick="btndelete_Click"   Text="Delete User"
                    Visible="false" CssClass="btn btn-block btn-outline-primary" OnClientClick="return confirm('Are you sure you want to delete?')" />
               
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
    
    <hr />
    <asp:GridView ID="gvs" AutoGenerateColumns="false" DataKeyNames="user_id" OnSelectedIndexChanged="gvs_SelectedIndexChanged" ClientIDMode="Static"
        Width="800" runat="server">
        <HeaderStyle BackColor="LightGreen" ForeColor="White" Font-Bold="true"
            Height="30" />

        <AlternatingRowStyle BackColor="#f5f5f5" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnSelect" runat="server"
                        CssClass="btn btn-outline-info" CommandName="Select" Text="Select" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField  HeaderText="View user">
                <ItemTemplate>
                    <!-- display the user name -->
                    <asp:Label ID="lbluserName" Text='<%#Eval("username")%>'
                        runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <%-- add an imagefield here to display the poster--%>
        </Columns>
    </asp:GridView>
</div>
</asp:Content>
