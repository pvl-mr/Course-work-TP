using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.ViewModels;
using Microsoft.EntityFrameworkCore;
using VetclinicStorage.Models;


namespace VetclinicStorage.Storages
{
    public class MedicineDinamicStorage : EntityStorage<MedicineDinamicViewModel, MedicineDinamicBindingModel, MedicinesDinamic>
    {
        Func<MedicinesDinamic, MedicineDinamicViewModel> selector;

        public MedicineDinamicStorage()
        {
            selector = s => new MedicineDinamicViewModel
            {
                Id = s.Id,
                Date = s.Date,
                Count = s.Count,
                MedicineName = s.Medicine.Name,
                AnimalBreed = s.Animal.Breed,
                AnimalType = s.Animal.Type,
                AnimalName = s.Animal.Name,
                AnimalId = s.AnimalId,
                DoctorId = s.DoctorId,
                DoctorFirstName = s.Doctor.FirstName,
                DoctorLastName = s.Doctor.LastName,
                MedicineId = s.MedicineId
            };
        }
  
        protected override MedicineDinamicViewModel CreateViewModel(MedicinesDinamic model)
        {
            return selector(model);
        }

        protected override MedicinesDinamic GetElement(MedicineDinamicBindingModel binding, VetclinicDbContext context)
        {
            return context.MedicinesDinamics.Include(md => md.Animal).Include(md => md.Medicine).Include(md => md.Doctor)
                .SingleOrDefault(md => md.Id == binding.Id);
        }

        protected override List<MedicineDinamicViewModel> GetFilteredList(MedicineDinamicBindingModel binding, VetclinicDbContext context)
        {
            return context.MedicinesDinamics
                .Where(md => md.DoctorId == binding.DoctorId && ((binding.DateFrom.HasValue && binding.DateTo.HasValue) ? (md.Date >= binding.DateFrom && md.Date <= binding.DateTo) : true ))
                .Include(md => md.Animal).Include(md => md.Medicine).Include(md => md.Doctor)
                .Select(selector).ToList();
        }

        protected override List<MedicineDinamicViewModel> GetFullList(VetclinicDbContext context)
        {
            return context.MedicinesDinamics.Include(md => md.Animal).Include(md => md.Medicine).Include(md => md.Doctor)
             .Select(selector).ToList();
        }

        protected override MedicinesDinamic CreateModel(MedicinesDinamic emptyModel, MedicineDinamicBindingModel binding)
        {
            emptyModel.AnimalId = binding.AnimalId;
            emptyModel.Count = binding.Count;
            emptyModel.Date = binding.Date;
            emptyModel.DoctorId = binding.DoctorId;
            emptyModel.MedicineId = binding.MedicineId;
            return emptyModel;
        }

        protected override void UpdateModel(MedicinesDinamic model, MedicineDinamicBindingModel binding, VetclinicDbContext context)
        {
            if (binding.Id < 1)
                return;
            CreateModel(model, binding);
        }
    }
}
