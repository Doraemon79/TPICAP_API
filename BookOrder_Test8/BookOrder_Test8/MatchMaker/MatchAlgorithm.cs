using BookOrder_Test8.Models;

namespace BookOrder_Test8.MatchMaker
{
    public class MatchAlgorithms : ImatchAlgorithms
    {
        public List<BookOrder> PriceTimePriority(List<BookOrder> bookOrders)
        {
            //select buy and order them by time ascending

            List<BookOrder> buyOrders = (List<BookOrder>)bookOrders.Where(x => x.OrderType.Equals("buy")).OrderBy(x => x.OrderDateTime).ToList();



            //if buy list not empty
            if (buyOrders.Any())
            {
                List<BookOrder> sellOrders = (List<BookOrder>)bookOrders.Where(x => x.OrderType.Equals("sell")).OrderBy(x => x.Notional).ThenBy(x => x.OrderDateTime).ToList();
                if (sellOrders.Any())
                {
                    // foreach element in the buy list do:
                    // check the price is less or equal to any value in the sell list, if there is any if not set no match
                    //foreach (var buy in buyOrders)foreach doesnot allow for changes and I do not know if link reads the list in order
                    for (int i = 0; i <= buyOrders.Count - 1; i++)
                    {
                        double quant = buyOrders[i].Notional;
                        //brose sellList
                        //foreach(var sale in sellOrders)
                        for (int j = 0; j <= sellOrders.Count - 1; j++)
                        {
                            if (buyOrders[i].Notional >= sellOrders[j].Notional)
                            {
                                if (sellOrders[j].Volume <= buyOrders[i].Volume)
                                {

                                    BookOrder tempOrder = buyOrders[i];
                                    tempOrder = buyOrders[i];
                                    tempOrder.Volume -= sellOrders[j].Volume;
                                    buyOrders[i] = tempOrder;

                                    tempOrder = sellOrders[j];
                                    tempOrder.Volume = 0;
                                    sellOrders[j] = tempOrder;

                                }
                                else
                                {
                                    BookOrder tempOrder = sellOrders[j];
                                    tempOrder.Volume -= buyOrders[i].Volume;
                                    sellOrders[j] = tempOrder;

                                    tempOrder = buyOrders[i];
                                    tempOrder.Volume = 0;
                                    buyOrders[i] = tempOrder;
                                    break;
                                }
                            }
                        }
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






            return buyOrders;
        }


        public List<BookOrder> ProRata(List<BookOrder> bookOrders)
        {
            throw new NotImplementedException();
        }

    }
}
