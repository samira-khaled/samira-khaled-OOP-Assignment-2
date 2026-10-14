using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab
{
    public class PagerService
    {
        private readonly List<string> _pagerLog = new();
        public IReadOnlyList<string> DrainPagerLog()
        {
            var copy = _pagerLog.ToList();
            _pagerLog.Clear();
            return copy;
        }
        public void CheckAndLogPager(int bed, int acuity)
        {
            if (acuity >= 8)
                _pagerLog.Add($"CODE-YELLOW bed={bed} at {DateTime.UtcNow:HH:mm}");
        }
    }
}
