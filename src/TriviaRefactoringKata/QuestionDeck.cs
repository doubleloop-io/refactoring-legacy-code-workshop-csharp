using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class QuestionDeck
    {
        readonly LinkedList<String> popQuestions;
        readonly Int32[] popPlaces;

        readonly LinkedList<String> scienceQuestions;
        readonly Int32[] sciencePlaces;

        readonly LinkedList<String> sportsQuestions;
        readonly Int32[] sportsPlaces;

        readonly LinkedList<String> rockQuestions;
        readonly Int32[] rockPlaces;

        public QuestionDeck()
        {
            popQuestions = new LinkedList<string>();
            popPlaces = new[] { 0, 4, 8 };

            scienceQuestions = new LinkedList<string>();
            sciencePlaces = new[] { 1, 5, 9 };

            sportsQuestions = new LinkedList<string>();
            sportsPlaces = new[] { 2, 6, 10 };

            rockQuestions = new LinkedList<string>();
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
            String question = null;
            LinkedList<String> questions = null;

            if (category == "Pop") questions = popQuestions;
            if (category == "Science") questions = scienceQuestions;
            if (category == "Sports") questions = sportsQuestions;
            if (category == "Rock") questions = rockQuestions;

            if (questions != null) question = NextQuestion(questions);

            return question;
        }

        static String NextQuestion(LinkedList<String> questions)
        {
            var result = questions.First();
            questions.RemoveFirst();
            return result;
        }
    }
}