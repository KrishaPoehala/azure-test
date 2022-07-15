namespace dz3Binary.Common.DTO.Project;

public record NewProjectDTO
{
    public string Name { get; init; }
    public string? Description { get; init; }
    public DateTime Deadline { get; init; }
    public DateTime CreatedAt { get; init; }
}
