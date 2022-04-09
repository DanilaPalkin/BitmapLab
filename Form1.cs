namespace scoi_lab1
{
    public partial class Form1 : Form
    {
        private Bitmap image1 = null;
        private Bitmap image2 = null;
        private Bitmap image3 = null;
        public Form1()
        {
            InitializeComponent();
            image1 = new Bitmap(500, 500);
            pictureBox1.Image = image1;
            image2 = new Bitmap(500, 500);
            pictureBox2.Image = image2;
            image3 = new Bitmap(500, 500);
            pictureBox3.Image = image3;
        }

        // Выбор первой картинки
        private void button1_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (image1 != null)
                {
                    pictureBox1.Image = null;
                    image1.Dispose();
                }

                image1 = new Bitmap(openFileDialog.FileName);
                pictureBox1.Image = image1;
            }
        }

        // Выбор второй картинки
        private void button2_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (image2 != null)
                {
                    pictureBox2.Image = null;
                    image2.Dispose();
                }

                image2 = new Bitmap(openFileDialog.FileName);
                pictureBox2.Image = image2;
            }
        }

        // Эта кнопка отвечает за выбор цвета маски
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult colorResult = colorDialog1.ShowDialog();
            if (colorResult == DialogResult.OK)
            {
                panel1.BackColor = colorDialog1.Color;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button3.Enabled = true;
            } else
            {
                button3.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button4.Enabled = true;
        }

        // Кнопка обработки изображений
        private void button4_Click(object sender, EventArgs e)
        {
            button5.Enabled = true;
            for (int i = 0; i < 500; ++i)
            {
                for (int j = 0; j < 500; ++j)
                {
                    var pix1 = image1.GetPixel(j, i); // Цвет пикселя с первой картинки
                    int r1 = pix1.R;
                    int g1 = pix1.G;
                    int b1 = pix1.B;
                    var pix2 = image2.GetPixel(j, i); // Цвет пикселя со второй картинки
                    int r2 = pix2.R;
                    int g2 = pix2.G;
                    int b2 = pix2.B;

                    switch (comboBox1.SelectedIndex)
                    {
                        // сумма
                        case 0:
                            int r3 = (int)Clamp(r1 + r2, 0, 255);
                            int g3 = (int)Clamp(g1 + g2, 0, 255);
                            int b3 = (int)Clamp(b1 + b2, 0, 255);
                            var pix3 = Color.FromArgb(r3, g3, b3);
                            image3.SetPixel(j, i, pix3);
                            break;
                        // произведение
                        case 1:
                            r3 = r1 * r2 / 255;
                            g3 = g1 * g2 / 255;
                            b3 = b1 * b2 / 255;
                            pix3 = Color.FromArgb(r3, g3, b3);
                            image3.SetPixel(j, i, pix3);
                            break;
                        // среднее-арифметическое
                        case 2:
                            r3 = (r1 + r2) / 2;
                            g3 = (g1 + g2) / 2;
                            b3 = (b1 + b2) / 2;
                            pix3 = Color.FromArgb(r3, g3, b3);
                            image3.SetPixel(j, i, pix3);
                            break;
                        // минимум
                        case 3:
                            r3 = Math.Min(r1, r2);
                            g3 = Math.Min(g1, g2);
                            b3 = Math.Min(b1, b2);
                            pix3 = Color.FromArgb(r3, g3, b3);
                            image3.SetPixel(j, i, pix3);
                            break;
                        // максимум
                        case 4:
                            r3 = Math.Max(r1, r2);
                            g3 = Math.Max(g1, g2);
                            b3 = Math.Max(b1, b2);
                            pix3 = Color.FromArgb(r3, g3, b3);
                            image3.SetPixel(j, i, pix3);
                            break;
                    }
                }
            }

            if (checkBox1.Checked)
            {
                for (int i = 0; i < 500; ++i)
                {
                    for (int j = 0; j < 500; ++j)
                    {
                        var pix3 = image3.GetPixel(j, i); // Цвет пикселя с третьей картинки
                        int r3 = pix3.R;
                        int g3 = pix3.G;
                        int b3 = pix3.B;
                        r3 = r3 * panel1.BackColor.R / 255;
                        g3 = g3 * panel1.BackColor.G / 255;
                        b3 = b3 * panel1.BackColor.B / 255;
                        pix3 = Color.FromArgb(r3, g3, b3);
                        image3.SetPixel(j, i, pix3);
                    }
                }
            }
            pictureBox3.Image = image3;
        }

        // Кнопка сохранения
        private void button5_Click(object sender, EventArgs e)
        {
            using SaveFileDialog saveFileFialog = new SaveFileDialog();
            saveFileFialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileFialog.Filter = "Картинки (png, jpg, bmp, gif) |*.png;*.jpg;*.bmp;*.gif|All files (*.*)|*.*";
            saveFileFialog.RestoreDirectory = true;

            if (saveFileFialog.ShowDialog() == DialogResult.OK)
            {
                if (image3 != null)
                {
                    image3.Save(saveFileFialog.FileName);
                }
            }
        }

        public static T Clamp<T>(T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var Form2 = new Form2(image1);
            Form2.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var Form2 = new Form2(image2);
            Form2.Show();
        }
    }
}