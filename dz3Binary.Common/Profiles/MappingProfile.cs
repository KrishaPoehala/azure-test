﻿
using AutoMapper;
using dz3Binary.Common.DTO.Project;
using dz3Binary.Common.DTO.Task;
using dz3Binary.Common.DTO.Team;
using dz3Binary.Common.DTO.User;
using dz3Binary.DAL.Entities;

namespace dz3Binary.Common.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDTO>();

        CreateMap<Project, ProjectDTO>();

        CreateMap<DAL.Entities.Task, TaskDTO>();
        CreateMap<DAL.Entities.Task, IdNameOnlyTaskDTO>();

        CreateMap<Team, TeamDTO>();
        CreateMap<Team, IdNameMembersOnlyTeamDTO>();
    }
}