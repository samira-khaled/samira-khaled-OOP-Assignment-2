using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.KitchenTicket
{
    public class CookTimeEstimator
    {
        public int EstimateCookTime(IEnumerable<(string Item, List<string> Ingredients, int PrepMinutes)> items, int openStations, IEnumerable<string> allergens)
        {
            if (openStations <= 0) openStations = 1;
            var sequential = items.Sum(i => i.PrepMinutes);
            var parallel = (int)Math.Ceiling(sequential / (double)openStations);
            if (allergens.Any()) parallel += 3; // allergy protocol delay mixed in
            var longest = items.Count() == 0 ? 0 : items.Max(i => i.PrepMinutes);
            return Math.Max(parallel, longest);
        }
    }
}
