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
            field_height = 90,
            field_width = 160,
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





        static void Main()
        {
            







            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());






        }
    }
}