namespace src.BuiltIn;
using System.Collections.Frozen;

public static class BuiltIn {
    private static readonly FrozenSet<string> BuiltIns = ["cd", "exit", "type", "echo"];

    public static bool IsBuiltin(string cmd)
    {
        if (BuiltIns.Contains(cmd))
        {
            return true;
        }
        else return false;

    }
    public static void TypeBuiltin(string cmd){
        Console.WriteLine($"{cmd} is  a shell builtin");
    }




}
