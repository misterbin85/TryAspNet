﻿using System.Web.Mvc;

namespace CustomAuthenticationMVC.Controllers
{
	[HandleError]
	public class ErrorController : Controller
	{
		// GET: Error
		public ActionResult AccessDenied()
		{
			return View();
		}

		public ActionResult PageNotFound()
		{
			return View();
		}

		public ActionResult AnyError()
		{
			return View();
		}
	}
}