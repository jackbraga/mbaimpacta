using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaAutistaDotnet.Application.DTO;
using VidaAutistaDotnet.Domain.Entities;

namespace VidaAutistaDotnet.Application.Mappings
{
  public class DomainToDTOMappingProfile: Profile
  {

    public DomainToDTOMappingProfile()
    {
      CreateMap<Calendario, CalendarioDTO>().ReverseMap();
    }
    
  }
}
