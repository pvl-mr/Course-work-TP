﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2.ViewModel;

namespace WpfApp2.pages
{
    /// <summary>
    /// Логика взаимодействия для VaccinationsPage.xaml
    /// </summary>
    public partial class VaccinationsPage : Page
    {
        public VaccinationsPage()
        {
            InitializeComponent();
            DataContext = new VaccinationsViewModel();
        }
    }
}