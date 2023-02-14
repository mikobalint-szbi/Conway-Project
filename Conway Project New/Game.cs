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
            int[] ratio = getRatio(16,9);

            int actual_width = ratio[0];
            int actual_height = ratio[1];


            while (actual_width < window_width-40 && actual_height < window_height-60)
            {
                actual_width += ratio[0];
                actual_height += ratio[1];
            }

            int position_x = (window_width - actual_width - 15) / 2;
            int position_y = (window_height - actual_height - 40) / 2;


            int[] result = {position_x, position_y, actual_width, actual_height};

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

            // g.DrawRectangle(pen, 10, 10, 100,100);


        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int width = Size.Width;
            int height = Size.Height;

            int[] fieldPosition = getFieldPosition(Size.Width, Size.Height);

            Graphics g = this.CreateGraphics();

            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.Black);

            g.Clear(Color.FromArgb(240,240,240));
            g.DrawRectangle(pen, fieldPosition[0], fieldPosition[1], fieldPosition[2], fieldPosition[3]);

        }
    }
}