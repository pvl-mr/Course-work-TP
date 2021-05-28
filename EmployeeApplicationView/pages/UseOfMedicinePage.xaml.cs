using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using EmployeeApplicationBusinessLogic.HelperModels;
using EmployeeApplicationBusinessLogic.ViewModels;
using LiveCharts;
using LiveCharts.Wpf;

namespace EmployeeApplicationView.pages
{
    public partial class UseOfMedicinePage : Page
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        private List<UseOfMedicine> _useOfMedicineList;
        private int _currentMedicine = 0;
        public UseOfMedicinePage(List<UseOfMedicine> useOfMedicineList)
        {
            InitializeComponent();

            _useOfMedicineList = useOfMedicineList;
            if (_useOfMedicineList.Count > 0)
                Configurate(0);
            else
                lTitle.Content = "За указаный периуд медикаменты не выписывались";
          

           // YFormatter = value => value.ToString("C");
            DataContext = this;
        }

        private void Configurate(int indexOfMedicine)
        {
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = _useOfMedicineList[indexOfMedicine].MedicineName,
                    Values = new ChartValues<int> (_useOfMedicineList[indexOfMedicine].CountOfUse)
                },
            };

            Labels = new string[_useOfMedicineList[indexOfMedicine].Date.Count];
            for (int i = 0; i < Labels.Length; i++)
            {
                Labels[i] = _useOfMedicineList[indexOfMedicine].Date[i].ToShortDateString();
            }

            lMedicineName.Content = _useOfMedicineList[indexOfMedicine].MedicineName;
            chart.Series = SeriesCollection;
            axisX.Labels = Labels;
            chart.Update(true, true);
        }
   
        private void bNext_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_currentMedicine < _useOfMedicineList.Count - 1)
            {
                _currentMedicine++;
                Configurate(_currentMedicine);
            }      
        }

        private void bBack_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (_currentMedicine > 0)
            {
                _currentMedicine--;
                Configurate(_currentMedicine);
            }
        }
    }
}
