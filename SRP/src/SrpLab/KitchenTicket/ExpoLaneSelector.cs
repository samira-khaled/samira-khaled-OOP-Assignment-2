using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.KitchenTicket
{
    public class ExpoLaneSelector
    {
        public string SelectExpoLane(int estimatedReadyMinutes, IEnumerable<string> allergens)
        {
            return allergens.Count() > 0 ? "LANE-ALLERGY" : estimatedReadyMinutes > 20 ? "LANE-SLOW" : "LANE-FAST";
        }
    }
}
