using MinecraftLaunch.Base.Models.Game;
using MinecraftLaunch.Components.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sekota_McLauncher.Models.Game
{
    public class Installer
    {
        public static async Task Install(string version)
        {
            var entry = await ForgeInstaller.EnumerableForgeAsync(version, true).FirstOrDefaultAsync();

            var installer = ForgeInstaller.Create(Manager.MinecraftPath, Manager.JavaEntries.FirstOrDefault().JavaPath,
                entry);

            await installer.InstallAsync();
        }
    }
}
