using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UglyTrivia;

namespace Trivia
{
    public class GameRunner
    {

        private static bool notAWinner;

        public static void Main(String[] args)
        {
            Run(new Random());
        }

        public static void Run(Random rand)
        {
            Game aGame = new Game();

            aGame.PlaceCategory("Pop", new[] { 0, 4, 8 });
            FillWithSimpleQuestions(aGame, "Pop");

            aGame.PlaceCategory("History", new[] { 1, 5, 9 });
            FillWithSimpleQuestions(aGame, "History");

            aGame.PlaceCategory("Sports", new[] { 2, 6, 10 });
            FillWithSimpleQuestions(aGame, "Sports");

            aGame.PlaceCategory("Rock", new[] { 3, 7, 11 });
            FillWithSimpleQuestions(aGame, "Rock");

            aGame.add("Chet");
            aGame.add("Pat");
            aGame.add("Sue");


            do
            {
                aGame.roll(rand.Next(5) + 1);

                if (rand.Next(9) == 7)
                {
                    notAWinner = aGame.wrongAnswer();
                }
                else
                {
                    notAWinner = aGame.wasCorrectlyAnswered();
                }
            } while (notAWinner);
        }

        static void FillWithSimpleQuestions(Game aGame, String categoryName)
        {
            for (var i = 0; i < 50; i++)
            {
                var question = CreateSimpleQuestion(categoryName, i);
                aGame.AddQuestion(categoryName, question);
            }
        }

        static String CreateSimpleQuestion(String categoryName, Int32 index)
        {
            return categoryName + " Question " + index;
        }
    }

}