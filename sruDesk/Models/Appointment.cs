using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sruDesk.Models
{
	public class Appointment
	{
		[Key]
		public int Id { get; set; }
		public string Type { get; set; }
		public DateTime CreatedDateTime { get; set; }
		public DateTime RequestedDateTime { get; set; }
		public int UserId { get; set; }
		public User User { get; set; }
		public int AnimalId { get; set; }
		public Animal Animal { get; set; }
	}
}
