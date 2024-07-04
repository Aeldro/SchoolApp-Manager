using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet
{
    internal class Promotion : Identifiable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Promotion(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public List<Student> GetStudents()
        {
            List<Student> students = ListsManagement.GetStudents();
            students = students.Where(el => el.Promotion.Id == this.Id).ToList();
            return students;
        }
    }
}
