using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace sidorencko_furniture.ClassFolder
{
    class LoadCBClass
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=10.128.14.42\SQLEXPRESS;
                                                        Initial Catalog=user251;
                                                        User ID=user251;
                                                        Password=wsruser251");
        SqlDataAdapter sqlDataAdapter;
        DataSet dataSet;

        public void LoadCBPost(ComboBox combobox)
        {
            try
            {
                sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter("Select " +
                    "IdPost, NamePost From dbo.Post " +
                    "Order by NamePost ASC", sqlConnection);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Post");
                combobox.ItemsSource = dataSet.Tables["Post"]
                    .DefaultView;
                combobox.DisplayMemberPath = dataSet.Tables["Post"]
                    .Columns["NamePost"].ToString();
                combobox.SelectedValuePath = dataSet.Tables["Post"]
                    .Columns["IdPost"].ToString();
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
