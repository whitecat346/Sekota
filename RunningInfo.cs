using System;
using System.IO;

namespace Sekota_McLauncher
{
    public class RunningInfo
    {
        public static readonly char Separator = Path.DirectorySeparatorChar;

        public static readonly string NewLine = Environment.NewLine;

        public static readonly string CurrentPath = Environment.CurrentDirectory;

        public static readonly string InstalledPath = AppDomain.CurrentDomain.BaseDirectory;
    }
}
