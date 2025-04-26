using Avalonia.Media;
using Avalonia.Media.Immutable;
using System.Drawing;
using Color = Avalonia.Media.Color;

namespace Sekota_McLauncher.Helpers;

public class ColorHelper
{
    public ImmutableSolidColorBrush Color { get; }

    ColorHelper(ImmutableSolidColorBrush brush)
    {
        Color = brush;
    }

    ColorHelper(string color)
    {
        Color = new ImmutableSolidColorBrush(Avalonia.Media.Color.Parse(color));
    }

    ColorHelper(SolidColorBrush brush)
    {
        Color = new ImmutableSolidColorBrush(brush);
    }

    ColorHelper(Brush brush)
    {
        Color = new ImmutableSolidColorBrush((ISolidColorBrush)brush);
    }

    public static implicit operator Color(ColorHelper color)
    {
        return color.Color.Color;
    }

    public static implicit operator Brush(ColorHelper color)
    {
        return new SolidColorBrush(color.Color.Color);
    }

    public static implicit operator ColorHelper(string color)
    {
        return new ColorHelper(color);
    }

    public static implicit operator SolidColorBrush(ColorHelper color)
    {
        return new SolidColorBrush(color.Color.Color);
    }
}