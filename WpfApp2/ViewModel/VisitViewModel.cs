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

        public VisitViewModel()
        {
            updateVisitPage = new UpdateVisitPage();
            CurrentPage = updateVisitPage;
        }
    }
}
