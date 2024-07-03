using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet
{
    internal interface IDatabase
    {
        public List<Student> Students { get; }
        public List<Subject> Subjects { get; }
        public List<Grade> Grades { get; }
        public List<Promotion> Promotions { get; }
    }
}
