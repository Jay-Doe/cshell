using Shell.Language;
using Shell.BuiltIn;
using Shell.Domain;
using Shell.Platform;

class Program
{
    static void Main()
    {

        while (true)
        {
            Console.Write("$ ");
            string? x = Console.ReadLine();
            if (x == null)
            {
                Console.WriteLine("Input is null exiting");
                return;
            }
            var words = Lexer.Lex(x);
            var cmd = Parser.ParseWords(words);
            var cmd_data = Parser.ResolveCmd(cmd.Name);
            Interpreter.DispatchCommand(cmd_data, cmd);

        }
    }
}
