using src.Parser;
using src.BuiltIn;

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

            ParsedCommand? command = Parser.Parse(x);
            if (command is null)
            {
                continue;
            }

            //handler
            switch (command.Name)
            {
                case "exit":
                    return;
                case "echo":
                    string echo = string.Join(" ", command.Arguments);
                    Console.WriteLine(echo);
                    break;
                case "type":
                    if (command.Arguments.Count == 0)
                    {
                        break;
                    }
                    string y = command.Arguments[0];
                    if (BuiltIn.IsBuiltin(y)){
                        BuiltIn.TypeBuiltin(y);
                        break;
                    }
                    Console.WriteLine($"{y}: not found");
                    break;
                default:
                    Parser.InvalidCommand(command.Name);
                    break;
            }
        }
    }
}
