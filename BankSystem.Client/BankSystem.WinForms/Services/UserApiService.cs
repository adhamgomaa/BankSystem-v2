using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BankSystem.DTOs.Users;
using BankSystem.WinForms.Helpers;

namespace BankSystem.WinForms.Services
{
    public class UserApiService
    {
        private readonly HttpClient _httpClient = ApiClient.httpClient;

        public async Task<LoginUserDTO?> LoginAsync(LoginRequestDTO loginRequest)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(ApiRoutes.User.Login, loginRequest);

            if (!response.IsSuccessStatusCode)
                return null;
            return await response.Content.ReadFromJsonAsync<LoginUserDTO>();
        }

        public async Task<List<UserViewDTO>?> GetAllUserAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(ApiRoutes.User.GetAll);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return new List<UserViewDTO>();
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<List<UserViewDTO>>();
        }

        public async Task<GetUserDTO?> GetUserByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.User.GetId, id));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return new GetUserDTO();
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<GetUserDTO>();
        }
        public async Task<UserDTO?> GetUserByUsernameAsync(string username)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.User.GetUsername, username));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<UserDTO>();
        }

        public async Task<bool> IsUserExistAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.User.IsExist, id));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> AddUserAsync(CreateUserDTO createUser)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(ApiRoutes.User.Add, createUser);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateUserAsync(int id, UpdateUserDTO updateUser)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(string.Format(ApiRoutes.User.Update, id), updateUser);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(string.Format(ApiRoutes.User.Delete, id));
            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }
            return response.IsSuccessStatusCode;
        }
    }
}
