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
    public partial class UseOfSomethingPage : Page
    {
        public SeriesCollection SeriesCollection { get; set; }

        public UseOfSomethingPage(List<UseOfThingViewModel> useOfMedicineList, string title)
        {
            InitializeComponent();

            lTitle.Content = title;
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
