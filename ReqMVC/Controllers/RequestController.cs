using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReqMVC.Models.Domian;
using ReqMVC.Models.ViewModel;
using Mvc.JQuery.DataTables;

namespace ReqMVC.Controllers
{
	public class RequestController : Controller
	{

		HdEntities entities = new HdEntities();

		// GET: Request
		public ActionResult Index()
		{
			string actionUrl = Url.Action(nameof(GetRequests));
			var dataTablesViewModel = DataTablesHelper.DataTableVm<DataTablesResult<RequestDTO>>("xxx", actionUrl);
			return View(dataTablesViewModel);
		}

		public DataTablesResult<RequestDTO> GetRequests(DataTablesParam dataTablesParam)
		{
			List<request> requests =
				entities.requests.Include("post")
					.Include("user")
					.Include("status")
					.Include("deviceinfos")
					.Include("deviceinfos.postoffice").ToList();

			var requestDtos = requests.Select(RequestDTOMapper.GetRequestDto);
			return DataTablesResult.Create(requestDtos.AsQueryable(), dataTablesParam);
		}

		protected override void Dispose(bool disposing)
		{
			entities.Dispose();
			base.Dispose(disposing);
		}
	}
}