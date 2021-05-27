using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.Interfaces;
using EmployeeApplicationBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;


namespace EmployeeApplicationBusinessLogic.BusinessLogic
{
    public class MedicineLogic
    {
        private readonly IEntityStorage<MedicineViewModel, MedicineBindingModel> _medicineStorage;

        public MedicineLogic(IEntityStorage<MedicineViewModel, MedicineBindingModel> medicineStorage)
        {
            _medicineStorage = medicineStorage;
        }

        public List<MedicineViewModel> GetFullList()
        {
            return _medicineStorage.GetFullList();
        }
        public List<MedicineViewModel> GetFilteredList(MedicineBindingModel binding)
        {
            return _medicineStorage.GetFilteredList(binding);
        }
        public MedicineViewModel GetElement(MedicineBindingModel binding)
        {
            return _medicineStorage.GetElement(binding);
        }

        public void CreateOrUpdate(MedicineBindingModel binding)
        {
            var element = _medicineStorage.GetElement(new MedicineBindingModel { Name = binding.Name });


            if (element != null && element.Id != binding.Id)
                throw new Exception("Медикамент с таким названием уже присутствует");

            if (binding.Id >= 1)
                _medicineStorage.Update(binding);
            else
                _medicineStorage.Insert(binding);  
        }

        public void Delete(MedicineBindingModel binding)
        {
            var element = _medicineStorage.GetElement(new MedicineBindingModel { Id = binding.Id });

            if (element == null)
                throw new Exception($"Элемент c id {binding.Id} найден");
            
            _medicineStorage.Delete(binding);
        }
    }
}
