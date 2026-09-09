class Program
{
    static void Main()
    {
        while (true) {
            Console.WriteLine("$ ");
            string? x = Console.ReadLine();
            if (x == null){
                Console.WriteLine("Input is null exiting");
                continue;
            }
            Console.WriteLine($"{x}: not found");
        }
    }
}
