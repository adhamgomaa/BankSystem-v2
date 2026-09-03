using BankSystem.DTOs.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using BankSystem.WinForms.Helpers;

namespace BankSystem.WinForms.Services
{
    public class PersonApiService
    {
        private readonly HttpClient _httpClient = ApiClient.httpClient;

        public async Task<List<PeopleViewDTO>?> GetAllPeopleAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(ApiRoutes.People.GetAll);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return new List<PeopleViewDTO>();
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<List<PeopleViewDTO>>();
        }

        public async Task<GetPersonDTO?> GetPersonByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.People.GetId, id));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return new GetPersonDTO();
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<GetPersonDTO>();
        }

        public async Task<bool> IsPersonExistAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.People.IsExist, id));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> AddPersonAsync(CreatePersonDTO createPerson)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(ApiRoutes.People.Add, createPerson);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdatePersonAsync(int id, UpdatePersonDTO updatePerson)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(string.Format(ApiRoutes.People.Update, id), updatePerson);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePersonAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(string.Format(ApiRoutes.People.Delete, id));
            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }
            return response.IsSuccessStatusCode;
        }
    }
}
