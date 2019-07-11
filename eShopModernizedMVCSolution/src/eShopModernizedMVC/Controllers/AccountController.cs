using log4net;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Web;
using System.Web.Mvc;

namespace eShopModernizedMVC.Controllers
{
    public class AccountController : Controller
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void SignIn()
        {
            _log.Info($"Now processing... AccountController.SignIn");
            // Send an OpenID Connect sign-in request.
            if (!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties { RedirectUri = "/" }, OpenIdConnectAuthenticationDefaults.AuthenticationType);
            }
        }
        public void SignOut()
        {
            _log.Info($"Now processing... AccountController.SignOut");
            // Send an OpenID Connect sign-out request.
            HttpContext.GetOwinContext().Authentication.SignOut(
                OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);
        }

        public void EndSession()
        {
            _log.Info($"Now processing... AccountController.EndSession");
            // If AAD sends a single sign-out message to the app, end the user's session, but don't redirect to AAD for sign out.
            HttpContext.GetOwinContext().Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
        }
    }
}