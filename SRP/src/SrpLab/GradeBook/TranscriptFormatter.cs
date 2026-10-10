using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.GradeBook
{
    public class TranscriptFormatter
    {
        public string ExportTranscript(string studentId, string fullName, decimal average, string letterGrade, bool meetsHonorRoll)
        { 
            // Registrar document format ≠ grading policy.
            return $"TRANSCRIPT\nStudent: {fullName} ({studentId})\nAverage: {average}\nLetter: {letterGrade}\nHonor: {meetsHonorRoll}\n";
        
        }
       
    }
}
