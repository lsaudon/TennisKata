using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace TennisKata.Tests
{
    public class TennisTests
    {
        private int _player1Score;
        private int _player2Score;
        private string _expectedScore;

        [Theory]
        [ClassData(typeof(TennisTestData))]
        public void CheckTennisGame1(int player1Score, int player2Score, string expectedScore)
        {
            _expectedScore = expectedScore;
            _player2Score = player2Score;
            _player1Score = player1Score;
            var game = new TennisGame1("player1", "player2");
            CheckAllScores(game);
        }


        [Theory]
        [ClassData(typeof(TennisTestData))]
        public void CheckTennisGame2(int player1Score, int player2Score, string expectedScore)
        {
            _expectedScore = expectedScore;
            _player2Score = player2Score;
            _player1Score = player1Score;
            var game = new TennisGame2("player1", "player2");
            CheckAllScores(game);
        }

        [Theory]
        [ClassData(typeof(TennisTestData))]
        public void CheckTennisGame3(int player1Score, int player2Score, string expectedScore)
        {
            _expectedScore = expectedScore;
            _player2Score = player2Score;
            _player1Score = player1Score;
            var game = new TennisGame3("player1", "player2");
            CheckAllScores(game);
        }

        private void CheckAllScores(ITennisGame game)
        {
            var highestScore = Math.Max(_player1Score, _player2Score);
            for (var i = 0; i < highestScore; i++)
            {
                if (i < _player1Score)
                    game.WonPoint("player1");
                if (i < _player2Score)
                    game.WonPoint("player2");
            }

            Assert.Equal(_expectedScore, game.GetScore());
        }
    }

    public class ExampleGameTennisTest
    {
        [Fact]
        public void CheckGame1()
        {
            var game = new TennisGame1("player1", "player2");
            RealisticTennisGame(game);
        }

        [Fact]
        public void CheckGame2()
        {
            var game = new TennisGame2("player1", "player2");
            RealisticTennisGame(game);
        }

        [Fact]
        public void CheckGame3()
        {
            var game = new TennisGame3("player1", "player2");
            RealisticTennisGame(game);
        }

        private void RealisticTennisGame(ITennisGame game)
        {
            string[] points = {"player1", "player1", "player2", "player2", "player1", "player1"};
            string[] expectedScores =
            {
                "Fifteen-Love", "Thirty-Love", "Thirty-Fifteen", "Thirty-All", "Forty-Thirty", "Win for player1"
            };
            for (var i = 0; i < 6; i++)
            {
                game.WonPoint(points[i]);
                Assert.Equal(expectedScores[i], game.GetScore());
            }
        }
    }

    public class TennisTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {0, 0, "Love-All"};
            yield return new object[] {1, 1, "Fifteen-All"};
            yield return new object[] {2, 2, "Thirty-All"};
            yield return new object[] {3, 3, "Deuce"};
            yield return new object[] {4, 4, "Deuce"};
            yield return new object[] {1, 0, "Fifteen-Love"};
            yield return new object[] {0, 1, "Love-Fifteen"};
            yield return new object[] {2, 0, "Thirty-Love"};
            yield return new object[] {0, 2, "Love-Thirty"};
            yield return new object[] {3, 0, "Forty-Love"};
            yield return new object[] {0, 3, "Love-Forty"};
            yield return new object[] {4, 0, "Win for player1"};
            yield return new object[] {0, 4, "Win for player2"};
            yield return new object[] {2, 1, "Thirty-Fifteen"};
            yield return new object[] {1, 2, "Fifteen-Thirty"};
            yield return new object[] {3, 1, "Forty-Fifteen"};
            yield return new object[] {1, 3, "Fifteen-Forty"};
            yield return new object[] {4, 1, "Win for player1"};
            yield return new object[] {1, 4, "Win for player2"};
            yield return new object[] {3, 2, "Forty-Thirty"};
            yield return new object[] {2, 3, "Thirty-Forty"};
            yield return new object[] {4, 2, "Win for player1"};
            yield return new object[] {2, 4, "Win for player2"};
            yield return new object[] {4, 3, "Advantage player1"};
            yield return new object[] {3, 4, "Advantage player2"};
            yield return new object[] {5, 4, "Advantage player1"};
            yield return new object[] {4, 5, "Advantage player2"};
            yield return new object[] {15, 14, "Advantage player1"};
            yield return new object[] {14, 15, "Advantage player2"};
            yield return new object[] {6, 4, "Win for player1"};
            yield return new object[] {4, 6, "Win for player2"};
            yield return new object[] {16, 14, "Win for player1"};
            yield return new object[] {14, 16, "Win for player2"};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}