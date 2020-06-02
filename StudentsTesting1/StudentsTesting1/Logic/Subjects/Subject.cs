using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsTesting1.Logic.Exams;
using StudentsTesting1.Logic.Groups;

namespace StudentsTesting1.Logic.Subjects
{
    public class Subject : ISubject
    {
        public int id { get; private set; }
        public string subjectTitle { get; private set; }
        public List<IExam> exams { get; private set; } = new List<IExam>();
        public List<IGroup> groups { get; private set; } = new List<IGroup>();

        public Subject(string SubjectTitle)
        {
            subjectTitle = SubjectTitle;
        }
        public Subject(int ID, string SubjectTitle)
        {
            id = ID;
            subjectTitle = SubjectTitle;
        }

        public void AddGroup(IGroup group)
        {
            groups.Add(group);
        }

        public void AddExam(IExam exam)
        {
            exams.Add(exam);
        }
    }
}
