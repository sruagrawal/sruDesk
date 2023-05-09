using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using sruDesk.DTOs;
using sruDesk.Models;

namespace sruDesk
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<AppointmentDto, Appointment>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.appointmentId))
				.ForMember(dest => dest.Type, opt => opt.MapFrom((src, dest) => src.appointmentType))
				.ForMember(dest => dest.CreatedDateTime, opt => opt.MapFrom(src => src.createDateTime))
				.ForMember(dest => dest.RequestedDateTime, opt => opt.MapFrom(src => src.requestedDateTimeOffset.UtcDateTime))
				.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.user_UserId))
				.ForMember(dest => dest.AnimalId, opt => opt.MapFrom(src => src.animal_AnimalId))
			;

			CreateMap<AnimalDto, Animal>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.animalId))
			;

			CreateMap<UserDto, User>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.userId))
			;
		}
	}
}
