using EmployeeApplicationBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApplicationBusinessLogic.BindingModels
{
    public class AnimalBindingModel : BindingModel
    {       
        public string Name { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }

        // 4 пункт задания. Выбираем из списка Visits несколько записей и сохраняем их id.
        // При Сохранении в бд создавать записи VisitAnimal. VisitId = AnimalBindingModel.VisitIds[0...n], AnimalId = VisitBindingModel.Id.
        public List<int> VisitIds;
    }
}
