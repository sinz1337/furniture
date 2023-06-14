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
using sidorencko_furniture.ClassFolder;

namespace sidorencko_furniture.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(ConnectClass.ConnectString);


        SqlDataReader sqlDataReader;
        SqlCommand sqlCommand;
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTB.Text))
            {
                MBClass.ErrorMB("Введите логин");
                Login.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordPB.Password))
            {
                MBClass.ErrorMB("Введите пароль");
                PasswordPB.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Select PasswordUser, IdUser From dbo.[User] " +
                        $"Where LoginUser='{LoginTB.Text}'", sqlConnection);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    sqlDataReader.Read();

                    if (sqlDataReader[0].ToString() != PasswordPB.Password)
                    {
                        MBClass.ErrorMB("Не правильный пароль!");
                        PasswordPB.Focus();
                    }
                    else
                    {

                        switch (sqlDataReader[1].ToString())
                        {
                            case "1":
                                MBClass.InfoMB("Администрация системы");
                                new AdminFolder.AdminWindow().Show();
                                AuthWnd.Close();
                                break;
                            case "2":
                                MBClass.InfoMB("Директор");
                                new DirectorFolder.DirectorWindow().Show();
                                AuthWnd.Close();
                                break;
                            case "3":
                                MBClass.InfoMB("Сотрудник");
                                new StaffFolder.StaffWindow().Show();
                                AuthWnd.Close();
                                break;
                            case "4":
                                MBClass.InfoMB("Поставщик");
                                new ProviderFolder.ProviderWindow().Show();
                                AuthWnd.Close();
                                break;
                            case "5":
                                MBClass.InfoMB("Заказчик");
                                new CustomerFolder.CustomerWindow().Show();
                                AuthWnd.Close();
                                break;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
        private void AuthWnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!string.IsNullOrWhiteSpace(LoginTB.Text) &&
                    !string.IsNullOrWhiteSpace(PasswordPB.Password))
                {
                    Login_Click(sender, e);
                }
                else
                {
                    if (LoginTB.IsFocused)
                        PasswordPB.Focus();
                    else
                        LoginTB.Focus();
                }
            }
        }
    }
}
