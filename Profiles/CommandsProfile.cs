using AutoMapper;
using Commander.DTOs;
using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandReadDto>(); //convert #Command to #CommandReadDto

            CreateMap<CommandWriteDto, Command>(); //convert #CommandWriteDto to #Command

            CreateMap<Command, CommandWriteDto>();
        }
    }
}
