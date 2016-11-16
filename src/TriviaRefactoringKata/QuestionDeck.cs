using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class QuestionDeck
    {
        readonly LinkedList<String> scienceQuestions;
        readonly Int32[] sciencePlaces;

        readonly LinkedList<String> sportsQuestions;
        readonly Int32[] sportsPlaces;

        readonly LinkedList<String> rockQuestions;
        readonly Int32[] rockPlaces;

        readonly CategoryQuestions pop;

        public QuestionDeck()
        {
            scienceQuestions = new LinkedList<string>();
            sciencePlaces = new[] { 1, 5, 9 };

            sportsQuestions = new LinkedList<string>();
            sportsPlaces = new[] { 2, 6, 10 };

            rockQuestions = new LinkedList<string>();
            rockPlaces = new[] { 3, 7, 11 };

            pop = new CategoryQuestions("Pop", new[] { 0, 4, 8 });
        }

        static String CreateQuestion(String categoryName, Int32 index)
        {
            return categoryName + " Question " + index;
        }

        public void FillQuestions()
        {
            for (var i = 0; i < 50; i++)
            {
                scienceQuestions.AddLast(CreateQuestion("Science", i));
                sportsQuestions.AddLast(CreateQuestion("Sports", i));
                rockQuestions.AddLast(CreateQuestion("Rock", i));

                pop.AddQuestion(CreateQuestion(pop.Name, i));
            }
        }

        public String CategoryForPlace(Int32 place)
        {
            if (sciencePlaces.Contains(place)) return "Science";
            if (sportsPlaces.Contains(place)) return "Sports";
            if (rockPlaces.Contains(place)) return "Rock";

            if (pop.Contains(place)) return pop.Name;
            throw new InvalidOperationException($"Place {place} is out of board.");
        }

        public String AskCategoryQuestion(String category)
        {
            LinkedList<String> questions = null;

            if (category == "Science") questions = scienceQuestions;
            if (category == "Sports") questions = sportsQuestions;
            if (category == "Rock") questions = rockQuestions;

            if (category == pop.Name) return pop.NextQuestion();

            if (questions != null) return NextQuestion(questions);

            throw new InvalidOperationException($"Missing category {category}");
        }

        static String NextQuestion(LinkedList<String> questions)
        {
            var result = questions.First();
            questions.RemoveFirst();
            return result;
        }
    }
}