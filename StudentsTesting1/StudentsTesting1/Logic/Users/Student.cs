﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsTesting1.Logic.Exams;
using StudentsTesting1.DataAccess;

namespace StudentsTesting1.Logic.Users
{
    public class Student : User
    {
        public string studentID { get; private set; }
        public string recordBook { get; private set; }

        public Student(string FirstName, string LastName, string ID, string RecordBook) : base(FirstName, LastName)
        {
            studentID = ID;
            recordBook = RecordBook;
        }
    }
}
