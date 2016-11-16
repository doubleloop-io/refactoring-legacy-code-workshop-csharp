using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class QuestionDeck
    {
        readonly List<CategoryQuestions> categories;

        public QuestionDeck()
        {
            var pop = new CategoryQuestions("Pop");
            pop.PlacedOn(new[] { 0, 4, 8 });

            var science = new CategoryQuestions("Science");
            science.PlacedOn(new[] { 1, 5, 9 });

            var sports = new CategoryQuestions("Sports");
            sports.PlacedOn(new[] { 2, 6, 10 });

            var rock = new CategoryQuestions("Rock");
            rock.PlacedOn(new[] { 3, 7, 11 });

            categories = new List<CategoryQuestions>
            {
                pop,
                science,
                sports,
                rock
            };
        }

        static String CreateQuestion(String categoryName, Int32 index)
        {
            return categoryName + " Question " + index;
        }

        public void FillQuestions()
        {
            for (var i = 0; i < 50; i++)
            {
                foreach (var category in categories)
                {
                    category.AddQuestion(CreateQuestion(category.Name, i));
                }
            }
        }

        public String CategoryForPlace(Int32 place)
        {
            var found = categories.SingleOrDefault(x => x.IsPlacedOn(place));
            if (found == null) throw new InvalidOperationException($"Place {place} is out of board.");
            return found.Name;
        }

        public String AskCategoryQuestion(String category)
        {
            var found = categories.SingleOrDefault(x => x.Name == category);
            if (found == null) throw new InvalidOperationException($"Missing category {category}");
            return found.NextQuestion();
        }
    }
}