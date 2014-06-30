using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisMatchCodingDojo
{
    public class TennisMatch
    {
        private SpelerScore _scoreSpeler1;
        //private SpelerScore _scoreSpeler2;

        public TennisMatch() {
            _scoreSpeler1 =
                new SpelerScore(
                    new GameScore(),
                    new SetScore(0,0)
                );
            //_scoreSpeler2 =
            //    new SpelerScore(
            //        new GameScore(),
            //        new SetScore(0)
            //    );
        }

        public void ScorePuntVoor(Speler speler) {
            //var spelerScore   = _scoreSpeler1;
            //var opponentScore = _scoreSpeler2;
            //if (speler == Speler.Twee) {
            //    spelerScore   = _scoreSpeler2;
            //    opponentScore = _scoreSpeler1;
            //}

            _scoreSpeler1.Score(speler);
            //opponentScore.CountOpponentScore();
        }


        public string BerekenScore() {
            //return  _scoreSpeler1.ToFormattedString("{0} {{0}} {1} {{1}}");
            return _scoreSpeler1.ToString();

            //return _scoreSpeler2.ToFormattedString(intermediateScore);
        }
    }
}
