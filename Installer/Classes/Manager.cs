using System.IO;

namespace ISO_Builder.Classes
{
    public class Manager
    {
        public class ExtractRecourse
        {
            public void ViaBytes(string name, byte[] array)
            {
                File.WriteAllBytes(name, array);
            }

            public void ViaString(string name, string array)
            {
                File.WriteAllText(name, array);
            }
        }
    }
}
