using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.Interfaces;
using EmployeeApplicationBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApplicationBusinessLogic.BusinessLogic
{
    public class DoctorLogic
    {
        private readonly IEntityStorage<DoctorViewModel, DoctorBindingModel> _doctorStorage;

        public DoctorLogic(IEntityStorage<DoctorViewModel, DoctorBindingModel> doctorStorage)
        {
            _doctorStorage = doctorStorage;
        }

        public List<DoctorViewModel> GetFullList()
        {
            return _doctorStorage.GetFullList();
        }

        public List<DoctorViewModel> GetFilteredList(DoctorBindingModel binding)
        {
            return _doctorStorage.GetFilteredList(binding);
        }

        public DoctorViewModel GetElement(DoctorBindingModel binding)
        {
            return _doctorStorage.GetElement(binding);
        }

        public void CreateOrUpdate(DoctorBindingModel binding)
        {
            var element = _doctorStorage.GetElement(new DoctorBindingModel { Email = binding.Email });


            if (element != null && element.Id != binding.Id)
                throw new Exception("Пользователь с такой почтой уже существует");

            if (binding.Id >= 1)
                _doctorStorage.Update(binding);
            else
                _doctorStorage.Insert(binding);
        }

        public void Delete(DoctorBindingModel binding)
        {
            var element = _doctorStorage.GetElement(new DoctorBindingModel { Id = binding.Id });

            if (element == null)
                throw new Exception($"Элемент c id {binding.Id} найден");

            _doctorStorage.Delete(binding);
        }
    }
}
