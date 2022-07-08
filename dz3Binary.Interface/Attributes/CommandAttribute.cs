namespace dz3Binary.Interface.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class CommandAttribute : Attribute
{
    public string CommandSyntax { get; init; }
    public string Description { get; init; }
    public string CommandName { get; init; }
    public int CommandNumber { get; set; }
    public CommandAttribute(string commandSyntax, string description, int commandNumber)
    {
        CommandSyntax = commandSyntax;
        Description = description;
        int spaceIndex = CommandSyntax.IndexOf(' ');
        CommandName = spaceIndex == -1 ? CommandSyntax : CommandSyntax.Remove(spaceIndex);
        CommandNumber = commandNumber;
    }
}
