﻿using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace Project1DotNet
{
    internal class Database : IDatabase
    {
        public List<Student> Students { get; } = new List<Student>();
        public List<Subject> Subjects { get; } = new List<Subject>();
        public List<Grade> Grades { get; } = new List<Grade>();

        public Database()
        {
            this.Students = FilesManagement.ReadFile(Students);
            this.Subjects = FilesManagement.ReadFile(Subjects);
            this.Grades = FilesManagement.ReadFile(Grades);
        }
    }
}
