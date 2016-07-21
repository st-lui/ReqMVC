using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using ReqMVC.Models.Domian;

namespace ReqMVC.Models
{
	class ApplicationUser:IdentityUser
	{
		public int? userid { get; set; }
		public ApplicationUser()
		{
		}
	}
}
