using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApplicationBusinessLogic.Interfaces
{
    public interface IEntityStorage <TViewModel, TBindingModel>
    {
        List<TViewModel> GetFullList();
        List<TViewModel> GetFilteredList(TBindingModel binding);
        TViewModel GetElement(TBindingModel binding);

        void Insert(TBindingModel binding);
        void Update(TBindingModel binding);
        void Delete(TBindingModel binding);

    }
}
