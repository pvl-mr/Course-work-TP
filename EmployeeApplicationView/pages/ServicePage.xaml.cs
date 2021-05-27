using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.BusinessLogic;
using EmployeeApplicationBusinessLogic.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using Unity;

namespace EmployeeApplicationView.pages
{
    /// <summary>
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private ServicesLogic _servicesLogic;

        public ServicePage( ServicesLogic servicesLogic)
        {
            _servicesLogic = servicesLogic;
            InitializeComponent();
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            var win = Container.Resolve<CreateOrUpdateServiceWindow>();
            win.Show();
        }


        private void bUpdate_Click(object sender, RoutedEventArgs e)
        {
            var win = Container.Resolve<CreateOrUpdateServiceWindow>();
            win.Service = (ServiceViewModel)dgServices.SelectedItem;
            win.Show();
        }

        private void dDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(dgServices.SelectedItems.Count == 1)
                {
                    _servicesLogic.Delete(new ServiceBindingModel { Id = ((ServiceViewModel)dgServices.SelectedItem).Id });
                }
                System.Windows.Forms.MessageBox.Show("Успешно удалено", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var list = _servicesLogic.GetFilteredList(new ServiceBindingModel { DoctorId = AuthorisationWindow.Doctor.Id});
                if (list != null)
                {
                    dgServices.ItemsSource = list;              
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
