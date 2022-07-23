using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Rekod.Model
{
    public class Deck
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string DeckName { get; set; }

        [TextBlob("CardsBlobbed")]
        public List<Card> CardList { get; set; }

        public string CardsBlobbed { get; set; }

        public Deck()
        {
            CardList = new List<Card>();
            CardsBlobbed = string.Empty;
        }

    }
}