using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.ViewModels;
using VetclinicStorage.Models;


namespace VetclinicStorage.Storages
{
    public class ClientStorage : EntityStorage<ClientViewModel, ClientBindingModel, Client>
    {
        Func<Client, ClientViewModel> selector;
        public ClientStorage()
        {
            selector = c => new ClientViewModel
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                NickName = c.NickName,
                Email = c.Email,
                Pass = c.Pass,
            };
        }

        protected override ClientViewModel CreateViewModel(Client model)
        {
            return selector(model);
        }

        protected override Client GetElement(ClientBindingModel binding, VetclinicDbContext context)
        {
            return context.Clients.SingleOrDefault(c => c.Id == binding.Id);
        }

        protected override List<ClientViewModel> GetFilteredList(ClientBindingModel binding, VetclinicDbContext context)
        {
            return context.Clients.Where(d => d.FirstName.Contains(binding.FirstName)).Select(selector).ToList();
        }

        protected override List<ClientViewModel> GetFullList(VetclinicDbContext context)
        {
            return context.Clients.Select(selector).ToList();
        }

        protected override Client CreateModel(Client emptyModel, ClientBindingModel binding)
        {
            emptyModel.Pass = binding.Pass;
            emptyModel.Email = binding.Email;
            emptyModel.NickName = binding.NickName;
            emptyModel.LastName = binding.LastName;
            emptyModel.FirstName = binding.FirstName;
            return emptyModel;
        }
        protected override void UpdateModel(Client model, ClientBindingModel binding, VetclinicDbContext context)
        {
            if (binding.Id < 1)
                return;
            CreateModel(model, binding);
        }
    }
}

