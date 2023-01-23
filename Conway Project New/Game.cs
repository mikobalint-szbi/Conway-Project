

namespace Conway_Project_New
{



    public partial class Form1 : Form
    {

        public int[] getFieldLocation(int window_width, int window_height/*, Settings settings*/)
        {
            return null;
        }


        public Form1(Settings settings)
        {
            InitializeComponent();
            Size = new Size(settings.window_width, settings.window_height);
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

            int[] fieldLocation = getFieldLocation(Size.Width, Size.Height);
        }
    }
}