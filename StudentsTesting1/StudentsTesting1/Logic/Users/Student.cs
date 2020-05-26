using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsTesting1.Logic.Exams;
using StudentsTesting1.Logic.Groups;
using StudentsTesting1.Logic.Questions;
using StudentsTesting1.Logic.Results;
using StudentsTesting1.IoC;

namespace StudentsTesting1.Logic.Users
{
    class Student : User
    {
    public string studentID { get; private set; }
    public string recordBook { get; private set; }
    public List<IExam> assignedExams { get; private set; } = new List<IExam>();
    private IoCContainer IoC { get; set; } = new IoCContainer();

        public Student(string FirstName, string LastName, string ID) : base(FirstName, LastName)
    {
        studentID = studentID;
        IoC.RegisterObject<IGroup, Group>();
        IoC.RegisterObject<IExam, Exam>();
        }

    public void AddExam(IExam exam)
        {
            assignedExams.Add(exam);
        }

    public Result PassExam(Exam exam, List<string> answers)
        {
            List<AnsweredQuestion> answeredQuestions = new List<AnsweredQuestion>();
            for(int i = 0; i < exam.questions.Count; i++)
            {
                AnsweredQuestion answeredQuestion = new AnsweredQuestion(exam.questions[i] as Question, answers[i]);
                answeredQuestions.Add(answeredQuestion);
            }
            List<object> param = new List<object>();
            param.Add(exam);
            param.Add(this);
            param.Add(answeredQuestions);
            return IoC.ResolveObject(typeof(Result), param) as Result;
        }
}
}
