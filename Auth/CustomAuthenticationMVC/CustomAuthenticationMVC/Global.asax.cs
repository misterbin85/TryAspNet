using CustomAuthenticationMVC.CustomAuthentication;
using CustomAuthenticationMVC.DataAccess;
using CustomAuthenticationMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Newtonsoft.Json.Linq;

namespace CustomAuthenticationMVC
{
    public class MvcApplication : HttpApplication
    {
        private static readonly string ExeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase)?.Replace("file:\\", string.Empty);

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            PopulateQuiz();
        }

        private static void PopulateQuiz()
        {
            using (AuthenticationDB db = new AuthenticationDB())
            {
                if (db.Questions.Any())
                    return;

                var questions = JObject.Parse(File.ReadAllText($@"{ExeDir}\Jsons\Questions.json"))["Questions"].ToObject<IList<Question>>();
                var answers = JObject.Parse(File.ReadAllText($@"{ExeDir}\Jsons\Answers.json"))["Answers"].ToObject<IList<Answer>>();
                foreach (var question in questions)
                {
                    question.PossibleAnswers = answers.Where(a => a.QuestionId.Equals(question.Id)).ToList();
                }

                db.Questions.AddRange(questions);
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

                CustomPrincipal principal = new CustomPrincipal(authTicket.Name)
                {
                    UserId = serializeModel.UserId,
                    FirstName = serializeModel.FirstName,
                    LastName = serializeModel.LastName,
                    Roles = serializeModel.RoleName.ToArray<string>()
                };

                HttpContext.Current.User = principal;
            }
        }
    }
}