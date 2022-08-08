using SQLite;

namespace Rekod.Model
{
    public enum CardStatus { New, Learning, Learned, Retired }

    [Table("Cards")]
    public class Card
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public CardStatus Status { get; set; }

        public string FrontText { get; set; }
        public string BackText { get; set; }

        public Card()
        {
            Status = CardStatus.New;
        }
    }
}