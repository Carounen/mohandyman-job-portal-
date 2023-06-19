<%@ Page Title="home" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="WebApplication1.home1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

        .vys{
            border-radius:50%;
        }
    </style>
    
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">

   
    

    <header class="bg-dark py-5">
           <%-- <div class="container px-4 px-lg-5 my-5">--%>
                <div class="text-center text-white">
                    <h1 class="display-4 fw-bolder font">DONATE & EXCHANGE</h1>
                </div>
           <%-- </div>--%>
        </header>
    <br>

    <div class="container">

        <div class="row form-group" runat="server">
            <div class="col-sm-6 text-white" style="float: left">
                <h1 class="display-4 fw-bolder font">List of Products</h1>
            </div>
            <div class="col-sm-3" style="float: right;">
                <div class="input-group">
                    <%--Trigger the TextChanged event--%>
                    <asp:DropDownList ID="ddlCategory" runat="server"  OnSelectedIndexChanged="TextBox1_TextChanged1" 
                        CssClass="form-control" AutoPostBack="true">
                    </asp:DropDownList>&nbsp;
                </div>
            </div>
            <div class="col-sm-3" style="float: right;">
                <div class="input-group">
                    <%--generate text changed event--%>
                    <asp:TextBox ID="TextBox1"  runat="server"  OnTextChanged="TextBox1_TextChanged1" AutoPostBack="true" CssClass="form-control" Placeholder="Search..." />
                    <span class="input-group-addon">
                        <i class="fa fa-search"></i></span>
                </div>
            </div>
        </div>

        <%-- START AJAX CONTROL --%>
        <hr />


        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

             <contentTemplate>
                  <asp:ListView
            ID="lvproduct" OnPagePropertiesChanging="lvproduct_PagePropertiesChanging"
            runat="server" ItemPlaceholderID="itemPlaceholder" DataKeyNames="product_id">



            <ItemTemplate>

                <div class="card"
                    style="width: 200px; float: left; margin: 8px;">
                    <asp:Image runat="server"
                        ImageUrl='<%# Eval("pictures", "~/images/{0}")%>' ID="Image1"
                        class="card-img-top vys card bg-info" alt="Card image" Width="193px" Height="195px" />
                    <div class="card-body">
                        <h6 class="card-title"><%# Eval("product_name")%></h6>
                        <p class="card-text">
                           
                        <asp:HyperLink runat="server" NavigateUrl='<%#Eval("product_id","viewprod.aspx?id={0}")%>'>
                            <%#Eval("description").ToString() +": "+ Eval("product_name").ToString() %>
                        </asp:HyperLink>
                        </p>

                        <p class="card-text">
                            <span><strong>Price Bought:<br />
                            </strong></span><%# Eval("cost","{0:c}")%>
                        </p>
                        <%--Eval movie_id as the commandargument--%>
                        <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" Text="Reserve" CommandName="btnAccess" CommandArgument='<%# Eval("product_id") %>' CssClass="btn btn-primary" />

                    </div>
                </div>
            </ItemTemplate>
            <LayoutTemplate>
                <div id="itemPlaceholder" class="categoryContainer" runat="server">
                </div>
                <hr style="clear: both" />

                <div class="text-right">
<asp:DataPager ID="DataPager1" runat="server" PageSize="5">
<Fields>
<asp:NextPreviousPagerField ButtonType="Link"
ShowNextPageButton="false" ShowFirstPageButton="true" />
<asp:NumericPagerField />
<asp:NextPreviousPagerField ButtonType="Link"
ShowPreviousPageButton="false" ShowLastPageButton="true" />

</Fields>
</asp:DataPager>
</div
            </LayoutTemplate>
        </asp:ListView>

        </contentTemplate>

        <Triggers>
      <asp:AsyncPostBackTrigger ControlID="ddlCategory" EventName="SelectedIndexChanged" />

            <asp:AsyncPostBackTrigger ControlID="TextBox1" EventName="TextChanged" />

        </Triggers>



        </asp:UpdatePanel>

       
       
        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
    </div>
    <br>


</asp:Content>
