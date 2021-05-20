using System.IO;

namespace Installer.Classes
{
    public class Manager
    {
        public class ExtractRecourse
        {
            public static void ViaBytes(string name, byte[] array)
            {
                File.WriteAllBytes(name, array);
            }

            public static void ViaString(string name, string array)
            {
                File.WriteAllText(name, array);
            }
        }
    }
}
