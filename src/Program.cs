using src.Parser;

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
                default:
                    Parser.InvalidCommand(command.Name);
                    break;
            }
        }
    }
}
