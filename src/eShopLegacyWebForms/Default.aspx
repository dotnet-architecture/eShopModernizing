<%@ page title="Home Page" language="C#" masterpagefile="~/Site.Master" autoeventwireup="true" codebehind="Default.aspx.cs" inherits="eShopLegacyWebForms._Default" %>

<asp:Content ID="CatalogList" ContentPlaceHolderID="MainContent" runat="server">

    <div class="esh-table">
        <p class="esh-link-wrapper">
            <%--@Html.ActionLink("Create New", "Create", null, new { @class = "btn esh-button" })--%>
            <asp:Button Text="Create New" CssClass="btn esh-button" runat="server" />
        </p>

        <asp:ListView ID="productList" runat="server" ItemType="eShopLegacyWebForms.Models.CatalogItem">
            <EmptyDataTemplate>
                <table>
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <ItemTemplate>
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
                                    <%#:Item.Price%>
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
                        </tr>
                    </tbody>
                </table>
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
