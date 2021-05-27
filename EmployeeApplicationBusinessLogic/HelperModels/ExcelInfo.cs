using EmployeeApplicationBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApplicationBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportServiceAnimalViewModel> DataForReport { get; set; }

    }
}
