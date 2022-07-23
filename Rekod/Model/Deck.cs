namespace Rekod.Model
{
    public class Deck
    {
        public string DeckName { get; set; }
        public List<Card> Cards { get; set; }

        public Deck(string name)
        {
            DeckName = name;
            Cards = new List<Card>();
        }
    }
}