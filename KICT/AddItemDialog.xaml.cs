using System.Windows;

namespace KICT;

public partial class AddItemDialog : Window
{
    public string ItemName { get; private set; } = string.Empty;
    public bool IsConfirmed { get; private set; } = false;

    public AddItemDialog(string title = "항목 추가")
    {
        InitializeComponent();
        DialogTitle.Text = title;
        ItemTextBox.Focus();
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(ItemTextBox.Text))
        {
            ItemName = ItemTextBox.Text.Trim();
            IsConfirmed = true;
            this.Close();
        }
        else
        {
            MessageBox.Show("항목 이름을 입력해주세요.", "알림", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        IsConfirmed = false;
        this.Close();
    }
}
