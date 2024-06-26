namespace BlazorFullStackCrud.Client.Services.GoodsService
{
    public interface IGoodsService
    {
        //Task<List<Goods>> GetGoods();
        //Task<Goods> GetGoodById(int id);
        //Task<Goods> AddGood(Goods good);
        //Task<Goods> UpdateGood(Goods good);
        //Task DeleteGood(int id);

        List<Good> Goods { get; set; }
        //List<Comic> Comics { get; set; }
        //Task GetComics();
        Task GetGoods();
        Task<Good> GetSingleGood(int id);
        Task CreateGood(Good good);
        Task UpdateGood(Good good);
        Task DeleteGood(int id);

    }
}
