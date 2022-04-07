using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Utils.Exceptions;

namespace Entities
{
    public class Store : IEnumerable
    {
        private static int _id;

        public int Id { get; }
        public string Name { get; set; }
        public List<Game> Games { get; set; }

        public Store()
        {
            _id++;
            Id = _id;
            Games = new List<Game>();
        }

        public void AddGame(Game game)
        {
            if (Games.Exists(g => !g.IsDeleted && g.Name == game.Name))
                throw new AlreadyExistsException("bu adda bir oyun var");

            Games.Add(game);
        }
        public Game GetGameById(int? id)
        {
            if (id == null)
                throw new NullReferenceException("id null ola bilmez");

            return Games.Find(g => !g.IsDeleted && g.Id == id);
        }
        public void RemoveGameById(int? id)
        {
            if (id == null)
                throw new NullReferenceException("id null ola bilmez");

            Game game = Games.Find(g => !g.IsDeleted && g.Id == id);
            if (game == null)
                throw new NotFoundException("bele bir oyun yoxdur");

            game.IsDeleted = true;
        }
        public List<Game> FilterGamesByPrice(double minPrice, double maxPrice)
        {
            List<Game> filteredGames = Games
                .FindAll(g => !g.IsDeleted && g.Price >= minPrice && g.Price <= maxPrice);
            if (filteredGames.Count == 0)
                throw new NotFoundException("bu araliqda hec bir oyun yoxdur");

            return filteredGames;
        }
        public List<Game> FilterGamesByDiscountedPrice(double minPrice, double maxPrice)
        {
            List<Game> filteredGames = Games
                .FindAll(g => !g.IsDeleted && g.GetDiscountedPrice() >= minPrice && g.GetDiscountedPrice() <= maxPrice);
            if (filteredGames.Count == 0)
                throw new NotFoundException("bu araliqda hec bir oyun yoxdur");

            return filteredGames;
        }
        public IEnumerator GetEnumerator()
        {
            foreach (var game in Games)
            {
                yield return game;
            }
        }
    }
}
