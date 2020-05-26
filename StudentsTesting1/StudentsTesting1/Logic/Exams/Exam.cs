using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsTesting1.Logic.Questions;
using StudentsTesting1.Logic.Results;

namespace StudentsTesting1.Logic.Exams
{
    class Exam : IExam
    {
        public string title { get; private set; }
        public int numberOfQuestions { get; private set; }
        public int attempts { get; private set; }
        public List<IQuestion> questions { get; private set; } = new List<IQuestion>();

        public Exam( string Title, int Number, int Attempts)
        {
            title = Title;
            numberOfQuestions = Number;
            attempts = Attempts;
        }

        public void SetQuestions(List<IQuestion> Questions)
        {
            questions = Questions;
        }
    }
}
