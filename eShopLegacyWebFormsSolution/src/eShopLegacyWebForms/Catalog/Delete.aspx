<%@ Page Title="Delete" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="eShopLegacyWebForms.Catalog.Delete" %>

<asp:Content ID="Delete" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="esh-body-title">Delete</h2>

    <div class="container">
        <h3>Are you sure you want to delete this?</h3>
        <div class="row">
            <asp:Image runat="server" CssClass="col-md-6 esh-picture" ImageUrl='<%#"/Pics/" + productToDelete.PictureFileName%>' />
            <dl class="col-md-6 dl-horizontal">
                <dt>Name
                </dt>

                <dd>
                    <asp:Label runat="server" Text='<%#productToDelete.Name%>' />
                </dd>

                <dt>Description
                </dt>

                <dd>
                    <asp:Label runat="server" Text='<%#productToDelete.Description%>' />
                </dd>

                <dt>Brand
                </dt>

                <dd>
                    <asp:Label runat="server" Text='<%#productToDelete.CatalogBrand.Brand%>' />
                </dd>

                <dt>Type
                </dt>

                <dd>
                    <asp:Label runat="server" Text='<%#productToDelete.CatalogType.Type%>' />
                </dd>
                <dt>Price
                </dt>

                <dd>
                    <asp:Label CssClass="esh-price" runat="server" Text='<%#productToDelete.Price%>' />
                </dd>

                <dt>Picture name
                </dt>

                <dd>
                    <asp:Label runat="server" Text='<%#productToDelete.PictureFileName%>' />
                </dd>

                <dt>Stock
                </dt>

                <dd>
                    <asp:Label runat="server" Text='<%#productToDelete.AvailableStock%>' />
                </dd>

                <dt>Restock
                </dt>

                <dd>
                    <asp:Label runat="server" Text='<%#productToDelete.RestockThreshold%>' />
                </dd>

                <dt>Max stock
                </dt>

                <dd>
                    <asp:Label runat="server" Text='<%#productToDelete.MaxStockThreshold%>' />
                </dd>

                <dt></dt>

                <dd class="text-right esh-button-actions">
                    <a runat="server" href="~" class="btn esh-button esh-button-secondary">[ Cancel ]
                    </a>
                    <asp:Button CssClass="btn esh-button esh-button-primary" runat="server" Text="[ Delete ]" OnClick="Delete_Click" />
                </dd>

            </dl>
        </div>

        <%--<div class="form-actions no-color esh-link-list">
            <a runat="server" href="~" class="esh-link-item">Back to list
            </a>
        </div>--%>

    </div>
</asp:Content>
