using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scoi_lab1
{
    public partial class Form2 : Form
    {
        int[] histogram;
        private Bitmap image = null;
        public Form2(Bitmap imageFromForm1)
        {
            InitializeComponent();
            image = imageFromForm1;
            pictureBox2.Image = image;
            histogram = GetHistogram(image);
            pictureBox1.Paint += (o, e) => DrawHistogram(e.Graphics, pictureBox1, histogram);
            pictureBox1.Resize += (o, e) => Refresh();
            Refresh();
        }

        private static void DrawHistogram(Graphics g, PictureBox pictureBox1, int[] histogram)
        {
            float max = histogram.Max();
            if (max > 0)
            {
                for(int i = 0; i < histogram.Length; i++)
                {
                    float h = pictureBox1.Height * histogram[i] / (float)max;
                    g.FillRectangle(Brushes.Black, i * pictureBox1.Width / (float)histogram.Length, pictureBox1.Height - h, pictureBox1.Width / (float)histogram.Length, h);
                }
            }
        }

        private static int[] GetHistogram(Bitmap image)
        {
            int[] result = new int[256];
            for(int x = 0; x < image.Width; x++)
            {
                for(int y = 0; y < image.Height; y++)
                {
                    int i = (int)(255 * image.GetPixel(x, y).GetBrightness());
                    result[i]++;
                }
            }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 500; ++i)
            {
                for (int j = 0; j < 500; ++j)
                {
                    var pix = image.GetPixel(j, i); // Цвет пикселя
                    int r = pix.R;
                    int g = pix.G;
                    int b = pix.B;
                    r = r + 15;
                    g = g + 15;
                    b = b + 15;
                    if(r > 255)
                        r = 255;
                    if(g > 255)
                        g = 255;
                    if(b > 255)
                        b = 255;
                    pix = Color.FromArgb(r, g, b);
                    image.SetPixel(j, i, pix);
                }
            }
            pictureBox2.Image = image;
            histogram = GetHistogram(image);
            pictureBox2.Refresh();
            pictureBox1.Paint += (o, e) => DrawHistogram(e.Graphics, pictureBox1, histogram);
            pictureBox1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 500; ++i)
            {
                for (int j = 0; j < 500; ++j)
                {
                    var pix = image.GetPixel(j, i); // Цвет пикселя
                    int r = pix.R;
                    int g = pix.G;
                    int b = pix.B;
                    r = r - 15;
                    g = g - 15;
                    b = b - 15;
                    if (r < 0)
                        r = 0;
                    if (g < 0)
                        g = 0;
                    if (b < 0)
                        b = 0;
                    pix = Color.FromArgb(r, g, b);
                    image.SetPixel(j, i, pix);
                }
            }
            pictureBox2.Image = image;
            histogram = GetHistogram(image);
            pictureBox2.Refresh();
            pictureBox1.Paint += (o, e) => DrawHistogram(e.Graphics, pictureBox1, histogram);
            pictureBox1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 500; ++i)
            {
                for (int j = 0; j < 500; ++j)
                {
                    var pix = image.GetPixel(j, i); // Цвет пикселя
                    int r = pix.R;
                    int g = pix.G;
                    int b = pix.B;
                    r = (int)((r * 100 - 128 * 10) / 90);
                    g = (int)((g * 100 - 128 * 10) / 90);
                    b = (int)((b * 100 - 128 * 10) / 90);
                    if (r < 0)
                        r = 0;
                    if (g < 0)
                        g = 0;
                    if (b < 0)
                        b = 0;
                    if (r > 255)
                        r = 255;
                    if (g > 255)
                        g = 255;
                    if (b > 255)
                        b = 255;
                    pix = Color.FromArgb(r, g, b);
                    image.SetPixel(j, i, pix);
                }
            }
            pictureBox2.Image = image;
            histogram = GetHistogram(image);
            pictureBox2.Refresh();
            pictureBox1.Paint += (o, e) => DrawHistogram(e.Graphics, pictureBox1, histogram);
            pictureBox1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 500; ++i)
            {
                for (int j = 0; j < 500; ++j)
                {
                    var pix = image.GetPixel(j, i); // Цвет пикселя
                    int r = pix.R;
                    int g = pix.G;
                    int b = pix.B;
                    r = (int)((r * 90 + 128 * 10) / 100);
                    g = (int)((g * 90 + 128 * 10) / 100);
                    b = (int)((b * 90 + 128 * 10) / 100);
                    if (r < 0)
                        r = 0;
                    if (g < 0)
                        g = 0;
                    if (b < 0)
                        b = 0;
                    if (r > 255)
                        r = 255;
                    if (g > 255)
                        g = 255;
                    if (b > 255)
                        b = 255;
                    pix = Color.FromArgb(r, g, b);
                    image.SetPixel(j, i, pix);
                }
            }
            pictureBox2.Image = image;
            histogram = GetHistogram(image);
            pictureBox2.Refresh();
            pictureBox1.Paint += (o, e) => DrawHistogram(e.Graphics, pictureBox1, histogram);
            pictureBox1.Refresh();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 500; ++i)
            {
                for (int j = 0; j < 500; ++j)
                {
                    var pix = image.GetPixel(j, i); // Цвет пикселя
                    int r = pix.R;
                    int g = pix.G;
                    int b = pix.B;
                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;
                    pix = Color.FromArgb(r, g, b);
                    image.SetPixel(j, i, pix);
                }
            }
            pictureBox2.Image = image;
            histogram = GetHistogram(image);
            pictureBox2.Refresh();
            pictureBox1.Paint += (o, e) => DrawHistogram(e.Graphics, pictureBox1, histogram);
            pictureBox1.Refresh();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            int factor = 10;
            for (int i = 0; i < 500; ++i)
            {
                for (int j = 0; j < 500; ++j)
                {
                    var pix = image.GetPixel(j, i); // Цвет пикселя
                    int r = pix.R;
                    int g = pix.G;
                    int b = pix.B;
                    int S = r + g + b;
                    if (S > (((255 + factor) / 2) * 3))
                    {
                        r = 255;
                        g = 255;
                        b = 255;
                    } else
                    {
                        r = 0;
                        g = 0;
                        b = 0;
                    }
                    pix = Color.FromArgb(r, g, b);
                    image.SetPixel(j, i, pix);
                }
            }
            pictureBox2.Image = image;
            histogram = GetHistogram(image);
            pictureBox2.Refresh();
            pictureBox1.Paint += (o, e) => DrawHistogram(e.Graphics, pictureBox1, histogram);
            pictureBox1.Refresh();
        }
    }
}
