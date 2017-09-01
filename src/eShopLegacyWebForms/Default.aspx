<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="eShopLegacyWebForms._Default" %>

<asp:Content ID="CatalogList" ContentPlaceHolderID="MainContent" runat="server">

    <div class="esh-table">
        <p class="esh-link-wrapper">
            <a runat="server" href="<%$RouteUrl:RouteName=CreateProductRoute%>" class="btn esh-button esh-button-primary">
                Create New
            </a>
        </p>

        <asp:ListView ID="productList" ItemPlaceholderID="itemPlaceHolder" runat="server" ItemType="eShopLegacyWebForms.Models.CatalogItem">
            <EmptyDataTemplate>
                <table>
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <LayoutTemplate>
                <table class="table">
                    <thead>
                        <tr class="esh-table-header">
                            <th></th>
                            <th>Name
                            </th>
                            <th>Description
                            </th>
                            <th>Brand
                            </th>
                            <th>Type
                            </th>
                            <th>Price
                            </th>
                            <th>Picture name
                            </th>
                            <th>Stock
                            </th>
                            <th>Restock
                            </th>
                            <th>Max stock
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                    </tbody>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <image class="esh-thumbnail" src='/Pics/<%#:Item.PictureFileName%>' />
                        </a>
                    </td>
                    <td>
                        <p>
                            <%#:Item.Name%>
                        </p>
                    </td>
                    <td>
                        <p>
                            <%#:Item.Description%>
                        </p>
                    </td>
                    <td>
                        <p>
                            <%#:Item.CatalogBrand.Brand%>
                        </p>
                    </td>
                    <td>
                        <p>
                            <%#:Item.CatalogType.Type%>
                        </p>
                    </td>
                    <td>
                        <p>
                            <span class="esh-price"><%#:Item.Price%></span>
                        </p>
                    </td>
                    <td>
                        <p>
                            <%#:Item.PictureFileName%>
                        </p>
                    </td>
                    <td>
                        <p>
                            <%#:Item.AvailableStock%>
                        </p>
                    </td>
                    <td>
                        <p>
                            <%#:Item.RestockThreshold%>
                        </p>
                    </td>
                    <td>
                        <p>
                            <%#:Item.MaxStockThreshold%>
                        </p>
                    </td>
                    <td>
                        <asp:HyperLink NavigateUrl='<%# GetRouteUrl("EditProductRoute", new {id =Item.Id}) %>' runat="server" CssClass="esh-table-link">
                            Edit
                        </asp:HyperLink>
                        |
                        <asp:HyperLink NavigateUrl='<%# GetRouteUrl("ProductDetailsRoute", new {id =Item.Id}) %>' runat="server" CssClass="esh-table-link">
                            Details
                        </asp:HyperLink>
                        |
                        <asp:HyperLink NavigateUrl='<%# GetRouteUrl("DeleteProductRoute", new {id =Item.Id}) %>' runat="server" CssClass="esh-table-link">
                            Delete
                        </asp:HyperLink>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>

    <div class="esh-pager">
        <div class="container">
            <article class="esh-pager-wrapper row">
                <nav>
                    <asp:HyperLink ID="PaginationPrevious" runat="server" CssClass="esh-pager-item esh-pager-item--navigable">
                        Previous
                    </asp:HyperLink>

                    <span class="esh-pager-item">Showing <%: Model.ItemsPerPage%> of <%: Model.TotalItems%> products - Page <%: (Model.ActualPage + 1)%> - <%: Model.TotalPages%>
                    </span>

                    <asp:HyperLink ID="PaginationNext" runat="server" CssClass="esh-pager-item esh-pager-item--navigable">
                        Next
                    </asp:HyperLink>
                </nav>
            </article>
        </div>
    </div>
</asp:Content>
