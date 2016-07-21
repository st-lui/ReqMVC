using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReqMVC.Models;

namespace ReqMVC.Models.ViewModel
{
	public class LoginModel
	{
		[Required]
		public string Name { get; set; }
		[Required]
		[DisplayName("Пароль")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
