using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ReqMVC.Models;
using ReqMVC.Models.Domian;

namespace ReqMVC.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		HdEntities hdEntities = new HdEntities();

		private ApplicationUserManager UserManager
		{
			get { return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
		}
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public async Task MigrateUsers()
		{
			int migrated = 0;
			foreach (var user in hdEntities.users)
			{
				await UserManager.CreateAsync(new ApplicationUser {UserName = user.name, userid = user.id}, user.password);
			}
			Response.Write($"Мигрировано {migrated} пользователей");
			Response.End();
		}

		protected override void Dispose(bool disposing)
		{
			hdEntities.Dispose();
			UserManager.Dispose();
			base.Dispose();
		}
	}
}