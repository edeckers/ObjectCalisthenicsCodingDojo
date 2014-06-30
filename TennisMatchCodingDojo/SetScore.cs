using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisMatchCodingDojo {
    public class SetScore {
        private int _scoreSpeler1;
        private int _scoreSpeler2;

        public SetScore(int scoreSpeler1, int scoreSpeler2) {
            _scoreSpeler1 = scoreSpeler1;
            _scoreSpeler2 = scoreSpeler2;
        }

        public void Score(Speler voorSpeler) {
            if (voorSpeler == Speler.Een) {
                _scoreSpeler1++;
                return;
            }
            _scoreSpeler2++;
        }

        public override string ToString() {
            return string.Format("{0} {1}", _scoreSpeler1, _scoreSpeler2);
        }
    }
}
