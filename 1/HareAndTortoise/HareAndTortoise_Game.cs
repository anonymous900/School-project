using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HareAndTortoise {
    public static class HareAndTortoise_Game {
        private static int numberOfPlayers = 6;

        private static string[] Player_Name_Arr = new string[] { "One", "Two", "Three", "Four", "Five", "Six" };
        private static Brush[] Player_Colour_Arr = new Brush[] { Brushes.Black, Brushes.Red, Brushes.Gold, Brushes.GreenYellow, Brushes.Fuchsia, Brushes.BlueViolet };

        public static Die die1 = new Die();
        public static Die die2 = new Die();

        private static BindingList<Player> players = new BindingList<Player>();
        public static BindingList<Player> Players {
            get {
                return players;
            }
        }


        public static void SetUpGame() {
            Board.SetUpBoard();
            for (int i = 0; i < numberOfPlayers; i++) {
                Player player = new Player(Player_Name_Arr[i], Board.StartSquare());
                player.PlayerTokenColour = Player_Colour_Arr[i];
                players.Add(player);

            }
        }
        // end SetUpGame
        //more code to be added later
        //public static void TwoDie() {
        // Die die1 = new Die();
        // Die die2 = new Die();
    public static void PlayOneRound() {
            for (int i = 0; i < numberOfPlayers; i++) {
                players[i].Location.Number = players[i].Location.Number + players[i].RollTheDice();
            }
        }


        // MORE METHODS TO BE ADDED HERE LATER

    }//end class
}//end namespace
