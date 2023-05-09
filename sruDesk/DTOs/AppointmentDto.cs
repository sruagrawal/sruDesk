using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sruDesk.DTOs
{
	public class AppointmentDto
	{
		public int appointmentId { get; set; }
		public string appointmentType { get; set; }
		public DateTime createDateTime { get; set; }
		public DateTimeOffset requestedDateTimeOffset { get; set; }
		public int user_UserId { get; set; }

		public UserDto user { get; set; }
		public int animal_AnimalId { get; set; }

		public AnimalDto animal { get; set; }
	}
}
