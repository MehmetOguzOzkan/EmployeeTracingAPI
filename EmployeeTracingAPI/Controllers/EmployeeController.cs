using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeTracingAPI.Controllers
{
	[Route("api/employees")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private List<Employee> employeeList = new List<Employee>();

		// GET : employees/
		[HttpGet]
		public IActionResult GetAll()
		{
			return Ok(employeeList);
		}

		// GET : employees/id
		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var employee = employeeList.FirstOrDefault(b => b.Id==id);
			if (employee == null)
			{
				return NotFound();
			}

			return Ok(employee);
		}

		// POST : employees/
		[HttpPost]
		public IActionResult Create([FromBody] CreateEmployeeModel createEmployeeModel)
		{
			Employee employee = new Employee();
			employee.Id = GetNewEmployeeId();
			employee.Name = createEmployeeModel.Name;
			employee.Surname = createEmployeeModel.Surname;
			employee.Email = createEmployeeModel.Email;
			employee.Phone = createEmployeeModel.Phone;
			employee.Department = createEmployeeModel.Department;

			employeeList.Add(employee);
			return CreatedAtAction(nameof(GetNewEmployeeId), employee);
		}

		// PUT : employees/id
		[HttpPut("{id}")]
		public IActionResult UpdatePersonel(int id, [FromBody] UpdateEmployeeModel updateEmployeeModel)
		{
			Employee employee = employeeList.FirstOrDefault(p => p.Id == id);
			if (employee == null)
				return NotFound();

			employee.Name = updateEmployeeModel.Name;
			employee.Surname= updateEmployeeModel.Surname;
			employee.Email = updateEmployeeModel.Email;
			employee.Phone = updateEmployeeModel.Phone;
			employee.Department = updateEmployeeModel.Department;

			return NoContent();
		}

		// DELETE : employees/id
		[HttpDelete("{id}")]
		public IActionResult DeletePersonel(int id)
		{
			Employee employee = employeeList.FirstOrDefault(p => p.Id == id);
			if (employee == null)
				return NotFound();

			employeeList.Remove(employee);

			return NoContent();
		}

		private int GetNewEmployeeId()
		{
			Employee employee = employeeList.LastOrDefault();
			if (employee == null)
				return 0;
			return employee.Id+1;
		}
	}
}
