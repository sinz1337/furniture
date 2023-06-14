using System;
using System.Collections.Generic;
using System.Data;
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

namespace sidorencko_furniture.WindowFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        DGClass dGClass;
        LoadCBClass loadCB;

        SqlConnection sqlConnection = new SqlConnection(ConnectClass.ConnectString);

        SqlCommand sqlCommand;
        public AdminWindow()
        {
            InitializeComponent();
            dGClass = new DGClass(ListStaffDG);
            loadCB = new LoadCBClass();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            dGClass.LoadDG("SELECT * FROM dbo.Staff " +
                $"WHERE SurnameStaff Like '%{SearchTB.Text}%' " +
                $"or PhoneStaff Like '%{SearchTB.Text}%'");
        }

        private void EditMI_Click(object sender, RoutedEventArgs e)
        {
            if (ListStaffDG.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите сотрудника для редактирования");
            }
            else
            {
                try
                {
                    GlobalVariableClass.IdStaff =
                        Int32.Parse(dGClass.SelectId());
                    new EditStaffWindow().ShowDialog();
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            new AuthorizationWindow().Show();
            AdminWnd.Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LastNameTB.Text))
            {
                MBClass.ErrorMB("Введите фамилию");
                LastNameTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(FirstNameTB.Text))
            {
                MBClass.ErrorMB("Введите имя");
                FirstNameTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(NumberPhoneTB.Text))
            {
                MBClass.ErrorMB("Введите номер телефона");
                NumberPhoneTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(DateOfBirthDP.Text))
            {
                MBClass.ErrorMB("Введите дату рождения");
                DateOfBirthDP.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("Insert Into dbo.Staff " +
                        "(SurnameStaff,NameStaff,MiddleNameStaff," +
                        "DateOfBirthStaff,PhoneStaff)" +
                        $"Values ('{LastNameTB.Text}','{FirstNameTB.Text}'," +
                        $"'{MiidleNameTB.Text}','{DateOfBirthDP.Text}'," +
                        $"'{NumberPhoneTB.Text}')",
                        sqlConnection);
                    sqlCommand.ExecuteNonQuery();

                    MBClass.InfoMB($"Сотрудник '{LastNameTB.Text}' " +
                        $"'{FirstNameTB.Text}' '{MiidleNameTB.Text}' " +
                        $"успешно добавлен");
                    dGClass.LoadDG("SELECT * FROM dbo.Staff");

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

        private void AdminWnd_Loaded(object sender, RoutedEventArgs e)
        {
            dGClass.LoadDG("SELECT * FROM dbo.Staff");
            
        }
    }
}
