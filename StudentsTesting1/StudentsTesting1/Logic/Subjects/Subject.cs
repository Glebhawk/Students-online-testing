using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsTesting1.Logic.Exams;
using StudentsTesting1.Logic.Groups;

namespace StudentsTesting1.Logic.Subjects
{
    class Subject : ISubject
    {
        public string subjectTitle { get; private set; }
        public List<Exam> exams { get; private set; } = new List<Exam>();
        public List<Group> groups { get; private set; } = new List<Group>();

        public Subject(string SubjectTitle)
        {
            subjectTitle = SubjectTitle;
        }

        public void AddGroup(Group group)
        {
            groups.Add(group);
        }

        public void AddExam(Exam exam)
        {
            exams.Add(exam);
        }
    }
}
