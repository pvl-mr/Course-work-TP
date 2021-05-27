using EmployeeApplicationBusinessLogic.BindingModels;
using EmployeeApplicationBusinessLogic.BusinessLogic;
using EmployeeApplicationBusinessLogic.HelperModels;
using EmployeeApplicationBusinessLogic.Interfaces;
using EmployeeApplicationBusinessLogic.ViewModels;
using System;
using System.Configuration;
using System.Windows;
using Unity;
using Unity.Lifetime;
using VetclinicStorage.Storages;

namespace EmployeeApplicationView
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MailLogic.MailConfig(new MailConfig
            {
                SmtpClientHost = ConfigurationManager.AppSettings["SmtpClientHost"],
                SmtpClientPort = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpClientPort"]),
                MailLogin = ConfigurationManager.AppSettings["MailLogin"],
                MailPassword = ConfigurationManager.AppSettings["MailPassword"],
                MailName = ConfigurationManager.AppSettings["MailName"]
            });

            var container = BuildUnityContainer();

            var win = container.Resolve<AuthorisationWindow>();

            win.Show();
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();

            currentContainer.RegisterType<IEntityStorage<MedicineViewModel, MedicineBindingModel>, MedicineStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEntityStorage<MedicineDinamicViewModel, MedicineDinamicBindingModel>, MedicineDinamicStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEntityStorage<ServiceViewModel, ServiceBindingModel>, ServiceStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEntityStorage<RecommendationViewModel, RecommendationBindingModel>, RecommendationStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEntityStorage<DoctorViewModel, DoctorBindingModel>, DoctorsStorage>(new HierarchicalLifetimeManager());


            currentContainer.RegisterType<IEntityStorage<ClientViewModel, ClientBindingModel>, ClientStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEntityStorage<AnimalViewModel, AnimalBindingModel>, AnimalStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEntityStorage<VaccinationViewModel, VaccinationBindingModel>, VaccinationStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEntityStorage<VisitViewModel, VisitBindingModel>, VisitStorage>(new HierarchicalLifetimeManager());


            currentContainer.RegisterType<DoctorLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ServicesLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<RecommendationLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<MedicineLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogic>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
