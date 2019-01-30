using CustomAuthenticationMVC.CustomAuthentication;
using CustomAuthenticationMVC.DataAccess;
using CustomAuthenticationMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace CustomAuthenticationMVC
{
	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);

			using (AuthenticationDB db = new AuthenticationDB())
			{
				var questions = db.Questions.ToList();

				var q = new Question
				{
					Id = 1,
					QuestionText = "Test Question 1"
				};

				List<Answer> answers = new List<Answer>
				{
					new Answer
					{
						Question = q,
						Id = 1,
						QuestionId = q.Id,
						Text = "Bla",
						IsCorrect = false
					},
					new Answer
					{
						Question = q,
						Id = 2,
						QuestionId = q.Id,
						Text = "Bla_2",
						IsCorrect = false
					}
				};
				q.PossibleAnswers = answers;

				db.Questions.Add(q);
				db.SaveChanges();
			}
		}

		protected void Session_End(object sender, EventArgs e)
		{
			HttpContext.Current.Session.Abandon();
		}

		protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
		{
			HttpCookie authCookie = Request.Cookies["Cookie1"];
			if (authCookie != null)
			{
				FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

				var serializeModel = JsonConvert.DeserializeObject<CustomSerializeModel>(authTicket.UserData);

				CustomPrincipal principal = new CustomPrincipal(authTicket.Name);

				principal.UserId = serializeModel.UserId;
				principal.FirstName = serializeModel.FirstName;
				principal.LastName = serializeModel.LastName;
				principal.Roles = serializeModel.RoleName.ToArray<string>();

				HttpContext.Current.User = principal;
			}
		}
	}
}
