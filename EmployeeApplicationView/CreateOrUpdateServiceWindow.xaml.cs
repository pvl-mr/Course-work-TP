using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.BusinessLogic;
using EmployeeApplicationBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using Unity;

namespace EmployeeApplicationView
{
    /// <summary>
    /// Логика взаимодействия для CreateOrUpdateServiceWindow.xaml
    /// </summary>
    public partial class CreateOrUpdateServiceWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private MedicineLogic _medicineLogic;
        private ServicesLogic _servicesLogic;
        private HashSet<MedicineViewModel> _selectedMedicines;

        public ServiceViewModel Service { get; set; }

        public CreateOrUpdateServiceWindow(MedicineLogic medicineLogic, ServicesLogic servicesLogic)
        {
            _medicineLogic = medicineLogic;
            _servicesLogic = servicesLogic;
            _selectedMedicines = new HashSet<MedicineViewModel>();
            InitializeComponent();
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbDescruption.Text))
            {
                System.Windows.Forms.MessageBox.Show("Пожалуйста, заполните все поля", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }     
            try
            {
                _servicesLogic.CreateOrUpdate(new ServiceBindingModel
                {
                    Id = Service == null ? 0 : Service.Id,
                    Name = tbName.Text,
                    Description = tbDescruption.Text,
                    DoctorId = AuthorisationWindow.Doctor.Id,
                    Medicines = _selectedMedicines.ToDictionary(m => m.Id, m => (m.Name, m.Description))
                }); 
                System.Windows.Forms.MessageBox.Show("Успешно изменено", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void bAddMedicene_Click(object sender, RoutedEventArgs e)
        {
            foreach (var medicine in dgAllMedicines.SelectedItems)
            {
                _selectedMedicines.Add((MedicineViewModel)medicine);
            }      
            dgSelectedMedicines.Items.Refresh();
        }

        private void bRemoveMedicine_Click(object sender, RoutedEventArgs e)
        {
            foreach (var medicine in dgSelectedMedicines.SelectedItems)
            {
                _selectedMedicines.Remove((MedicineViewModel)medicine);
            }
            dgSelectedMedicines.Items.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgAllMedicines.ItemsSource = _medicineLogic.GetFullList();
                dgSelectedMedicines.ItemsSource = _selectedMedicines;
                if(Service != null)
                {
                    tbName.Text = Service.Name;
                    tbDescruption.Text = Service.Description;
                    foreach (var medicineKeyValue in Service.Medicines)
                    {
                        _selectedMedicines.Add(new MedicineViewModel { Id = medicineKeyValue.Key, Name = medicineKeyValue.Value.name });
                    }                  
                }
                dgSelectedMedicines.Items.Refresh();
            }
            catch (Exception)
            {

                throw;
            }
        }     
    }
}
