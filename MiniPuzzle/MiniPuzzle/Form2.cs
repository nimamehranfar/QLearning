//Programmer : Mehran Rasa (M8SPY)
//http://m8spy.com

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MiniPuzzle
{
    public partial class FrmGame : Form
    {
        public FrmGame()
        {
            InitializeComponent();
        }
        public int Cn;

        public void get_rnd()
        {
            int[] m1 = new int[2]; m1[0] = b1.Top; m1[1] = b1.Left;
            int[] m2 = new int[2]; m2[0] = b2.Top; m2[1] = b2.Left;
            int[] m3 = new int[2]; m3[0] = b3.Top; m3[1] = b3.Left;
            int[] m4 = new int[2]; m4[0] = b4.Top; m4[1] = b4.Left;
            int[] m5 = new int[2]; m5[0] = b5.Top; m5[1] = b5.Left;
            int[] m6 = new int[2]; m6[0] = b6.Top; m6[1] = b6.Left;
            int[] m7 = new int[2]; m7[0] = b7.Top; m7[1] = b7.Left;
            int[] m8 = new int[2]; m8[0] = b8.Top; m8[1] = b8.Left;

            Random rnd1 = new Random();
            Random rnd = new Random(rnd1.Next());

            int r = rnd1.Next(100);
            string rndstr = Convert.ToString(r);
            rndstr = rndstr.Substring(0, 1);

            switch (rndstr)
            {
                case "1":
                    {
                        b5.Left = m6[1]; b5.Top = m6[0];
                        b6.Left = m5[1]; b6.Top = m5[0];
                        break;
                    }

                case "3":
                    {
                        b1.Left = m8[1]; b1.Top = m8[0];
                        b8.Left = m1[1]; b8.Top = m1[0];
                        b2.Left = m5[1]; b2.Top = m5[0];
                        b5.Left = m2[1]; b5.Top = m2[0];
                        break;
                    }

                case "5":
                    {
                        b1.Left = m2[1]; b1.Top = m2[0];
                        b2.Left = m1[1]; b2.Top = m1[0];
                        b3.Left = m4[1]; b3.Top = m4[0];
                        b4.Left = m3[1]; b4.Top = m3[0];
                        break;
                    }
                case "7" :
                    {
                        b7.Left = m8[1]; b7.Top = m8[0];
                        b8.Left = m7[1]; b8.Top = m7[0];
                        break ;
                    }
                default:
                    {
                        b1.Left = m2[1]; b1.Top = m2[0];
                        b2.Left = m1[1]; b2.Top = m1[0];
                        b3.Left = m4[1]; b3.Top = m4[0];
                        b4.Left = m3[1]; b4.Top = m3[0];
                        b5.Left = m6[1]; b5.Top = m6[0];
                        b6.Left = m5[1]; b6.Top = m5[0];
                        b7.Left = m8[1]; b7.Top = m8[0];
                        b8.Left = m7[1]; b8.Top = m7[0];
                        break;
                    }

            }

            timer1.Enabled = true;
        }

        private void FrmGame_Load(object sender, EventArgs e)
        {
                get_rnd();
        }


        private void b7_Click(object sender, EventArgs e)
        {

            int x = ll.Left - ll.Width;
            int cml;
            if (b7.Left - 1 == x && b7.Top == ll.Top)
            {
                cml = b7.Left;
                b7.Left = ll.Left;
                ll.Left = cml;
                Cn += 1;
            }
            else if (b7.Left + 1 == ll.Width + ll.Left && b7.Top == ll.Top)
            {
                cml = b7.Left;
                b7.Left = ll.Left;
                ll.Left = cml;
                Cn += 1;
            }
            ///////////////////////////////////////////////////////
            int y = ll.Top - ll.Height;
            if (b7.Top - 1 == y && b7.Left == ll.Left)
            {
                cml = b7.Top;
                b7.Top = ll.Top;
                ll.Top = cml;
                Cn += 1;
            }
            else if (b7.Top + 1 == ll.Height + ll.Top && b7.Left == ll.Left)
            {
                cml = b7.Top;
                b7.Top = ll.Top;
                ll.Top = cml;
                Cn += 1;
            }
        }

        private void b8_Click(object sender, EventArgs e)
        {
            int x = ll.Left - ll.Width;
            int cml;
            if (b8.Left-1 == x && b8.Top == ll.Top)
            {
                cml = b8.Left;
                b8.Left = ll.Left;
                ll.Left = cml;
                Cn += 1;
            }
            else if (b8.Left + 1 == ll.Width + ll.Left && b8.Top == ll.Top)
            {
                cml = b8.Left;
                b8.Left = ll.Left;
                ll.Left = cml;
                Cn += 1;
            }
        ///////////////////////////////////////////////////////
            int y = ll.Top - ll.Height;
            if (b8.Top - 1 == y && b8.Left == ll.Left)
            {
                cml = b8.Top;
                b8.Top = ll.Top;
                ll.Top = cml;
                Cn += 1;
            }
            else if (b8.Top + 1 == ll.Height + ll.Top && b8.Left == ll.Left)
            {
                cml = b8.Top;
                b8.Top = ll.Top;
                ll.Top = cml;
                Cn += 1;
            }

            
        }

        private void b6_Click(object sender, EventArgs e)
        {
            int x = ll.Left - ll.Width;
            int cml;
            if (b6.Left - 1 == x && b6.Top == ll.Top)
            {
                cml = b6.Left;
                b6.Left = ll.Left;
                ll.Left = cml;
                Cn += 1;
            }
            else if (b6.Left + 1 == ll.Width + ll.Left && b6.Top == ll.Top)
            {
                cml = b6.Left;
                b6.Left = ll.Left;
                ll.Left = cml;
                Cn += 1;
            }
            ///////////////////////////////////////////////////////
            int y = ll.Top - ll.Height;
            if (b6.Top - 1 == y && b6.Left == ll.Left)
            {
                cml = b6.Top;
                b6.Top = ll.Top;
                ll.Top = cml;
                Cn += 1;
            }
            else if (b6.Top + 1 == ll.Height + ll.Top && b6.Left == ll.Left)
            {
                cml = b6.Top;
                b6.Top = ll.Top;
                ll.Top = cml;
                Cn += 1;
            }
        }

        private void b5_Click(object sender, EventArgs e)
        {

            int x = ll.Left - ll.Width;
            int cml;
            if (b5.Left - 1 == x && b5.Top == ll.Top)
            {
                cml = b5.Left;
                b5.Left = ll.Left;
                ll.Left = cml;
                Cn += 1;
            }
            else if (b5.Left + 1 == ll.Width + ll.Left && b5.Top == ll.Top)
            {
                cml = b5.Left;
                b5.Left = ll.Left;
                ll.Left = cml;
                Cn += 1;
            }
            ///////////////////////////////////////////////////////
            int y = ll.Top - ll.Height;
            if (b5.Top - 1 == y && b5.Left == ll.Left)
            {
                cml = b5.Top;
                b5.Top = ll.Top;
                ll.Top = cml;
                Cn += 1;
            }
            else if (b5.Top + 1 == ll.Height + ll.Top && b5.Left == ll.Left)
            {
                cml = b5.Top;
                b5.Top = ll.Top;
                ll.Top = cml;
                Cn += 1;
            }
        }

        private void b4_Click(object sender, EventArgs e)
        {

            int x = ll.Left - ll.Width;
            int cml;
            if (b4.Left - 1 == x && b4.Top == ll.Top)
            {
                cml = b4.Left;
                b4.Left = ll.Left;
                ll.Left = cml;
                Cn += 1;
            }
            else if (b4.Left + 1 == ll.Width + ll.Left && b4.Top == ll.Top)
            {
                cml = b4.Left;
                b4.Left = ll.Left;
                ll.Left = cml;
                Cn += 1;
            }
            ///////////////////////////////////////////////////////
            int y = ll.Top - ll.Height;
            if (b4.Top - 1 == y && b4.Left == ll.Left)
            {
                cml = b4.Top;
                b4.Top = ll.Top;
                ll.Top = cml;
                Cn += 1;
            }
            else if (b4.Top + 1 == ll.Height + ll.Top && b4.Left == ll.Left)
            {
                cml = b4.Top;
                b4.Top = ll.Top;
                ll.Top = cml;
                Cn += 1;
            }
        }

        private void b3_Click(object sender, EventArgs e)
        {

            int x = ll.Left - ll.Width;
            int cml;
            if (b3.Left - 1 == x && b3.Top == ll.Top)
            {
                cml = b3.Left;
                b3.Left = ll.Left;
                ll.Left = cml;
                Cn += 1;
            }
            else if (b3.Left + 1 == ll.Width + ll.Left && b3.Top == ll.Top)
            {
                cml = b3.Left;
                b3.Left = ll.Left;
                ll.Left = cml;
                Cn += 1;
            }
            ///////////////////////////////////////////////////////
            int y = ll.Top - ll.Height;
            if (b3.Top - 1 == y && b3.Left == ll.Left)
            {
                cml = b3.Top;
                b3.Top = ll.Top;
                ll.Top = cml;
                Cn += 1;
            }
            else if (b3.Top + 1 == ll.Height + ll.Top && b3.Left == ll.Left)
            {
                cml = b3.Top;
                b3.Top = ll.Top;
                ll.Top = cml;
                Cn += 1;
            }
        }

        private void b2_Click(object sender, EventArgs e)
        {

            int x = ll.Left - ll.Width;
            int cml;
            if (b2.Left - 1 == x && b2.Top == ll.Top)
            {
                cml = b2.Left;
                b2.Left = ll.Left;
                ll.Left = cml;
                Cn += 1;
            }
            else if (b2.Left + 1 == ll.Width + ll.Left && b2.Top == ll.Top)
            {
                cml = b2.Left;
                b2.Left = ll.Left;
                ll.Left = cml;
                Cn += 1;
            }
            ///////////////////////////////////////////////////////
            int y = ll.Top - ll.Height;
            if (b2.Top - 1 == y && b2.Left == ll.Left)
            {
                cml = b2.Top;
                b2.Top = ll.Top;
                ll.Top = cml;
                Cn += 1;
            }
            else if (b2.Top + 1 == ll.Height + ll.Top && b2.Left == ll.Left)
            {
                cml = b2.Top;
                b2.Top = ll.Top;
                ll.Top = cml;
                Cn += 1;
            }
        }

        private void b1_Click(object sender, EventArgs e)
        {

            int x = ll.Left - ll.Width;
            int cml;
            if (b1.Left - 1 == x && b1.Top == ll.Top)
            {
                cml = b1.Left;
                b1.Left = ll.Left;
                ll.Left = cml;
                Cn += 1;
            }
            else if (b1.Left + 1 == ll.Width + ll.Left && b1.Top == ll.Top)
            {
                cml = b1.Left;
                b1.Left = ll.Left;
                ll.Left = cml;
                Cn += 1;
            }
            ///////////////////////////////////////////////////////
            int y = ll.Top - ll.Height;
            if (b1.Top - 1 == y && b1.Left == ll.Left)
            {
                cml = b1.Top;
                b1.Top = ll.Top;
                ll.Top = cml;
                Cn += 1;
            }
            else if (b1.Top + 1 == ll.Height + ll.Top && b1.Left == ll.Left)
            {
                cml = b1.Top;
                b1.Top = ll.Top;
                ll.Top = cml;
                Cn += 1;
            }
        }

        //Programmer : Mehran Rasa (M8SPY)
        //http://m8spy.com

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text ="Clicks : " + Convert.ToString(Cn);

            if (b1.Left == 12 && b1.Top == 9)
            {
                if (b2.Left == 92 && b2.Top == 9)
                {
                    if (b3.Left == 172 && b3.Top == 9)
                    {
                        if (b4.Left == 12 && b4.Top == 84)
                        {
                            if (b5.Left == 92 && b5.Top == 84)
                            {
                                if (b6.Left == 172 && b6.Top == 84)
                                {
                                    if (b7.Left == 12 && b7.Top == 159)
                                    {
                                        if (b8.Left == 92 && b8.Top == 159)
                                        {
                                            timer1.Enabled = false;
                                            MessageBox.Show("! You Can Complete the Puzzle with " + Convert.ToString (Cn ) + " Clicks !");
                                            Application.Restart();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
