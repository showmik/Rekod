using SQLite;

namespace Rekod.Model
{
    [Table("Decks")]
    public class Deck
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string DeckName { get; set; }

        [Ignore]
        public List<Card> CardList { get; set; }

        public Deck()
        {
            CardList = new List<Card>();
        }
    }
}