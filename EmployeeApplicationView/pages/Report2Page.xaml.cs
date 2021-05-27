using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.BusinessLogic;
using EmployeeApplicationBusinessLogic.HelperModels;
using EmployeeApplicationBusinessLogic.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using Unity;
using MessageBox = System.Windows.Forms.MessageBox;

namespace EmployeeApplicationView.pages
{
    /// <summary>
    /// Логика взаимодействия для Report2Page.xaml
    /// </summary>
    public partial class Report2Page : Page
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly ReportLogic _reportLogic;

        public Report2Page(ReportLogic reportLogic)
        {
            _reportLogic = reportLogic;
            InitializeComponent();
        }

        private void bShow_Click(object sender, RoutedEventArgs e)
        {
            if(dpFrom.SelectedDate == null || dpTo.SelectedDate == null)
            {
                System.Windows.Forms.MessageBox.Show("Пожалуйста, укажите периуд", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dpFrom.SelectedDate >= dpTo.SelectedDate)
            {
                MessageBox.Show("Начальная дата должна быть меньше конечной", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var list = _reportLogic.GetMedicineDinamicForPeriod(new ReportBindingModel
                {
                    DateFrom = dpFrom.SelectedDate.Value,
                    DateTo = dpTo.SelectedDate.Value,
                    DoctorId = AuthorisationWindow.Doctor.Id
                });

                if(list.Count > 0)
                {
                    var win = new MedicineDinamicReportWindow(list);
                    win.Show();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Не найдено записей, относящихся к указанному периуду", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }        
        }

        private void bSend_Click(object sender, RoutedEventArgs e)
        {
            if (dpFrom.SelectedDate == null || dpTo.SelectedDate == null)
            {
                System.Windows.Forms.MessageBox.Show("Пожалуйста, укажите периуд", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dpFrom.SelectedDate >= dpTo.SelectedDate)
            {
                MessageBox.Show("Начальная дата должна быть меньше конечной", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string fileName = "__report.pdf";
                _reportLogic.SaveToPdfFile(new ReportBindingModel
                {
                    FileName = fileName,
                    DateFrom = dpFrom.SelectedDate.Value,
                    DateTo = dpTo.SelectedDate.Value,
                    DoctorId = AuthorisationWindow.Doctor.Id
                });

                MailLogic.MailSend(new MailSendInfo
                {
                    MailAddress = AuthorisationWindow.Doctor.Email,
                    Subject = "Отчет за периуд по медикаментам",
                    Text = "Отчет по медикаментам от " + dpFrom.SelectedDate.Value.ToShortDateString() + " по " + dpTo.SelectedDate.Value.ToShortDateString(),
                    FileName = fileName
                });
                MessageBox.Show("Выполнено", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
