using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApplicationBusinessLogic.BindingModels
{ 
    public class ClientBindingModel : BindingModel
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }     
    }
}
