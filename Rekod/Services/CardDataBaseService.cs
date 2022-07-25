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

            if (db != null && db.DatabasePath == filePath)
            {
                return;
            }
            db = new SQLiteAsyncConnection(filePath);
            _ = await db.CreateTableAsync<Card>();
        }

        public static async Task AddCard(string deckName, string frontText, string backText)
        {
            await Init(deckName);
            var card = new Card
            {
                FrontText = frontText,
                BackText = backText
            };
            _ = await db.InsertAsync(card);
        }

        public static async Task RemoveCard(string deckName, int id)
        {
            await Init(deckName);
        }

        public static async Task<IEnumerable<Card>> GetCards(string deckName)
        {
            await Init(deckName);
            return await db.Table<Card>().ToListAsync();
        }

        public static async Task DeleteDatabase(string deckName)
        {
            //await db.ExecuteAsync("DELETE FROM Cards");
            File.Delete(Path.Combine(FileSystem.AppDataDirectory, $"{deckName}CardData.db"));
        }
    }
}