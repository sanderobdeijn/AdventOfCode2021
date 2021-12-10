namespace AdventOfCode2021.Day06
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

    public class LanternfishColony
    {
        public LanternfishColony(int daysUntilReproduction, BigInteger count)
        {
            DaysUntilReproduction = daysUntilReproduction;
            Count = count;
        }

        public int DaysUntilReproduction { get; private set; }

        public BigInteger Count { get; private set; }

        public IEnumerable<LanternfishColony> NextDay()
        {
            if(DaysUntilReproduction == 0)
            {
                return new List<LanternfishColony>() 
                { 
                    new LanternfishColony(8, Count),
                    new LanternfishColony(6, Count)
                };
            }

            return new List<LanternfishColony>() { new LanternfishColony(DaysUntilReproduction - 1, Count) };
        }
    }
}
