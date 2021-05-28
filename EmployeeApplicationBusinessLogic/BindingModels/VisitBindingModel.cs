using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApplicationBusinessLogic.BindingModels
{
    public class VisitBindingModel : BindingModel
    {
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int ClientId { get; set; }
      
        // 1 пункт задания. Выбираем из списка Services несколько записей и сохраняем их id.
        // При Сохранении в бд создавать записи VisitServices. VisitId = VisitBindingModel.Id, ServiceId = VisitBindingModel.ServiceIds[0...n].
        public List<int> ServiceIds { get; set; }

        public List<int> AnimalIds { get; set; }

        public List<int> VisitsId { get; set; }

        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? DoctorId { get; set; }
    }
}
