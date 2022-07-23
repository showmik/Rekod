using Rekod.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekod.Services
{
    public static class DeckDataService
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null)
            {
                return;
            }
            var dataBasePath = Path.Combine(FileSystem.AppDataDirectory, "DeckData.db");
            db = new SQLiteAsyncConnection(dataBasePath);
            await db.CreateTableAsync<Deck>();
        }

        public static async Task AddDeck(Deck deck)
        {
            await Init();
            var id = await db.InsertAsync(deck);
        }

        public static async Task RemoveDeck(int id)
        {
            await Init();
            await db.DeleteAsync<Deck>(id);
        }

        public static async Task<IEnumerable<Deck>> GetDecks()
        {
            await Init();

            var deckList = await db.Table<Deck>().ToListAsync();
            return deckList;
        }
    }
}
