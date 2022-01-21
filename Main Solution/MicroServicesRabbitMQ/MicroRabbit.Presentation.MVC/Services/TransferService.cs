﻿using MicroRabbit.Presentation.MVC.Models.DTO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Presentation.MVC.Services
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
            var uri = "https://localhost:5001/api/Banking";
            var transferContent = new StringContent(JsonConvert.SerializeObject(transferDTO), Encoding.UTF8, "application/json");

            var response = await _apiClient.PostAsync(uri, transferContent);

            response.EnsureSuccessStatusCode();
        }
    }
}
