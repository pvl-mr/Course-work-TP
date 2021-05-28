using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApplicationBusinessLogic.HelperModels
{
    public class UseOfMedicine
    {
        public string MedicineName { get; set; }
        public List<int> CountOfUse;
        public List<DateTime> Date;
    }
}
