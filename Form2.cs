using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
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

        private void button5_Click(object sender, EventArgs e)
        {
            int w = image.Width;
            int h = image.Height;
            BitmapData image_data = image.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            //Массив для сохранения пикселей
            int bytes = image_data.Stride * image_data.Height;
            byte[] buffer = new byte[bytes];
            Marshal.Copy(image_data.Scan0, buffer, 0, bytes);
            image.UnlockBits(image_data);

            //значение r для уменьшения размера (эта фильтрация изменит размер выходного изображения)
            //изменив значение r, мы можем четко получить эффект размытия
            int r = 2;
            int wres = w - 2 * r;
            int hres = h - 2 * r;

            Bitmap result_image = new Bitmap(wres, hres);
            BitmapData result_data = result_image.LockBits(
                new Rectangle(0, 0, wres, hres),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);

            int res_bytes = result_data.Stride * result_data.Height;
            byte[] result = new byte[res_bytes];

            for (int x = r; x < w - r; x++)
            {
                for (int y = r; y < h - r; y++)
                {
                    int pixel_location = x * 3 + y * image_data.Stride;
                    int res_pixel_location = (x - r) * 3 + (y - r) * result_data.Stride;
                    double[] mean = new double[3];

                    for (int kx = -r; kx <= r; kx++)
                    {
                        for (int ky = -r; ky <= r; ky++)
                        {
                            int kernel_pixel =
                                pixel_location + kx * 3 + ky * image_data.Stride;

                            //sum all pixel
                            for (int c = 0; c < 3; c++)
                            {
                                mean[c] += buffer[kernel_pixel + c] / Math.Pow(2 * r + 2, 2); //прибавляем 1 для r
                            }
                        }
                    }

                    for (int c = 0; c < 3; c++)
                    {
                        result[res_pixel_location + c] = (byte)mean[c];
                    }
                }
            }
            Marshal.Copy(result, 0, result_data.Scan0, res_bytes);
            result_image.UnlockBits(result_data);
            pictureBox2.Image = result_image;
            histogram = GetHistogram(result_image);
            pictureBox2.Refresh();
            pictureBox1.Paint += (o, e) => DrawHistogram(e.Graphics, pictureBox1, histogram);
            pictureBox1.Refresh();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int matrixSize = Int32.Parse(textBox1.Text);
            BitmapData sourceData =
                image.LockBits(new Rectangle(0, 0,
                        image.Width, image.Height),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format32bppArgb);
            bool grayscale = false;
            byte[] pixelBuffer = new byte[sourceData.Stride *
                                          sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride *
                                           sourceData.Height];
            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0,
                pixelBuffer.Length);
            image.UnlockBits(sourceData);

            //Gray-scale
            if (grayscale == true)
            {
                float rgb;
                for (int k = 0; k < pixelBuffer.Length; k += 4)
                {
                    rgb = pixelBuffer[k] * 0.11f;
                    rgb += pixelBuffer[k + 1] * 0.59f;
                    rgb += pixelBuffer[k + 2] * 0.3f;

                    pixelBuffer[k] = (byte)rgb;
                    pixelBuffer[k + 1] = pixelBuffer[k];
                    pixelBuffer[k + 2] = pixelBuffer[k];
                    pixelBuffer[k + 3] = 255;
                }
            }
            /*filterOffset:index value for defining extra-matrix
              calcOffset:define amount of pixels in the extra-matrix
              byteOffset:define amout of pixels in the origin matrix
             */
            int filterOffset = (matrixSize - 1) / 2;
            int calcOffset;
            int byteOffset;

            //медианы.
            List<int> neighbourPixels = new List<int>();
            byte[] middlePixel;

            //Основной алгоритм
            for (int offsetY = filterOffset;
                 offsetY <
                 image.Height - filterOffset;
                 offsetY++)
            {
                for (int offsetX = filterOffset;
                     offsetX <
                     image.Width - filterOffset;
                     offsetX++)
                {
                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4; //4 из-за учета 4 компонентов из pixelBuffer


                    neighbourPixels.Clear();

                    //значение пикселя рядом (слева, вверху) в отрицательном положении по сравнению с рассматриваемым пикселем
                    for (int filterY = -filterOffset;
                         filterY <= filterOffset;
                         filterY++)
                    {
                        for (int filterX = -filterOffset;
                             filterX <= filterOffset;
                             filterX++)
                        {


                            calcOffset = byteOffset +
                                         (filterX * 4) +
                                         (filterY * sourceData.Stride);

                            //добавить целочисленное значение (медиану) в качестве соседнего пикселя
                            neighbourPixels.Add(BitConverter.ToInt32(
                                pixelBuffer, calcOffset));
                        }
                    }
                    neighbourPixels.Sort();

                    //назначение определенного среднего пикселя текущему пикселю в виде массива байтов компонента цвета пикселя.
                    middlePixel = BitConverter.GetBytes(
                        neighbourPixels[filterOffset]);
                    resultBuffer[byteOffset] = middlePixel[0];
                    resultBuffer[byteOffset + 1] = middlePixel[1];
                    resultBuffer[byteOffset + 2] = middlePixel[2];
                    resultBuffer[byteOffset + 3] = middlePixel[3];
                }
            }

            Bitmap resultBitmap = new Bitmap(image.Width,
                image.Height);
            BitmapData resultData =
                resultBitmap.LockBits(new Rectangle(0, 0,
                        resultBitmap.Width, resultBitmap.Height),
                    ImageLockMode.WriteOnly,
                    PixelFormat.Format32bppArgb);
            Marshal.Copy(resultBuffer, 0, resultData.Scan0,
                resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);
            
            pictureBox2.Image = resultBitmap;
            histogram = GetHistogram(resultBitmap);
            pictureBox2.Refresh();
            pictureBox1.Paint += (o, e) => DrawHistogram(e.Graphics, pictureBox1, histogram);
            pictureBox1.Refresh();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }
    }
}
