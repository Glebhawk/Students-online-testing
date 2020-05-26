using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsTesting1.Logic.Exams;
using StudentsTesting1.Logic.Subjects;
using StudentsTesting1.Logic.Questions;
using StudentsTesting1.Logic.Groups;
using StudentsTesting1.Logic.Results;
using StudentsTesting1.IoC;

namespace StudentsTesting1.Logic.Users
{
    class Teacher : User
    {
        public string teacherID { get; private set; }
        public List<ISubject> subjects { get; private set; } = new List<ISubject>();
        private IoCContainer IoC { get; set; } = new IoCContainer();

        public Teacher(string FirstName, string LastName, string ID) : base(FirstName, LastName)
        {
            teacherID = ID;
            IoC.RegisterObject<IGroup, Group>();
            IoC.RegisterObject<IExam, Exam>();
            IoC.RegisterObject<IResult, Result>();
        }

        public void AddSubject(ISubject subject)
        {
            subjects.Add(subject);
        }

        public bool CreateExam(string Title, int NumberOfQuestions, int Attempts, List<IQuestion> Questions, ISubject subject)
        {
            if (Questions.Count < NumberOfQuestions)
            {
                return false;
            }
            else {
                List<object> param = new List<object>();
                param.Add(Title);
                param.Add(NumberOfQuestions);
                param.Add(Attempts);
                Exam exam = IoC.ResolveObject(typeof(Exam), param) as Exam;
                exam.SetQuestions(Questions);
                subject.AddExam(exam);
                return true;
            }
        }

        public void AssignExamToGroup(IExam exam, IGroup group)
        {
            group.AssignExam(exam);
        }

        public List<Result> CheckResults(Group group)
        {

        }
    }
}
