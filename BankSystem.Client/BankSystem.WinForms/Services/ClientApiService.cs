using BankSystem.DTOs.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BankSystem.WinForms.Helpers;

namespace BankSystem.WinForms.Services
{
    public class ClientApiService
    {
        private readonly HttpClient _httpClient = ApiClient.httpClient;

        public async Task<List<ClientViewDTO>?> GetAllClientAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(ApiRoutes.Client.GetAll);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return new List<ClientViewDTO>();
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<List<ClientViewDTO>>();
        }

        public async Task<ClientDTO?> GetClientByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.Client.GetId, id));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return new ClientDTO();
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<ClientDTO>();
        }
        public async Task<ClientDTO?> GetClientByAccNumAsync(int AccNum)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.Client.GetAccNum, AccNum));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return new ClientDTO();
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<ClientDTO>();
        }

        public async Task<bool> IsClientExistAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.Client.IsExist, id));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
            return await response.Content.ReadFromJsonAsync<bool>();
        }
        
        public async Task<decimal> GetBalanceAsync(int accNum)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(string.Format(ApiRoutes.Client.GetBalance, accNum));
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return -1;
            }
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
            return await response.Content.ReadFromJsonAsync<decimal>();
        }

        public async Task<decimal> GetAllBalancesAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(ApiRoutes.Client.GetTotalBalances);
            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return -1;
            }
            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());
            return await response.Content.ReadFromJsonAsync<decimal>();
        }

        public async Task<string> DepositAsync(DepositWithdrawDTO DepositDTO)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(ApiRoutes.Client.Deposit, DepositDTO);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                return "Transaction Falied";
            }

            return await response.Content.ReadAsStringAsync();
        }
        
        public async Task<string> WithdrawAsync(DepositWithdrawDTO withdrawDTO)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(ApiRoutes.Client.Withdraw, withdrawDTO);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                return "Transaction Falied";
            }

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<bool> AddClientAsync(CreateClientDTO createClient)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(ApiRoutes.Client.Add, createClient);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return false;
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateClientAsync(int id, UpdateClientDTO updateClient)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(string.Format(ApiRoutes.Client.Update, id), updateClient);

            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(string.Format(ApiRoutes.Client.Delete, id));
            if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }
            return response.IsSuccessStatusCode;
        }
    }
}
