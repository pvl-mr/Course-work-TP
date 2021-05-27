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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private RegistrationViewModel _vm;
        public RegistrationPage()
        {      
            InitializeComponent();        
            DataContext = _vm;
        }
        public RegistrationPage(RegistrationViewModel registrationViewModel) 
        {
            InitializeComponent();
            _vm = registrationViewModel;
            DataContext = _vm;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _vm.LogIn();
        }
    }
}
