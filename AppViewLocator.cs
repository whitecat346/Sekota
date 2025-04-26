using ReactiveUI;
using Sekota_McLauncher.ViewModels;
using System;

namespace Sekota_McLauncher
{
    public class AppViewLocator : IViewLocator
    {
        /// <inheritdoc />
        public IViewFor? ResolveView<T>(T? viewModel, string? contract = null) =>
            viewModel switch
            {
                HomeViewModel context => new HomeView { DataContext = context },
                AboutViewModel context => new AboutView { DataContext = context },
                _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
            };
    }
}
