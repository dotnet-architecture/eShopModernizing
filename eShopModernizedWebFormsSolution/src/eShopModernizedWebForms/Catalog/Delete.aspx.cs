using eShopModernizedWebForms.Models;
using eShopModernizedWebForms.Services;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eShopModernizedWebForms.Catalog
{
    public partial class Delete : System.Web.UI.Page
    {
        protected CatalogItem productToDelete; 

        public ICatalogService CatalogService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Send an OpenID Connect sign-in request.
            if (!Request.IsAuthenticated)
            {
                Context.GetOwinContext().Authentication.Challenge(new AuthenticationProperties { RedirectUri = "/" }, OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
            var productId = Convert.ToInt32(Page.RouteData.Values["id"]);
            productToDelete = CatalogService.FindCatalogItem(productId);

            this.DataBind();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            CatalogService.RemoveCatalogItem(productToDelete);

            Response.Redirect("~");
        }
    }
}