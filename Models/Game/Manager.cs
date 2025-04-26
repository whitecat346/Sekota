using MinecraftLaunch.Base.Models.Game;
using MinecraftLaunch.Components.Parser;
using MinecraftLaunch.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sekota_McLauncher.Models.Game
{
    public class Manager
    {
        private static List<JavaEntry>? _javaEntries;

        public static List<JavaEntry> JavaEntries
        {
            get
            {
                _javaEntries ??= JavaUtil.EnumerableJavaAsync().ToListAsync().Result;
                return _javaEntries;
            }
        }

        public static string MinecraftPath = Path.Combine(RunningInfo.InstalledPath, ".minecraft");

        public static MinecraftParser MinecraftParser = MinecraftPath;

        private static List<MinecraftEntry>? _minecrafts;

        public static List<MinecraftEntry> Minecrafts
        {
            get
            {
                _minecrafts ??= MinecraftParser.GetMinecrafts();
                return _minecrafts;
            }
        }
    }
}
