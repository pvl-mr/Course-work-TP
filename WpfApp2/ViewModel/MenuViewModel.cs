using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp2.pages;

namespace WpfApp2.ViewModel
{
    class MenuViewModel
    {
        public Page CurrentPage { get; set; }

        public Page visitPage { get; }
        public Page petsPage { get; }
        public Page vaccinPage { get; }
        public Page report1Page { get; }
        public Page report2Page { get; }

        public MenuViewModel()
        {
            visitPage = new VisitPage();
            petsPage = new PetsPage();
            vaccinPage = new VaccinationsPage();
            report1Page = new Report1Page();
            report2Page = new Report2Page();
            CurrentPage = visitPage;

        }
    }
}
