using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc.JQuery.DataTables;
using ReqMVC.Models.Domian;

namespace ReqMVC.Models.ViewModel
{
	public class RequestDTO
	{
		//[DataTables(DisplayName = "Номер заявки")]
		public int Id { get; set; }
		//[DataTables(DisplayName = "Организация")]
		public string Post { get; set; }
		//[DataTables(DisplayName = "Дата создания")]
		public DateTime DateCreated { get; set; }
		//[DataTables(DisplayName = "Подразделение")]
		public string Ops { get; set; }
		//[DataTables(DisplayName = "Модель оборудования")]
		public string Model { get; set; }
		//[DataTables(DisplayName = "Серийный номер")]
		public string SerialNumber { get; set; }
		//[DataTables(DisplayName = "Содержание заяки")]
		public string Text { get; set; }
		//[DataTables(DisplayName = "Закрыта")]
		public bool Solved { get; set; }
		//[DataTables(DisplayName = "Статус")]
		public string Status { get; set; }
		//[DataTables(DisplayName = "Примечание")]
		public string Comment { get; set; }
		//[DataTables(DisplayName = "Дата закрытия")]
		public string DateSolved { get; set; }

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
				SerialNumber = d.serial_number??"",
				Text = r.text??"",
				Solved = r.solved.HasValue && r.solved.Value,
				Status = r.status?.text??"",
				Comment = r.bf_comment??"",
				DateSolved = r.datesolved?.ToString("dd.MM.yyyy HH:mm:ss")??""
			};
		}
	}


	public class RequestViewModel
	{
		public RequestViewModel(IEnumerable<RequestDTO> requestList)
		{
			RequestList = requestList;
		}

		public RequestViewModel()
		{
			RequestList = new List<RequestDTO>();
		}

		public IEnumerable<RequestDTO> RequestList { get; set; }
	}
}
