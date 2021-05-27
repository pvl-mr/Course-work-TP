using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp2.ViewModel
{
    public class RegistrationViewModel
    {
        private MainViewModel _mainViewModel;
        public void SetMainViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }
        public void LogIn()
        {
            _mainViewModel.CurrentPage = _mainViewModel.menuPage;
        }
    }
}
