using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class CategoryQuestions
    {
        readonly LinkedList<String> questions;
        readonly List<Int32> places;
        public String Name { get; }

        public CategoryQuestions(String name)
        {
            questions = new LinkedList<String>();
            places = new List<Int32>();
            Name = name;
        }

        public void PlacedOn(Int32[] where)
        {
            places.AddRange(@where);
        }

        public Boolean IsPlacedOn(Int32 place)
        {
            return places.Contains(place);
        }

        public void AddQuestion(String question)
        {
            questions.AddLast(question);
        }

        public String NextQuestion()
        {
            if (questions.Count == 0) throw new InvalidOperationException("out of questions");
            var result = questions.First();
            questions.RemoveFirst();
            return result;
        }
    }
}