using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zz
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            timer1.Start();
        }
        byte key = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            key += 1;
            guna2CircleProgressBar1.Value = key;
            label1.Text = guna2CircleProgressBar1.Value + "%";
            if (guna2CircleProgressBar1.Value == 100)
            {
                guna2CircleProgressBar1.Value = 100;
                timer1.Stop();
                login f = new login();
                f.Show();
                this.Hide();
            }
        }

    }
}

