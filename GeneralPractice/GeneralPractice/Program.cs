using Entities;
using System;
using Utils.Enums;

namespace GeneralPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store()
            {
                Name = "test store"
            };

            Game game1 = new Game("test1 game", Platform.Pc, 120);
            Game game2 = new Game("test2 game", Platform.PlayStation, 125);

            store.AddGame(game1);
            store.AddGame(game2);

            foreach (Game game in store)
            {
                Console.WriteLine(game.ShowInfo());
            }
        }
    }
}
