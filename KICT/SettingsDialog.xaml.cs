using System.Windows;

namespace KICT;

public partial class SettingsDialog : Window
{
    public SettingsDialog()
    {
        InitializeComponent();

        if (ThemeManager.CurrentTheme == ThemeVariant.Dark)
        {
            DarkThemeRadio.IsChecked = true;
        }
        else
        {
            LightThemeRadio.IsChecked = true;
        }
    }

    private void LightThemeRadio_Checked(object sender, RoutedEventArgs e)
    {
        ThemeManager.ApplyTheme(ThemeVariant.Light);
    }

    private void DarkThemeRadio_Checked(object sender, RoutedEventArgs e)
    {
        ThemeManager.ApplyTheme(ThemeVariant.Dark);
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}
