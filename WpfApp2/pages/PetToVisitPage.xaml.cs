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

namespace WpfApp2.pages
{
    /// <summary>
    /// Логика взаимодействия для PetToVisitPage.xaml
    /// </summary>
    public partial class PetToVisitPage : Page
    {
        public List<String> list { get; set; }
        public PetToVisitPage()
        {
            list = new List<string>();
            list.Add("cnhjrf");
            list.Add("123");
            InitializeComponent();
            
        }
    }
}