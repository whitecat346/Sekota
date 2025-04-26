using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sekota_McLauncher.ViewModels
{
    public class AboutViewModel : ReactiveObject, IRoutableViewModel
    {
        /// <inheritdoc />
        public string? UrlPathSegment { get; } = Guid.NewGuid().ToString()[..5];

        /// <inheritdoc />
        public IScreen HostScreen { get; }

        public AboutViewModel(IScreen screen) => HostScreen = screen;
    }
}
