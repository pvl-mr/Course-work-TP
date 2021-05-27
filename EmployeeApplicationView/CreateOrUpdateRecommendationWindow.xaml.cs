using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.BusinessLogic;
using EmployeeApplicationBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using Unity;


namespace EmployeeApplicationView
{
    /// <summary>
    /// Логика взаимодействия для CreateOrUpdateRecommendationWindow.xaml
    /// </summary>
    public partial class CreateOrUpdateRecommendationWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private RecommendationLogic _recommendationLogic;
        private ServicesLogic _servicesLogic;
        private List<ServiceViewModel> _services;
        public RecommendationViewModel Recommendation;

        public CreateOrUpdateRecommendationWindow(RecommendationLogic recommendationLogic, ServicesLogic servicesLogic)
        {
            _recommendationLogic = recommendationLogic;
            _servicesLogic = servicesLogic;
            _services = servicesLogic.GetFilteredList(new ServiceBindingModel { DoctorId = AuthorisationWindow.Doctor.Id});
            InitializeComponent();
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbDescription.Text))
            {
                System.Windows.Forms.MessageBox.Show("Пожалуйста, заполните поля", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbServices.SelectedIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Пожалуйста, выберите услугу", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                _recommendationLogic.CreateOrUpdate(new RecommendationBindingModel
                {                   
                    Id = Recommendation == null ? 0 : Recommendation.Id,
                    Name = tbName.Text,
                    Description = tbDescription.Text,
                    ServiceId = _services[cbServices.SelectedIndex].Id,                 
                    DoctorId = AuthorisationWindow.Doctor.Id
                });

                System.Windows.Forms.MessageBox.Show("Успешно", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {       
            var servicesName = new List<string>();
            foreach (var service in _services)
            {
                servicesName.Add(service.Name);
            }
            cbServices.ItemsSource = servicesName;       
        

            if (Recommendation != null)
            {
                tbDescription.Text = Recommendation.Description;
                tbName.Text = Recommendation.Name;
                cbServices.SelectedIndex = servicesName.IndexOf(Recommendation.ServiceName);
            }
            cbServices.Items.Refresh();
        }
    }
}
