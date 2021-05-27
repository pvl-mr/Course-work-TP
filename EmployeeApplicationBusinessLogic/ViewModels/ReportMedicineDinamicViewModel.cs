using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EmployeeApplicationBusinessLogic.ViewModels
{
    public class ReportMedicineDinamicViewModel
    {
        [DisplayName("Дата")]
        public System.DateTime Date { get; set; }
        [DisplayName("Медикамент")]
        public string MedicineName { get; set; }
        [DisplayName("Кол-во")]
        public int Count { get; set; }

        [DisplayName("Выписал: Имя")]
        public string DoctorFirstName { get; set; }
        [DisplayName("Фамилия")]
        public string DoctorLastName { get; set; }

        [DisplayName("Кому: Вид")]
        public string AnimalType { get; set; }
        [DisplayName("Порода")]
        public string AnimalBreed { get; set; }
        [DisplayName("Имя")]
        public string AnimalName { get; set; }
    }
}
