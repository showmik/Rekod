using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekod.Model
{
    public class Card
    {
        public string FrontText { get; set; }
        public string BackText { get; set; }

        public Card(string front, string back)
        {
            FrontText = front;
            BackText = back;
        }
    }
}
