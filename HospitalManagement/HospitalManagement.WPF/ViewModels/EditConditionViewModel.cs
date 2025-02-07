using System.Windows.Input;
using HospitalManagement.Domain.Entities;
using HospitalManagement.WPF.Commands;
using HospitalManagement.WPF.Services;

namespace HospitalManagement.WPF.ViewModels
{
    public class EditConditionViewModel : ViewModelBase
    {
        private readonly HospitalizationService _service;
        public Hospitalization Hospitalization { get; }

        private string _conditionDescription;
        public string ConditionDescription
        {
            get => _conditionDescription;
            set
            {
                _conditionDescription = value;
                OnPropertyChanged(nameof(ConditionDescription)); // Передаем имя свойства
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public EditConditionViewModel(Hospitalization hospitalization, HospitalizationService service)
        {
            _service = service;
            Hospitalization = hospitalization;
            _conditionDescription = hospitalization.ConditionDescription ?? "";

            SaveCommand = new RelayCommand(_ => Save());
            CancelCommand = new RelayCommand(_ => Cancel());
        }

        private async void Save()
        {
            Hospitalization.ConditionDescription = ConditionDescription;
            await _service.UpdateHospitalizationAsync(Hospitalization);
            CloseWindow();
        }

        private void Cancel()
        {
            CloseWindow();
        }

        private void CloseWindow()
        {
            System.Windows.Application.Current.Windows
                .OfType<System.Windows.Window>()
                .FirstOrDefault(w => w.DataContext == this)?.Close();
        }
    }
}