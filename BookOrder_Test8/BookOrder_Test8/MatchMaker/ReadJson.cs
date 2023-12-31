﻿using BookOrder_Test8.Models;
using Microsoft.Extensions.Primitives;
using System;
using System.Globalization;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookOrder_Test8.MatchMaker
{
    public class ReadJson : IReadJson
    {
        public List<BookOrder> ReadInput()
        {
            //string text = File.ReadAllText(@"./person.json");
            //var order = JsonSerializer.Deserialize<BookOrder>(text);

            List<BookOrder> source = new List<BookOrder>();

            using (StreamReader r = new StreamReader(@"./BookOrder.json"))
            {
                string json = r.ReadToEnd();
                source = JsonSerializer.Deserialize<List<BookOrder>>(json);
            }

            List<BookOrder> destination = source.Select(d => new BookOrder
            {
                Id = d.Id ,
                Company = d.Company,
                Notional = d.Notional,
                OrderType = d.OrderType,
                Volume=d.Volume,
                MatchState="NoMatch",
                OrderDateTime= d.OrderDateTime 
            }).ToList();

            return destination;
        }

    }
}
