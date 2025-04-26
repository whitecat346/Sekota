using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using Sekota_McLauncher.ViewModels;
using System.Reactive;
using System.Reactive.Disposables;

namespace Sekota_McLauncher.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            this.PointerPressed += MainWindowPinterPressed;

            this.WhenActivated(disposables =>
            {
                ViewModel.CloseWindowsInteraction.RegisterHandler(interaction =>
                {
                    this.Close();
                    interaction.SetOutput(Unit.Default);
                }).DisposeWith(disposables);

                ViewModel.MinimizeInteraction.RegisterHandler(interaction =>
                {
                    this.WindowState = WindowState.Minimized;
                    interaction.SetOutput(Unit.Default);
                }).DisposeWith(disposables);
            });

#if DEBUG
            this.AttachDevTools();
#endif

            AvaloniaXamlLoader.Load(this);
        }

        private void MainWindowPinterPressed(object? sender, PointerPressedEventArgs e)
        {
            if (e.Pointer.Type == PointerType.Mouse)
            {
                this.BeginMoveDrag(e);
            }
        }
    }
}