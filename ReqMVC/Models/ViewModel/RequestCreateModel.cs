using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Mvc.JQuery.DataTables;
using ReqMVC.Models.Domian;

namespace ReqMVC.Models.ViewModel
{

	public class RequestCreateModel
	{
		[DisplayName("Оборудование для заявки")]
		public List<DeviceInfoStringRep> DevicesList { get; set; }

		public RequestCreateModel()
		{
			DevicesList = new List<DeviceInfoStringRep>();
			Author = "";
			Text = "";
		}
		[Range(1,int.MaxValue,ErrorMessage = "Выберите оборудование для заявки")]
		[Required(ErrorMessage = "Выберите оборудование для загрузки")]
		public int DeviceId { get; set; }

		[DisplayName("Инициатор")]
		[Required(ErrorMessage = "Поле обязательно для заполнения")]
		public string Author { get; set; }
		[DisplayName("Текст заявки")]
		[Required(ErrorMessage = "Введите текст заявки")]
		public string Text { get; set; }
	}
}
