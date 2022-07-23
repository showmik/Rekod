namespace Rekod.Model
{
    public class Deck
    {
        public string DeckName { get; set; }
        public List<Card> CardList { get; set; }

        public Deck(string name)
        {
            DeckName = name;
            CardList = new List<Card>();
        }

        public override string ToString()
        {
            return DeckName;
        }
    }
}