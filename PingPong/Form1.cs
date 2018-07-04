using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong
{
    public partial class Form1 : Form
    {
     

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = true;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == (char)Keys.W)
            {
                if (pictureBox1.Location.Y > 0)
                {
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 30);
                }
            }

            if ((e.KeyValue == (char)Keys.S))
            {
                if (pictureBox1.Location.Y < 500)
                {
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 30);
                }
            }

            if (e.KeyValue == (char)Keys.Up)
            {
                if (pictureBox2.Location.Y > 0)
                {
                    pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y - 30);
                }
            }

            if ((e.KeyValue == (char)Keys.Down))
            {
                if (pictureBox2.Location.Y < 500)
                {
                    pictureBox2.Location = new Point(pictureBox2.Location.X, pictureBox2.Location.Y + 30);
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Threading.Thread myThread = new System.Threading.Thread(new System.Threading.ThreadStart(BallMove));
            myThread.Start();
        }

        private void BallMove()
            {
            int ballPower = 10;
            int ballAngle = 10;
            int countPasses = 0;
            while (true)
            {
                int wayLeft = new Random().Next(1, 3);

                while (true)
                {
                    System.Threading.Thread.Sleep(50);
                    if(wayLeft == 1)
                    {
                        pictureBox3.Location = new Point(pictureBox3.Location.X - ballPower, pictureBox3.Location.Y + new Random().Next(1, ballAngle));
                        if (pictureBox3.Location.Y - pictureBox3.Height >= 415)
                        {
                            wayLeft = 2;
                        }
                    }
                    else
                    {
                        pictureBox3.Location = new Point(pictureBox3.Location.X - ballPower, pictureBox3.Location.Y - new Random().Next(1, ballAngle));
                        if (pictureBox3.Location.Y <= 0)
                        {
                            wayLeft = 1;
                        }
                    }
                    if (pictureBox3.Location.X <= 0)
                    {
                        label1.Visible = true;
                        label1.Text = "Game OVER";
                        label2.Visible = true;
                        label2.Text = "Right Player Win";
                        label3.Visible = false;
                        pictureBox1.Visible = false;
                        pictureBox2.Visible = false;
                        pictureBox3.Visible = false;
                    }

                    if (pictureBox3.Bounds.IntersectsWith(pictureBox1.Bounds))
                    {
                        countPasses += 1;
                        if(countPasses == 5)
                        {
                            countPasses = 0;
                            ballPower += 5;
                            ballAngle += 2;
                        }
                        int wayRight = new Random().Next(1, 3);
                        while (true)
                        {
                            System.Threading.Thread.Sleep(50);
                            if (wayRight == 1)
                            {
                                pictureBox3.Location = new Point(pictureBox3.Location.X + ballPower, pictureBox3.Location.Y+ new Random().Next(1, ballAngle));
                                if (pictureBox3.Location.Y - pictureBox3.Height >= 415)
                                {
                                    wayRight = 2;
                                }
                            }
                            else
                            {
                                pictureBox3.Location = new Point(pictureBox3.Location.X + ballPower, pictureBox3.Location.Y- new Random().Next(1, ballAngle));
                                if (pictureBox3.Location.Y  <= 0)
                                {
                                    wayRight = 1;
                                }
                            }
                            
                            if (pictureBox3.Bounds.IntersectsWith(pictureBox2.Bounds))
                            {
                                countPasses += 1;
                                if (countPasses == 5)
                                {
                                    countPasses = 0;
                                    ballPower += 5;
                                    ballAngle += 2;
                                }
                                break;
                            }
                            
                            if (pictureBox3.Location.X + pictureBox3.Width >= this.Width)
                            {
                                label1.Visible = true;
                                label1.Text = "Game OVER";
                                label2.Visible = true;
                                label2.Text = "Left Player Win";
                                label3.Visible = false;
                                pictureBox1.Visible = false;
                                pictureBox2.Visible = false;
                                pictureBox3.Visible = false;
                            }
                        }
                        break;
                    }
                }
            }
        }
    }
}
