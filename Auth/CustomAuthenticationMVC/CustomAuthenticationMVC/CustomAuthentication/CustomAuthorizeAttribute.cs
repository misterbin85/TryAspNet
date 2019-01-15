using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CustomAuthenticationMVC.CustomAuthentication
{
	public sealed class CustomAuthorizeAttribute : AuthorizeAttribute
	{
		private CustomPrincipal CurrentUser => HttpContext.Current.User as CustomPrincipal;

		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			return ((CurrentUser == null || CurrentUser.IsInRole(Roles)) && CurrentUser != null);
		}

		protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
		{
			RedirectToRouteResult routeData = null;

			routeData = new RedirectToRouteResult(new RouteValueDictionary
				(new
				{
					controller = "Account",
					action = "Login",
				}
				));
			if (CurrentUser == null)
			{
			}
			else
			{
				HttpContext.Current.Session.Abandon();
			}

			filterContext.Result = routeData;
		}
	}
}