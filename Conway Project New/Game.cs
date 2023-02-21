using Conway_Project_New;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;

namespace Conway_Project_New
{



    public partial class Form1 : Form
    {

        private static System.Timers.Timer aTimer;

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(9000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Debug.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",
                              e.SignalTime);
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



        public int[] getFieldPosition()
        {
            int[] ratio = getRatio(Settings.g.field_width, Settings.g.field_height);

            int actual_width = ratio[0];
            int actual_height = ratio[1];

            int window_width = Settings.g.window_width;
            int window_height = Settings.g.window_height;


            while (actual_width < window_width - 40 && actual_height < window_height - 60)
            {
                actual_width += ratio[0];
                actual_height += ratio[1];
            }

            int position_x = (window_width - actual_width - 15) / 2;
            int position_y = (window_height - actual_height - 40) / 2;


            int[] result = { position_x, position_y, actual_width, actual_height };

            return result;
        }



        public Tuple<int[], int[], int> get_cellPositions()
        {
            int[] fieldPosition = getFieldPosition();

            int field_width = Settings.g.field_width;
            int field_height = Settings.g.field_height;

            int[] cellPositions_x = new int[field_width];
            int[] cellPositions_y = new int[field_height];

            int x = fieldPosition[0];
            int y = fieldPosition[1];
            int w = fieldPosition[2];
            int h = fieldPosition[3];

            int cellSize = w / field_width;

            int currentCell_x = x;
            int currentCell_y = y;

            for (int i = 0; i < field_width; i++)
            {
                cellPositions_x[i] = currentCell_x;
                currentCell_x += cellSize;
            }

            for (int i = 0; i < field_height; i++)
            {
                Debug.WriteLine($"{i} {cellPositions_y.Length}");
                cellPositions_y[i] = currentCell_y;
                currentCell_y += cellSize;
            }

            return Tuple.Create(cellPositions_x, cellPositions_y, cellSize);

        }



        public void displayField(int[,] field)
        {
            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.DarkBlue);
            Tuple<int[], int[], int> cellPositions = get_cellPositions();


            g.Clear(Color.FromArgb(240, 240, 240));

            for (int i = 0; i < Settings.g.field_height; i++)
            {
                for (int j = 0; j < Settings.g.field_width; j++)
                {
                    g.DrawRectangle(pen, cellPositions.Item1[j], cellPositions.Item2[i], cellPositions.Item3, cellPositions.Item3);
                }
            }
        }



        public Form1()
        {
            InitializeComponent();
            Size = new Size(Settings.g.window_width, Settings.g.window_height);
            // MinimumSize = new Size(settings.window_width, settings.window_height);





        }


        private void Form1_Resize(object sender, EventArgs e)
        {

            Settings.g.window_width = Size.Width;
            Settings.g.window_height = Size.Height;

            int[] fieldPosition = getFieldPosition();

            Graphics g = this.CreateGraphics();

            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.DarkBlue);

            // g.FillRectangle(brush, fieldPosition[0], fieldPosition[1], fieldPosition[2], fieldPosition[3]);







        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        public static bool paused = false;

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {


            int[,] field = new_Field();

            for (int i = 0; i < 400; i++)
            {
                displayField(field);
                field = nextFrame(field);

                Thread.Sleep(1000);


            }

            aTimer.Dispose();

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            paused = true;
        }

    }
}