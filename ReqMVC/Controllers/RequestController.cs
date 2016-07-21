using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReqMVC.Models.Domian;
using ReqMVC.Models.ViewModel;

namespace ReqMVC.Controllers
{
    public class RequestController : Controller
    {
        
		HdEntities entities = new HdEntities();

		// GET: Request
        public ActionResult Index()
        {
	        List<request> requests =
		        entities.requests.Include("post")
			        .Include("user")
			        .Include("status")
			        .Include("deviceinfos")
			        .Include("deviceinfos.postoffice")
			        .ToList();
			List<RequestDTO> requestDtos = new List<RequestDTO>();
			foreach (request r in requests)
				requestDtos.Add(RequestDTOMapper.GetRequestDto(r));
			RequestViewModel rvm = new RequestViewModel(requestDtos);
			return View(rvm);
        }

	    protected override void Dispose(bool disposing)
	    {
			entities.Dispose();
			base.Dispose(disposing);
	    }
    }
}