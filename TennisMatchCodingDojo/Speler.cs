using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisMatchCodingDojo {
    public class Speler {
        private static Speler _spelerEen = new Speler();
        private static Speler _spelerTwee = new Speler();

        public static Speler Een {
            get { return _spelerEen; }
        }

        public static Speler Twee {
            get { return _spelerTwee; }
        }
    }
}
