using System;
using Mvc.JQuery.DataTables;

namespace ReqMVC.Models.ViewModel
{
	public class RequestDTO
	{
		[DataTables(DisplayName = "",Sortable = false)]
		public int EditId { get; set; }
		[DataTables(DisplayName = "Номер заявки")]
		public int Id { get; set; }
		[DataTables(DisplayName = "Организация")]
		public string Post { get; set; }
		[DataTables(DisplayName = "Дата создания")]
		public DateTime DateCreated { get; set; }
		[DataTables(DisplayName = "Подразделение")]
		public string Ops { get; set; }
		[DataTables(DisplayName = "Модель оборудования")]
		public string Model { get; set; }
		[DataTables(DisplayName = "Серийный номер")]
		public string SerialNumber { get; set; }
		[DataTables(DisplayName = "Содержание заявки")]
		public string Text { get; set; }
		[DataTables(DisplayName = "Закрыта")]
		public bool Solved { get; set; }
		[DataTables(DisplayName = "Статус")]
		public string Status { get; set; }
		[DataTables(DisplayName = "Примечание")]
		public string Comment { get; set; }
		[DataTables(DisplayName = "Дата закрытия")]
		public string DateSolved { get; set; }

	}
}