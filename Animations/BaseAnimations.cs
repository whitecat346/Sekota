using Avalonia.Animation;
using Avalonia.Animation.Easings;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sekota_McLauncher.Animations
{
    public abstract class BaseAnimations(
        Animatable control,
        double? before = null,
        double? after = null,
        Easing? easing = null,
        TimeSpan? duration = null,
        TimeSpan? delay = null)
        : IAnimations
    {
        /// <inheritdoc />
        public TimeSpan Delay { get; set; } = delay ?? TimeSpan.Zero;

        /// <inheritdoc />
        public bool Wait { get; set; }

        private readonly CancellationTokenSource _cancellationTokenSource = new();
        public Animatable Control { get; set; } = control;
        public TimeSpan Duration { get; set; } = duration ?? TimeSpan.FromSeconds(1);
        public double? Before { get; set; } = before;
        public double? After { get; set; } = after;
        public Easing Easing { get; set; } = easing ?? new LinearEasing();


        ///<inheritdoc/>
        public async Task RunAsync() => await RunAsyncBuilder().RunAsync(Control, _cancellationTokenSource.Token);

        /// <summary>
        /// Build the animation
        /// </summary>
        /// <returns><see cref="Animation"/> The animation</returns>
        public abstract Animation RunAsyncBuilder();


        /// <inheritdoc />
        public void Cancel()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}
