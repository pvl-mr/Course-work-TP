using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.BusinessLogic;
using EmployeeApplicationBusinessLogic.ViewModels;
using System;
using System.Windows;
using System.Windows.Forms;
using Unity;

namespace EmployeeApplicationView
{
    /// <summary>
    /// Логика взаимодействия для CreateOrUpdateMedicene.xaml
    /// </summary>
    public partial class CreateOrUpdateMedicene : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private MedicineLogic _medicineLogic;

        public MedicineViewModel Medicine { get; set; }

        public CreateOrUpdateMedicene(MedicineLogic medicineLogic)
        {
            _medicineLogic = medicineLogic;
            InitializeComponent();
        }

        private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbDescription.Text))
            {
                System.Windows.Forms.MessageBox.Show("Пожалуйста, заполните все поля", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                _medicineLogic.CreateOrUpdate(new MedicineBindingModel
                {
                    Id = Medicine == null ? 0 : Medicine.Id,
                    Name = tbName.Text,
                    Description = tbDescription.Text,                 
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
            if(Medicine != null)
            {
                tbName.Text = Medicine.Name;
                tbDescription.Text = Medicine.Description;
            }
        }
    }
}
