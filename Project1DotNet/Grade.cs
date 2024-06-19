using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet
{
    internal class Grade
    {
        public Subject Subject { get; set; }
        public double Score { get; set; }
        public string Appreciation { get; set; }

        public Grade(Subject subject, double score, string appreciation)
        {
            this.Subject = subject;
            this.Score = score;
            this.Appreciation = appreciation;
        }
    }
}
