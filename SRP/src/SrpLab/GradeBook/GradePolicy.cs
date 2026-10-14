using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.GradeBook
{
    public class GradePolicy
    {
        public string LetterGrade( decimal average)
        {
            if (average >= 90) return "A";
            if (average >= 80) return "B";
            if (average >= 70) return "C";
            if (average >= 60) return "D";
            return "F";
        }
        public bool IsHonorRoll(decimal average)
        {
            // Extra academic rule set embedded beside averaging.
            return average >= 85 && LetterGrade( average) is "A" or "B";
        }
    }
}
