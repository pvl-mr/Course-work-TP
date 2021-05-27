using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EmployeeApplicationBusinessLogic.ViewModels
{ 
    public class RecommendationViewModel
    {
        public int Id { get; set; }
        [DisplayName("Услуга")]
        public string ServiceName { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Рекоммендация")]
        public string Description { get; set; }
        public int DoctorId { get; set; } //&?
        public int ServiceId { get; set; }
     
    }
}
