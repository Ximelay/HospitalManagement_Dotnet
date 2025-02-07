using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using HospitalManagement.Domain.Entities;
using HospitalManagement.WPF.Commands;
using HospitalManagement.WPF.Services;

namespace HospitalManagement.WPF.ViewModels
{
    public class AddHospitalizationViewModel : ViewModelBase
    {
        private readonly HospitalizationService _service;
        public ObservableCollection<HospitalizationReason> Reasons { get; set; } = new();

        public Hospitalization Hospitalization { get; set; } = new();
        public ICommand SaveCommand { get; }

        public AddHospitalizationViewModel(HospitalizationService service)
        {
            _service = service;
            LoadReasons();
            SaveCommand = new RelayCommand(_ => Save()); // ✅ Исправлено
        }

        private async void LoadReasons()
        {
            var reasons = await _service.GetHospitalizationReasonsAsync();
            foreach (var reason in reasons)
                Reasons.Add(reason);
        }

        private async void Save()
        {
            await _service.AddHospitalizationAsync(Hospitalization);
        }
    }
}