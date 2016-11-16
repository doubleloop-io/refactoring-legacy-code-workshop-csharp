using System;
using Xunit;

namespace Trivia
{
    public class CategoryQuestionsTests
    {
        [Fact]
        public void ExposeName()
        {
            var categoryQuestions = new CategoryQuestions("my name");
            Assert.Equal("my name", categoryQuestions.Name);
        }

        [Fact]
        public void PlacedOnAskedPosition()
        {
            var categoryQuestions = new CategoryQuestions("anything");
            categoryQuestions.PlacedOn(new[] { 5, 9 });
            Assert.True(categoryQuestions.IsPlacedOn(5));
            Assert.True(categoryQuestions.IsPlacedOn(9));
        }

        [Fact]
        public void NotPlacedOnAskedPosition()
        {
            var categoryQuestions = new CategoryQuestions("anything");
            categoryQuestions.PlacedOn(new[] { 5, 9 });
            Assert.False(categoryQuestions.IsPlacedOn(6));
        }

        [Fact]
        public void AskManyQuestions()
        {
            var categoryQuestions = new CategoryQuestions("anything");
            categoryQuestions.AddQuestion("first");
            categoryQuestions.AddQuestion("second");
            Assert.Equal("first", categoryQuestions.NextQuestion());
            Assert.Equal("second", categoryQuestions.NextQuestion());
        }

        [Fact]
        public void AskTooManyQuestions()
        {
            var categoryQuestions = new CategoryQuestions("anything");
            categoryQuestions.AddQuestion("first");
            categoryQuestions.NextQuestion();

            var ex = Record.Exception(() => categoryQuestions.NextQuestion());

            Assert.IsType<InvalidOperationException>(ex);
            Assert.Contains("out of questions", ex.Message, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}