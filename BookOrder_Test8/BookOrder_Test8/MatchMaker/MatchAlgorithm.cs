using BookOrder_Test8.Models;

namespace BookOrder_Test8.MatchMaker
{
    public class MatchAlgorithms : ImatchAlgorithms
    {
       public List<BookOrder>  PriceTimePriority(List<BookOrder> bookOrders)
        {
            //select buy and order them by time ascending

            List<BookOrder> buyOrders = (List<BookOrder>)bookOrders.Where(x => x.OrderType.Equals("buy")).OrderBy(x=>x.OrderDateTime).ToList();



            //if buy list not empty
            if (buyOrders.Any())
            {
                List<BookOrder> sellOrders = (List<BookOrder>)bookOrders.Where(x => x.OrderType.Equals("sell")).OrderBy(x => x.Notional).ThenBy(x=>x.OrderDateTime).ToList();
                if(sellOrders.Any())
                        {
                    // foreach element in the buy list do:
                    // check the price is less or equal to any value in the sell list, if there is any if not set no match
                    foreach (var el in buyOrders)
                    {

                    }
                }
                else { throw new NotImplementedException(); }

            }
            else { throw new NotImplementedException(); }

            //if there is any order sells which have price<= buy price in order of price and then time
            //var orderedCustomers = Customer.OrderBy(c => c.LastName).ThenBy(c => c.FirstName)
            //until the n is reached foreach row satisfying requirements ???
            //update row
            //if n is reached set full 
            //partial otherwise

            //take the first order from a time sorted array






            throw new NotImplementedException();
        }


      public  List<BookOrder>  ProRata(List<BookOrder> bookOrders)
        {
            throw new NotImplementedException();
        }

    }
}
