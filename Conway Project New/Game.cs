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
            int[] ratio = getRatio(Settings.g.field_width, Settings.g.field_height);

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

        static int numOfNeighbours(int i, int j, int[,] field)
        {
            int count = 0;
            if (!Settings.g.infiniteField_mode)
            {
                int[] move = { -1, 0, 1 };
                foreach (int movI in move)
                {
                    foreach (int movJ in move)
                    {
                        if (field[i + movI, j + movJ] != -1)
                        {
                            if (movI != 0 && movJ != 0)
                                count++;
                        }
                    }
                }
                if (field[i, j] != -1)
                    count--;

            }

            if (Settings.g.infiniteField_mode)
            {

                int[] move = { -1, 0, 1 };
                foreach (int movI in move)
                {
                    foreach (int movJ in move)
                    {
                        if (field[i + movI, j + movJ] != -1)
                        {
                            if (movI != 0 && movJ != 0)
                                count++;
                        }
                    }
                }
                if (field[i, j] != -1)
                    count--;

            }




            return count;

        }



        static int[,] nextFrame(int[,] field)
        {

            int[,] field2 = new_Field();

            if (!Settings.g.infiniteField_mode)
            {

                for (int i = 1; i < Settings.g.field_height; i++)
                {
                    for (int j = 1; j < Settings.g.field_width; j++)
                    {

                        switch (numOfNeighbours(i, j, field))
                        {
                            case < 2:
                                field2[i, j] = -1; break;

                            case 3:
                                field2[i, j] += 1; break;

                            case > 3:
                                field2[i, j] = -1; break;

                        }
                    }
                }
            }
            else
            {
                for (int i = 1; i < Settings.g.field_height; i++)
                {
                    for (int j = 1; j < Settings.g.field_width; j++)
                    {
                    }
                }
            }
            return field2;
        }


        static int[,] new_Field()
        {
            int[,] field = new int[Settings.g.field_height + 2, Settings.g.field_width + 2];

            for (int i = 0; i < Settings.g.field_height; i++)
            {
                for (int j = 0; j < Settings.g.field_width; j++)
                {
                    field[i, j] = -1;
                }
            }
            return field;
        }
        
        public void positionsTable()
        {
            // int[] = getFieldPosition()   <-- nem mûködik
            // hiba: a getFieldPosition mindig elkéri a screen widthet és heightot
            // ezt a settingsben kellene tárolni. Van is neki megfelelõ változó
            // onResize függvény --> akárhányszor módosul az ablak mérete, frissíti a beállítások screensize változóit a megfelelõ értékre
        }



        public void displayField(int[,] field)
        {

            for (int x = 1; x < Settings.g.field_height+1; x++)
            {
                for (int y = 1; y < Settings.g.field_width+1; y++)
                {

                }
            }
        }



        public Form1()
        {
            InitializeComponent();
            Size = new Size(Settings.g.window_width, Settings.g.window_height);
            // MinimumSize = new Size(settings.window_width, settings.window_height);


                


        }

        private void Form1_Load(object sender, EventArgs e)
        {

            int[,] field = new_Field();

            for (int i = 0; i < 200; i++)
            {
                field = nextFrame(field);
                displayField(field);

            }

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