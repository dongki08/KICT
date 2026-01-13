using System;
using System.Linq;
using System.Windows;

namespace KICT;

public enum ThemeVariant
{
    Light,
    Dark
}

public static class ThemeManager
{
    private const string LightThemePath = "Themes/Light.xaml";
    private const string DarkThemePath = "Themes/Dark.xaml";

    public static ThemeVariant CurrentTheme { get; private set; } = ThemeVariant.Light;

    public static void InitializeFromAppProperties()
    {
        if (Application.Current == null)
        {
            return;
        }

        if (Application.Current.Properties["Theme"] is string themeName
            && Enum.TryParse(themeName, out ThemeVariant variant))
        {
            ApplyTheme(variant);
        }
        else
        {
            ApplyTheme(CurrentTheme);
        }
    }

    public static void ApplyTheme(ThemeVariant variant)
    {
        if (Application.Current == null)
        {
            return;
        }

        var dictionaries = Application.Current.Resources.MergedDictionaries;
        var existing = dictionaries.FirstOrDefault(dictionary =>
            dictionary.Source != null &&
            (dictionary.Source.OriginalString.Contains(LightThemePath, StringComparison.OrdinalIgnoreCase)
             || dictionary.Source.OriginalString.Contains(DarkThemePath, StringComparison.OrdinalIgnoreCase)));

        var newDictionary = new ResourceDictionary
        {
            Source = new Uri(variant == ThemeVariant.Light ? LightThemePath : DarkThemePath, UriKind.Relative)
        };

        if (existing != null)
        {
            var index = dictionaries.IndexOf(existing);
            dictionaries[index] = newDictionary;
        }
        else
        {
            dictionaries.Insert(0, newDictionary);
        }

        CurrentTheme = variant;
        Application.Current.Properties["Theme"] = variant.ToString();
    }
}
