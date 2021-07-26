using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Buildbox
{
    public partial class MainForm : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        bool isGridVisible = false;
        bool isLevelEditor = false;


        public MainForm()
        {
            // Random random = new Random();
            //int timeRandom = random.Next(3, 9);
            //Thread trd = new Thread(new ThreadStart(StartForm));
            //trd.Start();
            //Thread.Sleep(timeRandom * 1000);
            InitializeComponent();
            //trd.Abort();
            this.WindowState = FormWindowState.Normal;
        }

        private void StartForm()
        {
            Application.Run(new Splash());
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MainFormBorder_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainFormBorder_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            MainFormBorder_MouseMove(Handle, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void setProjectDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Choose your explorer path." })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                    explorerShow.Url = new Uri(fbd.SelectedPath);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gridToggleButton_Click(object sender, EventArgs e)
        {
            if (isGridVisible == false)
            {
                gridBox.Visible = true;
                isGridVisible = true;
                levelEditor_panel.Visible = false;
                isLevelEditor = false;
            }
            else
            {
                gridBox.Visible = false;
                isGridVisible = false;
            }
        }

        private void lvlButton_Click(object sender, EventArgs e)
        {
            if (isLevelEditor == false)
            {
                levelEditor_panel.Visible = true;
                isLevelEditor = true;
                gridBox.Visible = false;
                isGridVisible = false;
            }
            else
            {
                levelEditor_panel.Visible = false;
                isLevelEditor = false;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
