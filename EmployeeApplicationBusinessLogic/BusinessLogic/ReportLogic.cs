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
    public class ReportLogic
    {
        private readonly IEntityStorage<MedicineDinamicViewModel, MedicineDinamicBindingModel> _medicineDinamicStorage;
        private readonly IEntityStorage<ServiceViewModel, ServiceBindingModel> _serviceStorage;

        private readonly IEntityStorage<VisitViewModel, VisitBindingModel> _visitStorage;
        private readonly IEntityStorage<AnimalViewModel, AnimalBindingModel> _animalStorage;
        private readonly IEntityStorage<ClientViewModel, ClientBindingModel> _clientStorage;

        public ReportLogic(IEntityStorage<MedicineDinamicViewModel, MedicineDinamicBindingModel> medicineDinamicStorage,
           IEntityStorage<ServiceViewModel, ServiceBindingModel> serviceStorage,
           IEntityStorage<VisitViewModel, VisitBindingModel> visitStorage,
           IEntityStorage<AnimalViewModel, AnimalBindingModel> animalStorage,
           IEntityStorage<ClientViewModel, ClientBindingModel> clientStorage)
        {
            _medicineDinamicStorage = medicineDinamicStorage;
            _serviceStorage = serviceStorage;
            _visitStorage = visitStorage;
            _animalStorage = animalStorage;
            _clientStorage = clientStorage;
        }

        public List<ReportMedicineDinamicViewModel> GetMedicineDinamicForPeriod(ReportBindingModel reportBinding) 
        {
            return _medicineDinamicStorage.GetFilteredList(new MedicineDinamicBindingModel
            {
                DateFrom = reportBinding.DateFrom,
                DateTo = reportBinding.DateTo,
                DoctorId = reportBinding.DoctorId
            }).Select(mdvm => new ReportMedicineDinamicViewModel
            {
                MedicineName = mdvm.MedicineName,
                Count = mdvm.Count,
                Date = mdvm.Date,
                AnimalBreed = mdvm.AnimalBreed,
                AnimalName = mdvm.AnimalName,
                AnimalType = mdvm.AnimalType,
                DoctorFirstName = mdvm.DoctorFirstName,
                DoctorLastName = mdvm.DoctorLastName
              
            }).ToList();
            
        }

        public List<ReportServiceAnimalViewModel> GetServiceAnimals (ReportBindingModel reportBinding)
        {
            var reportDataList = new List<ReportServiceAnimalViewModel>();
            var servicesList = _serviceStorage.GetFilteredList(new ServiceBindingModel
            {
                DoctorId = reportBinding.DoctorId,
                ServicesId = reportBinding.ServicesId
            });

            foreach (var service in servicesList)
            {
                var visitsList = _visitStorage.GetFilteredList(new VisitBindingModel { VisitsId = service.VisitsId });
                foreach (var visit in visitsList)
                {
                    var client = _clientStorage.GetElement(new ClientBindingModel { Id = visit.ClientId });
                    foreach (var animal in visit.Animals){
                        reportDataList.Add(new ReportServiceAnimalViewModel
                        {
                            AnimalBreed = animal.Value.petBreed,
                            AnimalName = animal.Value.petName,
                            AnimalType = animal.Value.petType,
                            ClientFirstName = client.FirstName,
                            ClientLastName = client.LastName,
                            ClientNickName = client.NickName,
                            ServiceName = service.Name,
                            Date = visit.Date
                        });
                    }
                   
                }           
            }
            return reportDataList;
            /*
            var finalReport = new List<ReportServiceAnimalViewModel>();

            var visits = _visitStorage.GetFullList();

            foreach (int serviceId in reportBinding.ServicesId)
            {
                var selectedService = _serviceStorage.GetElement(new ServiceBindingModel { Id = serviceId, DoctorId = reportBinding.DoctorId });
                if (selectedService == null)
                    throw new Exception($"Элемент с {serviceId} не найден");


                foreach (var visit in visits)
                {
                    if (visit.Services.ContainsKey(serviceId))
                    {
                        foreach (int animalId in visit.Animals.Keys)
                        {
                            var animal = _animalStorage.GetElement(new AnimalBindingModel { Id = animalId });

                            if (animal == null)
                                throw new Exception($"Элемент (Animal) с id {animalId} не найден");

                            var client = _clientStorage.GetElement(new ClientBindingModel { Id = animal.ClientId });

                            if (client == null)
                                throw new Exception($"Элемент (Client) с id {animal.ClientId} не найден");

                            finalReport.Add(new ReportServiceAnimalViewModel
                            {
                                AnimalBreed = animal.Breed,
                                AnimalName = animal.Name,
                                AnimalType = animal.Type,
                                ClientFirstName = client.FirstName,
                                ClientLastName = client.LastName,
                                ClientNickName = client.NickName,
                                ServiceName = selectedService.Name,
                                Date = visit.Date
                            });
                        }
                    }
                }
            }
            return finalReport;*/
        }

        public void SaveToWordFile(ReportBindingModel binding)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = binding.FileName,
                Title = "Информация об оказаных услугах",
                DataForReport = GetServiceAnimals(new ReportBindingModel { ServicesId = binding .ServicesId, DoctorId = binding.DoctorId})
            });
        }

        public void SaveCarToExcelFile(ReportBindingModel binding)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = binding.FileName,
                Title = "Информация об оказаных услугах",
                DataForReport = GetServiceAnimals(new ReportBindingModel { ServicesId = binding.ServicesId, DoctorId = binding.DoctorId })
            });
        }

        public void SaveToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Отчет по движению медикаментов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                DataForReport = GetMedicineDinamicForPeriod(model)
            });
        }
    }
}
