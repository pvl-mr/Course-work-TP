using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EmployeeApplicationBusinessLogic.ViewModels
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        [DisplayName("Имя")]
        public string FirstName { get; set; }
        [DisplayName("Имя")]
        public string LastName { get; set; }
        [DisplayName("Логин")]
        public string NickName { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Пароль")]
        public string Pass { get; set; }
    }
}
