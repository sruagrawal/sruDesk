using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sruDesk.DTOs;
using sruDesk.Models;

namespace sruDesk.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IMapper _mapper;

		static HttpClient client = new HttpClient();
		
		public HomeController(ILogger<HomeController> logger, IMapper mapper)
		{
			_logger = logger;
			_mapper = mapper;
		}

		public async Task<IActionResult> IndexAsync(int? index)
		{
			var data = await GetAppointments(); ;

			int max = data.Count() - 1;

			int currentIndex = index.GetValueOrDefault();
			if (currentIndex == 0)
			{
				ViewBag.NextIndex = 1;
			}
			else if (currentIndex >= max)
			{
				currentIndex = max;
				ViewBag.PreviousIndex = currentIndex - 1;
			}
			else
			{
				ViewBag.PreviousIndex = currentIndex - 1;
				ViewBag.NextIndex = currentIndex + 1;
			}

			Appointment appointment = data[currentIndex];

			return View(appointment);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public async Task<List<Appointment>> GetAppointments()
		{
			string apiURL = String.Format("https://petdesk-mobile-int.web.app/api/appointment.json");
			HttpResponseMessage res = await client.GetAsync(apiURL);
			res.EnsureSuccessStatusCode();
			var response = res.Content.ReadAsStringAsync().Result;
			var result = JsonSerializer.Deserialize<IList<AppointmentDto>>(response);
			var mapped = result.Select(a => _mapper.Map<Appointment>(a));
			return mapped.OrderBy(app => app.CreatedDateTime).ToList();
		}
	}
}
