using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Crosshair
{
    public partial class Main : Form
    {
        Form2 crosshair = new Form2();
        bool CrosshairEnabled = false;
        int X = Crosshair.Properties.Settings.Default.LocX;
        int Y = Crosshair.Properties.Settings.Default.LocY;
        public Main()
        {
            InitializeComponent();
            textBox_X.Text = Convert.ToString(X);
            textBox_Y.Text = Convert.ToString(Y);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!CrosshairEnabled)
            {
                crosshair.Show();
                CrosshairEnabled = true;
                checkBox1.Text = "Выключить";
            }
            else
            {
                crosshair.Hide();
                CrosshairEnabled = false;
                checkBox1.Text = "Включить";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton3.Checked)
                crosshair.BackgroundImage = Properties.Resources.red_point_2px;
            else
                crosshair.BackgroundImage = Properties.Resources.red_point;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                crosshair.BackgroundImage = Properties.Resources.green_point_2px;
            else
                crosshair.BackgroundImage = Properties.Resources.green_point;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                X = Convert.ToInt32(textBox_X.Text);
                Y = Convert.ToInt32(textBox_Y.Text);
                Properties.Settings.Default.LocX = X;
                Properties.Settings.Default.LocY = Y;
                Properties.Settings.Default.Save();
                crosshair.Location = new Point(X, Y);
            }
            catch (FormatException) { MessageBox.Show("Ошибка ввода! :("); }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                crosshair.BackgroundImage = Properties.Resources.red_point_2px;
            else
                crosshair.BackgroundImage = Properties.Resources.green_point_2px;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                crosshair.BackgroundImage = Properties.Resources.red_point;
            else
                crosshair.BackgroundImage = Properties.Resources.green_point;
        }

        private void Main_Load(object sender, EventArgs e)
        {
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            X = Convert.ToInt32(hScrollBar1.Value);
            textBox_X.Text = Convert.ToString(X);
            crosshair.Location = new Point(X, Y);
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Y = Convert.ToInt32(vScrollBar1.Value);
            textBox_Y.Text = Convert.ToString(Y);
            crosshair.Location = new Point(X, Y);
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            switch (tabControl1.SelectedIndex.ToString())
            {
                case ("0"):
                    this.Size = new Size(194, 214);
                    tabControl1.Size = new Size(194, 189);
                    break;
                case ("1"):
                    this.Size = new Size(471, 420);
                    tabControl1.Size = new Size(471, 395);
                    break;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://tikhonex.ru");
        }
    }
}
