using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NUnit.Framework;
using ReqMVC.Models.Domian;
using ReqMVC.Models.ViewModel;
namespace _test
{
	public class test
	{
		[Test]
		public static void Test1()
		{
			using (HdEntities entities = new HdEntities())
			{
				request req = entities.requests.First();
				RequestUpdateModel rum = Mapper.Map<RequestUpdateModel>(req);
			}
		}
		[Test]
		public static void Test2()
		{
			using (HdEntities entities = new HdEntities())
			{
				request req = entities.requests.First();
				RequestUpdateModel rum = Mapper.Map<RequestUpdateModel>(req);
			}
		}
	}
}
