using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisMatchCodingDojo {
    public class GameScore {
        private ScoreInGame _scoreCount;
        private ScoreInGame _opponentScoreCount;

        public GameScore() {
            _scoreCount = ScoreInGame.Nil;
            _opponentScoreCount = ScoreInGame.Nil;
        }

        public void Score(Speler voorSpeler, SetScore setScore) {
            var spelerScore = _scoreCount;
            var opponentScore = _opponentScoreCount;
            if (voorSpeler == Speler.Twee) {
                spelerScore = _opponentScoreCount;
                opponentScore = _scoreCount;
            }

            if (IsDeuce()) {
                handleDeuce(voorSpeler, spelerScore, opponentScore, setScore);
                return;
            }

            if (spelerScore == ScoreInGame.Forty) {
                GameIsVoor(setScore, voorSpeler);
                return;
            }

            NextScoreVoorSpeler(voorSpeler); 
        }

        private void NextScoreVoorSpeler(Speler voorSpeler) {
            if (voorSpeler == Speler.Een) {
                _scoreCount = NextScore(_scoreCount);
                return;
            }

            _opponentScoreCount = NextScore(_opponentScoreCount);
        }

        private void handleDeuce(Speler voorSpeler, ScoreInGame spelerScore, ScoreInGame opponentScore, SetScore setScore) {
            if (spelerScore == ScoreInGame.Advantage) {
                GameIsVoor(setScore, voorSpeler);
                return;
            }

            if (opponentScore == ScoreInGame.Advantage) {
                ResetToDeuce();
                return;
            }

            NextScoreVoorSpeler(voorSpeler);
        }

        private void ResetToDeuce() {
            _scoreCount= ScoreInGame.Forty;
            _opponentScoreCount= ScoreInGame.Forty;
        }

        private void GameIsVoor(SetScore setScore,Speler voorSpeler) {
            setScore.Score(voorSpeler);
            _scoreCount = ScoreInGame.Nil;
            _opponentScoreCount = ScoreInGame.Nil;
        }

        private bool IsDeuce() {
            if (_scoreCount == ScoreInGame.Forty && _opponentScoreCount == ScoreInGame.Forty) {
                return true;
            }

            if (_scoreCount == ScoreInGame.Advantage || _opponentScoreCount == ScoreInGame.Advantage) {
                return true;
            }

            return false;
        }

        public override string ToString() {
            return string.Format("{0} {1}", _scoreCount, _opponentScoreCount);
        }


        readonly static Dictionary<ScoreInGame, ScoreInGame> _nextScores;

        static GameScore() {
            _nextScores = new Dictionary<ScoreInGame, ScoreInGame>();
            _nextScores[ScoreInGame.Nil] = ScoreInGame.Fifteen;
            _nextScores[ScoreInGame.Fifteen] = ScoreInGame.Thirty;
            _nextScores[ScoreInGame.Thirty] = ScoreInGame.Forty;

            _nextScores[ScoreInGame.Forty] = ScoreInGame.Advantage;
        }

        static ScoreInGame NextScore(ScoreInGame score) {
            if (_nextScores.ContainsKey(score)) {
                return _nextScores[score];
            }

            throw new InvalidOperationException("Situatie mag niet voorkomen, bel ely");
        }
    }
}
