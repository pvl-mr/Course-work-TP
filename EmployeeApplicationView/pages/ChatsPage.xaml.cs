using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.BusinessLogic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using Unity;
using MessageBox = System.Windows.Forms.MessageBox;

namespace EmployeeApplicationView.pages
{
    /// <summary>
    /// Логика взаимодействия для ChatsPage.xaml
    /// </summary>
    public partial class ChatsPage : Page
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private ChatLogic _chatLogic;

        public ChatsPage(ChatLogic chatLogic)
        {
            _chatLogic = chatLogic;
            InitializeComponent();
        }

        private void bUseOfMedicines_Click(object sender, RoutedEventArgs e)
        {
            if (dpFrom.SelectedDate >= dpTo.SelectedDate)
            {
                MessageBox.Show("Начальная дата должна быть меньше конечной", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dataForDisplay = _chatLogic.GetUseOfMedicinesStatistic(new ReportBindingModel
            {
                DoctorId = AuthorisationWindow.Doctor.Id,
                DateFrom = dpFrom.SelectedDate,
                DateTo = dpTo.SelectedDate,
            });
            frame.Navigate(new UseOfSomethingPage(dataForDisplay, "Количество выписаных медикаментов за указаный периуд"));
        }

        private void dMedicine_Click(object sender, RoutedEventArgs e)
        {
            if (dpFrom.SelectedDate >= dpTo.SelectedDate)
            {
                MessageBox.Show("Начальная дата должна быть меньше конечной", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dataForDisplay = _chatLogic.GetUseOfMedicineStatistic(new ReportBindingModel
            {
                DoctorId = AuthorisationWindow.Doctor.Id,
                DateFrom = dpFrom.SelectedDate,
                DateTo = dpTo.SelectedDate,
            });
            frame.Navigate(new UseOfMedicinePage(dataForDisplay));
        }

        private void bUseOfServices_Click(object sender, RoutedEventArgs e)
        {
            if (dpFrom.SelectedDate >= dpTo.SelectedDate)
            {
                MessageBox.Show("Начальная дата должна быть меньше конечной", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dataForDisplay = _chatLogic.GetUseOfServicesStatistic(new ReportBindingModel
            {
                DoctorId = AuthorisationWindow.Doctor.Id,
                DateFrom = dpFrom.SelectedDate,
                DateTo = dpTo.SelectedDate,
            });
            frame.Navigate(new UseOfSomethingPage(dataForDisplay, "Оказаные услуги за указаный периуд"));
        }

        private void dService_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
