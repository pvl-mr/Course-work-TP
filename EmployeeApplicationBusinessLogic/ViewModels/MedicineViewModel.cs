using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EmployeeApplicationBusinessLogic.ViewModels
{
    public class MedicineViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }
    }
}
