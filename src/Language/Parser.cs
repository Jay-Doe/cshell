namespace Shell.Language;

using Shell.Domain;
using Shell.Platform;


public static class Lexer
{
    public static readonly string[] BuiltIns = ["cd", "type", "exit", "echo"];
    public static IReadOnlyList<Word> Lex(string input)
    {
        string[] tokens = input.Split(
            (char[]?)null, //char null for whitespace overload
            StringSplitOptions.RemoveEmptyEntries);

        if (tokens.Length == 0)
        {
            return [new Word("")];
        }

        List<Word> words = [];
        foreach (string token in tokens)
        {
            var t = new Word(token);
            words.Add(t);

        }
        return words;

    }

}

public static class Parser
{
    public static Command ParseWords(IReadOnlyList<Word> words)
    {
        if (words[0].Val == "")
        {
            return new Command("None", []);
        }
        var name = words[0].Val;
        var args = words.Skip(1).Select(w => w.Val).ToList();
        return new Command(name, args);
    }

    public static CommandData ResolveCmd(string name)
    {
        if (name == "None"){
            return new CommandData(CommandType.NotFound, name);
        }

        bool IsBuiltIn = Lexer.BuiltIns.Contains(name);
        if (IsBuiltIn) {
            return new CommandData(CommandType.Builtin, name);
        }
        string? ExePath = Platform.FindExe(name);
        if (ExePath is not null){
            return new CommandData(CommandType.Exe, name, ExePath);
        }
        return new CommandData(CommandType.NotFound, name);
    }

}
