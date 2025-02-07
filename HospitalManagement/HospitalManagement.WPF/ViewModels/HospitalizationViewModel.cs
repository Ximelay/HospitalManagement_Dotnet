using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HospitalManagement.Domain.Entities;
using HospitalManagement.WPF.Commands;
using HospitalManagement.WPF.Services;
using HospitalManagement.WPF.Views;

namespace HospitalManagement.WPF.ViewModels
{
    public class HospitalizationViewModel : ViewModelBase
    {
        private readonly HospitalizationService _service;
        public ObservableCollection<Hospitalization> Hospitalizations { get; set; } = new();

        public ICommand AddHospitalizationCommand { get; }
        public ICommand EditConditionCommand { get; }
        public ICommand DischargePatientCommand { get; }

        public HospitalizationViewModel(HospitalizationService service)
        {
            _service = service;
            _ = LoadHospitalizations();

            AddHospitalizationCommand = new RelayCommand(_ => AddHospitalization());
            EditConditionCommand = new RelayCommand(h => EditCondition((Hospitalization)h));
            DischargePatientCommand = new RelayCommand(h => DischargePatient((Hospitalization)h));
        }

        private async Task LoadHospitalizations()
        {
            var hospitalizations = await _service.GetAllHospitalizationsAsync();
            System.Windows.Application.Current.Dispatcher.Invoke(() => // ✅ Исправлено
            {
                Hospitalizations.Clear();
                foreach (var h in hospitalizations)
                    Hospitalizations.Add(h);
            });
        }

        private void AddHospitalization()
        {
            var window = new Views.AddHospitalizationView
            {
                DataContext = new AddHospitalizationViewModel(new HospitalizationService(new HttpClient()))
            };

            window.ShowDialog();
            _ = LoadHospitalizations();
        }

        private void EditCondition(Hospitalization hospitalization)
        {
            var window = new EditConditionView(hospitalization, _service); // Теперь передаем сервис
            window.ShowDialog();
            _ = LoadHospitalizations();
        }

        private async void DischargePatient(Hospitalization hospitalization)
        {
            if (MessageBox.Show("Выписать пациента?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                await _service.DischargePatientAsync(hospitalization.Id);
                _ = LoadHospitalizations();
            }
        }
    }
}
