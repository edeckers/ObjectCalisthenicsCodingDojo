using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TennisMatchCodingDojo.Tests {
	[TestClass]
	public class MutableTests {
		TennisMatch game;

		[TestInitialize]
		public void Init() {
			game = new TennisMatch();
		}

		[TestMethod]
		public void een_nieuw_spel() {
			var berekendeScore = game.BerekenScore();

			Assert.AreEqual("0 0 0 0", berekendeScore);
		}

		[TestMethod]
		public void een_punt_voor_speler_1() {
			game.ScorePuntVoor(Speler.Een);

			var berekendeScore = game.BerekenScore();

			Assert.AreEqual("0 0 15 0", berekendeScore);
		}

		[TestMethod]
		public void twee_punten_voor_speler_1() {
			game.ScorePuntVoor(Speler.Een);
			game.ScorePuntVoor(Speler.Een);
		
			var berekendeScore = game.BerekenScore();

			Assert.AreEqual("0 0 30 0", berekendeScore);
		}

		[TestMethod]
		public void drie_punten_voor_speler_1() {
			game.ScorePuntVoor(Speler.Een);
			game.ScorePuntVoor(Speler.Een);
			game.ScorePuntVoor(Speler.Een);

			var berekendeScore = game.BerekenScore();

			Assert.AreEqual("0 0 40 0", berekendeScore);
		}

		[TestMethod]
		public void een_love_game_voor_speler_een() {
			game.ScorePuntVoor(Speler.Een);
			game.ScorePuntVoor(Speler.Een);
			game.ScorePuntVoor(Speler.Een);
			game.ScorePuntVoor(Speler.Een);

			var berekendeScore = game.BerekenScore();

			Assert.AreEqual("1 0 0 0", berekendeScore);
		}

		[TestMethod]
		public void nul_vijftien() {
			game.ScorePuntVoor(Speler.Twee);

			var berekendeScore = game.BerekenScore();

			Assert.AreEqual("0 0 0 15", berekendeScore);
		}

		[TestMethod]
		public void een_love_game_voor_speler_twee() {
			game.ScorePuntVoor(Speler.Twee);
			game.ScorePuntVoor(Speler.Twee);
			game.ScorePuntVoor(Speler.Twee);
			game.ScorePuntVoor(Speler.Twee);

			var berekendeScore = game.BerekenScore();

			Assert.AreEqual("0 1 0 0", berekendeScore);
		}

		[TestMethod]
		public void vijftien_vijftien() {
			game.ScorePuntVoor(Speler.Twee);
			game.ScorePuntVoor(Speler.Een);
			
			var berekendeScore = game.BerekenScore();

			Assert.AreEqual("0 0 15 15", berekendeScore);
		}

		[TestMethod]
		public void een_nul_nul_vijftien() {
			game.ScorePuntVoor(Speler.Een);
			game.ScorePuntVoor(Speler.Een);
			game.ScorePuntVoor(Speler.Een);
			game.ScorePuntVoor(Speler.Een);
			game.ScorePuntVoor(Speler.Twee);
			
			var berekendeScore = game.BerekenScore();

			Assert.AreEqual("1 0 0 15", berekendeScore);
		}


		[TestMethod]
		public void acceptatie_test() {
			ScorePoints(Speler.Een, 12);
			ScorePoints(Speler.Twee, 20);
			ScorePoints(Speler.Een, 2);
			ScorePoints(Speler.Twee, 1);
			
			var berekendeScore = game.BerekenScore();

			Assert.AreEqual("3 5 30 15", berekendeScore);
		}

		[TestMethod]
		public void deuce() {
			ScorePoints(Speler.Een, 3);
			ScorePoints(Speler.Twee, 3);

			var score = game.BerekenScore();

			Assert.AreEqual("0 0 40 40", score);
		}

		[TestMethod]
		public void advantage_speler_1() {
			ScorePoints(Speler.Een, 3);
			ScorePoints(Speler.Twee, 3);
			ScorePoints(Speler.Een, 1);

			var score = game.BerekenScore();

			Assert.AreEqual("0 0 A 40", score);
		}

		[TestMethod]
		public void advantage_speler_2() {
			ScorePoints(Speler.Een, 3);
            ScorePoints(Speler.Twee, 3);
            ScorePoints(Speler.Twee, 1);

            var score = game.BerekenScore();

            Assert.AreEqual("0 0 40 A", score);
        }

        [TestMethod]
        public void advantage_speler_1_dan_deuce() {
            ScorePoints(Speler.Een, 3);
            ScorePoints(Speler.Twee, 3);
            ScorePoints(Speler.Een, 1);
            ScorePoints(Speler.Twee, 1);

            var score = game.BerekenScore();

            Assert.AreEqual("0 0 40 40", score);
        }

        [TestMethod]
        public void advantage_speler_1_dan_deuce_dan_speler_2_wint() {
            ScorePoints(Speler.Een, 3);
            ScorePoints(Speler.Twee, 3);
            ScorePoints(Speler.Een, 1);
            ScorePoints(Speler.Twee, 1);
            ScorePoints(Speler.Twee, 1);
            ScorePoints(Speler.Twee, 1);

            var score = game.BerekenScore();

            Assert.AreEqual("0 1 0 0", score);
        }

		private void ScorePoints(Speler speler,int p) {
			for(var i=0;i<p;i++) {
				game.ScorePuntVoor(speler);
			}
		}
	}
}
