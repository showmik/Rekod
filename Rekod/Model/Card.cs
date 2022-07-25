using SQLite;

namespace Rekod.Model
{
    [Table("Cards")]
    public class Card
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string FrontText { get; set; }
        public string BackText { get; set; }
    }
}