namespace Shell.Language;

using Shell.Domain;


public static class Interpreter {
    public static ProgramState DispatchCommand(CommandData data,  Command cmd)
    {
        switch (data.Type)
        {
            case CommandType.Builtin:
                return ExecuteBuiltin(data, cmd);
           // case CommandType.Exe:
            //    return ExecuteExe(data, cmd);
            case CommandType.NotFound:
                return ExecuteNotFound(data);
            default:
                 throw new ArgumentException($"No way to interpret {data.Type}");


        }

    }

    private static ProgramState ExecuteBuiltin(CommandData data, Command cmd)
    {
        switch (data.Name)
        {
            case "exit":
                return ProgramState.Exiting;
            case "echo":
                Console.WriteLine(String.Join(" ", cmd.Args));
                return ProgramState.Running;
            case "type":
                var type = data.Type switch
                {
                    CommandType.Builtin => "a shell builtin",
                    CommandType.Exe => data.ExePath ?? throw new ArgumentException("Exe type shoudln't be allowed with no path provided"),
                    CommandType.NotFound => "not found",
                    _ => throw new ArgumentOutOfRangeException($"Cannot categorize Type {data.Type}")
                };
                Console.WriteLine($"{data.Name} is a {type}");
                return ProgramState.Running;
        }
        throw new ArgumentOutOfRangeException($"Cannot categorize Builtin {data.Name}");
    }


/**
    private static ProgramState ExecuteExe(ResolvedCommand cmd){
        return ProgramState.Running;
    }
    */
    private static ProgramState ExecuteNotFound(CommandData cmd){
        Console.WriteLine($"Command not found: {cmd.Name}");
        return ProgramState.Running;
    }

}
