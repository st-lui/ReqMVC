using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using ReqMVC.Models.Domian;
using ReqMVC.Models.ViewModel;

namespace ReqMVC.App_Start
{
	public class AutoMapperConfig
	{
		public static void RegisterMappings()
		{
			IProfileExpression config = new MapperConfigurationExpression();
			config.CreateMap<request, RequestUpdateModel>()
				.ForMember(x => x.organization, 
					model => model.MapFrom(src => $"{src.deviceinfo.postoffice.idx} {src.deviceinfo.postoffice.name_ops}"));
			config.CreateMap<request, RequestDTO>();
			config.CreateMap<deviceinfo, DeviceInfoStringRep>().ForMember(x=>x.ViewName,model=>model.MapFrom(src=> $"{src.postoffice.post.name} {src.model} {src.serial_number}"));
			Mapper.Initialize((MapperConfigurationExpression)config);
		}
	}
}
