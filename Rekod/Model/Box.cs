using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekod.Model
{
    internal class Box
    {
        public int BoxID { get; set; }
        public DateTime IntervalTime { get; set; }
        public List<Card> CardList { get; set; }
    }
}
