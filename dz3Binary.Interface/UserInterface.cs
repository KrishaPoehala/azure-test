using dz3Binary.Interface;
using dz3Binary.Interface.Attributes;
using System.Reflection;

namespace dz1_binary;

public class UserInterface
{
    private readonly Commands _commands = new();
    private readonly PrintResults _printResults = new();
    private readonly IEnumerable<MethodInfo> _methods;
    private readonly IEnumerable<MethodInfo> _printResultMethods;
    private readonly IDictionary<string, string> _commandNamesAndDescriptions;
    public UserInterface()
    {
        _methods = _commands
            .GetType()
            .GetMethods()
            .Where(m => m.GetCustomAttribute<CommandAttribute>() is not null);

        _commandNamesAndDescriptions = _methods
            .Select(m => m.GetCustomAttribute<CommandAttribute>())
            .ToDictionary(key => key.CommandSyntax, value => value.Description);

        _printResultMethods = _printResults
            .GetType()
            .GetMethods()
            .Where(m => m.GetCustomAttribute<TaskToPrintAttribute>() is not null);
    }
    public async Task Run()
    {
        Console.WriteLine("Welcome to my program! Print help to see the commands");
        while (true)
        {
            var sourceStr = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(sourceStr))
                continue;

            var tokens = sourceStr.Trim().Split(' ');
            if (tokens.Length >= 3)
            {
                Console.WriteLine("There are too many parameters.None of the commands has so many");
                continue;
            }

            CallTheRightCommand(tokens);
        }
    }

    private async void CallTheRightCommand(string[] tokens)
    {
        if (IsHelpCommand(tokens))
        {
            Help();
            return;
        }

        var methodToInvoke = _methods
            .SingleOrDefault(m => m.GetCustomAttribute<CommandAttribute>().CommandName == tokens[0]);

        if (methodToInvoke is null)
        {
            Console.WriteLine($"There is no such a comamnd as {tokens[0]}");
            return;
        }

        if (methodToInvoke.GetParameters().Length != tokens.Length - 1)
        {
            Console.WriteLine("Wrong parameters count");
            return;
        }

        object result;
        if (tokens.Length == 2)
        {
            var param = int.Parse(tokens[1]);
            result = methodToInvoke.Invoke(_commands, new object[] { param });
        }
        else
        {
            result = methodToInvoke.Invoke(_commands, null);
        }

        PrintResult(methodToInvoke, result);
    }

    private void PrintResult(MethodInfo methodToInvoke, object result)
    {
        Console.WriteLine("----------------START---------------");
        var methodOrder = methodToInvoke.GetCustomAttribute<CommandAttribute>().CommandNumber;
        var printMethod = _printResultMethods
            .SingleOrDefault(m => m.GetCustomAttribute<TaskToPrintAttribute>().TasksToPrint.Contains(methodOrder));
        printMethod.Invoke(_printResults, new[] { result });
        Console.WriteLine("----------------END---------------");
    }

    private void Help()
    {
        Console.WriteLine("Here are the list of commands you can use");
        foreach (var (key, value) in _commandNamesAndDescriptions)
        {
            Console.WriteLine(key);
            Console.WriteLine("\t" + value);
        }
    }
    private static bool IsHelpCommand(string[] tokens) =>
        tokens.Length == 1 && string.Compare(tokens[0], "help", true) == 0;
}
