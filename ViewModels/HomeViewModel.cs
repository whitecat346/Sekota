using ReactiveUI;
using Sekota_McLauncher.Models.Game;
using System;
using System.Reactive;
using System.Threading.Tasks;

namespace Sekota_McLauncher.ViewModels
{
    public class HomeViewModel : ViewModelBase, IRoutableViewModel
    {
        /// <inheritdoc />
        public string? UrlPathSegment { get; } = Guid.NewGuid().ToString()[..5];

        /// <inheritdoc />
        public IScreen HostScreen { get; }


        public ReactiveCommand<Unit, Unit> LaunchCommand { get; }
        public ReactiveCommand<Unit, Unit> InstallCommand { get; }

        public HomeViewModel(IScreen screen)
        {
            HostScreen = screen;

            LaunchCommand = ReactiveCommand.CreateFromTask(LaunchMinecraft);
            InstallCommand = ReactiveCommand.CreateFromTask(Install);
        }

        private static async Task LaunchMinecraft() => await Launch.LaunchMinecraft("1.20.1");
        private static async Task Install() => await Installer.Install("1.20.1");
    }
}
