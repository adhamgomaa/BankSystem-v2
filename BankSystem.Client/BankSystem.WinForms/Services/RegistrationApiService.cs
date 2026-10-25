using BankSystem.DTOs.People;
using BankSystem.DTOs.Registerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BankSystem.WinForms.Helpers;

namespace BankSystem.WinForms.Services
{
    public class RegistrationApiService
    {
        private readonly HttpClient _httpClient = ApiClient.httpClient;

        public async Task<bool> AddRegistrationAsync(CreateRegisterDTO createRegister)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(ApiRoutes.Registration.Add, createRegister);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            return true;
        }

        public async Task<List<RegistrationViewDTO>?> GetAllRegistrsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(ApiRoutes.Registration.GetAll);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return new List<RegistrationViewDTO>();
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<List<RegistrationViewDTO>>();
        }
    }
}
