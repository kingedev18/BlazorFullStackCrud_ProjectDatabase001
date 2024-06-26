namespace GoodsIssueNoteApp.Services.GoodsService
{
    public interface IGoodsService
    {
        //Task<List<Goods>> GetGoods();
        //Task<Goods> GetGoodById(int id);
        //Task<Goods> AddGood(Goods good);
        //Task<Goods> UpdateGood(Goods good);
        //Task DeleteGood(int id);

        List<Goods> Goods { get; set; }
        //List<Comic> Comics { get; set; }
        //Task GetComics();
        Task GetGoods();
        Task<Goods> GetSingleGood(int id);
        Task CreateGood(Goods good);
        Task UpdateGood(Goods good);
        Task DeleteGood(int id);

    }
}
