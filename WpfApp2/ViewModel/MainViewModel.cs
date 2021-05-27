using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using WpfApp2.pages;

namespace WpfApp2.ViewModel
{
   public  class MainViewModel
    {
        public Page CurrentPage { get; set; }

        public Page menuPage;

        private Page visitPage;
        private Page petsPage;
        private Page updateVisitPage;
        private Page serviceUpdatePage;

        private Page e;

        private AuthorizationViewModel AuthorizationViewModel;
        private RegistrationViewModel RegistrationViewModel;
        public MainViewModel()
        {

            e = new Empty();
            menuPage = new MenuPage();

            visitPage = new ServicePage();
            petsPage = new MedicinUpdatePage();
            serviceUpdatePage = new MedicinUpdatePage();
            updateVisitPage = new ServiceUpdatePage();



            CurrentPage = menuPage;
            
        }

    }
}
