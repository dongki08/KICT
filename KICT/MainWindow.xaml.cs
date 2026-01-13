using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KICT;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ClickCount == 1)
        {
            this.DragMove();
        }
    }

    private void MinimizeButton_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void SettingsButton_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new SettingsDialog
        {
            Owner = this
        };

        dialog.ShowDialog();
    }

    private void AddClientName_Click(object sender, RoutedEventArgs e)
    {
        ShowAddItemDialog("의뢰자명 추가", ClientNameComboBox);
    }

    private void AddPurpose_Click(object sender, RoutedEventArgs e)
    {
        ShowAddItemDialog("성적서 용도 추가", PurposeComboBox);
    }

    private void AddProductItem_Click(object sender, RoutedEventArgs e)
    {
        ShowAddItemDialog("시험대상품목 추가", ProductItemComboBox);
    }

    private void AddEnvironment_Click(object sender, RoutedEventArgs e)
    {
        ShowAddItemDialog("시험환경 추가", EnvironmentComboBox);
    }

    private void AddAuthor_Click(object sender, RoutedEventArgs e)
    {
        ShowAddItemDialog("작성자 추가", AuthorComboBox);
    }

    private void AddApprover_Click(object sender, RoutedEventArgs e)
    {
        ShowAddItemDialog("승인자 추가", ApproverComboBox);
    }

    private void ShowAddItemDialog(string title, ComboBox targetComboBox)
    {
        var dialog = new AddItemDialog(title)
        {
            Owner = this
        };

        dialog.ShowDialog();

        if (dialog.IsConfirmed && !string.IsNullOrWhiteSpace(dialog.ItemName))
        {
            var newItem = new ComboBoxItem
            {
                Content = dialog.ItemName
            };
            targetComboBox.Items.Add(newItem);
            targetComboBox.SelectedItem = newItem;
        }
    }
}
