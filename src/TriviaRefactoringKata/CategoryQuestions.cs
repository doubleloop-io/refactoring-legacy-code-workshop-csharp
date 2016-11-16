using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class CategoryQuestions
    {
        readonly Int32[] places;
        readonly LinkedList<String> questions;
        public String Name { get; }

        public CategoryQuestions(String name, Int32[] places)
        {
            questions = new LinkedList<String>();
            this.places = places;
            Name = name;
        }

        public void AddQuestion(String question)
        {
            questions.AddLast(question);
        }

        public Boolean IsPlacedOn(Int32 place)
        {
            return places.Contains(place);
        }

        public String NextQuestion()
        {
            var result = questions.First();
            questions.RemoveFirst();
            return result;
        }
    }
}