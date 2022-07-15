
namespace dz3Binary.Common.DTO.Task;

public record TaskDTO
{
    public int Id { get; set; }
    public string RenamedName { get; init; }
    public string Description { get; init; }
    public int State { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? FinishedAt { get; init; }
}
