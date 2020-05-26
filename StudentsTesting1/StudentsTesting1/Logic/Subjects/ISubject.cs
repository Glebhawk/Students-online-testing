using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsTesting1.Logic.Groups;
using StudentsTesting1.Logic.Exams;

namespace StudentsTesting1.Logic.Subjects
{
    interface ISubject
    {
        public void AddGroup(Group group);
        public void AddExam(Exam exam);
    }
}
