using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.BusinessLogic;
using EmployeeApplicationBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using Unity;
using MessageBox = System.Windows.Forms.MessageBox;

namespace EmployeeApplicationView.pages
{
    /// <summary>
    /// Логика взаимодействия для Report1Page.xaml
    /// </summary>
    public partial class Report1Page : Page
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private ServicesLogic _servicesLogic;
        private ReportLogic _reportLogic;
        private HashSet<ServiceViewModel> _selectedServices;

        public Report1Page(ServicesLogic servicesLogic, ReportLogic reportLogic)
        {
            _servicesLogic = servicesLogic;
            _reportLogic = reportLogic;
            _selectedServices = new HashSet<ServiceViewModel>();
            InitializeComponent();
        }

        private void bRemove_Click(object sender, RoutedEventArgs e)
        {
            foreach (var service in dgSelectedServices.SelectedItems)
            {
                _selectedServices.Remove((ServiceViewModel)service);
            }
            dgSelectedServices.Items.Refresh();
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            foreach (var service in dgAllServices.SelectedItems)
            {
                _selectedServices.Add((ServiceViewModel)service);
            }
            dgSelectedServices.Items.Refresh();
        }

        private void bToWord_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var servisesId = new List<int>();
                        foreach (var service in _selectedServices)
                        {
                            servisesId.Add(service.Id);
                        }
                        _reportLogic.SaveToWordFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
                            ServicesId = servisesId,
                            DoctorId = AuthorisationWindow.Doctor.Id
                        });
                        MessageBox.Show("Выполнено", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void bToExcel_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var servisesId = new List<int>();
                        foreach (var service in _selectedServices)
                        {
                            servisesId.Add(service.Id);
                        }
                        _reportLogic.SaveCarToExcelFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
                            ServicesId = servisesId,
                            DoctorId = AuthorisationWindow.Doctor.Id

                        });
                        MessageBox.Show("Выполнено", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            foreach (var service in dgSelectedServices.Items)
            {
                _selectedServices.Remove((ServiceViewModel)service);
            }
            dgSelectedServices.Items.Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgAllServices.ItemsSource = _servicesLogic.GetFilteredList(new ServiceBindingModel { DoctorId = AuthorisationWindow.Doctor.Id});
                dgSelectedServices.ItemsSource = _selectedServices;

                dgSelectedServices.Items.Refresh();
            }
            catch (Exception)
            {

                throw;
            }
        }    
    }
}
