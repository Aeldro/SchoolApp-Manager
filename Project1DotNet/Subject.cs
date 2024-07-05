using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet
{
    internal class Subject : Identifiable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Subject(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public List<Grade> GetGrades(Promotion promotion)
        {
            List<Grade> grades = ListsManagement.GetGrades().Where(el => el.SubjectId == this.Id).ToList();
            List<Student> students = promotion.GetStudents();

            List<Grade> promotionGrades = grades.Where(el => el.GetStudent().Promotion == promotion).ToList();

            return promotionGrades;
        }

        public double GetAverage(Promotion promotion)
        {
            List<Grade> grades = GetGrades(promotion);
            double average = grades.Average(grade => grade.Score);
            return average;
        }
    }
}
