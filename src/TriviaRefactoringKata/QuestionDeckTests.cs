﻿using System;
using Xunit;
using Xunit.Extensions;

namespace Trivia
{
    public class QuestionDeckTests
    {
        [Fact]
        public void CategoryForPlace()
        {
            var deck = new QuestionDeck();

            deck.PlaceOn("my name", new[] { 1, 2, 3, 4, 5, 6 });
            var category = deck.CategoryForPlace(3);

            Assert.Equal("my name", category);
        }

        [Theory]
        [InlineData(12)]
        [InlineData(1234)]
        [InlineData(Int32.MaxValue)]
        [InlineData(-1)]
        public void CategoryForOutOfBoardPlace_(Int32 place)
        {
            var deck = new QuestionDeck();

            deck.FillQuestions();
            var ex = Record.Exception(() => deck.CategoryForPlace(place));

            Assert.IsType<InvalidOperationException>(ex);
            Assert.Contains("out of board", ex.Message);
        }

        [Fact]
        public void CategoryForOutOfBoardPlace()
        {
            var deck = new QuestionDeck();

            deck.PlaceOn("anything", new[] { 6 });
            var ex = Record.Exception(() => deck.CategoryForPlace(10));

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