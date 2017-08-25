<%@ page title="Home Page" language="C#" masterpagefile="~/Site.Master" autoeventwireup="true" codebehind="Default.aspx.cs" inherits="eShopLegacyWebForms._Default" %>

<asp:Content ID="CatalogList" ContentPlaceHolderID="MainContent" runat="server">

    <div class="esh-table">
        <p class="esh-link-wrapper">
            @Html.ActionLink("Create New", "Create", null, new { @class = "btn esh-button" })
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
                                <image class="esh-thumbnail" src='/Pics/<%#:Item.PictureFileName%>'/>
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
                                    <%#:Item.CatalogBrand%>
                                </p>
                            </td>
                            <td>
                                <p>
                                    <%#:Item.CatalogType%>
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
</asp:Content>
