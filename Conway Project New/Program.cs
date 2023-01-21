namespace Conway_Project_New
{
    /*struct Cell
    {
        public int age;
        public bool alive;

    }*/

    struct Settings
    {
        public int field_height;
        public int field_width;
        public bool infiniteField_mode;

        public Settings(int field_width, int field_height, bool infiniteField_mode)
        {
            this.field_width = field_width;
            this.field_height = field_height;
            this.infiniteField_mode = infiniteField_mode;
        }
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


            return count;

        }

        static int[,] new_Field(Settings settings)
        {
            int[,] field = new int[settings.field_height+2, settings.field_width+2];

            for (int i = 0; i < settings.field_height; i++)
            {
                for (int j = 0; j < settings.field_width; j++)
                {
                    field[i, j] = -1;
                }
            }
            return field;
        }



        static int[,] nextFrame(int[,] field, Settings settings)
        {

            int[,] field2 = new int[settings.field_height, settings.field_width];

            for (int i = 1; i < settings.field_height-1; i++)
            {
                for (int j = 1; j < settings.field_width-1; j++)
                {

                    switch (numOfNeighbours(i, j, field))
                    {
                        case < 2:
                            field2[i,j] = -1;    break;

                        case 3:
                            field2[i, j] += 1;   break;

                        case > 3:
                            field2[i, j] = -1;   break;

                    }
                }
            }
            return field2;
        }

        static void displayFrame()
        {

        }



        static void Main()
        {
            Settings settings = new Settings
            {
                field_height = 256,
                field_width = 256,
                infiniteField_mode = false
            };


            int[,] field = new_Field(settings);
            



            for (int i = 0; i < 200; i++)
            {

                field = nextFrame(field, settings);
                displayFrame();


            }





            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());






        }
    }
}