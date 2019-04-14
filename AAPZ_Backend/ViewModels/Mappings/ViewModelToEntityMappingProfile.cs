using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AAPZ_Backend.Models.Tokens;
using AAPZ_Backend.Models;
using AAPZ_Backend.ViewModels.Validations;
using AutoMapper;

namespace AAPZ_Backend.ViewModels.Mappings
{
    public class ViewModelToEntityMappingProfile : Profile
    {
        public ViewModelToEntityMappingProfile()
        {
            CreateMap<RegistrationViewModel, User>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));
        }
    }
}
