using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using WpfApp2.pages;

namespace WpfApp2.ViewModel
{
    class VaccinationsViewModel
    {
        public Page CurrentPage { get; set; }
        private Page vaccinUpdatePage;

        public VaccinationsViewModel()
        {
            vaccinUpdatePage = new VaccinUpdatePage();
            CurrentPage = vaccinUpdatePage;
        }
    }
}
