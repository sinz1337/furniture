﻿using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для EditStaffWindow.xaml
    /// </summary>
    public partial class EditStaffWindow : Window
    {
        LoadCBClass LoadCB;
        public EditStaffWindow()
        {
            InitializeComponent();
            LoadCB = new LoadCBClass();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            EditStaffWnd.Close();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
