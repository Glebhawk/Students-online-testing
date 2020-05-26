using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsTesting1.Logic.Questions
{
    class Question : IQuestion
    {
        public string question { get; protected set; }
        public string correctAnswer { get; protected set; }
        public List<string> falseAnswers { get; protected set; } = new List<string>();

        public Question() { }

        public Question(string Question, string CorrectAnswer, List<string> FalseAnswers)
        {
            question = Question;
            correctAnswer = CorrectAnswer;
            falseAnswers = FalseAnswers;
        }
    }
}
