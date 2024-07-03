using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet
{
    internal static class Generate
    {
        // Méthodes "GENERATE"
        public static int GenerateId(List<Student> students)
        {
            if (students.Count > 0) return students.Last().Id + 1;
            else return 0;
        }

        public static int GenerateId(List<Subject> subjects)
        {
            if (subjects.Count > 0) return subjects.Last().Id + 1;
            else return 0;
        }

        public static int GenerateId(List<Promotion> promotions)
        {
            if (promotions.Count > 0) return promotions.Last().Id + 1;
            else return 0;
        }
    }
}
