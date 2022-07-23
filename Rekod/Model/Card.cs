using SQLite;

namespace Rekod.Model
{
    public class Card
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string FrontText { get; set; }
        public string BackText { get; set; }

        //public Card(string front, string back)
        //{
        //    FrontText = front;
        //    BackText = back;
        //}
    }
}