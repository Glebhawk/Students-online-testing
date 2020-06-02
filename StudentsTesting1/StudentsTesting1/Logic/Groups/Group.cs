using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsTesting1.Logic.Users;
using StudentsTesting1.Logic.Exams;
using StudentsTesting1.DataAccess;
using StudentsTesting1.IoC;
using StudentsTesting1.Logic.Subjects;

namespace StudentsTesting1.Logic.Groups
{
    public class Group : IGroup
    {
        public string title { get; private set; }
        public List<Student> students { get; private set; } = new List<Student>(); 
        private IDBAccess dbAccess { get; set; }
        private ExamAccess examAccess;
        private GroupAccess groupAccess;

        public Group(string Title)
        {
            title = Title;
            dbAccess = dbAccess.GetInstance();
            examAccess = new ExamAccess(dbAccess);
            groupAccess = new GroupAccess(dbAccess);
        }

        public void AssignExam(IExam exam)
        {
            foreach (Student student in students)
            {
                examAccess.AssignExam(exam as Exam, student.studentID);
            }
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            students.Remove(student);
        }

        public void AssignSubject(Subject subject)
        {
            groupAccess.AddSubjectToGroup(this, subject);
        }
    }
}
