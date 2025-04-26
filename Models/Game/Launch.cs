using MinecraftLaunch.Base.Models.Game;
using MinecraftLaunch.Components.Authenticator;
using MinecraftLaunch.Extensions;
using MinecraftLaunch.Launch;
using System.Threading.Tasks;

namespace Sekota_McLauncher.Models.Game
{
    public class Launch
    {
        public static async Task LaunchMinecraft(string version)
        {
            var targetMinecraft = Manager.MinecraftParser.GetMinecraft(version);
            MinecraftRunner runner =
                new(
                    new LaunchConfig
                    {
                        Account = new OfflineAuthenticator().Authenticate("test"),
                        MaxMemorySize = 2048,
                        MinMemorySize = 512,
                        LauncherName = "MinecraftLauncher",
                        JavaPath = targetMinecraft.GetAppropriateJava(Manager.JavaEntries)
                    }, Manager.MinecraftParser);

            var process = await runner.RunAsync(targetMinecraft);
        }
    }
}
