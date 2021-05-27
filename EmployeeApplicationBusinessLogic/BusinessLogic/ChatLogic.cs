using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.HelperModels;
using EmployeeApplicationBusinessLogic.Interfaces;
using EmployeeApplicationBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeApplicationBusinessLogic.BusinessLogic
{
    public class ChatLogic
    {
        private readonly IEntityStorage<MedicineDinamicViewModel, MedicineDinamicBindingModel> _medicineDinamicStorage;
        private readonly IEntityStorage<ServiceViewModel, ServiceBindingModel> _serviceStorage;
        private readonly IEntityStorage<VisitViewModel, VisitBindingModel> _visitStorage;


        public ChatLogic(IEntityStorage<MedicineDinamicViewModel, MedicineDinamicBindingModel> medicineDinamicStorage,
           IEntityStorage<ServiceViewModel, ServiceBindingModel> serviceStorage,
           IEntityStorage<VisitViewModel, VisitBindingModel> visitStorage)
        {
            _medicineDinamicStorage = medicineDinamicStorage;
            _serviceStorage = serviceStorage;
            _visitStorage = visitStorage;
        }

        public List<UseOfThingViewModel> GetUseOfMedicinesStatistic(ReportBindingModel reportBinding)
        {
          
            return _medicineDinamicStorage.GetFilteredList(new MedicineDinamicBindingModel
            {
                DateFrom = reportBinding.DateFrom,
                DateTo = reportBinding.DateTo,
                DoctorId = reportBinding.DoctorId
            }).GroupBy(md => md.MedicineId).Select(gmd => new UseOfThingViewModel
            {
                Count = gmd.Sum(smd => smd.Count),
                ThingName = gmd.First().MedicineName
            }).ToList();
        }


    }
}
