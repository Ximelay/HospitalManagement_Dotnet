using System.Windows;
using HospitalManagement.Domain.Entities;
using HospitalManagement.WPF.ViewModels;
using HospitalManagement.WPF.Services;

namespace HospitalManagement.WPF.Views
{
    public partial class EditConditionView : Window
    {
        public EditConditionView(Hospitalization hospitalization, HospitalizationService service)
        {
            InitializeComponent();
            DataContext = new EditConditionViewModel(hospitalization, service);
        }
    }
}