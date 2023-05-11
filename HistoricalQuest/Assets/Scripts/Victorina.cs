using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;

namespace DefaultNamespace
{
    public static class Victorina
    {
        public class Question
        {
            public readonly string textOfQuestion;
            public readonly string rightAnswer;
            public readonly string answer2;
            public readonly string answer3;
            public readonly string answer4;
            public int century;

            public Question(string textOfQuestion, string rightAnswer, string answer2, string answer3, string answer4, int century)
            {
                this.textOfQuestion = textOfQuestion;
                this.rightAnswer = rightAnswer;
                this.answer2 = answer2;
                this.answer3 = answer3;
                this.answer4 = answer4;
                this.century = century;

            }
        }
        private static List<Question> gotQuestions=new List<Question>();
        public static event Action GameOver;

        public static Question GetQuestion(int era)
        {
            var array = new Question[0];
            switch (era)
            {
                case 0:
                    array = ZeroEraQuestions;
                    break;
                case 1:
                    array = FirstEraQuestions;
                    break;
                case 2:
                    array = SecondEraQuestions;
                    break;
            }

            var x = GetRandomQuestion(array);
            while (gotQuestions.Contains(x))
            {
                x = GetRandomQuestion(array);
                if(gotQuestions.Count(x => SecondEraQuestions.Contains(x)) == array.Length)
                {
                    Console.WriteLine("Игра пройдена");
                    gotQuestions = new List<Question>();
                    GameOver.Invoke();
                }
            }
            gotQuestions.Add(x);
            return x;
        }

        private static Question GetRandomQuestion(Question[] array)
        {
            var rnd = new System.Random();
            var x = rnd.Next(0, array.Length);
            return array[x];
        }

        public static readonly Question[] ZeroEraQuestions =
        {
            new Question
            ("Кирилл и Мефодий создают славянскую письменность - глаголицу",
                "863г.",
                "879г.",
                "859г.",
                "867г.",9),
            new Question
            ("Крещение руси произошло в...",
                "988г.",
                "887г.",
                "978г.",
                "899г.",10),
            new Question
                ("Ледовое побоище произошло в...",
                "1242г.",
                "1240г.",
                "1230г.",
                "1246г.",13),
        };
        public static readonly Question[] FirstEraQuestions = new[]
        {
            new Question
            ("Провозглашение Ивана IV царём произошло в...",
                "1547г.",
                "1549г.",
                "1533г.",
                "1545г.",16),
            new Question
            ("Взятие Астрахани произошло в...",
                "1556г.",
                "1552г.",
                "1554г.",
                "1548г.", 16),
            new Question
            ("Опричнина Ивана IV длилась...",
                "7 лет",
                "10 лет",
                "11 лет",
                "5 лет", 16),

        };
        public static readonly Question[] SecondEraQuestions = new[]
        {
            new Question
            ("Год начала НЭП...",
                "1920г.",
                "1549г.",
                "1533г.",
                "1545г.",20),
            new Question
            ("Год смерти Иосифа Сталина...",
                "1954г.",
                "1552г.",
                "1554г.",
                "1548г.", 20),
            new Question
            ("Дата начала Великой отечественной войны...",
                "1941",
                "10 лет",
                "11 лет",
                "5 лет", 20),

        };
    }
}