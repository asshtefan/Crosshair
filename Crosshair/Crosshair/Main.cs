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
    }
}
