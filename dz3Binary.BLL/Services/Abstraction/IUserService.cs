using dz3Binary.Common.DTO.User;

namespace dz3Binary.BLL.Services.Abstraction
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetSortedUsers();
        IEnumerable<UserTasksInfoDTO> GetTasksInfo(int userId);
        Task<DeletedUserDTO> DeleteUser(int userId);
        Task<UserDTO> GetFirst();
        Task<UserDTO> CreateUser(NewUserDTO dto);
        Task PutUser(UserDTO userDTO);
    }
}