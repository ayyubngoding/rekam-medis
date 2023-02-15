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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
            label1.Text = login.nama;
            
        }
       public static string username = "";
        private void pasienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            username = label1.Text;
            pasien p = new pasien();
            p.ShowDialog();
        }

        private void obatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            username = label1.Text;
            obat p = new obat();
            p.ShowDialog();
        }

        private void ruanganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            username = label1.Text;
            ruangan p = new ruangan();
            p.ShowDialog();
        }

        private void pemeriksaanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            username = label1.Text;
            pemeriksaan p = new pemeriksaan();
            p.ShowDialog();
        }

        private void perawatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            username = label1.Text;
            perawat p = new perawat();
            p.ShowDialog();
        }

        private void transaksiRawatInapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            username = label1.Text;
            rawatinap p = new rawatinap();
            p.ShowDialog();
        }

        private void transaksiRawatJalanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            username = label1.Text;
            rawatjalan p = new rawatjalan();
            p.ShowDialog();
        }

        private void dataMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            username = label1.Text;
            petugas p = new petugas();
            p.ShowDialog();
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }

        private void dokterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            username = label1.Text;
            dokter p = new dokter();
            p.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
