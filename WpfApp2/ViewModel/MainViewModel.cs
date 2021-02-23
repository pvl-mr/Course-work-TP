using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using WpfApp2.pages;

namespace WpfApp2.ViewModel
{
    class MainViewModel
    {
        public Page CurrentPage { get; set; }

        private Page registrationPage;
        private Page authorizationPage;
        private Page menuPage;

        private Page visitPage;
        private Page petsPage;
        private Page updateVisitPage;
        private Page updatePetPage;

        public MainViewModel()
        {
            registrationPage = new RegistrationPage();
            authorizationPage = new AuthorizationPage();
            menuPage = new MenuPage();

            visitPage = new VisitPage();
            petsPage = new PetsPage();
            updatePetPage = new UpdatePet();
            updateVisitPage = new UpdateVisitPage();

            CurrentPage = menuPage;
            
        }
    }
}
