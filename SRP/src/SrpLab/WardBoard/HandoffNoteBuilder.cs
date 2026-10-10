using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab
{
    public class HandoffNoteBuilder
    {
        public string BuildHandoffNote(int bed, string patient, int acuity)
        {
            var tone = acuity >= 8 ? "ESCALATE"
                : acuity >= 4 ? "WATCH"
                : "STABLE";

            return $"[HANDOFF {DateTime.UtcNow:yyyy-MM-dd}] Bed {bed} · {patient} · acuity={acuity} · {tone}";
        }
    }
}