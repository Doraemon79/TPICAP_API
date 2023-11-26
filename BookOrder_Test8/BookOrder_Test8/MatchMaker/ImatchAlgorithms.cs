using BookOrder_Test8.Models;

namespace BookOrder_Test8.MatchMaker
{
    public interface ImatchAlgorithms
    {
        List<BookOrder> PriceTimePriority(List<BookOrder> bookOrders);

        List<BookOrder> ProRata(List<BookOrder> bookOrders);
    }
}
