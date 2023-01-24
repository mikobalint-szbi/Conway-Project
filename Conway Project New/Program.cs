namespace Conway_Project_New
{
    /*struct Cell
    {
        public int age;
        public bool alive;

    }*/

    public struct Settings
    {
        public int field_height;
        public int field_width;
        public int window_height;
        public int window_width;
        
        public bool infiniteField_mode;


        public Settings(int field_width, int field_height, bool infiniteField_mode, int window_height, int window_width)
        {
            this.field_width = field_width;
            this.field_height = field_height;
            this.infiniteField_mode = infiniteField_mode;
            this.window_height = window_height;
            this.window_width = window_width;
        }

        public static Settings g = new Settings
        {
            field_height = 256,
            field_width = 256,
            infiniteField_mode = false,
            window_height = 720,
            window_width = 1280
        };
    }


    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]




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

                for (int i = 1; i < Settings.g.field_height                  ; i++)
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


        static void displayFrame()
        {

        }



        static void Main()
        {
            
            


            int[,] field = new_Field();
            



            for (int i = 0; i < 200; i++)
            {

                field = nextFrame(field);
                displayFrame();


            }





            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());






        }
    }
}