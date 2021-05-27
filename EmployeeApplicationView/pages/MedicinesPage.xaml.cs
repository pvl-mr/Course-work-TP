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
    /// Логика взаимодействия для MedicinesPage.xaml
    /// </summary>
    public partial class MedicinesPage : Page
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private MedicineLogic _medicineLogic;

        public MedicinesPage(MedicineLogic medicineLogic)
        {
            _medicineLogic = medicineLogic;
            InitializeComponent();
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            var win = Container.Resolve<CreateOrUpdateMedicene>();
            win.Show();
        }

        private void bUpdate_Click(object sender, RoutedEventArgs e)
        {
            var win = Container.Resolve<CreateOrUpdateMedicene>();
            win.Medicine = (MedicineViewModel)dgMedicines.SelectedItem;
            win.Show();
        }

        private void bPrescribe_Click(object sender, RoutedEventArgs e)
        {
            var win = Container.Resolve<PrescribeMedicinesWindow>();
            List<MedicineViewModel> medicines = new List<MedicineViewModel>();
            foreach (var medicine in dgMedicines.SelectedItems)
            {
                medicines.Add((MedicineViewModel)medicine);
            }
            win.Medicines = medicines;
            win.Show();
        }

        private void dDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgMedicines.SelectedItems.Count == 1)
                {
                    _medicineLogic.Delete(new MedicineBindingModel { Id = ((MedicineViewModel)dgMedicines.SelectedItem).Id });
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
                var list = _medicineLogic.GetFullList();
                if (list != null)
                {
                    dgMedicines.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
