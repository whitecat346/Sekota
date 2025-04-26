using System;
using Avalonia;
using Avalonia.ReactiveUI;
using MinecraftLaunch;
using MinecraftLaunch.Components.Provider;
using MinecraftLaunch.Utilities;

namespace Sekota_McLauncher
{
    internal sealed class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args)
        {
            DownloadMirrorManager.MaxThread = 256;
            DownloadMirrorManager.IsEnableMirror = false;
            HttpUtil.Initialize();

            BuildAvaloniaApp()
                .StartWithClassicDesktopLifetime(args);
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp() =>
            AppBuilder.Configure<App>()
                .UseReactiveUI()
                .UsePlatformDetect()
                .LogToTrace();
    }
}
