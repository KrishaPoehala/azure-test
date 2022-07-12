﻿using dz3Binary.Common.DTO.User;

namespace dz3Binary.BLL.Services.Abstraction
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetSortedUsers();
        IEnumerable<UserTasksInfoDTO> GetTasksInfo(int userId);
    }
}