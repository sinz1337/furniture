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

namespace sidorencko_furniture.WindowFolder.DirectorFolder
{
    /// <summary>
    /// Логика взаимодействия для DirectorWindow.xaml
    /// </summary>
    public partial class DirectorWindow : Window
    {
        DGClass dGClass;
        DGClass dGClass1;
        DGClass dGClass2;
        DGClass dGClass3;
        SqlConnection sqlConnection = new SqlConnection(ConnectClass.ConnectString);
        SqlCommand sqlCommand;
        public DirectorWindow()
        {
            InitializeComponent();
            dGClass = new DGClass(ListStaffDG);
            dGClass1 = new DGClass(ListProductDG);
            dGClass2 = new DGClass(ListCustomerDG);
            dGClass3 = new DGClass(ListProviderDG);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass.LoadDG("SELECT * FROM dbo.Staff");
            dGClass1.LoadDG("SELECT * FROM dbo.Product");
            dGClass2.LoadDG("SELECT * FROM dbo.Customer");
            dGClass3.LoadDG("SELECT * FROM dbo.Provider");
        }

        private void EditProductMI_Click(object sender, RoutedEventArgs e)
        {
            new EditProductWindow().Show();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            dGClass.LoadDG("SELECT * FROM dbo.Staff " +
                $"WHERE SurnameStaff Like '%{SearchTB.Text}%' " +
                $"or PhoneStaff Like '%{SearchTB.Text}%'");
        }        
    }
}
