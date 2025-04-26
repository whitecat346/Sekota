using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using Sekota_McLauncher.ViewModels;

namespace Sekota_McLauncher;

public partial class AboutView : ReactiveUserControl<AboutViewModel>
{
    public AboutView()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }
}