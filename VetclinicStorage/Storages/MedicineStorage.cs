using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.ViewModels;
using VetclinicStorage.Models;

namespace VetclinicStorage.Storages
{
    public class MedicineStorage : EntityStorage<MedicineViewModel, MedicineBindingModel, Medicine>
    {
        private Func<Medicine, MedicineViewModel> selector;
     
        public MedicineStorage() 
        {       
            selector = m => new MedicineViewModel { Id = m.Id, Name = m.Name, Description = m.Description };      
        }

        protected override MedicineViewModel CreateViewModel(Medicine model)
        {
            return selector(model);
        }

        protected override Medicine GetElement(MedicineBindingModel binding, VetclinicDbContext context)
        {
            return context.Medicines.SingleOrDefault(m => m.Id == binding.Id || m.Name == binding.Name);
        }

        protected override List<MedicineViewModel> GetFilteredList(MedicineBindingModel binding, VetclinicDbContext context)
        {
            return context.Medicines.Where(m => m.Name.Contains(binding.Name)).Select(selector).ToList();
        }

        protected override List<MedicineViewModel> GetFullList(VetclinicDbContext context)
        {
            return context.Medicines.Select(selector).ToList();
        }

        protected override Medicine CreateModel(Medicine model, MedicineBindingModel binding)
        {
            model.Name = binding.Name;
            model.Description = binding.Description;
            return model;
        }
        protected override void UpdateModel(Medicine model, MedicineBindingModel binding, VetclinicDbContext context)
        {
            if (binding.Id < 1)
                return;
            CreateModel(model, binding);       
        }
    }
}
