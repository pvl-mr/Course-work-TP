using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using WpfApp2.pages;

namespace WpfApp2.ViewModel
{
    public class MedicinesViewModel
    {
        public Page CurrentPage { get; set; }
        public Page medicinUpdatePage;
        public Page medicinesMinusPage;
        public Page e;

        public MedicinesViewModel()
        {
            e = new Empty();
            medicinesMinusPage = new MedicinecMinusPage();
            medicinUpdatePage = new MedicinUpdatePage();
            CurrentPage = e;
        }
    }
}
