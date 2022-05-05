using System.Numerics;

namespace Карта_Кохонена
{
    public partial class Form1 : Form
    {
        MainMap mainMap;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Bitmap bmp = GetBitmap();
            if(bmp != null)
            {
                pictureBox1.Image = new Bitmap(bmp, 50, 50);
            }
        }

        protected Bitmap GetBitmap()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "jpg files (*.jpg)|*.jpg";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return (Bitmap)Image.FromFile(openFileDialog.FileName);
                }
            }
            return null;
        }

        protected Double[] BitmaptoArr(Bitmap bitmap)
        {
            Double[] arr = new Double[bitmap.Width * bitmap.Height];
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    arr[i * 50 + j] = bitmap.GetPixel(i, j).GetBrightness() > 0.99 ? 1 : 0;
                }
            }
            return arr;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.mainMap.SetMap(BitmaptoArr((Bitmap)pictureBox1.Image));
            var arr = this.mainMap.GetMap();
            flowLayoutPanel1.Controls.Clear();
            foreach (var item in arr)
            {
                flowLayoutPanel1.Controls.Add(new TextBox());
                flowLayoutPanel1.Controls[flowLayoutPanel1.Controls.Count-1].Text = item.ToString();
                flowLayoutPanel1.Controls[flowLayoutPanel1.Controls.Count - 1].Margin = new System.Windows.Forms.Padding(1);
            }
        }



        private double activ(double a)
        {
            return a;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.mainMap = new MainMap(50 * 50, 10, activ);
        }
    }
}