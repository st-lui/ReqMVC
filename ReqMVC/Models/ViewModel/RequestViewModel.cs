using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReqMVC.Models.Domian;

namespace ReqMVC.Models.ViewModel
{
	public class RequestDTO
	{
		public int Id { get; set; }
		public string Post { get; set; }
		public DateTime DateCreated { get; set; }
		public string Ops { get; set; }
		public string Model { get; set; }
		public string SerialNumber { get; set; }
		public string Text { get; set; }
		public bool Solved { get; set; }
		public string Status { get; set; }
		public DateTime? DateSolved { get; set; }

	}

	public class RequestDTOMapper
	{
		public static RequestDTO GetRequestDto(request r)
		{
			deviceinfo d = r.deviceinfos.First();
			return new RequestDTO()
			{
				Id = r.id,
				Post = r.post.name,
				DateCreated = r.datecreated,
				Ops = $"{d.postoffice.idx}, {d.postoffice.name_ops}",
				Model = d.model??"",
				SerialNumber = d.serial_number,
				Text = r.text??"",
				Solved = r.solved.HasValue && r.solved.Value,
				Status = r.status==null?"":r.status.text,
				DateSolved = r.datesolved
			};
		}
	}


	class RequestViewModel
	{
		public RequestViewModel(IEnumerable<RequestDTO> requestList)
		{
			RequestList = requestList;
		}

		public IEnumerable<RequestDTO> RequestList { get; set; }
	}
}
