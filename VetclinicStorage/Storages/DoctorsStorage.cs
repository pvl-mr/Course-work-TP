using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.ViewModels;
using VetclinicStorage.Models;


namespace VetclinicStorage.Storages
{
    public class DoctorsStorage : EntityStorage<DoctorViewModel, DoctorBindingModel, Doctor>
    {
        Func<Doctor, DoctorViewModel> selector;
        public DoctorsStorage()
        {
            selector = d => new DoctorViewModel
            {
                Id = d.Id,
                Email = d.Email,
                FirstName = d.FirstName,
                LastName = d.LastName,
                NickName = d.NickName,
                Pass = d.Pass,
                Post = d.Post
            };
        }
      
        protected override DoctorViewModel CreateViewModel(Doctor model)
        {
            return selector(model);
        }

        protected override Doctor GetElement(DoctorBindingModel binding, VetclinicDbContext context)
        {
            return context.Doctors.SingleOrDefault(d => d.Id == binding.Id || d.Email.Equals(binding.Email));
        }

        protected override List<DoctorViewModel> GetFilteredList(DoctorBindingModel binding, VetclinicDbContext context)
        {
            return context.Doctors.Where(d => d.Email == binding.Email && d.Pass == binding.Pass || d.NickName == binding.NickName && d.Pass == binding.Pass).Select(selector).ToList();
        }

        protected override List<DoctorViewModel> GetFullList(VetclinicDbContext context)
        {
            return context.Doctors.Select(selector).ToList();
        }

        protected override Doctor CreateModel(Doctor emptyModel, DoctorBindingModel binding)
        {
            emptyModel.Post = binding.Post;
            emptyModel.Pass = binding.Pass;
            emptyModel.Email = binding.Email;
            emptyModel.NickName = binding.NickName;
            emptyModel.LastName = binding.LastName;
            emptyModel.FirstName = binding.FirstName;
            return emptyModel;
        }
        protected override void UpdateModel(Doctor model, DoctorBindingModel binding, VetclinicDbContext context)
        {
            if (binding.Id < 1)
                return;
            CreateModel(model, binding);
        }
    }
}
