using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsTesting1.Logic.Users;
using StudentsTesting1.Logic.Exams;

namespace StudentsTesting1.Logic.Groups
{
    class Group : IGroup
    {
        public string title { get; private set; }
        public List<Student> students { get; private set; } = new List<Student>();

        public Group(string Title)
        {
            title = Title;
        }

        public void AssignExam(IExam exam)
        {
            foreach (Student student in students)
            {
                student.AddExam(exam);
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
    }
}
