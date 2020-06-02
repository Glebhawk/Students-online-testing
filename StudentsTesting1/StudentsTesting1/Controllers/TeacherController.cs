using StudentsTesting1.Logic.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsTesting1.IoC;
using StudentsTesting1.Logic.Groups;
using StudentsTesting1.Logic.Exams;
using StudentsTesting1.Logic.Results;
using StudentsTesting1.DataAccess;
using StudentsTesting1.Logic.Subjects;
using StudentsTesting1.Logic.Questions;

namespace StudentsTesting1.Controllers
{
    public class TeacherController
    {
        private Teacher teacher { get; set; }
        private IoCContainer IoC { get; set; } = new IoCContainer();
        private IDBAccess dbAccess { get; set; }
        private ResultAccess resultAccess { get; set; }
        private StudentAccess studentAccess { get; set; }

        public TeacherController()
        {
            IoC.RegisterObject<IGroup, Group>();
            IoC.RegisterObject<IExam, Exam>();
            IoC.RegisterObject<IResult, Result>();
            IoC.RegisterObject<IDBAccess, DBAccess>();
            resultAccess = new ResultAccess(dbAccess);
            studentAccess = new StudentAccess(dbAccess);
        }

        public bool CreateExam(string Title, int NumberOfQuestions, int Attempts, List<Question> Questions, Subject subject)
        {
            if (Questions.Count < NumberOfQuestions)
            {
                return false;
            }
            else
            {
                List<object> param = new List<object>();
                param.Add(Title);
                param.Add(NumberOfQuestions);
                param.Add(Attempts);
                Exam exam = IoC.ResolveObject(typeof(Exam), param) as Exam;
                for (int i = 0; i < Questions.Count; i++)
                {
                    exam.AddQuestion(Questions[i]);
                }
                ExamAccess examAccess = new ExamAccess(dbAccess.GetInstance());
                examAccess.InsertExamToDB(exam, subject.id);
                return true;
            }
        }

        public void AssignExamToGroup(IExam exam, IGroup group)
        {
            group.AssignExam(exam);
        }

        public List<Result> CheckResults(Group group, Exam exam)
        {
            List<Result> results = resultAccess.GetResultsOfGroup(group.title, exam.id);
            List<Student> students = studentAccess.GetStudentsFromGroup(group.title);
            foreach (Student student in students)
            {
                int score = 0;
                foreach(Result result in results)
                {
                    if(result.student.studentID == student.studentID)
                    {
                        if (result.score > score)
                        {
                            score = result.score;
                        }
                        else
                        {
                            results.Remove(result);
                        }
                    }
                }
                if (score == 0)
                {
                    results.Add(new Result(student, 0, new List<AnsweredQuestion>()));
                }
            }
            results.OrderBy(r => r.student.lastName);
            return results;
        }
    }
}
