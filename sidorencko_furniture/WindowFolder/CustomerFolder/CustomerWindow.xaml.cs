using sidorencko_furniture.ClassFolder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace sidorencko_furniture.WindowFolder.CustomerFolder
{
    /// <summary>
    /// Логика взаимодействия для CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        DGClass dGClass;
        SqlConnection sqlConnection = new SqlConnection(ConnectClass.ConnectString);

        public CustomerWindow()
        {
            InitializeComponent();
            dGClass = new DGClass(ListProductDG);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass.LoadDG("SELECT * FROM dbo.[Product]");
        }

        private void SearchProductTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            dGClass.LoadDG("SELECT * FROM dbo.Product " +
                $"WHERE NameProduct Like '%{SearchProductTB.Text}%' " +
                $"or IdProduct Like '%{SearchProductTB.Text}%'");
        }
    }
}
