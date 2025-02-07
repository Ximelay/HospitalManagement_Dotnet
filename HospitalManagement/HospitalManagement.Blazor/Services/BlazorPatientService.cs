using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using System.Net.Http.Json;

namespace HospitalManagement.Blazor.Services
{
    public class BlazorPatientService : IPatientService
    {
        private readonly HttpClient _httpClient;

        public BlazorPatientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Patient>>("api/patients");
        }

        public async Task<Patient?> GetPatientByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Patient>($"api/patients/{id}");
        }

        public async Task<Patient> CreatePatientAsync(Patient patient)
        {
            var response = await _httpClient.PostAsJsonAsync("api/patients", patient);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Patient>();
            }
            throw new Exception($"Ошибка при создании пациента: {response.ReasonPhrase}");
        }

        public async Task<Patient?> UpdatePatientAsync(int id, Patient patient)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/patients/{id}", patient);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Patient>();
            }
            throw new Exception($"Ошибка при обновлении пациента: {response.ReasonPhrase}");
        }

        public async Task<bool> DeletePatientAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/patients/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
