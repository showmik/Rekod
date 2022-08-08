using SQLite;

namespace Rekod.Model
{
    public enum CardStatus
    { New, Learning, Learned, Retired }

    public enum Boxes
    { Box0, Box1, Box2, Box3, Box4, Box5, Box6, Box7, Box8, Box9, Box10 }

    [Table("Cards")]
    public class Card
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public CardStatus Status { get; set; }
        public DateTime NextStudyTime { get; set; }
        public Boxes CurrentBox { get; set; }
        public bool DoneForToday { get; set; }

        public string FrontText { get; set; }
        public string BackText { get; set; }

        public Card()
        {
            Status = CardStatus.New;
            CurrentBox = Boxes.Box0;
            NextStudyTime = DateTime.Now;
            DoneForToday = false;
        }

        public void MoveToNextBox()
        {
            if (CurrentBox != Boxes.Box10)
            {
                NextStudyTime = DateTime.Now + GetDuration();
                CurrentBox++;

                if (NextStudyTime > DateTime.Now)
                {
                    DoneForToday = true;
                }

                if (CurrentBox >= Boxes.Box4)
                {
                    Status = CardStatus.Learned;
                }
                else if (CurrentBox == Boxes.Box10)
                {
                    Status = CardStatus.Retired;
                }
            }
        }

        public void MoveToPreviousBox()
        {
            if (CurrentBox != Boxes.Box0)
            {
                NextStudyTime = DateTime.Now - GetDuration();
                CurrentBox--;

                if (CurrentBox == Boxes.Box0)
                {
                    Status = CardStatus.Learning;
                }
            }
        }

        public TimeSpan GetDuration()
        {
            switch (CurrentBox)
            {
                case Boxes.Box0:
                    return new TimeSpan(0, 0, 0);
                case Boxes.Box1:
                    return new TimeSpan(0, 10, 0);
                case Boxes.Box2:
                    return new TimeSpan(1, 0, 0, 0);
                case Boxes.Box3:
                    return new TimeSpan(2, 0, 0, 0);
                case Boxes.Box4:
                    return new TimeSpan(4, 0, 0, 0);
                case Boxes.Box5:
                    return new TimeSpan(7, 0, 0, 0);
                case Boxes.Box6:
                    return new TimeSpan(15, 0, 0, 0);
                case Boxes.Box7:
                    return new TimeSpan(30, 0, 0, 0);
                case Boxes.Box8:
                    return new TimeSpan(60, 0, 0, 0);
                case Boxes.Box9:
                    return new TimeSpan(180, 0, 0, 0);
                default:
                    return TimeSpan.Zero;
            }
        }

        public void Refresh()
        {
        }
    }
}