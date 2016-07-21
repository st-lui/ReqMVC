﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqMVC.Models.ViewModel
{
	public class RegisterModel
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public int Year { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[Compare("Password", ErrorMessage = "Пароли не совпадают")]
		[DataType(DataType.Password)]
		public string PasswordConfirm { get; set; }
	}
}
