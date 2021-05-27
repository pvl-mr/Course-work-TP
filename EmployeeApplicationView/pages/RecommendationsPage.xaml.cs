using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.BusinessLogic;
using EmployeeApplicationBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using Unity;


namespace EmployeeApplicationView.pages
{
    /// <summary>
    /// Логика взаимодействия для RecommendationsPage.xaml
    /// </summary>
    public partial class RecommendationsPage : Page
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private RecommendationLogic _recommendationLogic;

        public RecommendationsPage(RecommendationLogic recommendationLogic)
        {
            _recommendationLogic = recommendationLogic;
            InitializeComponent();
        }
    
        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            var win = Container.Resolve<CreateOrUpdateRecommendationWindow>();
            win.Show();
        }

        private void bUpdate_Click(object sender, RoutedEventArgs e)
        {
            var win = Container.Resolve<CreateOrUpdateRecommendationWindow>();
            win.Recommendation = (RecommendationViewModel)dgRecommendation.SelectedItem;
            win.Show();
        }

        private void dDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgRecommendation.SelectedItems.Count == 1)
                {
                    _recommendationLogic.Delete(new RecommendationBindingModel { Id = ((RecommendationViewModel)dgRecommendation.SelectedItem).Id });
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
                var list = _recommendationLogic.GetFilteredList(new RecommendationBindingModel { DoctorId = AuthorisationWindow.Doctor.Id});
                if (list != null)
                {
                    dgRecommendation.ItemsSource = list;
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
