using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using WpfApp2.pages;

namespace WpfApp2.ViewModel
{
    class VisitViewModel
    {
        public Page CurrentPage { get; set; }

        private Page updateVisitPage;
        private Page petToVisitPage;
        public VisitViewModel()
        {
            petToVisitPage = new PetToVisitPage();
            updateVisitPage = new UpdateVisitPage();
            CurrentPage = petToVisitPage;
        }
    }
}
