using System.Reflection;

namespace SimplePacker.Loader
{
    internal class Packer
    {
        private static readonly byte[] _key = { 0x13, 0x37, 0xAF, 0x22, 0x99 };

        public static void Protect(string inputFile, string outputFile)
        {
            File.WriteAllBytes(outputFile, Pack(inputFile));
            File.Delete(inputFile);

            Console.WriteLine($"[Packer] Binary successfully encoded:\n{inputFile}");
        }

        public static void Launch(string binFile, string typeName, string methodName)
        {
            Assembly assembly = Assembly.Load(Pack(binFile));
            Type? type = assembly.GetType(typeName);

            if (type == null)
                return;

            object? instance = Activator.CreateInstance(type);
            type.GetMethod(methodName)?.Invoke(instance, null);
        }

        private static byte[] Pack(string file)
        {
            if (!File.Exists(file))
            {
                Console.WriteLine("[Error] Binary not found.");
                return new byte[0];
            }

            byte[] data = File.ReadAllBytes(file);
            XorTransform(data);

            return data;
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

