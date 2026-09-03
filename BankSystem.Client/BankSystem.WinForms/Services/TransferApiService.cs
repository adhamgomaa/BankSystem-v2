using BankSystem.DTOs.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BankSystem.DTOs.Registerations;
using BankSystem.WinForms.Helpers;

namespace BankSystem.WinForms.Services
{
    public class TransferApiService
    {
        private readonly HttpClient _httpClient = ApiClient.httpClient;

        public async Task<bool> AddTransferAsync(CreateTransferDTO createTransfer)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(ApiRoutes.Transfer.Add, createTransfer);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            return true;
        }

        public async Task<List<TransferDTO>?> GetAllTransfersAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(ApiRoutes.Transfer.GetAll);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return new List<TransferDTO>();
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<List<TransferDTO>>();
        }
    }
}
