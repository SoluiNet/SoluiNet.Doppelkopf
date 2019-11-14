// <copyright file="AzureDataStore.cs" company="SoluiNet">
// Copyright (c) SoluiNet. All rights reserved.
// </copyright>

namespace SoluiNet.Doppelkopf.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using SoluiNet.Doppelkopf.Models;
    using Xamarin.Essentials;

    public class AzureDataStore : IDataStore<Item>
    {
        private readonly HttpClient client;
        private IEnumerable<Item> items;

        public AzureDataStore()
        {
            this.client = new HttpClient { BaseAddress = new Uri($"{App.AzureBackendUrl}/") };

            this.items = new List<Item>();
        }

        private bool IsConnected
        {
            get { return Connectivity.NetworkAccess == NetworkAccess.Internet; }
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && this.IsConnected)
            {
                var json = await this.client.GetStringAsync($"api/item");
                this.items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Item>>(json));
            }

            return this.items;
        }

        public async Task<Item> GetItemAsync(string id)
        {
            if (id != null && this.IsConnected)
            {
                var json = await this.client.GetStringAsync($"api/item/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<Item>(json));
            }

            return null;
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            if (item == null || !this.IsConnected)
            {
                return false;
            }

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await this.client.PostAsync($"api/item", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            if (item == null || item.Id == null || !this.IsConnected)
            {
                return false;
            }

            var serializedItem = JsonConvert.SerializeObject(item);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await this.client.PutAsync(new Uri($"api/item/{item.Id}"), byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !this.IsConnected)
            {
                return false;
            }

            var response = await this.client.DeleteAsync($"api/item/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
