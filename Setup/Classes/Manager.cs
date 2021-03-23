using System.IO;

namespace Setup.Classes
{
    public class Manager
    {
        public class ExtractResource
        {
            public void Bytes(string name, byte[] array)
            {
                File.WriteAllBytes(name, array);
            }

            public void String(string name, string array)
            {
                File.WriteAllText(name, array);
            }
        }
    }
}
