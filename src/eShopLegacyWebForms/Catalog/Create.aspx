<%@ page title="" language="C#" masterpagefile="~/Site.Master" autoeventwireup="true" codebehind="Create.aspx.cs" inherits="eShopLegacyWebForms.Catalog.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="esh-body-title">Create</h2>

    <div>
        <div class="form-horizontal">
            <%--@Html.ValidationSummary(true, "", new { @class = "text-danger" })--%>
            <div class="form-group">
                <%--@Html.LabelFor(model => model.Name, htmlAttributes: new { @class = "control-label col-md-2" })--%>
                <label class="control-label col-md-2">Name</label>
                <div class="col-md-10">
                    <asp:TextBox ID="Name" runat="server" CssClass="form-control"></asp:TextBox>
                    <%--@Html.EditorFor(model => model.Name, new { htmlAttributes = new { @class = "form-control" } })--%>
                    <%--@Html.ValidationMessageFor(model => model.Name, "", new { @class = "text-danger" })--%>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-md-2">Description</label>
                <div class="col-md-10">
                    <asp:TextBox ID="Description" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-md-2">Brand</label>
                <div class="col-md-10">
                    <%--@Html.DropDownList("CatalogTypeId", null, htmlAttributes: new { @class = "form-control" })--%>
                    <asp:DropDownList ID="Brand" runat="server" CssClass="form-control" ></asp:DropDownList>
                    <%--<asp:TextBox ID="Brand" runat="server" CssClass="form-control"></asp:TextBox>--%>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-md-2">Type</label>
                <div class="col-md-10">
                    <asp:TextBox ID="Type" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-md-2">Price</label>
                <div class="col-md-10">
                    <asp:TextBox ID="Price" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-md-2">Picture name</label>
                <div class="col-md-10 esh-form-information">
                    Uploading images not allowed for this version.
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-md-2">Stock</label>
                <div class="col-md-10">
                    <asp:TextBox ID="Stock" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-md-2">Restock</label>
                <div class="col-md-10">
                    <asp:TextBox ID="Restock" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-md-2">Max stock</label>
                <div class="col-md-10">
                    <asp:TextBox ID="Maxstock" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <input type="submit" value="[ Create ]" class="btn esh-button" />
                </div>
            </div>
        </div>
    </div>

<div>
    <a runat="server" href="~" class="esh-link-item esh-link-item--margin">
        Back to list
    </a>
</div>

</asp:Content>
