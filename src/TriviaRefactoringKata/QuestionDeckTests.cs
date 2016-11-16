using System;
using Xunit;
using Xunit.Extensions;

namespace Trivia
{
    public class QuestionDeckTests
    {
        [Fact]
        public void PlaceWithCategory()
        {
            var deck = new QuestionDeck();

            deck.PlaceOn("my name", new[] { 1, 2, 3, 4, 5, 6 });
            var category = deck.CategoryForPlace(3);

            Assert.Equal("my name", category);
        }

        [Fact]
        public void PlaceWithoutCategory()
        {
            var deck = new QuestionDeck();

            deck.PlaceOn("anything", new[] { 6 });
            var ex = Record.Exception(() => deck.CategoryForPlace(10));

            Assert.IsType<InvalidOperationException>(ex);
            Assert.Contains("no category on place 10", ex.Message, StringComparison.InvariantCultureIgnoreCase);
        }

        [Fact]
        public void FirstQuestionForOneCategory()
        {
            var deck = new QuestionDeck();

            deck.AddQuestion("my name", "first question");
            var question = deck.AskCategoryQuestion("my name");

            Assert.Equal("first question", question);
        }

        [Fact]
        public void QuestionForUnknownCategory()
        {
            var deck = new QuestionDeck();

            deck.AddQuestion("anything", "anything");
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