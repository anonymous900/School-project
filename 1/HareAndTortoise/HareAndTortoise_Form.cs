using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 * Name: Hoang Minh Nguyen (Jackie)
 * Student number: n9930191
 * 
 * Name: Tien Khai Nguyen (kyle)
 * Student number: n9913998
 * 
 * 
 */

namespace HareAndTortoise {
    public partial class HareAndTortoise_Form : Form {

        const int NUM_OF_ROWS = 8;
        const int NUM_OF_COLUMNS = 7;
        const int NUM_START = 0;
        const int NUM_FINISH = 55;
        const int row = 7, column = 0;
        /// <summary>
        /// Hare and tortoise_form
        /// </summary>
        public HareAndTortoise_Form() {

            InitializeComponent();
            HareAndTortoise_Game.SetUpGame();
            ResizeGameBoard();
            SetUpGuiGameBoard();
            playerBindingSource.DataSource = HareAndTortoise_Game.Players;
            UpdateGuiPlayerSquare();
        }
        /// <summary>
        /// Set up GUI game board square
        /// </summary>
            private void SetUpGuiGameBoard() {

            // for each square that is on the game board 
            //      obtain the Square object associated with the square
            //      create a SquareControl object (ie call Constructor)
            //      if the square is either Start square or Finish square
            //         set the BackColor of the SquareControl to BurlyWood
            //      otherwise do not set the BackColor
            //      Determine the correct position (cell) in the TablelayoutPanel of the square
            //      Add the SquareControl object to that position of the TableLayoutPanel
            int row, column;
            //get the determined square to each TableLayoutPanel
            for (int number = 0; number < 56; number++) {
                SquareControl squareControl = new SquareControl(Board.GetGameBoardSquare(number), HareAndTortoise_Game.Players);
                if (number == NUM_START || number == NUM_FINISH) {
                    squareControl.BackColor = Color.BurlyWood;
                }

                MapSquareToTablePanel(number, out row, out column);


                gameBoardPanel.Controls.Add(squareControl, column, row);
                                
            }
        }//end SetUpGuiGameBoard()

    public void UpdateGuiPlayerSquare() {
            int row, column;
            for (int i = 0; i < HareAndTortoise_Game.Players.Count; i++) {
                var locationSquare = HareAndTortoise_Game.Players[i].Location;
                MapSquareToTablePanel(locationSquare.Number, out row, out column);
                var squareControl = SquareControlAt(locationSquare.Number);
                squareControl.ContainsPlayers[i] = true;

            }
            gameBoardPanel.Invalidate(true);

    }
    private SquareControl SquareControlAt(int squareNumber) {
        int row, column;
        MapSquareToTablePanel(squareNumber, out row, out column);
        return (SquareControl)gameBoardPanel.GetControlFromPosition(column, row);
    }

        /// <summary>
        /// resize game board square
        /// </summary>
        private void ResizeGameBoard() {
            const int SQUARE_SIZE = SquareControl.SQUARE_SIZE;
            int currentHeight = gameBoardPanel.Size.Height;
            int currentWidth = gameBoardPanel.Size.Width;
            int desiredHeight = SQUARE_SIZE * NUM_OF_ROWS;
            int desiredWidth = SQUARE_SIZE * NUM_OF_COLUMNS;
            int increaseInHeight = desiredHeight - currentHeight;
            int increaseInWidth = desiredWidth - currentWidth;
            this.Size += new Size(increaseInWidth, increaseInHeight);
            gameBoardPanel.Size = new Size(desiredWidth, desiredHeight);
        } //end ResizeGameBoard

        private void btnRollDice_Click(object sender, EventArgs e) {
            HareAndTortoise_Game.PlayOneRound();
            UpdateGuiPlayerSquare();
        }

        /// <summary>
        /// determine the correct position in TableLayoutPanel of the square
        /// </summary>
        /// <param name="number">square number</param>
        /// <param name="row">row of TableLayoutPanel</param>
        /// <param name="column">column of TableLayourPanel</param>
        private static void MapSquareToTablePanel(int number, out int row, out int column) {

            switch (number / 7) {
                case 0:
                    row = 7;
                    break;
                case 1:
                    row = 6;
                    break;
                case 2:
                    row = 5;
                    break;
                case 3:
                    row = 4;
                    break;
                case 4:
                    row = 3;
                    break;
                case 5:
                    row = 2;
                    break;
                case 6:
                    row = 1;
                    break;
                default:
                    row = 0;
                    break;

            }

            if (row % 2 != 0) {
                column = number % 7;
            } else {
                column = 6 - number % 7;
            }

        }
    }//end class 
} //end namespace
