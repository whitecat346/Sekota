using Avalonia;
using Avalonia.Animation.Easings;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Media;
using Sekota_McLauncher.Animations;
using Sekota_McLauncher.Helpers;
using Semi.Avalonia.Locale;
using System;
using ColorHelper = Sekota_McLauncher.Helpers.ColorHelper;

namespace Sekota_McLauncher.Controls;

public class CycleButton : Button
{
    private          Border?         _panForeground;
    private readonly AnimationHelper _animation = new();
    private          Path?           _icon;
    public           int             Uuid = Guid.NewGuid().GetHashCode();

    /// <inheritdoc />
    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        _panForeground = e.NameScope.Find<Border>("PanForeground");
        _icon          = e.NameScope.Find<Path>("Icon");
    }

    public static readonly StyledProperty<Geometry?> DataProperty =
        AvaloniaProperty.Register<CycleButton, Geometry?>(nameof(Data));

    public Geometry? Data
    {
        get => GetValue(DataProperty);
        set
        {
            SetValue(DataProperty, value);
            if (_icon != null)
            {
                _icon.Data = value;
            }
        }
    }

    public static readonly StyledProperty<double> ScaleProperty =
        AvaloniaProperty.Register<CycleButton, double>(nameof(Scale));

    public double Scale
    {
        get => GetValue(ScaleProperty);
        set
        {
            SetValue(ScaleProperty, value);
            if (_icon != null)
            {
                _icon.RenderTransform = new ScaleTransform(value, value);
            }
        }
    }

    public static new readonly StyledProperty<Transform> RenderTransformProperty =
        AvaloniaProperty.Register<CycleButton, Transform>(nameof(RenderTransform));

    public new Transform RenderTransform
    {
        get => GetValue(RenderTransformProperty);
        set => SetValue(RenderTransformProperty, value);
    }

    /// <inheritdoc />
    protected override async void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);

        if (!e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
            return;

        _animation.Clear();
        _animation.Animations.AddRange([
            new ScaleTransformXAnimation(control: this, duration: TimeSpan.FromMilliseconds(80),
                                         before: this.GetValue(ScaleTransform.ScaleXProperty), after: 0.955,
                                         easing: new CubicEaseOut()),
            new ScaleTransformYAnimation(control: this, duration: TimeSpan.FromMilliseconds(80),
                                         before: this.GetValue(ScaleTransform.ScaleYProperty), after: 0.955,
                                         easing: new CubicEaseOut())
        ]);
        await _animation.RunAsync();
    }

    /// <inheritdoc />
    protected override async void OnPointerReleased(PointerReleasedEventArgs e)
    {
        base.OnPointerReleased(e);
        if (e.InitialPressMouseButton != MouseButton.Left)
            return;

        _animation.Clear();
        _animation.Animations.AddRange([
            new ScaleTransformXAnimation(control: this, duration: TimeSpan.FromMilliseconds(300), before: 0.955,
                after: 1, easing: new CubicEaseOut()),
            new ScaleTransformYAnimation(control: this, duration: TimeSpan.FromMilliseconds(300), before: 0.955,
                after: 1, easing: new CubicEaseOut())
        ]);
        await _animation.RunAsync();
    }
}
