using MicroRabbit.MVC.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroRabbit.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _apiClient;

        public TransferService(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task Transfer(TransferDTO transferDTO)
        {
            var url = "http://localhost:19917/api/Banking";
            var transferContent = new StringContent(JsonConvert.SerializeObject(transferDTO), System.Text.Encoding.UTF8, "application/json");
            var response = await _apiClient.PostAsync(url, transferContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
