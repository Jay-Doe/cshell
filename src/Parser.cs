namespace src.Parser;

using System.Collections.Frozen;

public  static class Parser
{

    public static ParsedCommand? Parse(string input)
    {
        string[] tokens = input.Split(
            (char[]?)null, //char null for whitespace overload
            StringSplitOptions.RemoveEmptyEntries);

        return tokens.Length == 0
            ? null
            : new ParsedCommand(tokens[0], tokens[1..]);
    }

    public static void InvalidCommand(string cmd)
    {
        Console.WriteLine($"{cmd}: command not found");
    }


}

public sealed record ParsedCommand(string Name, IReadOnlyList<string> Arguments);
