using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisMatchCodingDojo {
    public class SpelerScore {
        private GameScore _gameScore;
        private SetScore _setScore;


        public SpelerScore(GameScore gameScore, SetScore setScore) {
            _gameScore     = gameScore;
            _setScore      = setScore;
        }

        public void Score(Speler voorSpeler) {
            _gameScore.Score(voorSpeler, _setScore);
        }

        //public void CountOpponentScore() {
        //    _gameScore.CountOpponentScore();
        //}

        public string ToFormattedString(String format) {
            return String.Format(format, _setScore, _gameScore);
        }

        public override string ToString() {
            return string.Format("{0} {1}", _setScore, _gameScore);
            //return base.ToString();
        }
    }
}
