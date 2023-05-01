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

            public Question(string textOfQuestion, string rightAnswer, string answer2, string answer3, string answer4)
            {
                this.textOfQuestion = textOfQuestion;
                this.rightAnswer = rightAnswer;
                this.answer2 = answer2;
                this.answer3 = answer3;
                this.answer4 = answer4;
            }
        }

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
            }

            var x = GetRandomQuestion(array);
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
                "863",
                "879",
                "859",
                "867"),
            new Question
            ("Тестовый вопрос2",
                "Правильный ответ",
                "ГЫЫЫ",
                "БЫЫЫЫ",
                "МЫЫЫ"),
        };
        public static readonly Question[] FirstEraQuestions = new[]
        {
            new Question
            ("Тестовый вопрос iz epohi 1",
                "Правильный ответ",
                "ГЫЫЫ",
                "БЫЫЫЫ",
                "МЫЫЫ"),
            new Question
            ("Тестовый вопрос2 iz epohi 1",
                "Правильный ответ",
                "ГЫЫЫ",
                "БЫЫЫЫ",
                "МЫЫЫ"),
        };
    }
}