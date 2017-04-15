using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LoginTraining
{
	/// <summary>
	/// Employee.
	/// </summary>
	public class Employee
	{
		/// <summary>
		/// Gets or sets the role.
		/// </summary>
		/// <value>The role.</value>
		public String Role { get; set; }
		/// <summary>
		/// Gets or sets the passcode.
		/// </summary>
		/// <value>The passcode.</value>
		public String Passcode { get; set; }
		/// <summary>
		/// Gets or sets the selected role.
		/// </summary>
		/// <value>The selected role.</value>
		public String SelectedRole { get; set; }
	}

	/// <summary>
	/// Employee dump data.
	/// </summary>
	public static class EmployeeDumpData
	{
		//string jsonData = @"{ 'rolejson': [
  //      {'Role': 'Admin1', 'Passcode': '123' },
  //  	{'Role': 'Admin2', 'Passcode': '123' },
  //      {'Role': 'Admin3', 'Passcode': '123' },
  //      {'Role': 'Staff1', 'Passcode': '123' },
  //      {'Role': 'Staff2', 'Passcode': '123' },
  //      {'Role': 'Staff3', 'Passcode': '123' },
  //      {'Role': 'Staff4', 'Passcode': '123' },
  //      {'Role': 'Staff5','Passcode': '123'  },]}";
		
		//public static List<Employee> GetQuotes()
		//{
		//	List<Employee> questions = JsonConvert.DeserializeObject<List<Employee>>(jsonData);
		//	return questions;
		//}

		public static List<Employee> data = new List<Employee>()
		{
			new Employee
			{
				Role = "Admin",
				Passcode = "123"
			},
			new Employee
			{
				Role = "Staff1",
				Passcode = "4444"
			},
			new Employee
			{
				Role = "Staff2",
				Passcode = "3333"
			},
			new Employee
			{
				Role = "Staff3",
				Passcode = "2222"
			},
			new Employee
			{
				Role = "Staff4",
				Passcode = "1111"
			}
		};
		/// <summary>
		/// Gets or sets the index of the selected.
		/// </summary>
		/// <value>The index of the selected.</value>
		public static int SelectedIndex { get; set; }
	}
}
