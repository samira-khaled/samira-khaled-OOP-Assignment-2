using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.GradeBook
{
    public class GradeCalculator
    {
        public void RecordScore(Dictionary<string, List<decimal>> scores, string studentId, decimal score)
        {
            if (score is < 0 or > 100) throw new ArgumentOutOfRangeException(nameof(score));
            if (!scores.TryGetValue(studentId, out var list))
            {
                list = new List<decimal>();
                scores[studentId] = list;
            }
            list.Add(score);
        }

        public decimal CalculateAverage(Dictionary<string, List<decimal>> scores, string studentId)
        {
            if (!scores.TryGetValue(studentId, out var list) || list.Count == 0) return 0m;
            return Math.Round(list.Average(), 2);
        }
    }
}
