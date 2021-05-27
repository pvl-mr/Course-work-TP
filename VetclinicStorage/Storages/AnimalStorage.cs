using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.ViewModels;
using VetclinicStorage.Models;

namespace VetclinicStorage.Storages
{
    public class AnimalStorage : EntityStorage<AnimalViewModel, AnimalBindingModel, Animal>
    {
        private Func<Animal, AnimalViewModel> selector;

        public AnimalStorage()
        {
            selector = m => new AnimalViewModel
            {
                Id = m.Id,
                Name = m.Name,
                Type = m.Type,
                Breed = m.Breed,
                Description = m.Description,
                ClientId = m.ClientId
            };
        }

        protected override AnimalViewModel CreateViewModel(Animal model)
        {
            return selector(model);
        }

        protected override Animal GetElement(AnimalBindingModel binding, VetclinicDbContext context)
        {
            return context.Animals.SingleOrDefault(m => m.Id == binding.Id);
        }

        protected override List<AnimalViewModel> GetFilteredList(AnimalBindingModel binding, VetclinicDbContext context)
        {
            return context.Animals.Where(m => m.Name.Contains(binding.Name)).Select(selector).ToList();
        }

        protected override List<AnimalViewModel> GetFullList(VetclinicDbContext context)
        {
            return context.Animals.Select(selector).ToList();
        }

        protected override Animal CreateModel(Animal model, AnimalBindingModel binding)
        {
            model.Name = binding.Name;
            model.Type = binding.Type;
            model.Breed = binding.Breed;
            model.Description = binding.Description;
            model.ClientId = binding.ClientId;
            return model;
        }
        protected override void UpdateModel(Animal model, AnimalBindingModel binding, VetclinicDbContext context)
        {
            if (binding.Id < 1)
                return;
            CreateModel(model, binding);
        }   
    }
}
