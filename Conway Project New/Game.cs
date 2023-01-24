using Conway_Project_New;
using System.Diagnostics;
using System.Collections.Generic;

namespace Conway_Project_New
{



    public partial class Form1 : Form
    {

        public static int[] getRatio(int a, int b)
        {
            int a_original = a;
            int b_original = b;

            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            int[] ratio = { a_original / (a | b), b_original / (a | b) };

            return ratio;
        }



        public int[] getFieldPosition(int window_width, int window_height)
        {
            int[] ratio = getRatio(1080,1920);

            int actual_width = ratio[0];
            int actual_height = ratio[1];

            if (ratio[0] >= ratio[1])
            {
                while (actual_width < window_width - 10)
                {
                    actual_width += ratio[0];
                }
                actual_height = actual_width / ratio[0] * ratio[1];
                
            }
            else
            {
                while (actual_height < window_height - 10)
                {
                    actual_height += ratio[0];
                }
                actual_width = actual_height / ratio[1] * ratio[0];

            }

            int[] result = {actual_width, actual_height};

            return result;
        }


        public Form1()
        {
            InitializeComponent();
            Size = new Size(Settings.g.window_width, Settings.g.window_height);
            // MinimumSize = new Size(settings.window_width, settings.window_height);


                


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black);

            int height = this.Height;

            g.DrawRectangle(pen, 10, 10, 100,100);


        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int width = Size.Width;
            int height = Size.Height;

            int[] fieldLocation = getFieldPosition(Size.Width, Size.Height);
            


        }
    }
}