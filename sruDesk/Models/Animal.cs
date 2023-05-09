using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sruDesk.Models
{
	public class Animal
	{
		[Key]
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string Species { get; set; }
		public string Breed { get; set; }
	}
}
