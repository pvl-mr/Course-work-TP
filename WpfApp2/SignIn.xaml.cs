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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void bLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
        }
    }
}
