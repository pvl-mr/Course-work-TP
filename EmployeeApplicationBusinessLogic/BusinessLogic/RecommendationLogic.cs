using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.Interfaces;
using EmployeeApplicationBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApplicationBusinessLogic.BusinessLogic
{
    public class RecommendationLogic
    {
        private readonly IEntityStorage<RecommendationViewModel, RecommendationBindingModel> _recommendationStorage;

        public RecommendationLogic(IEntityStorage<RecommendationViewModel, RecommendationBindingModel> recommendationStorage)
        {
            _recommendationStorage = recommendationStorage;
        }

        public List<RecommendationViewModel> GetFullList()
        {
            return _recommendationStorage.GetFullList();
        }

        public List<RecommendationViewModel> GetFilteredList(RecommendationBindingModel binding)
        {
            return _recommendationStorage.GetFilteredList(binding);
        }

        public RecommendationViewModel GetElement(RecommendationBindingModel binding)
        {
            return _recommendationStorage.GetElement(binding);
        }

        public void CreateOrUpdate(RecommendationBindingModel binding)
        {
            if (binding.Id >= 1)
                _recommendationStorage.Update(binding);
            else
                _recommendationStorage.Insert(binding);
        }

        public void Delete(RecommendationBindingModel binding)
        {
            var element = _recommendationStorage.GetElement(new RecommendationBindingModel { Id = binding.Id });

            if (element == null)
                throw new Exception($"Элемент c id {binding.Id} найден");

            _recommendationStorage.Delete(binding);
        }
    }
}
