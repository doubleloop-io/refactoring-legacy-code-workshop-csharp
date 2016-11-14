using System;

namespace Trivia
{
    public class CategoryQuestions
    {
        public String Name { get; }

        public CategoryQuestions(String name, Int32[] places)
        {
            Name = name;
        }

        public void AddQuestion(String question)
        {
        }

        public Boolean Contains(Int32 place)
        {
            return false;
        }

        public String NextQuestion()
        {
            return null;
        }
    }
}