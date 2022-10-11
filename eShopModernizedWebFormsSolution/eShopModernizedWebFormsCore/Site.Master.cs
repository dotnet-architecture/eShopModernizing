﻿//using Microsoft.Owin.Security;
//using Microsoft.Owin.Security.Cookies;
//using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eShopModernizedWebForms
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Login.Visible = CatalogConfiguration.UseAzureActiveDirectory;

            // Example of a legacy session usage - left intact with minimal code changes to use Azure Redis Cache to back it
            SessionInfoLabel.Text = $"{HttpContext.Current.Session["MachineName"]}, {HttpContext.Current.Session["SessionStartTime"]}";
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            //Context.GetOwinContext().Authentication.SignOut(
                //OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            // Send an OpenID Connect sign-in request.
            if (!Request.IsAuthenticated)
            {
                //Context.GetOwinContext().Authentication.Challenge(new AuthenticationProperties { RedirectUri = "/" }, OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
        }
    }
}