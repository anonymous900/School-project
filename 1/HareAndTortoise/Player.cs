using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTProject;
using System.Drawing;

namespace HareAndTortoise {

    public class Player {
        private string name;
        private Square location;
        private Image playerTokenImage;
        private Brush playerTokenColour;
        private int money;
        private bool hasWon;


        /// <summary>
        /// defalt player class
        /// </summary>
        public Player() {
            throw new ArgumentException("its use is invalid");
        }
        /// <summary>
        /// Player class
        /// </summary>
        /// <param name="name">player name</param>
        /// <param name="location">location of square</param>
        public Player(string name, Square location) {
            this.name = name;
            this.location = location;
        }


        /// <summary>
        /// set name value and return value
        /// </summary>
        public string Name {
            set { name = value; }
            get { return name; }
        }
        /// <summary>
        /// set money value and return
        /// </summary>
        public int Money {
            set { money = value; }
            get { return money; }
        }
        /// <summary>
        /// set haswon value and return
        /// </summary>
        public bool HasWon {
            set { hasWon = value; }
            get { return hasWon; }
        }
        /// <summary>
        /// set location value and return
        /// </summary>
        public Square Location {
            set { location = value; }
            get { return location; }
        }
        /// <summary>
        /// only return value player token image
        /// </summary>
        public Image PlayerTokenImage {
            get { return playerTokenImage; }
        }
        /// <summary>
        /// set colour of player token and return
        /// </summary>
        public Brush PlayerTokenColour {
            set {
                playerTokenColour = value;
                playerTokenImage = new Bitmap(1, 1);
                using (Graphics g = Graphics.FromImage(PlayerTokenImage)) {
                    g.FillRectangle(playerTokenColour, 0, 0, 1, 1);
                }
            }
            get { return playerTokenColour; }
            
        }
        public int RollTheDice() {
            //Die die1 = HareAndTortoise_Game.Die1;
            Die die1 = HareAndTortoise_Game.die1;
            Die die2 = HareAndTortoise_Game.die2;
            return die1.Roll() + die2.Roll();
            
        }
    }
}


