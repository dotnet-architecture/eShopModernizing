<%@ Page Title="Create" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="Create.aspx.cs" Inherits="eShopModernizedWebForms.Catalog.Create" %>

<asp:Content ID="Create" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="esh-body-title">Create</h2>
    <div class="container">
        <div class="row">

            <div class="col-md-4">
                <div class="row">
                    <asp:Image runat="server" CssClass="esh-picture" ImageUrl='<%#pictureUri%>' />
                </div>

                <div runat="server" id="UploadButton" class="row">
                    <div class="col-md-6">
                        <label class="btn btn-default esh-button-upload">
                            Upload image
                            <input type="file" id="uploadEditorImage" accept="image/*" class="hidden" />
                        </label>
                        <asp:HiddenField ID="TempImageName" runat="server" Value="" ClientIDMode="Static"/>
                    </div>

                    <div class="esh-loader col-md-3 hidden"></div>
                    <div class="col-md-6">
                        <span class="text-danger field-validation-error" id="img-validation-error"></span>
                    </div>
                </div>
            </div>

            <div class="col-md-8 form-horizontal">
                <div class="form-group">
                    <label class="control-label col-md-2">Name</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="Name" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Name" Display="Dynamic"
                            CssClass="field-validation-valid text-danger" ErrorMessage="The Name field is required." />
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label col-md-2">Description</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="Description" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label col-md-2">Brand</label>
                    <div class="col-md-8">
                        <asp:DropDownList ID="Brand" runat="server"
                            SelectMethod="GetBrands"
                            ItemType="eShopModernizedWebForms.Models.CatalogBrand"
                            DataTextField="Brand"
                            DataValueField="Id"
                            CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label col-md-2">Type</label>
                    <div class="col-md-8">
                        <asp:DropDownList ID="Type" runat="server"
                            SelectMethod="GetTypes"
                            ItemType="eShopModernizedWebForms.Models.CatalogType"
                            DataTextField="Type"
                            DataValueField="Id"
                            CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label col-md-2">Price</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="Price" runat="server" CssClass="form-control">0.00</asp:TextBox>
                        <asp:RangeValidator runat="server" ControlToValidate="Price" Type="Currency" CssClass="text-danger" Display="Dynamic"
                            MinimumValue="0" MaximumValue="1000000" ErrorMessage="The Price must be a positive number with maximum two decimals between 0 and 1 million." />
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label col-md-2">Stock</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="Stock" runat="server" CssClass="form-control">0</asp:TextBox>
                        <asp:RangeValidator runat="server" ControlToValidate="Stock" Type="Integer" CssClass="text-danger" Display="Dynamic"
                            MinimumValue="0" MaximumValue="10000000" ErrorMessage="The field Stock must be between 0 and 10 million." />
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label col-md-2">Restock</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="Restock" runat="server" CssClass="form-control">0</asp:TextBox>
                        <asp:RangeValidator runat="server" ControlToValidate="Restock" Type="Integer" CssClass="text-danger" Display="Dynamic"
                            MinimumValue="0" MaximumValue="10000000" ErrorMessage="The field Restock must be between 0 and 10 million." />
                    </div>
                </div>

                <div class="form-group">
                    <label class="control-label col-md-2">Max stock</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="Maxstock" runat="server" CssClass="form-control">0</asp:TextBox>
                        <asp:RangeValidator runat="server" ControlToValidate="Maxstock" Type="Integer" CssClass="text-danger" Display="Dynamic"
                            MinimumValue="0" MaximumValue="10000000" ErrorMessage="The field Max stock must be between 0 and 10 million." />
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-offset-2 col-md-8 text-right esh-button-actions">
                        <a runat="server" href="~" class="btn esh-button esh-button-secondary">[ Cancel ]
                        </a>
                        <asp:Button CssClass="btn esh-button esh-button-primary" runat="server" Text="[ Create ]"
                            OnClick="Create_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
