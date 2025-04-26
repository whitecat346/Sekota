using ReactiveUI;
using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Sekota_McLauncher.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase, IScreen
    {
        private IRoutableViewModel _currentViewModel;

        public MainWindowViewModel()
        {
            // Initialize Close and Minimize Commands
            CloseWindowCommand = ReactiveCommand.CreateFromTask(CloseWindowAsync);
            MinimizeWindowCommand = ReactiveCommand.CreateFromTask(MinimizeWindowsAsync);

#if DEBUG
            CloseWindowCommand.ThrownExceptions.Subscribe(ex => HandleError("CloseCommand", ex));
            MinimizeWindowCommand.ThrownExceptions.Subscribe(ex => HandleError("Minimize", ex));
#endif
            // Initialize Home and About Commands
            HomeCommand =
                ReactiveCommand.CreateFromObservable(() =>
                    ViewModelChanger(new HomeViewModel(this))); // TODO: add can executable

            AboutCommand =
                ReactiveCommand.CreateFromObservable(() =>
                    Router.Navigate.Execute(new AboutViewModel(this))); // TODO: add can executable

            // Switch to Home View
            var home = new HomeViewModel(this);
            _currentViewModel = home;
            Router.Navigate.Execute(home);
        }

        private IObservable<IRoutableViewModel> ViewModelChanger(IRoutableViewModel viewModel)
        {
            _currentViewModel = viewModel;
            return Router.Navigate.Execute(viewModel);
        }

        public Interaction<Unit, Unit> CloseWindowsInteraction { get; } = new();
        public Interaction<Unit, Unit> MinimizeInteraction { get; } = new();

        public ReactiveCommand<Unit, Unit> CloseWindowCommand { get; }

        public ReactiveCommand<Unit, Unit> MinimizeWindowCommand { get; }

        private async Task CloseWindowAsync()
        {
            await CloseWindowsInteraction.Handle(Unit.Default);
        }

        private async Task MinimizeWindowsAsync()
        {
            await MinimizeInteraction.Handle(Unit.Default);
        }

#if DEBUG
        private static void HandleError(string message, Exception e) => Console.WriteLine($"{message}\n{e.Message}");
#endif
        /// <inheritdoc />
        public RoutingState Router { get; } = new();

        public ReactiveCommand<Unit, IRoutableViewModel> HomeCommand { get; }
        public ReactiveCommand<Unit, IRoutableViewModel> AboutCommand { get; }
    }
}
