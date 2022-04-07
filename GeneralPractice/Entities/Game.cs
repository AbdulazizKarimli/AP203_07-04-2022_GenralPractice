using System;
using System.Collections.Generic;
using System.Text;
using Utils.Enums;

namespace Entities
{
    public class Game
    {
        private static int _id;

        public int Id { get; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double DiscountPercent { get; set; }
        public Platform Platform { get; set; }
        public string Publisher { get; set; }
        public bool IsDeleted { get; set; }

        public Game(string name, Platform platform, double price)
        {
            _id++;
            Id = _id;
            Name = name;
            Price = price;
            Platform = platform;
        }

        public string ShowInfo()
        {
            return $"Id: {Id} - Name: {Name} - Platform: {Platform} - IsDeleted: {IsDeleted}";
        }
        public double GetDiscountedPrice()
        {
            return Price - (Price * DiscountPercent) / 100;
        }
    }
}
