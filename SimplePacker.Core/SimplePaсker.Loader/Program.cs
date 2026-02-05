namespace SimplePaсker.Loader
{
    internal class Program
    {
        private const string SOURCE_DLL = "SimplePacker.Payload.dll";
        private const string TARGET_BIN = "payload.dll";

        static void Main(string[] args)
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("        SIMPLE PACKER LOADER             ");
            Console.WriteLine("=========================================\n");
            

            Packer.Protect(SOURCE_DLL, TARGET_BIN);

            Packer.Launch(
                binFile: TARGET_BIN,
                typeName: "SimplePacker.Payload.ExampleService",
                methodName: "Execute"
            );

            Console.WriteLine("\n[*] Payload executed. Press any key to exit");
            Console.ReadKey();
        }
    }
}