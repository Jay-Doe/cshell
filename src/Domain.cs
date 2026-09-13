namespace Shell.Domain;


public sealed record CommandLine(IReadOnlyList<Word> Words);

public sealed record Word(string Val);

public sealed record Command(string Name, IReadOnlyList<string> Args);

public enum ProgramState
{
    Running,
    Exiting,

}


public enum CommandType
{
    Builtin,
    Exe,
    NotFound,
}



public sealed record CommandData(CommandType Type, string Name, string? ExePath = null);
