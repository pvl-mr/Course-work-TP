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
    /// Логика взаимодействия для PrescribeMedicinesWindow.xaml
    /// </summary>
    public partial class PrescribeMedicinesWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private MedicineDinamicLogic _medicineDinamicLogic;
        private AnimalLogic _animalLogic;
        private List<AnimalViewModel> _animalViewModelsList;
        public List<MedicineViewModel> Medicines;

        public PrescribeMedicinesWindow(MedicineDinamicLogic medicineDinamicLogic, AnimalLogic animalLogic)
        {
            _medicineDinamicLogic = medicineDinamicLogic;
            _animalLogic = animalLogic;
            _animalViewModelsList = _animalLogic.GetFullList();
            InitializeComponent();
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            int count;
            if (string.IsNullOrEmpty(tbCount.Text) || int.TryParse(tbCount.Text, out count) == false)
            {
                System.Windows.Forms.MessageBox.Show("Пожалуйста, укажите количество", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(cbPets.SelectedIndex == -1)
            {
                System.Windows.Forms.MessageBox.Show("Пожалуйста, выберите питомца", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                foreach (var medicine in Medicines)
                {
                    _medicineDinamicLogic.Create(new MedicineDinamicBindingModel
                    {
                        AnimalId = _animalViewModelsList[cbPets.SelectedIndex].Id,
                        DoctorId = AuthorisationWindow.Doctor.Id,
                        MedicineId = medicine.Id,
                        Count = count,
                        Date = DateTime.Now,
                    });
                }            
                System.Windows.Forms.MessageBox.Show("Успешно", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(Medicines != null)
            {
                dgMedicines.ItemsSource = Medicines;
                var animalNames = new List<string>();
                foreach (var animal in _animalViewModelsList)
                {
                    animalNames.Add(animal.Name);
                }
                cbPets.ItemsSource = animalNames;
            }
            dgMedicines.Items.Refresh();
            cbPets.Items.Refresh();
        }
    }
}
