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
            categories = new List<CategoryQuestions>();
        }

        static String CreateQuestion(String categoryName, Int32 index)
        {
            return categoryName + " Question " + index;
        }

        public void FillQuestions()
        {
            var pop = AddCategoryQuestions("Pop");
            pop.PlacedOn(new[] { 0, 4, 8 });
            for (var i = 0; i < 50; i++) pop.AddQuestion(CreateQuestion(pop.Name, i));

            var science = AddCategoryQuestions("Science");
            science.PlacedOn(new[] { 1, 5, 9 });
            for (var i = 0; i < 50; i++) science.AddQuestion(CreateQuestion(science.Name, i));

            var sports = AddCategoryQuestions("Sports");
            sports.PlacedOn(new[] { 2, 6, 10 });
            for (var i = 0; i < 50; i++) sports.AddQuestion(CreateQuestion(sports.Name, i));

            var rock = AddCategoryQuestions("Rock");
            rock.PlacedOn(new[] { 3, 7, 11 });
            for (var i = 0; i < 50; i++) rock.AddQuestion(CreateQuestion(rock.Name, i));
        }

        public void PlaceOn(String categoryName, Int32[] places)
        {
            var categoryQuestions = AddCategoryQuestions(categoryName);
            categoryQuestions.PlacedOn(places);
        }

        public String CategoryForPlace(Int32 place)
        {
            var found = categories.SingleOrDefault(x => x.IsPlacedOn(place));
            if (found == null) throw new InvalidOperationException($"No category on place {place}.");
            return found.Name;
        }

        public void AddQuestion(String categoryName, String question)
        {
            var categoryQuestions = AddCategoryQuestions(categoryName);
            categoryQuestions.AddQuestion(question);
        }

        public String AskCategoryQuestion(String category)
        {
            var found = categories.SingleOrDefault(x => x.Name == category);
            if (found == null) throw new InvalidOperationException($"Missing category {category}");
            return found.NextQuestion();
        }

        CategoryQuestions AddCategoryQuestions(String categoryName)
        {
            var categoryQuestions = new CategoryQuestions(categoryName);
            categories.Add(categoryQuestions);
            return categoryQuestions;
        }
    }
}