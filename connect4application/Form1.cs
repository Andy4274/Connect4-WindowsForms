using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace connect4application
{
    public partial class Form1 : Form
    {
        Game g = new Game();
        PauseClass p = new PauseClass();
        Button[] playHereButtons = new Button[7];
        PictureBox[,] map = new PictureBox[7,6];
        Image player;
        Image computer;
        Image empty;
        
        public Form1()
        {
            InitializeComponent();
            
            playHereButtons[0] = column1B;
            playHereButtons[1] = column2B;
            playHereButtons[2] = column3B;
            playHereButtons[3] = column4B;
            playHereButtons[4] = column5B;
            playHereButtons[5] = column6B;
            playHereButtons[6] = column7B;
            wireMap();
            player = Image.FromFile(@".\..\..\..\player.bmp");
            computer = Image.FromFile(@".\..\..\..\computer.bmp");
            empty = Image.FromFile(@".\..\..\..\empty.bmp");
            DrawMap();
        }

        public void ClickPlayHereButton(int column)
        {
            g.move(column, Game.player);
            //disable all buttons
            for (int i = 0; i < 7; i++)
            {                
                    playHereButtons[i].Enabled = false;            
            }
            //redraw the map
            DrawMap();
            if (g.getWin())
            {
                if (MessageBox.Show("You won!", "Connect4", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            // check for a draw
            if (!g.moreMoves())
            {
                if (MessageBox.Show("It's a draw!", "Connect4", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            //do computers move
            g.move(g.getCompMove(), Game.computer);
            label2.Visible = true;

            //wait 3 seconds
            p.Pause(3000);
            label2.Visible = false;
            DrawMap();
            if (g.getWin())
            {
                if (MessageBox.Show("You lost!", "Connect4", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            //check for a draw
            if (!g.moreMoves())
            {
                if (MessageBox.Show("It's a draw!", "Connect4", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            //enable buttons for non-full columns
            for (int i = 0; i < 7; i++)
            {
                if (g.checkColumn(i))
                {
                    playHereButtons[i].Enabled = true;
                }
            }


        }

        public void DrawMap()
        {
            for(int i = 0; i < 7; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    switch (g.getMap(i, j))
                    {
                        case Game.player:
                            map[i, j].Image = player;
                            break;
                        case Game.computer:
                            map[i, j].Image = computer;
                            break;
                        case Game.empty:
                        default:
                            map[i, j].Image = empty;
                            break;
                    }
                } 
            }
        }

        public void wireMap()
        {
            map[0, 0] = mapSquare0;
            map[1, 0] = mapSquare1;
            map[2, 0] = mapSquare2;
            map[3, 0] = mapSquare3;
            map[4, 0] = mapSquare4;
            map[5, 0] = mapSquare5;
            map[6, 0] = mapSquare6;
            map[0, 1] = mapSquare7;
            map[1, 1] = mapSquare8;
            map[2, 1] = mapSquare9;
            map[3, 1] = mapSquare10;
            map[4, 1] = mapSquare11;
            map[5, 1] = mapSquare12;
            map[6, 1] = mapSquare13;
            map[0, 2] = mapSquare14;
            map[1, 2] = mapSquare15;
            map[2, 2] = mapSquare16;
            map[3, 2] = mapSquare17;
            map[4, 2] = mapSquare18;
            map[5, 2] = mapSquare19;
            map[6, 2] = mapSquare20;
            map[0, 3] = mapSquare21;
            map[1, 3] = mapSquare22;
            map[2, 3] = mapSquare23;
            map[3, 3] = mapSquare24;
            map[4, 3] = mapSquare25;
            map[5, 3] = mapSquare26;
            map[6, 3] = mapSquare27;
            map[0, 4] = mapSquare28;
            map[1, 4] = mapSquare29;
            map[2, 4] = mapSquare30;
            map[3, 4] = mapSquare31;
            map[4, 4] = mapSquare32;
            map[5, 4] = mapSquare33;
            map[6, 4] = mapSquare34;
            map[0, 5] = mapSquare35;
            map[1, 5] = mapSquare36;
            map[2, 5] = mapSquare37;
            map[3, 5] = mapSquare38;
            map[4, 5] = mapSquare39;
            map[5, 5] = mapSquare40;
            map[6, 5] = mapSquare41;
        }


        private void column1B_Click(object sender, EventArgs e)
        {
            ClickPlayHereButton(0);
        }

        private void column2B_Click(object sender, EventArgs e)
        {
            ClickPlayHereButton(1);
        }

        private void column3B_Click(object sender, EventArgs e)
        {
            ClickPlayHereButton(2);
        }

        private void column4B_Click(object sender, EventArgs e)
        {
            ClickPlayHereButton(3);
        }

        private void column5B_Click(object sender, EventArgs e)
        {
            ClickPlayHereButton(4);
        }

        private void column6B_Click(object sender, EventArgs e)
        {
            ClickPlayHereButton(5);
        }

        private void column7B_Click(object sender, EventArgs e)
        {
            ClickPlayHereButton(6);
        }
    }
}
