using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp2.pages;

namespace WpfApp2.ViewModel
{
    public class MenuViewModel
    {
        public Page CurrentPage { get; set; }

        public Page servicePage { get; }
        public Page medicinesPage { get; }
        public Page recommendationsPage { get; }
        public Page report1Page { get; }
        public Page report2Page { get; }

        private Page e;

        public MenuViewModel()
        {
            e = new Empty();
            recommendationsPage = new RecommendationsPage();
            medicinesPage = new MedicinesPage();
            servicePage = new ServicePage();
            report1Page = new Report1Page();
            report2Page = new Report2Page();
            CurrentPage = e;

        }
    }
}
