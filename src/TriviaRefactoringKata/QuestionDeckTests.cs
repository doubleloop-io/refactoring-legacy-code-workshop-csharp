using System;
using Xunit;
using Xunit.Extensions;

namespace Trivia
{
    public class QuestionDeckTests
    {
        [Theory]
        [InlineData(0, "Pop")]
        [InlineData(4, "Pop")]
        [InlineData(8, "Pop")]
        [InlineData(1, "Science")]
        [InlineData(5, "Science")]
        [InlineData(9, "Science")]
        [InlineData(2, "Sports")]
        [InlineData(6, "Sports")]
        [InlineData(10, "Sports")]
        [InlineData(3, "Rock")]
        [InlineData(7, "Rock")]
        [InlineData(11, "Rock")]
        public void CategoryForBoardPlace(Int32 place, String expected)
        {
            var deck = new QuestionDeck();

            var category = deck.CategoryForPlace(place);

            Assert.Equal(expected, category);
        }

        [Theory]
        [InlineData(12)]
        [InlineData(1234)]
        [InlineData(Int32.MaxValue)]
        [InlineData(-1)]
        public void CategoryForOutOfBoardPlace(Int32 place)
        {
            var deck = new QuestionDeck();

            var ex = Record.Exception(() => deck.CategoryForPlace(place));

            Assert.IsType<InvalidOperationException>(ex);
            Assert.Contains("out of board", ex.Message);
        }

        [Theory]
        [InlineData("Pop")]
        [InlineData("Science")]
        [InlineData("Sports")]
        [InlineData("Rock")]
        public void FirstQuestionForOneCategory(String category)
        {
            var deck = new QuestionDeck();

            deck.FillQuestions();
            var question = deck.AskCategoryQuestion(category);

            Assert.Equal(category + " Question 0", question);
        }

        [Fact]
        public void QuestionForUnknownCategory()
        {
            var deck = new QuestionDeck();

            deck.FillQuestions();
            var ex = Record.Exception(() => deck.AskCategoryQuestion("unknown"));

            Assert.IsType<InvalidOperationException>(ex);
            Assert.Contains("missing category unknown", ex.Message, StringComparison.InvariantCultureIgnoreCase);
        }

        [Fact]
        public void AskMultipleQuestionForSameCategory()
        {
            var deck = new QuestionDeck();

            deck.FillQuestions();
            Assert.Equal("Pop Question 0", deck.AskCategoryQuestion("Pop"));
            Assert.Equal("Pop Question 1", deck.AskCategoryQuestion("Pop"));
            Assert.Equal("Pop Question 2", deck.AskCategoryQuestion("Pop"));
        }

        [Fact]
        public void AskMultipleQuestionsForMixedCategories()
        {
            var deck = new QuestionDeck();

            deck.FillQuestions();
            Assert.Equal("Pop Question 0", deck.AskCategoryQuestion("Pop"));
            Assert.Equal("Sports Question 0", deck.AskCategoryQuestion("Sports"));
            Assert.Equal("Pop Question 1", deck.AskCategoryQuestion("Pop"));
            Assert.Equal("Rock Question 0", deck.AskCategoryQuestion("Rock"));
            Assert.Equal("Sports Question 1", deck.AskCategoryQuestion("Sports"));
        }
    }
}