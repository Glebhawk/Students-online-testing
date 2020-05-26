using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsTesting1.Logic.Questions;

namespace StudentsTesting1.Logic.Exams
{
    interface IExam
    {
        public void SetQuestions(List<IQuestion> Questions);
    }
}
