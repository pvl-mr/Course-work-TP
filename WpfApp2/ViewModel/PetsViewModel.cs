using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using WpfApp2.pages;

namespace WpfApp2.ViewModel
{
    class PetsViewModel
    {
        public Page CurrentPage { get; set; }
        private Page updatePet;
        public PetsViewModel()
        {

            updatePet = new UpdatePet();
            CurrentPage = updatePet;
        }
    }
}
