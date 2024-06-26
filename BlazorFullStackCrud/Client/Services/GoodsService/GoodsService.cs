using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorFullStackCrud.Client.Services.GoodsService
{
    public class GoodsService : IGoodsService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public GoodsService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Good> Goods { get; set; } = new List<Good>();

        public async Task CreateGood(Good good)
        {
            var result = await _http.PostAsJsonAsync("api/goods", good);
            await SetGoods(result);
        }

        private async Task SetGoods(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Good>>();
            Goods = response;
            _navigationManager.NavigateTo("goods");
        }

        public async Task DeleteGood(int id)
        {
            var result = await _http.DeleteAsync($"api/goods/{id}");
            await SetGoods(result);
        }

        public async Task<Good> GetSingleGood(int id)
        {
            var result = await _http.GetFromJsonAsync<Good>($"api/goods/{id}");
            if (result != null)
                return result;
            throw new Exception("Goods Not Found!");
        }

        public async Task GetGoods()
        {
            var result = await _http.GetFromJsonAsync<List<Good>>("api/goods");
            if (result != null)
                Goods = result;
        }

        public async Task UpdateGood(Good good)
        {
            var result = await _http.PutAsJsonAsync($"api/goods/{good.GoodId}", good);
            await SetGoods(result);
        }
    }
}
