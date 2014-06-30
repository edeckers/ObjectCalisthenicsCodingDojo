using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TennisMatchCodingDojo {
    struct ScoreInGame {
        private int p;

        public ScoreInGame(int p) {
            // TODO: Complete member initialization
            this.p = p;
        }

        public static bool operator  == (ScoreInGame score1, ScoreInGame score2) {
            return score1.Equals(score2);
        }

        public static bool operator  != (ScoreInGame s1, ScoreInGame s2) {
            return !(s1==s2);
        }

        public static ScoreInGame Nil {
            get {
                return new ScoreInGame(0);
            }
        }

        public static ScoreInGame Fifteen {
            get {
                return new ScoreInGame(15);
            }
        }

        public static ScoreInGame Thirty {
            get {
                return new ScoreInGame(30);
            }
        }

        public static ScoreInGame Forty {
            get {
                return new ScoreInGame(40);
            }
        }

        public static ScoreInGame Advantage {
            get {
                return new ScoreInGame(4);
            }
        }

        //public void NextScore() {
        //    if (this == Nil) {
        //        p = Fifteen.p;
        //        return;
        //    }

        //    if (this == Fifteen) {
        //        p = Thirty.p;
        //        return;
        //    }

        //    if (this == Thirty) {
        //        p = Forty.p;
        //        return;
        //    }

        //    if (this == Forty) {
        //        p = Advantage.p;
        //        return;
        //    }
        //}

        public override string ToString() {
            return this==Advantage ? "A" : p.ToString();
        }
    }
}
