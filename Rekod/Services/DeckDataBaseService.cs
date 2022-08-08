using Rekod.Model;
using SQLite;

namespace Rekod.Services
{
    public static class DeckDataBaseService
    {
        private static SQLiteAsyncConnection db;

        private static async Task Init()
        {
            if (db == null)
            {
                var dataBasePath = Path.Combine(FileSystem.AppDataDirectory, "DeckData.db");
                db = new SQLiteAsyncConnection(dataBasePath);
                _ = await db.CreateTableAsync<Deck>();
            }
        }

        public static async Task AddDeck(Deck deck)
        {
            await Init();
            deck.CardList.Clear();
            var cards = await CardDataBaseService.GetCards(deck.DeckName);
            deck.CardList.AddRange(cards);
            _ = await db.InsertAsync(deck);
        }

        public static async Task RemoveDeck(int id)
        {
            await Init();
            _ = await db.DeleteAsync<Deck>(id);
        }

        public static async Task<IEnumerable<Deck>> GetDecks()
        {
            await Init();
            return await db.Table<Deck>().ToListAsync();
        }
    }
}