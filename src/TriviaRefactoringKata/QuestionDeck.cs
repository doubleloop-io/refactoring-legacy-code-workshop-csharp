using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class QuestionDeck
    {
        readonly CategoryQuestions pop;
        readonly CategoryQuestions science;
        readonly CategoryQuestions sports;
        readonly CategoryQuestions rock;

        public QuestionDeck()
        {
            pop = new CategoryQuestions("Pop");
            pop.PlacedOn(new[] { 0, 4, 8 });

            science = new CategoryQuestions("Science");
            science.PlacedOn(new[] { 1, 5, 9 });

            sports = new CategoryQuestions("Sports");
            sports.PlacedOn(new[] { 2, 6, 10 });

            rock = new CategoryQuestions("Rock");
            rock.PlacedOn(new[] { 3, 7, 11 });
        }

        static String CreateQuestion(String categoryName, Int32 index)
        {
            return categoryName + " Question " + index;
        }

        public void FillQuestions()
        {
            for (var i = 0; i < 50; i++)
            {
                pop.AddQuestion(CreateQuestion(pop.Name, i));
                science.AddQuestion(CreateQuestion(science.Name, i));
                sports.AddQuestion(CreateQuestion(sports.Name, i));
                rock.AddQuestion(CreateQuestion(rock.Name, i));
            }
        }

        public String CategoryForPlace(Int32 place)
        {
            if (pop.IsPlacedOn(place)) return pop.Name;
            if (science.IsPlacedOn(place)) return science.Name;
            if (sports.IsPlacedOn(place)) return sports.Name;
            if (rock.IsPlacedOn(place)) return rock.Name;
            throw new InvalidOperationException($"Place {place} is out of board.");
        }

        public String AskCategoryQuestion(String category)
        {
            if (category == pop.Name) return pop.NextQuestion();
            if (category == science.Name) return science.NextQuestion();
            if (category == sports.Name) return sports.NextQuestion();
            if (category == rock.Name) return rock.NextQuestion();

            throw new InvalidOperationException($"Missing category {category}");
        }
    }
}