using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EmployeeApplicationBusinessLogic.ViewModels
{
    public class VaccinationViewModel
    {
        public int Id { get; set; }

        [DisplayName("Дата")]
        public DateTime Date { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }
        [DisplayName("Питомец")]
        public string AnimalName { get; set; }

        public int AnimalId { get; set; }
    }
}
