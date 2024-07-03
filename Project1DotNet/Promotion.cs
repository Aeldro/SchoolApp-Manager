using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet
{
    internal class Promotion
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Promotion(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
