using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ReqMVC.Models
{
	class IdentityContext:IdentityDbContext<ApplicationUser>
	{
		public IdentityContext():base("HdEntities")
		{
		}

		public static IdentityContext Create()
		{
			return new IdentityContext();
		}
	}
}
