using Rekod.Model;
using SQLite;

namespace Rekod.Services
{
    public static class CardServices
    {
        private static SQLiteAsyncConnection db;

        private static async Task Init()
        {
            if (db != null)
            {
                return;
            }
            var dataBasePath = Path.Combine(FileSystem.AppDataDirectory, "CardData.db");
            db = new SQLiteAsyncConnection(dataBasePath);
            await db.CreateTableAsync<Card>();
        }

        public static async Task AddCard(string frontText, string backText)
        {
            await Init();
            var card = new Card
            {
                FrontText = frontText,
                BackText = backText
            };

            var id = await db.InsertAsync(card);
        }

        public static async Task RemoveCard(int id)
        {
            await Init();
        }

        public static async Task<IEnumerable<Card>> GetCards()
        {
            await Init();

            var cards = await db.Table<Card>().ToListAsync();
            return cards;
        }
    }
}