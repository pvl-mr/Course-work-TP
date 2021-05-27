using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.Interfaces;
using EmployeeApplicationBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApplicationBusinessLogic.BusinessLogic
{
    public class ServicesLogic
    {
        private readonly IEntityStorage<ServiceViewModel, ServiceBindingModel> _servicesStorage;

        public ServicesLogic(IEntityStorage<ServiceViewModel, ServiceBindingModel> servicesStorage)
        {
            _servicesStorage = servicesStorage;
        }

        public List<ServiceViewModel> GetFullList()
        {
            return _servicesStorage.GetFullList();
        }

        public List<ServiceViewModel> GetFilteredList(ServiceBindingModel binding)
        {
            return _servicesStorage.GetFilteredList(binding);
        }

        public ServiceViewModel GetElement(ServiceBindingModel binding)
        {
            return _servicesStorage.GetElement(binding);
        }

        public void CreateOrUpdate(ServiceBindingModel binding)
        {
            var element = _servicesStorage.GetElement(new ServiceBindingModel { Name = binding.Name });


            if (element != null && element.Id != binding.Id)
                throw new Exception("Услуга с таким названием уже существует");

            if (binding.Id >= 1)
                _servicesStorage.Update(binding);
            else
                _servicesStorage.Insert(binding);
        }

        public void Delete(ServiceBindingModel binding)
        {
            var element = _servicesStorage.GetElement(new ServiceBindingModel { Id = binding.Id });

            if (element == null)
                throw new Exception($"Элемент c id {binding.Id} найден");

            _servicesStorage.Delete(binding);
        }
    }
}
