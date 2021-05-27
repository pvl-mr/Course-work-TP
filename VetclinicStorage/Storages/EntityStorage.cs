using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.Interfaces;
using EmployeeApplicationBusinessLogic.ViewModels;
using VetclinicStorage.Models;

namespace VetclinicStorage.Storages
{
    public abstract class EntityStorage<TViewModel, TBindingModel, T> : IEntityStorage <TViewModel, TBindingModel>
        where TViewModel: class
        where TBindingModel: BindingModel
        where T: class, new()
    {      

        public TViewModel GetElement(TBindingModel binding)
        {
            if (binding == null)
                throw new Exception("Аргумент не может быть null");
            using (var context = new VetclinicDbContext())
            {              
                var element = GetElement(binding, context);
                if (element != null)
                    return CreateViewModel(element);

                return null;
            }
        }        

        public List<TViewModel> GetFilteredList(TBindingModel binding)
        {
            if (binding == null)
                throw new Exception("Аргумент не может быть null");
            using (var context = new VetclinicDbContext())
            {
                return GetFilteredList(binding, context);
            }
        }
       
        public List<TViewModel> GetFullList()
        {
            using (var context = new VetclinicDbContext())
            {
                return GetFullList(context);
            }
        }

        public void Insert(TBindingModel binding)
        {
            if (binding == null)
                throw new Exception("Аргумент не может быть null");
            using (var context = new VetclinicDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var entity = context.Add(CreateModel(new T(), binding));
                        context.SaveChanges();
                        UpdateModel(entity.Entity, binding, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(TBindingModel binding)
        {
            if (binding == null)
                throw new Exception("Аргумент не может быть null");
            using (var context = new VetclinicDbContext())
            {
                var element = GetElement(binding, context);
                if (element == null)
                    throw new Exception($"Элемент с id {binding.Id} не найден");

                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {                 
                        UpdateModel(element, binding, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(TBindingModel binding)
        {
            if (binding == null)
                throw new Exception("Аргумент не может быть null");
            using (var context = new VetclinicDbContext())
            {
                var element = GetElement(binding, context);

                if (element == null)
                    throw new Exception($"Элемент с id {binding.Id} не найден");

                context.Remove(element);
                context.SaveChanges();
            }
        }

        protected abstract T CreateModel(T emptyModel, TBindingModel binding);
        protected abstract void UpdateModel(T model, TBindingModel binding, VetclinicDbContext context);
        protected abstract TViewModel CreateViewModel(T model);
        protected abstract T GetElement(TBindingModel binding, VetclinicDbContext context);     
        protected abstract List<TViewModel> GetFullList(VetclinicDbContext context);
        protected abstract List<TViewModel> GetFilteredList(TBindingModel binding, VetclinicDbContext context);      
    }
}
