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
    public partial class Form2 : Form
    {
        int X;
        int Y;
        public Form2()
        {
            InitializeComponent();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (Crosshair.Properties.Settings.Default.LocX != 0)
            {
                X = Crosshair.Properties.Settings.Default.LocX;
                Y = Crosshair.Properties.Settings.Default.LocY;
                this.Location = new Point(X, Y);
            }
        }
    }
}
