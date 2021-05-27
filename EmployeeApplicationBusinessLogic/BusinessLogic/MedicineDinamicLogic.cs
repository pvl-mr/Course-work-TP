using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.Interfaces;
using EmployeeApplicationBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApplicationBusinessLogic.BusinessLogic
{
    public class MedicineDinamicLogic
    {
        private readonly IEntityStorage<MedicineDinamicViewModel, MedicineDinamicBindingModel> _medicineStorage;

        public MedicineDinamicLogic(IEntityStorage<MedicineDinamicViewModel, MedicineDinamicBindingModel> medicineStorage)
        {
            _medicineStorage = medicineStorage;
        }

        public void Create(MedicineDinamicBindingModel binding)
        {
            _medicineStorage.Insert(binding);
        }
    }
}
