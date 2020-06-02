using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsTesting1.Logic.Results;
using StudentsTesting1.Logic.Exams;
using StudentsTesting1.Logic.Users;
using StudentsTesting1.Logic.Groups;
using StudentsTesting1.IoC;
using StudentsTesting1.DataAccess;
using StudentsTesting1.Logic.Questions;
using StudentsTesting1.Logic.Subjects;

namespace StudentsTesting1.Controllers
{
    public class StudentController
    {
        private Student student { get; set; }
        private IoCContainer IoC { get; set; } = new IoCContainer();
        private IDBAccess dbAccess { get; set; }
        private ResultAccess resultAccess { get; set; }

        public StudentController()
        {
            IoC.RegisterObject<IGroup, Group>();
            IoC.RegisterObject<IExam, Exam>();
            IoC.RegisterObject<IDBAccess, DBAccess>();
            resultAccess = new ResultAccess(dbAccess);
        }
        public void PassExam(Exam exam, List<string> answers)
        {
            List<AnsweredQuestion> answeredQuestions = new List<AnsweredQuestion>();
            for (int i = 0; i < exam.questions.Count; i++)
            {
                AnsweredQuestion answeredQuestion = new AnsweredQuestion(exam.questions[i] as Question, answers[i]);
                answeredQuestions.Add(answeredQuestion);
            }
            List<object> param = new List<object>();
            param.Add(exam);
            param.Add(this);
            param.Add(answeredQuestions);
            resultAccess.InsertResultToDB(IoC.ResolveObject(typeof(Result), param) as Result, exam.id, student.studentID);
        }

        public Result CheckResult(Exam exam)
        {
            return resultAccess.GetResultOfStudent(student.studentID, exam.id);
        }
    }
}
