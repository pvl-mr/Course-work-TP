using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.BusinessLogic;
using EmployeeApplicationBusinessLogic.ViewModels;
using System.Windows;
using System.Windows.Forms;
using Unity;
using VetclinicStorage.Storages;
using MessageBox = System.Windows.Forms.MessageBox;

namespace EmployeeApplicationView
{
    /// <summary>
    /// Логика взаимодействия для AuthorisationWindow.xaml
    /// </summary>
    public partial class AuthorisationWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private DoctorLogic _doctorLogic;

        public static DoctorViewModel Doctor { get; private set; }

        public AuthorisationWindow(DoctorLogic doctorLogic)
        {
            _doctorLogic = doctorLogic;
            InitializeComponent();
        }

        private void bLogin_Click(object sender, RoutedEventArgs e)
        {
            var user = _doctorLogic.GetFilteredList(new DoctorBindingModel { Pass = tbPassword.Text, Email = tbLogin.Text, NickName = tbLogin.Text});
            if (user == null || user.Count == 0)
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }        
            var win = Container.Resolve<MainWindow>();
            Doctor = user[0];
            win.Show();
            Close();
        }

        private void bReqister_Click(object sender, RoutedEventArgs e)
        {
             // var win = new RegisterWindow(_doctorLogic);
            var win = Container.Resolve<RegisterWindow>();
            win.Show();
            Close();
        }
    }
}
