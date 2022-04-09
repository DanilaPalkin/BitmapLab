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
        public Form2(Bitmap image)
        {
            InitializeComponent();
            histogram = GetHistogram(image);
            this.Paint += (o, e) => DrawHistogram(e.Graphics, ClientRectangle, histogram);
            this.Resize += (o, e) => Refresh();
            Refresh();
        }

        private static void DrawHistogram(Graphics g, Rectangle rectangle, int[] histogram)
        {
            float max = histogram.Max();
            if (max > 0)
            {
                for(int i = 0; i < histogram.Length; i++)
                {
                    float h = rectangle.Height * histogram[i] / (float)max;
                    g.FillRectangle(Brushes.Black, i * rectangle.Width / (float)histogram.Length, rectangle.Height - h, rectangle.Width / (float)histogram.Length, h);
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
    }
}
