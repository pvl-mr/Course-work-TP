using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.BusinessLogic;
using EmployeeApplicationBusinessLogic.ViewModels;
using System.Windows.Forms;
using Unity;

namespace EmployeeApplicationView
{
    /// <summary>
    /// Логика взаимодействия для MedicineDinamicReportWindow.xaml
    /// </summary>
    public partial class MedicineDinamicReportWindow : Window
    {
        List<ReportMedicineDinamicViewModel> _reportData;

        public MedicineDinamicReportWindow(List<ReportMedicineDinamicViewModel> reportData)
        {
            _reportData = reportData;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {         
             dgMedicines.ItemsSource = _reportData;         
        }
    }
}
