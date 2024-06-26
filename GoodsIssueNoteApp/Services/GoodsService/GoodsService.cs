using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace GoodsIssueNoteApp.Services.GoodsService
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

        public List<Goods> Goods { get; set; } = [];

        public async Task CreateGood(Goods good)
        {
            var result = await _http.PostAsJsonAsync("api/goods", good);
            await SetGoods(result);
        }

        private async Task SetGoods(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Goods>>();
            Goods = response;
            _navigationManager.NavigateTo("goods");
        }

        public async Task DeleteGood(int id)
        {
            var result = await _http.DeleteAsync($"api/goods/{id}");
            await SetGoods(result);
        }

        public async Task<Goods> GetSingleGood(int id)
        {
            var result = await _http.GetFromJsonAsync<Goods>($"api/goods/{id}");
            if (result != null)
                return result;
            throw new Exception("Goods Not Found!");
        }

        public async Task GetGoods()
        {
            var result = await _http.GetFromJsonAsync<List<Goods>>("api/goods");
            if (result != null)
                Goods = result;
        }

        public async Task UpdateGood(Goods good)
        {
            var result = await _http.PutAsJsonAsync($"api/goods/{good.GoodID}", good);
            await SetGoods(result);
        }
    }
}
