using System;
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
}