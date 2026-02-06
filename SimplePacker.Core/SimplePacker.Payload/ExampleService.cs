using System;

namespace SimplePacker.Payload
{
    public class ExampleService
    {
        public void Execute()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n[SUCCESS] Payload launched!");
            Console.WriteLine("[INFO] PE-header decoded.");
            Console.ResetColor();
        }
    }
}