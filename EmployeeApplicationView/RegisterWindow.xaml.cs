using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Unity;

namespace EmployeeApplicationView
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private DoctorLogic _doctorLogic;
     
        public RegisterWindow(DoctorLogic doctorLogic)
        {
            _doctorLogic = doctorLogic;
            InitializeComponent();
        }

        private void bRegister_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(tbFirstName.Text) || string.IsNullOrEmpty(tbFirstName.Text) || string.IsNullOrEmpty(tbLasName.Text)
                || string.IsNullOrEmpty(tbEmail.Text) || string.IsNullOrEmpty(tbLogin.Text) || string.IsNullOrEmpty(tbPassword.Text)
                || string.IsNullOrEmpty(tbPost.Text))
            {
                System.Windows.Forms.MessageBox.Show("Пожалуйста, заполните все поля", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(tbPassword.Text.Equals(tbPassword2.Text) == false)
            {
                System.Windows.Forms.MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _doctorLogic.CreateOrUpdate(new DoctorBindingModel
                {
                    FirstName = tbFirstName.Text,
                    LastName = tbLasName.Text,
                    NickName = tbLogin.Text,
                    Post = tbPost.Text,
                    Pass = tbPassword.Text,
                    Email = tbEmail.Text,
                });
                System.Windows.Forms.MessageBox.Show("Успешная регистрация", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

            // var win = new AuthorisationWindow();
            var win = Container.Resolve<AuthorisationWindow>();
            win.Show();
            Close();
        }

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            var win = Container.Resolve<AuthorisationWindow>();
            win.Show();
            Close();
        }
    }
}
