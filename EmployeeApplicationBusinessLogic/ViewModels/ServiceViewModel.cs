using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EmployeeApplicationBusinessLogic.ViewModels
{
    public class ServiceViewModel
    {
        public int Id { get; set; }
        [DisplayName("Услуга")]
        public string Name { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }
        public int DoctorId { get; set; }// &?

        public virtual Dictionary<int, (string name, string description)> Medicines { get; set; }// &? Нужно.
    }
}
