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
        readonly Int32[] popPlaces;
        readonly Int32[] sciencePlaces;
        readonly Int32[] sportsPlaces;
        readonly Int32[] rockPlaces;

        public QuestionDeck()
        {
            popQuestions = new LinkedList<string>();
            scienceQuestions = new LinkedList<string>();
            sportsQuestions = new LinkedList<string>();
            rockQuestions = new LinkedList<string>();
            popPlaces = new[] { 0, 4, 8 };
            sciencePlaces = new[] { 1, 5, 9 };
            sportsPlaces = new[] { 2, 6, 10 };
            rockPlaces = new[] { 3, 7, 11 };
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

        public String CategoryForPlace(Int32 place)
        {
            if (popPlaces.Contains(place)) return "Pop";
            if (sciencePlaces.Contains(place)) return "Science";
            if (sportsPlaces.Contains(place)) return "Sports";
            if (rockPlaces.Contains(place)) return "Rock";

            throw new InvalidOperationException($"Place {place} is out of board.");
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