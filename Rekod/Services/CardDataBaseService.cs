using Rekod.Model;
using SQLite;

namespace Rekod.Services
{
    public static class CardDataBaseService
    {
        private static SQLiteAsyncConnection db;

        private static async Task Init(string deckName)
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, $"{deckName}CardData.db");

            if (db == null || db.DatabasePath != filePath)
            {
                db = new SQLiteAsyncConnection(filePath);
                await db.CreateTableAsync<Card>();
            }
        }

        public static async Task AddCard(string deckName, Card card)
        {
            await Init(deckName);
            await db.InsertAsync(card);
        }

        public static async Task RemoveCard(string deckName, int id)
        {
            await Init(deckName);
        }

        public static async Task UpdateCard(string deckName, Card card)
        {
            await Init(deckName);
            await db.UpdateAsync(card);
        }

        public static async Task<IEnumerable<Card>> GetCards(string deckName)
        {
            await Init(deckName);
            return await db.QueryAsync<Card>("SELECT * FROM Cards ORDER BY NextStudyTime ASC");
        }

        public static async Task<IEnumerable<Card>> GetCardsForStudy(string deckName)
        {
            await Init(deckName);
            return await db.QueryAsync<Card>("SELECT * FROM Cards WHERE DoneForToday = FALSE ORDER BY NextStudyTime ASC");
        }

        public static void DeleteDatabase(string deckName)
        {
            File.Delete(Path.Combine(FileSystem.AppDataDirectory, $"{deckName}CardData.db"));
        }
    }
}