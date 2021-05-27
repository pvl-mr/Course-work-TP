using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EmployeeApplicationBusinessLogic.ViewModels;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace EmployeeApplicationView.pages
{
    /// <summary>
    /// Логика взаимодействия для UseOfMedicinePage.xaml
    /// </summary>
    public partial class UseOfMedicinePage : Page
    {
        public SeriesCollection SeriesCollection { get; set; }

        public UseOfMedicinePage(List<UseOfThingViewModel> useOfMedicineList)
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection();
            foreach (var data in useOfMedicineList)
            {
                SeriesCollection.Add(new PieSeries
                {
                    Title = data.ThingName,
                    Values = new ChartValues<ObservableValue> { new ObservableValue(data.Count) },
                    DataLabels = true
                });
            }       

            DataContext = this;
        }
      
    }
}
