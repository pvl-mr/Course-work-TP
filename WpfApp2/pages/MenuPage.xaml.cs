using System;
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
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        private MenuViewModel vm;
        public MenuPage()
        {         
            InitializeComponent();
            vm = new MenuViewModel();
            DataContext = vm;
        }


        private void b1_Click(object sender, RoutedEventArgs e)
        {               
            frame.Navigate(vm.visitPage);
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(vm.petsPage);
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(vm.vaccinPage);
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(vm.report1Page);
        }

        private void b5_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(vm.report2Page);
        }
    }
}
