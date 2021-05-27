using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using WpfApp2.pages;

namespace WpfApp2.ViewModel
{
    public class ServiceViewModel
    {
        public Page CurrentPage { get; set; }

        public Page serviceUpdatePage;
        public Page medicinecMinus;
        public Page e;

        public ServiceViewModel()
        {
            e = new Empty();

            medicinecMinus = new MedicinecMinusPage();
            serviceUpdatePage = new ServiceUpdatePage();
            CurrentPage = e;
            
        }
    }
}
