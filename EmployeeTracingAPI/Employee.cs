﻿using System.ComponentModel.DataAnnotations;

namespace EmployeeTracingAPI
{
	public class Employee
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		[EmailAddress]
		public string Email { get; set; }
		[Phone]
		public string Phone { get; set; }
		public string Department { get; set; }
	}
}
