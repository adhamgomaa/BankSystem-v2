using BankSystem.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using BankSystem.WinForms.Helpers;

namespace BankSystem.WinForms.Services
{
    public class RegistrationApiService
    {
        private readonly HttpClient _httpClient = ApiClient.httpClient;

        public async Task<List<LoginAttemptDTO>?> GetAllRegistersAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(ApiRoutes.Registration.GetAll);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return new List<LoginAttemptDTO>();
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<List<LoginAttemptDTO>>();
        }
    }
}
