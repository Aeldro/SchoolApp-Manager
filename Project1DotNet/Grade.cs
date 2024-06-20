using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet
{
    internal class Grade
    {
        public int StudentId { get; }
        public int SubjectId { get; }
        public double Score { get; }
        public string Appreciation { get; }

        public Grade(int studentId, int subjectId, double score, string appreciation)
        {
            this.StudentId = studentId;
            this.SubjectId = subjectId;
            this.Score = score;
            this.Appreciation = appreciation;
        }
    }
}
