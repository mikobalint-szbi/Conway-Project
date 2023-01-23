

namespace Conway_Project_New
{

    public partial class Form1 : Form
    {
        public Form1(Conway_Project_New.Settings settings)
        {
            InitializeComponent();
            MaximumSize = new Size(settings.window_width, settings.window_height);
            MinimumSize = new Size(settings.window_width, settings.window_height);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}