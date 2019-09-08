using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace eShopModernizedMVC.Middleware
{
    public class AuthenticationMiddleware : OwinMiddleware
    {
        public AuthenticationMiddleware(OwinMiddleware next)
        : base(next)
        {
        }

        public async override Task Invoke(IOwinContext context)
        {
            var identity = new ClaimsIdentity("cookies");
            identity.AddClaim(new Claim("iat", "1234"));
            context.Authentication.User = new ClaimsPrincipal();
            context.Authentication.User.AddIdentity(identity);
            await Next.Invoke(context);
        }
    }
}