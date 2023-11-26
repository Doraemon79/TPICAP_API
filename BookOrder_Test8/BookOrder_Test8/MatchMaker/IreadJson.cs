using BookOrder_Test8.Models;
using static BookOrder_Test8.MatchMaker.ReadJson;

namespace BookOrder_Test8.MatchMaker
{
    public interface IreadJson
    {
        List<SellOrder> ReadInput();
    }
}
