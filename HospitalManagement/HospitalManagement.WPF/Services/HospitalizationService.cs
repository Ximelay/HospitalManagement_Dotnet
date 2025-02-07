using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Domain.Entities;

namespace HospitalManagement.WPF.Services
{
    public class HospitalizationService
    {
        private readonly HttpClient _httpClient;

        public HospitalizationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress ??= new Uri("https://localhost:7293/"); // Укажи свой API URL
        }

        public async Task<List<Hospitalization>> GetAllHospitalizationsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Hospitalization>>("api/hospitalizations") ?? new List<Hospitalization>();
        }

        public async Task<List<HospitalizationReason>> GetHospitalizationReasonsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<HospitalizationReason>>("api/hospitalizationReasons") ?? new List<HospitalizationReason>();
        }

        public async Task<bool> AddHospitalizationAsync(Hospitalization hospitalization)
        {
            var response = await _httpClient.PostAsJsonAsync("api/hospitalizations", hospitalization);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateConditionAsync(int id, string condition)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/hospitalizations/{id}", new { ConditionDescription = condition });
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateHospitalizationAsync(Hospitalization hospitalization)
        {
            var json = JsonSerializer.Serialize(hospitalization);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/hospitalizations/{hospitalization.Id}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DischargePatientAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/hospitalizations/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}