using BookOrder_Test8.Models;

namespace BookOrder_Test8.MatchMaker
{
    public interface IMatchAlgorithms
    {
        Task<List<BookOrder>> PriceTimePriority(List<BookOrder> bookOrders);

        List<BookOrder> ProRata(List<BookOrder> bookOrders);
    }
}
