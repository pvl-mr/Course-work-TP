using System;
using EmployeeApplicationBusinessLogic.ViewModels;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApplicationBusinessLogic.HelperModels
{
    class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public List<ReportMedicineDinamicViewModel> DataForReport { get; set; }
    }
}
