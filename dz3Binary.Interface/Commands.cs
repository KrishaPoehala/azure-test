using dz3Binary.Common.DTO.Project;
using dz3Binary.Common.DTO.Task;
using dz3Binary.Common.DTO.Team;
using dz3Binary.Common.DTO.User;
using dz3Binary.Interface.Attributes;
using Newtonsoft.Json;

namespace dz3Binary.Interface;

public class Commands
{
    private readonly HttpClient _client;
    private const string BASE_URL = "http://localhost:5052/api";
    public Commands()
    {
        _client = new HttpClient();
    }

    [Command("getProjectAndTasksCount userId",
         "gets the project and the count of its tasks of a user identified by its id", 1)]
    public IDictionary<int, ProjectDTO> GetProjectsById(int id)
    {
        var response = _client.GetAsync(BASE_URL + "/Task/tasksCountByProject" + id)
            .GetAwaiter().GetResult();
        var str = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        return JsonConvert.DeserializeObject<IDictionary<int, ProjectDTO>>(str);
    }

    [Command("getTasks userId",
         "gets the tasks for a user identified by its id", 2)]
    public IEnumerable<TaskDTO> GetTasks(int id)
    {
        var response = _client.GetAsync(BASE_URL + "/Task/tasks" + id)
            .GetAwaiter().GetResult();
        var str = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        return JsonConvert.DeserializeObject<IEnumerable<TaskDTO>>(str);
    }

    [Command("getFinishedTasks",
         "gets tasks that were finished in 2022", 3)]
    public IEnumerable<IdNameOnlyTaskDTO> GetFinishedTasks(int id)
    {
        var response = _client.GetAsync(BASE_URL + "/Task/finishedTasks" + id)
            .GetAwaiter().GetResult();
        var str = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        return JsonConvert.DeserializeObject<IEnumerable<IdNameOnlyTaskDTO>>(str);
    }

    [Command("getTeams",
          "gets the list of teams which members are older than 10 years", 4)]
    public IEnumerable<IdNameMembersOnlyTeamDTO> GetTeams()
    {
        var response = _client.GetAsync(BASE_URL + "/Task/teamInfo")
            .GetAwaiter().GetResult();
        var str = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        return JsonConvert.DeserializeObject<IEnumerable<IdNameMembersOnlyTeamDTO>>(str);
    }

    [Command("getSortedUsers",
          "gets sorted users with sorted task(by name's length)", 5)]
    public IEnumerable<UserDTO> GetSortedUsers()
    {
        var response = _client.GetAsync(BASE_URL + "/User/sortedUsers/")
            .GetAwaiter().GetResult();
        var str = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        return JsonConvert.DeserializeObject<IEnumerable<UserDTO>>(str);
    }

    //6
    [Command("task6Get userId",
          "gets the custom list(user,last created project,canceled and" +
        "in-progress count and longest task)", 6)]
    public IEnumerable<UserTasksInfoDTO> GetSixthTaskDTOs(int id)
    {
        var response = _client.GetAsync(BASE_URL + "User/tasksInfo/" + id)
            .GetAwaiter().GetResult();
        var str = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        return JsonConvert.DeserializeObject<IEnumerable<UserTasksInfoDTO>>(str);
    }

    //7
    [Command("task7Get",
          "gets the custom list(project,its longest and shortes task,and the amount of users in a team)", 7)]
    public IEnumerable<ProjectTasksInfoDTO> GetSevethTaskDTOs()
    {
        var response = _client.GetAsync(BASE_URL + "/Project/projectInfo")
            .GetAwaiter().GetResult();
        var str = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        return JsonConvert.DeserializeObject<IEnumerable<ProjectTasksInfoDTO>>(str);
    }
}
