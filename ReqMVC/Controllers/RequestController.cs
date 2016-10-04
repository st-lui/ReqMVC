using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ReqMVC.Models.Domian;
using ReqMVC.Models.ViewModel;
using Mvc.JQuery.DataTables;
using ReqMVC.App_Code;
using ReqMVC.Models;
using ReqMVC.App_Start;
using AutoMapper;
namespace ReqMVC.Controllers
{
	[Authorize]
	public class RequestController : Controller
	{

		HdEntities entities = new HdEntities();
		IdentityContext usersContext = new IdentityContext();
		private ApplicationUserManager UserManager
		{
			get { return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
		}

		// GET: Request
		[HttpGet]
		public ActionResult Index()
		{
			DataTableConfigVm dataTablesViewModel = DataTablesHelper.DataTableVm<RequestDTO>("xxx", Url.Action(nameof(GetRequests)));
			dataTablesViewModel.Language = $"{{'sUrl':'{Url.Content("~/Content/dataTables.ru.lang.json")}'}}";
			return View(dataTablesViewModel);
		}


		public DataTablesResult<RequestDTO> GetRequests(DataTablesParam dataTablesParam)
		{
			string identityUserId = User.Identity.GetUserId();
			var u = usersContext.Users.FirstOrDefault(x => x.Id == identityUserId);
			if (u == null)
				return null;
			user currentUser = entities.users.FirstOrDefault(x => x.id == u.userid);
			var postsList = new PostTree(currentUser.post_id).Build();
			var postIdList = postsList.Select(x => x.id).ToList();
			var requests =
				entities.requests.Where(x=>postIdList.Contains(x.deviceinfo.postoffice.idx_post.Value));

			var requestDtos = requests.Select(Mapper.Map<RequestDTO>);
			var dtr = DataTablesResult.Create(requestDtos.AsQueryable(), dataTablesParam, rowviewmodel => new
			{
				EditId =
					$"<a href='{Url.Action("Update", "Request", new { id = rowviewmodel.EditId })}'><img src='{Url.Content("~/Content/images/edit.png")}' alt='Редактировать'/></a>",
				Solved =
					"<div class='checkbox disabled centered-content'><label><input type=checkbox " +
					(rowviewmodel.Solved ? "checked" : "") + " disabled></label></div>"
			});
			return dtr;
		}

		protected override void Dispose(bool disposing)
		{
			entities.Dispose();
			usersContext.Dispose();
			base.Dispose(disposing);
		}
		[HttpGet]
		public ActionResult Create()
		{
			var currentUserID = User.Identity.GetUserId();
			if (string.IsNullOrWhiteSpace(currentUserID))
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			var userid = usersContext.Users.FirstOrDefault(x => x.Id == currentUserID).userid;
			user currentUser = entities.users.FirstOrDefault(x => x.id == userid);
			if (currentUser != null)
			{
				int postId = currentUser.post_id;
				List<post> postTree = (List<post>)new PostTree(postId).Build();
				RequestCreateModel rcm = new RequestCreateModel();
				rcm.Author = currentUser.contact;
				
				var postOffices = new List<postoffice>();

				foreach (var post in postTree)
				{
					postOffices.AddRange(post.postoffices.Where(x=>x.closed==null || x.closed !="1"));
				}

				//entities.postoffices.Include("deviceinfos").Where(postOffice => postTree.Contains(postOffice.post)).ToList();
				var devicesList = new List<deviceinfo>();
				foreach (postoffice postoffice in postOffices)
				{
					devicesList.AddRange(postoffice.deviceinfos);
				}
				foreach (var deviceinfo in devicesList)
				{
					rcm.DevicesList.Add(Mapper.Map<DeviceInfoStringRep>(deviceinfo));
				}
				return View(rcm);
			}
			return new HttpStatusCodeResult(HttpStatusCode.Unauthorized,"Вы не авторизовались в системе");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(RequestCreateModel model)
		{
			if (ModelState.IsValid)
			{
				var currentUserID = User.Identity.GetUserId();
				if (string.IsNullOrWhiteSpace(currentUserID))
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				var userid = usersContext.Users.FirstOrDefault(x => x.Id == currentUserID).userid;
				request newRequest = new request();
				newRequest.deviceinfo_id = model.DeviceId;
				newRequest.contact = model.Author;
				newRequest.datecreated = DateTime.Now;
				newRequest.author_id = userid.Value;
				newRequest.text = model.Text;
				newRequest.shorttext = "Обслуживание франкировальной машины";
				newRequest.status = entities.statuses.FirstOrDefault(x => x.text == "Принят");
				entities.requests.Add(newRequest);
				entities.SaveChanges();
				return RedirectToAction("/");
			}
			else
				return View(model);
		}
		[HttpGet]
		[Authorize(Roles = "admin")]
		public ActionResult Update(int? id)
		{
			if (id == null)
				return HttpNotFound();
			var req = entities.requests.FirstOrDefault(x => x.id == id);
			if (req == null)
				return HttpNotFound();
			RequestUpdateModel rum = Mapper.Map<RequestUpdateModel>(req);
			rum.statusList = new SelectList(entities.statuses.ToList(), "id", "text");
			return View(rum);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "admin")]
		public ActionResult Update(RequestUpdateModel updateModel)
		{
			if (updateModel == null)
				return HttpNotFound();
			request req = entities.requests.FirstOrDefault(x => x.id == updateModel.id);
			if (req == null)
				return HttpNotFound();
			var currentUserID = User.Identity.GetUserId();
			if (string.IsNullOrWhiteSpace(currentUserID))
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			var userid = usersContext.Users.FirstOrDefault(x => x.Id == currentUserID).userid;
			req.status_id = updateModel.status_id.Value;
			status newStatus = entities.statuses.FirstOrDefault(x=>x.id== req.status_id.Value);
			if (newStatus.text != "Принят")
			{
				req.solved = true;
				req.datesolved = updateModel.datesolved;
				req.solver_id = userid;
			}
			else
			{
				req.solved = false;
				req.datesolved = null;
				req.solver_id = null;
			}

			req.text = updateModel.text;
			
			req.contact = updateModel.contact;
			req.bf_comment = updateModel.bf_comment;
			entities.Entry(req).State = EntityState.Modified;
			entities.SaveChanges();
			return RedirectToAction("/");
		}
		public async Task MigrateUsers()
		{
			int migrated = 0;
			foreach (var user in entities.users)
			{
				IdentityResult x = await UserManager.CreateAsync(new ApplicationUser { UserName = user.name, userid = user.id }, user.password);
				migrated++;
			}
			Response.Write($"Мигрировано {migrated} пользователей");
			Response.End();
		}
	}
}
