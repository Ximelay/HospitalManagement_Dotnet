using System.Net.Http;
using System.Windows;
using HospitalManagement.WPF.ViewModels;
using HospitalManagement.WPF.Services;

namespace HospitalManagement.WPF.Views
{
    public partial class HospitalizationView : Window
    {
        public HospitalizationView()
        {
            InitializeComponent();
            DataContext = new HospitalizationViewModel(new HospitalizationService(new HttpClient()));
        }
    }
}