using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form1 : Form
    {
        bool left;
        bool right;
        bool up;
        bool down;

        int speed;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                speed = 3;
                left = true;
                right = false;
                up = false;
                down = false;
                pbPacman.Image = Properties.Resources.esquerda1;
            }

            if (e.KeyCode == Keys.Right)
            {
                speed = 3;
                right = true;
                up = false;
                down = false;
                left = false;
                pbPacman.Image = Properties.Resources.direita1;
            }

            if (e.KeyCode == Keys.Up)
            {
                speed = 3;
                up = true;
                right = false;
                down = false;
                left = false;
                pbPacman.Image = Properties.Resources.cima1;
            }

            if (e.KeyCode == Keys.Down)
            {
                speed = 3;
                down = true;
                up = false;
                right = false;
                left = false;
                pbPacman.Image = Properties.Resources.baixo1;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (up)
            {
                pbPacman.Top -= speed;
            }

            if (down)
            {
                pbPacman.Top += speed;
            }

            if (left)
            {
                pbPacman.Left -= speed;
            }

            if (right)
            {
                pbPacman.Left += speed;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "wallR")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(pbPacman.Bounds))
                    {
                        speed = 0;
                        pbPacman.Left = pbPacman.Location.X + 1;
                    }
                }

                if (x is PictureBox && x.Tag == "wallL")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(pbPacman.Bounds))
                    {
                        speed = 0;
                        pbPacman.Left = pbPacman.Location.X - 1;
                    }
                }

                if (x is PictureBox && x.Tag == "wallD")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(pbPacman.Bounds))
                    {
                        speed = 0;
                        pbPacman.Top = pbPacman.Location.Y + 1;
                    }
                }

                if (x is PictureBox && x.Tag == "wallU")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(pbPacman.Bounds))
                    {
                        speed = 0;
                        pbPacman.Top = pbPacman.Location.Y - 1;
                    }
                }
            }

        }
    }
}
