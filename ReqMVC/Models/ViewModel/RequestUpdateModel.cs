using ReqMVC.Models.Domian;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ReqMVC.Models.ViewModel
{
	public class RequestUpdateModel
	{
		public int id { get; set; }

		[StringLength(4096)]
		[DisplayName("Текст заявки")]
		[Required(ErrorMessage = "Введите текст заявки")]
		public string text { get; set; }

		[DisplayName("Дата создания")]
		public DateTime datecreated { get; set; }

		[DisplayName("Дата закрытия")]
		[DataType(DataType.DateTime, ErrorMessage = "Дата введена в некорректном формате, корректный формат ДД.ММ.ГГГГ чч:мм:сс")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy hh:mm:ss}")]
		public DateTime? datesolved { get; set; }

		[DisplayName("Инициатор")]
		[StringLength(512)]
		[Required(ErrorMessage="Поле обязательно для заполнения")]
		public string contact { get; set; }

		[DisplayName("Закрытие")]
		public bool? solved { get; set; }

		[DisplayName("Статус")]
		public SelectList statusList { get; set; }

		public int? status_id { get; set; }

		[DisplayName("Примечание")]
		[StringLength(1024)]
		public string bf_comment { get; set; }

		public virtual deviceinfo deviceinfo { get; set; }
		public string organization { get; set; }
	}
}
