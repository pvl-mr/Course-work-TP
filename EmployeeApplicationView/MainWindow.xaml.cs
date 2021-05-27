using EmployeeApplicationBusinessLogic.BusinessLogic;
using EmployeeApplicationBusinessLogic.ViewModels;
using EmployeeApplicationView.pages;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unity;
using VetclinicStorage.Storages;

namespace EmployeeApplicationView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void bServises_Click(object sender, RoutedEventArgs e)
        {
            var page = Container.Resolve<ServicePage>();
            frame.Navigate(page);
        }

        private void bMedicines_Click(object sender, RoutedEventArgs e)
        {
            var page = Container.Resolve<MedicinesPage>();
            frame.Navigate(page);
        }

        private void bRecommendetions_Click(object sender, RoutedEventArgs e)
        {
            var page = Container.Resolve<RecommendationsPage>();
            frame.Navigate(page);
        }

        private void bReportServises_Click(object sender, RoutedEventArgs e)
        {
            iLogo.Visibility = Visibility.Collapsed;
            var page = Container.Resolve<Report1Page>();
            frame.Navigate(page);
        }

        private void bReportMedicines_Click(object sender, RoutedEventArgs e)
        {
            iLogo.Visibility = Visibility.Collapsed;
            var page = Container.Resolve<Report2Page>();
            frame.Navigate(page);
        }

        private void bCharts_Click(object sender, RoutedEventArgs e)
        {
            iLogo.Visibility = Visibility.Collapsed;
            var page = Container.Resolve<ChatsPage>();
            frame.Navigate(page);
        }
    }
}
