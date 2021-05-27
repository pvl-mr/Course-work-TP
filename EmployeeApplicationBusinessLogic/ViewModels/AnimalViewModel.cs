using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EmployeeApplicationBusinessLogic.ViewModels
{
    public class AnimalViewModel
    {
        public int Id { get; set; }

        [DisplayName("Кличка")]
        public string Name { get; set; }
        [DisplayName("Вид")]
        public string Type { get; set; }
        [DisplayName("Порода")]
        public string Breed { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }

        public int ClientId { get; set; }
    }
}
