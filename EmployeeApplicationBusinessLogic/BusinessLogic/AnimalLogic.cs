using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.Interfaces;
using EmployeeApplicationBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;


namespace EmployeeApplicationBusinessLogic.BusinessLogic
{
    public class AnimalLogic
    {
        private readonly IEntityStorage<AnimalViewModel, AnimalBindingModel> _animalStorage;

        public AnimalLogic(IEntityStorage<AnimalViewModel, AnimalBindingModel> animalStorage)
        {
            _animalStorage = animalStorage;
        }

        public List<AnimalViewModel> GetFullList()
        {
            return _animalStorage.GetFullList();
        }

        public List<AnimalViewModel> GetFilteredList(AnimalBindingModel binding)
        {
            return _animalStorage.GetFilteredList(binding);
        }

        public AnimalViewModel GetElement(AnimalBindingModel binding)
        {
            return _animalStorage.GetElement(binding);
        }

    }
}
