using Avalonia.Animation;
using Avalonia.Animation.Easings;
using Avalonia.Media;
using Avalonia.Styling;
using System;

namespace Sekota_McLauncher.Animations
{
    public class RotateTransformAngleAnimation(
        Animatable control,
        double? before = null,
        double? after = null,
        Easing? easing = null,
        TimeSpan? duration = null,
        TimeSpan? delay = null) : BaseAnimations(control, before, after, easing, duration, delay)
    {
        /// <inheritdoc />
        public override Animation RunAsyncBuilder() =>
            new()
            {
                Easing = Easing,
                Duration = Duration,
                Delay = Delay,
                FillMode = FillMode.Both,
                Children =
                {
                    new KeyFrame { Setters = { new Setter(RotateTransform.AngleProperty, Before) }, Cue = new Cue(0d) },
                    new KeyFrame { Setters = { new Setter(RotateTransform.AngleProperty, After) }, Cue = new Cue(1d) }
                }
            };
    }
}
