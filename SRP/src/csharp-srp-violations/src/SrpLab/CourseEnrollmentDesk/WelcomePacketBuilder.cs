using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.CourseEnrollmentDesk
{
    public class WelcomePacketBuilder
    {
        public string BuildWelcomePacket(string studentName, string courseCode, string status)
        {
            // Content design changes with academy marketing — not with seat algorithms.
            
            return $"# Welcome to {courseCode}\nHi {studentName},\nYour status: **{status}**.\n" +
                   $"Bring a laptop. Discord onboarding link: https://example.invalid/{courseCode.ToLowerInvariant()}\n";
        }
    }
}
