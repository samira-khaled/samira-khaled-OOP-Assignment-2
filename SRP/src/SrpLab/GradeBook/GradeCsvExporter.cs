using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.GradeBook
{
    public class GradeCsvExporter
    {
        public string ExportCsvBuilder(IEnumerable<string> studentIds, Func<string, decimal> averageFunc, Func<string, string> letterFunc, Func<string, bool> meetsHonorRollFunc)
        {
            var rows = new List<string> { "studentId,average,letter,honor" };
            foreach (var id in studentIds.OrderBy(x => x))
                rows.Add($"{id},{averageFunc(id)},{letterFunc(id)},{(meetsHonorRollFunc(id) ? 1 : 0)}");
            return string.Join('\n', rows);
        }
    }
}
