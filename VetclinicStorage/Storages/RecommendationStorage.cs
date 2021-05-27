using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.ViewModels;
using Microsoft.EntityFrameworkCore;
using VetclinicStorage.Models;


namespace VetclinicStorage.Storages
{
    public class RecommendationStorage : EntityStorage<RecommendationViewModel, RecommendationBindingModel, Recommendation>
    {
        private Func<Recommendation, RecommendationViewModel> selector;

        public RecommendationStorage()
        {
            selector = r => new RecommendationViewModel
            {
                Id = r.Id,
                ServiceName = r.Service.Name,
                Name = r.Name,
                Description = r.Description,
                DoctorId = r.DoctorId,
                ServiceId = r.ServiceId
            };   
        }

        protected override RecommendationViewModel CreateViewModel(Recommendation model)
        {
            return selector(model);
        }

        protected override Recommendation GetElement(RecommendationBindingModel binding, VetclinicDbContext context)
        {
            return context.Recommendations.Include(r => r.Service).SingleOrDefault(r => r.Id == binding.Id );
        }

        protected override List<RecommendationViewModel> GetFilteredList(RecommendationBindingModel binding, VetclinicDbContext context)
        {
            return context.Recommendations.Include(r => r.Service).Where(r => r.DoctorId == binding.DoctorId).Select(selector).ToList();
        }

        protected override List<RecommendationViewModel> GetFullList(VetclinicDbContext context)
        {
            return context.Recommendations.Include(r => r.Service).Select(selector).ToList();
        }

        protected override Recommendation CreateModel(Recommendation model, RecommendationBindingModel binding)
        {
            model.Name = binding.Name;
            model.Description = binding.Description;
            model.DoctorId = binding.DoctorId;
            model.ServiceId = binding.ServiceId;
            return model;
        }

        protected override void UpdateModel(Recommendation model, RecommendationBindingModel binding, VetclinicDbContext context)
        {
            if (binding.Id < 1)
                return;
            CreateModel(model, binding);
        }
    }
}
