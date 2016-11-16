using Xunit;

namespace Trivia
{
    public class CategoryQuestionsTests
    {
        // first questions
        // many questions
        // out of questions

        [Fact]
        public void PlacedOnAskedPosition()
        {
            var categoryQuestions = new CategoryQuestions("not useful", new[] {5, 9});
            Assert.True(categoryQuestions.Contains(5));
            Assert.True(categoryQuestions.Contains(9));
        }

        [Fact]
        public void NotPlacedOnAskedPosition()
        {
            var categoryQuestions = new CategoryQuestions("not useful", new[] {5, 9});
            Assert.False(categoryQuestions.Contains(6));
        }
    }
}