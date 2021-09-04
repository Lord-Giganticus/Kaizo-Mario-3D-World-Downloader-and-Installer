using System;
using System.IO;
using System.Reflection;


namespace Updater.Classes
{
    internal class Data
    {
        internal static FileInfo ExeInfo
        {
            get => new(Assembly.GetExecutingAssembly().Location);
        }

        internal static DirectoryInfo ExeDir
        {
            get => ExeInfo.Directory ?? new DirectoryInfo(Path.GetDirectoryName(ExeInfo.FullName));
        }

        internal static DateTime CompileTime
        {
            get => ExeInfo.LastWriteTime;
        }

        internal static DateTimeOffset CompileTimeOffest
        {
            get => ExeInfo.LastWriteTimeUtc;
        }
    }
}
