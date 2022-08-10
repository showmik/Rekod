using SQLite;

namespace Rekod.Model
{
    [Table("Decks")]
    public class Deck
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string DeckName { get; set; }
    }
}