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
                foreach (var target in cmd.Args)
                {
                    var targetData = Parser.ResolveCmd(target);
                    switch (targetData.Type)
                    {
                        case CommandType.Builtin:
                            Console.WriteLine($"{target} is a shell builtin");
                            break;
                        case CommandType.Exe:
                            Console.WriteLine($"{target} is {targetData.ExePath}");
                            break;
                        case CommandType.NotFound:
                            Console.WriteLine($"{target}: not found");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(
                                $"Cannot categorize Type {targetData.Type}");
                    }
                }
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
        Console.WriteLine($"{cmd.Name}: command not found");
        return ProgramState.Running;
    }

}
