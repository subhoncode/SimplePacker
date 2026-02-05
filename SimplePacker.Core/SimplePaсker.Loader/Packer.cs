using System.Reflection;

namespace SimplePaсker.Loader
{
    internal class Packer
    {
        private static readonly byte[] _key = { 0x13, 0x37, 0xAF, 0x22, 0x99 };

        public static void Protect(string inputFile, string outputFile)
        {
            if (!File.Exists(inputFile)) return;

            byte[] data = File.ReadAllBytes(inputFile);
            XorTransform(data);

            File.WriteAllBytes(outputFile, data);
            File.Delete(inputFile);

            Console.WriteLine($"[Packer] Binary successfully encoded:\n{inputFile}");
        }

        public static void Launch(string binFile, string typeName, string methodName)
        {
            if (!File.Exists(binFile))
            {
                Console.WriteLine("[Error] Binary not found.");
                return;
            }

            byte[] data = File.ReadAllBytes(binFile);
            XorTransform(data);

            Assembly assembly = Assembly.Load(data);
            Type? type = assembly.GetType(typeName);

            if (type != null)
            {
                object? instance = Activator.CreateInstance(type);
                type.GetMethod(methodName)?.Invoke(instance, null);
            }
        }

        private static void XorTransform(byte[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] ^= _key[i % _key.Length];
            }
        }
    }
}