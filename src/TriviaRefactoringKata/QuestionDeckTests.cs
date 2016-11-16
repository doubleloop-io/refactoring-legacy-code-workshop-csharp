using System;
using Xunit;

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
        public void AskMultipleQuestionsForMixedCategories()
        {
            var deck = new QuestionDeck();

            deck.AddQuestion("category1", "q1");
            deck.AddQuestion("category1", "q2");
            deck.AddQuestion("category2", "q3");
            deck.AddQuestion("category2", "q4");
            Assert.Equal("q1", deck.AskCategoryQuestion("category1"));
            Assert.Equal("q3", deck.AskCategoryQuestion("category2"));
            Assert.Equal("q4", deck.AskCategoryQuestion("category2"));
            Assert.Equal("q2", deck.AskCategoryQuestion("category1"));
        }
    }
}