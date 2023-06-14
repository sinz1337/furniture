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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=10.128.14.42\SQLEXPRESS;
                                                        Initial Catalog=user251;
                                                        User ID=user251;
                                                        Password=wsruser251");
        SqlCommand sqlCommand;
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            new AuthorizationWindow().Show();
            RegWnd.Close();
        }

        private void RegestrationBtn_Click(object sender, RoutedEventArgs e)
        {
            string pass = PasswordPB.Password;
            string Uper = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string lower = "qwertyuiopasdfghjklzxcvbnm";
            string numbers = "0123456789";
            string symbols = "!@#$%^&*№()_-";

            if (string.IsNullOrWhiteSpace(LoginTB.Text))
            {
                MBClass.ErrorMB("Введите логин");
                LoginTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordPB.Password))
            {
                MBClass.ErrorMB("Введите пароль");
                PasswordPB.Focus();
            }
            else if (pass.Length < 7)
            {
                MBClass.ErrorMB("Пароль должен содердать 7 символов");
                PasswordPB.Focus();
            }
            else if (Uper.IndexOfAny(pass.ToCharArray()) == -1)
            {
                MBClass.ErrorMB("Пароль должен содержать 1 заглавную букву");
                PasswordPB.Focus();
            }
            else if (lower.IndexOfAny(pass.ToCharArray()) == -1)
            {
                MBClass.ErrorMB("Пароль должен содержать 1 строчную букву");
                PasswordPB.Focus();
            }
            else if (numbers.IndexOfAny(pass.ToCharArray()) == -1)
            {
                MBClass.ErrorMB("Пароль должен содержать 1 цифру");
                PasswordPB.Focus();
            }
            else if (symbols.IndexOfAny(pass.ToCharArray()) == -1)
            {
                MBClass.ErrorMB("Пароль должен содержать 1 специальный символ");
                PasswordPB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordPBAgain.Password))
            {
                MBClass.ErrorMB("Заполните пароль повторно");
                PasswordPB.Focus();
            }
            else if (PasswordPB.Password != PasswordPBAgain.Password)
            {
                MBClass.ErrorMB("Пароли должны совпадать");
                PasswordPB.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Insert Into " +
                        "dbo.[User] " +
                        "(LoginUser,PasswordUser,Idrole) " +
                        "Values" +
                        "(@LoginUser,@PasswordUser,@IdRole) ", 
                        sqlConnection);

                    sqlCommand.Parameters
                        .AddWithValue("LoginUser", LoginTB.Text);
                    sqlCommand.Parameters
                        .AddWithValue("PasswordUser", PasswordPB.Password);
                    sqlCommand.Parameters
                        .AddWithValue("IdRole", 1);
                    sqlCommand.ExecuteNonQuery();

                    MBClass.InfoMB("Вы успешно зарегестрировались!");
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
    }
}
