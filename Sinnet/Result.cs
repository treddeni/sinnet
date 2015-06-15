using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinnet
{
    class Result
    {
        public bool Win { get; set; }
        public string Opponent { get; set; }
        public string Score { get; set; }
        public double OpponentELO { get; set; }
        public double OpponentDQ { get; set; }

        public override string ToString()
        {
            if (Win)
            {
                return string.Format("{0:N1}", OpponentELO) + "\t" + string.Format("{0:N0}", OpponentDQ) + "\tW\t" + Opponent + "\t\t" + Score;
            }
            else
            {
                return string.Format("{0:N1}", OpponentELO) + "\t" + string.Format("{0:N0}", OpponentDQ) + "\tL\t" + Opponent + "\t\t" + Score;
            }
        }
    }
}
