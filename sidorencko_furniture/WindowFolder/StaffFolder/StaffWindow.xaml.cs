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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace sidorencko_furniture.WindowFolder.StaffFolder
{
    /// <summary>
    /// Логика взаимодействия для StaffWindow.xaml
    /// </summary>
    public partial class StaffWindow : Window
    {
        DGClass dGClass1;
        DGClass dGClass2;
        DGClass dGClass3;
        SqlConnection sqlConnection = new SqlConnection(ConnectClass.ConnectString);
        SqlCommand sqlCommand;
        public StaffWindow()
        {
            InitializeComponent();
            dGClass1 = new DGClass(ListProductDG);
            dGClass2 = new DGClass(ListCustomerDG);
            dGClass3 = new DGClass(ListProviderDG);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass1.LoadDG("SELECT * FROM dbo.Product");
            dGClass2.LoadDG("SELECT * FROM dbo.Customer");
            dGClass3.LoadDG("SELECT * FROM dbo.Provider");
        }
    }
}
