using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class QuestionDeck
    {
        readonly LinkedList<String> popQuestions;
        readonly LinkedList<String> scienceQuestions;
        readonly LinkedList<String> sportsQuestions;
        readonly LinkedList<String> rockQuestions;

        public QuestionDeck()
        {
            popQuestions = new LinkedList<string>();
            scienceQuestions = new LinkedList<string>();
            sportsQuestions = new LinkedList<string>();
            rockQuestions = new LinkedList<string>();
        }

        static String CreateQuestion(String categoryName, Int32 index)
        {
            return categoryName + " Question " + index;
        }

        public void FillQuestions()
        {
            for (var i = 0; i < 50; i++)
            {
                popQuestions.AddLast(CreateQuestion("Pop", i));
                scienceQuestions.AddLast(CreateQuestion("Science", i));
                sportsQuestions.AddLast(CreateQuestion("Sports", i));
                rockQuestions.AddLast(CreateQuestion("Rock", i));
            }
        }

        public String CurrentCategoryPlace(Int32 currentPlace)
        {
            if (currentPlace == 0) return "Pop";
            if (currentPlace == 4) return "Pop";
            if (currentPlace == 8) return "Pop";
            if (currentPlace == 1) return "Science";
            if (currentPlace == 5) return "Science";
            if (currentPlace == 9) return "Science";
            if (currentPlace == 2) return "Sports";
            if (currentPlace == 6) return "Sports";
            if (currentPlace == 10) return "Sports";
            if (currentPlace == 3) return "Rock";
            if (currentPlace == 7) return "Rock";
            if (currentPlace == 11) return "Rock";

            throw new InvalidOperationException($"Place {currentPlace} is out of board.");
        }

        public String AskCategoryQuestion(String category)
        {
            if (category == "Pop")
            {
                var question = popQuestions.First();
                Console.WriteLine(question);
                popQuestions.RemoveFirst();
                return question;
            }
            if (category == "Science")
            {
                var question = scienceQuestions.First();
                Console.WriteLine(question);
                scienceQuestions.RemoveFirst();
                return question;
            }
            if (category == "Sports")
            {
                var question = sportsQuestions.First();
                Console.WriteLine(question);
                sportsQuestions.RemoveFirst();
                return question;
            }
            if (category == "Rock")
            {
                var question = rockQuestions.First();
                Console.WriteLine(question);
                rockQuestions.RemoveFirst();
                return question;
            }
            return null;
        }
    }
}