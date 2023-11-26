using BookOrder_Test8.MatchMaker;
using BookOrder_Test8.Models;

namespace BookOrder_Tests
{
    public class MatchAlgorithmsTest
    {
        private readonly MatchAlgorithms sut;
        public MatchAlgorithmsTest() 
        {
            sut = new MatchAlgorithms();
        }

        BookOrder buy0 = new BookOrder { Id = "A0", Company = "A", Notional = 2.00, Volume = 0, OrderDateTime = new TimeSpan(1, 30, 1), MatchState = "NoMatch", OrderType = "buy" };
        BookOrder buy1 = new BookOrder { Id = "A1", Company = "A", Notional = 2.01, Volume = 100, OrderDateTime = new TimeSpan(1, 30, 1), MatchState = "NoMatch", OrderType = "buy" };
        BookOrder buy2 = new BookOrder { Id = "A2", Company = "A", Notional = 2.01, Volume = 150, OrderDateTime = new TimeSpan(1, 30, 0), MatchState = "NoMatch", OrderType = "buy" };
        BookOrder buy3 = new BookOrder { Id = "A3", Company = "A", Notional = 2.01, Volume = 10, OrderDateTime = new TimeSpan(1, 30, 1), MatchState = "NoMatch", OrderType = "buy" };

        BookOrder sell0 = new BookOrder { Id = "A0", Company = "A", Notional = 2.01, Volume = 0, OrderDateTime = new TimeSpan(1, 30, 1), MatchState = "NoMatch", OrderType = "sell" };
        BookOrder sell1 = new BookOrder { Id = "A1", Company = "A", Notional = 2.01, Volume = 100, OrderDateTime = new TimeSpan(1, 30, 0), MatchState = "NoMatch", OrderType = "sell" };
        BookOrder sell2 = new BookOrder { Id = "A2", Company = "A", Notional = 2.01, Volume = 150, OrderDateTime = new TimeSpan(1, 30, 0), MatchState = "NoMatch", OrderType = "sell" };
        BookOrder sell3 = new BookOrder { Id = "A3", Company = "A", Notional = 2.01, Volume = 10, OrderDateTime = new TimeSpan(1, 30, 1), MatchState = "NoMatch", OrderType = "sell" };

        [Fact]
        public async Task PriceTimePriority_ShouldReturn_BuyOrder_FullMatch_SellOrder_FullMatch()
        {
            //Arrange
            List<BookOrder> SampleBookOrder = new List<BookOrder>();

            SampleBookOrder.Add(buy1);
            SampleBookOrder.Add(sell1);

            //Act
            var tst = await sut.PriceTimePriority(SampleBookOrder);


            //Assert
            Assert.Equal(0, tst[0].Volume);
            Assert.Equal("FullMatch", tst[0].MatchState);
            Assert.Equal("FullMatch", tst[1].MatchState);
        }

        [Fact]
        public async Task PriceTimePriority_ShouldReturn_BuyOrder_NoMatch_BuyOrder_NoMatch()
        {
            //Arrange
            List<BookOrder> SampleBookOrder = new List<BookOrder>();

            SampleBookOrder.Add(buy0);
            SampleBookOrder.Add(sell1);

            //Act
            var tst = await sut.PriceTimePriority(SampleBookOrder);


            //Assert
            Assert.Equal(0, tst[0].Volume);
            Assert.Equal("NoMatch", tst[0].MatchState);
            Assert.Equal("NoMatch", tst[1].MatchState);
        }

        [Fact]
        public async Task PriceTimePriority_ShouldReturn_BuyOrder_PartialMatch_SellOrder_FullMatch()
        {
            //Arrange
            List<BookOrder> SampleBookOrder = new List<BookOrder>();

            SampleBookOrder.Add(buy2);
            SampleBookOrder.Add(sell1);

            //Act
            var tst = await sut.PriceTimePriority(SampleBookOrder);


            //Assert
            Assert.Equal(50, tst[0].Volume);
            Assert.Equal("PartialMatch", tst[0].MatchState);
            Assert.Equal("FullMatch", tst[1].MatchState);
        }

        [Fact]
        public async Task PriceTimePriority_ShouldReturn_BuyOrder_FullMatch_SellOrder_PartialMatch()
        {
            //Arrange
            List<BookOrder> SampleBookOrder = new List<BookOrder>();

            SampleBookOrder.Add(buy1);
            SampleBookOrder.Add(sell2);

            //Act
            var tst = await sut.PriceTimePriority(SampleBookOrder);


            //Assert
            Assert.Equal(0, tst[0].Volume);
            Assert.Equal("FullMatch", tst[0].MatchState);
            Assert.Equal("PartialMatch", tst[1].MatchState);
        }
    }
}