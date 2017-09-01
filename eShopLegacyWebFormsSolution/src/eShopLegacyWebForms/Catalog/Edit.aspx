<%@ Page Title="Edit" Language="C#" Debug="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Edit.aspx.cs" Inherits="eShopLegacyWebForms.Catalog.Edit" %>

<asp:Content ID="Edit" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="esh-body-title">Edit</h2>

    <div class="container">
        <div class="row">
            <asp:Image runat="server" CssClass="col-md-6 esh-picture" ImageUrl='<%#"/Pics/" + product.PictureFileName%>' />
            <div class="col-md-6 form-horizontal">

                <div class="form-group">
                    <label class="control-label col-md-4">Name</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="Name" runat="server" CssClass="form-control" Text='<%#product.Name%>'></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Name" Display="Dynamic"
                            CssClass="field-validation-valid text-danger" ErrorMessage="The Name field is required." />
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label col-md-4">Description</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="Description" runat="server" CssClass="form-control" Text='<%#product.Description%>'></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label col-md-4">Brand</label>
                    <div class="col-md-8">
                        <asp:DropDownList ID="BrandDropDownList" runat="server"
                            ItemType="eShopLegacyWebForms.Models.CatalogBrand"
                            DataTextField="Brand"
                            DataValueField="Id"
                            CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label col-md-4">Type</label>
                    <div class="col-md-8">
                        <asp:DropDownList ID="TypeDropDownList" runat="server"
                            ItemType="eShopLegacyWebForms.Models.CatalogType"
                            DataTextField="Type"
                            DataValueField="Id"
                            CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label col-md-4">Price</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="Price" runat="server" CssClass="form-control" Text='<%#product.Price%>'></asp:TextBox>
                        <asp:RangeValidator runat="server" ControlToValidate="Price" Type="Currency" CssClass="text-danger" Display="Dynamic"
                            MinimumValue="0" MaximumValue="1000000" ErrorMessage="The Price must be a positive number with maximum two decimals between 0 and 1 million." />
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label col-md-4">Picture name</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="PictureFileName" runat="server" ReadOnly="true" ToolTip="Not allowed for edition"
                            CssClass="form-control" Text='<%#product.PictureFileName%>'></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label col-md-4">Stock</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="Stock" runat="server" CssClass="form-control" Text='<%#product.AvailableStock%>'></asp:TextBox>
                        <asp:RangeValidator runat="server" ControlToValidate="Stock" Type="Integer" CssClass="text-danger" Display="Dynamic"
                            MinimumValue="0" MaximumValue="10000000" ErrorMessage="The field Stock must be between 0 and 10 million." />
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label col-md-4">Restock</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="Restock" runat="server" CssClass="form-control" Text='<%#product.RestockThreshold%>'></asp:TextBox>
                        <asp:RangeValidator runat="server" ControlToValidate="Restock" Type="Integer" CssClass="text-danger" Display="Dynamic"
                            MinimumValue="0" MaximumValue="10000000" ErrorMessage="The field Restock must be between 0 and 10 million." />
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label col-md-4">Max stock</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="Maxstock" runat="server" CssClass="form-control" Text='<%#product.MaxStockThreshold%>'></asp:TextBox>
                        <asp:RangeValidator runat="server" ControlToValidate="Maxstock" Type="Integer" CssClass="text-danger" Display="Dynamic"
                            MinimumValue="0" MaximumValue="10000000" ErrorMessage="The field Max stock must be between 0 and 10 million." />
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-12 text-right esh-button-actions">
                        <a runat="server" href="~" class="btn esh-button esh-button-secondary">[ Cancel ]
                        </a>
                        <asp:Button CssClass="btn esh-button esh-button-primary" runat="server" Text="[ Save ]" OnClick="Save_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
