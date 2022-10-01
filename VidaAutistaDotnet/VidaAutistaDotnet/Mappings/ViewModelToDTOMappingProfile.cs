using AutoMapper;
using VidaAutistaDotnet.API.ViewModels;
using VidaAutistaDotnet.Application.DTO;

namespace VidaAutistaDotnet.API.Mappings
{
  public class ViewModelToDTOMappingProfile : Profile
  {

    public ViewModelToDTOMappingProfile()
    {
      CreateMap<CalendarioDTO, CalendarioViewModel>().ReverseMap();
    }

  }
}
