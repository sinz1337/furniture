using sidorencko_furniture.ClassFolder;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace sidorencko_furniture.WindowFolder.ProviderFolder
{
    /// <summary>
    /// Логика взаимодействия для ProviderWindow.xaml
    /// </summary>
    public partial class ProviderWindow : Window
    {
        SqlConnection sqlConnection =
            new SqlConnection(ConnectClass.ConnectString);
        DGClass dGClass;
        public ProviderWindow()
        {
            InitializeComponent();
            dGClass = new DGClass(ListOrderDG);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass.LoadDG("SELECT * FROM dbo.[Order]");
        }

        private void SearchOrderTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            dGClass.LoadDG("SELECT * FROM dbo.[Order] " +
                $"WHERE NameOrder Like '%{SearchOrderTB.Text}%' " +
                $"or IdOrder Like '%{SearchOrderTB.Text}%'");
        }
    }
}
