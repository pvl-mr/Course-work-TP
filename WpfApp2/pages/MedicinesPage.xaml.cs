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
    /// Логика взаимодействия для PetsPage.xaml
    /// </summary>
    public partial class MedicinesPage : Page
    {
        private MedicinesViewModel vm;
        public MedicinesPage()
        {
            InitializeComponent();
            vm = new MedicinesViewModel();
            DataContext = vm;
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(vm.medicinUpdatePage);
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(vm.medicinesMinusPage);
        }
    }
}
