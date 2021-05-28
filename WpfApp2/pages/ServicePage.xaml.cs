﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2.ViewModel;

namespace WpfApp2.pages
{
    /// <summary>
    /// Логика взаимодействия для VisitPage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        ServiceViewModel vm;
        public ServicePage()
        {
            vm = new ServiceViewModel();
            InitializeComponent();
            DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(vm.serviceUpdatePage);
        }
    }
}