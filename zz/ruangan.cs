using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace zz
{
    public partial class ruangan : Form
    {
        public ruangan()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0R16R5N\AYYUB;Initial Catalog=rekammedis;Integrated Security=True");
        void tampil()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from ruangan", conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "ruangan");
            dgvruangan.DataSource = ds;
            dgvruangan.DataMember = "ruangan";
            conn.Close();
        }
        void bersih()
        {
           txtkoderuangan.Text= "";
           txtnamaruangan.Text = "";
           txtbiaya.Text = "";
           combotype.Text = "";
        }
        private void ruangan_Load(object sender, EventArgs e)
        {
            tampil();
            label5.Text = menu.username;
        }

        private void dgvruangan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtkoderuangan.Text = dgvruangan.SelectedRows[0].Cells[0].Value.ToString();
            txtnamaruangan.Text = dgvruangan.SelectedRows[0].Cells[1].Value.ToString();
            txtbiaya.Text = dgvruangan.SelectedRows[0].Cells[2].Value.ToString();
            combotype.Text = dgvruangan.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from ruangan where namaruangan like'%" + bunifuTextbox1.text + "%'", conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "ruangan");
            dgvruangan.DataSource = ds;
            dgvruangan.DataMember = "ruangan";
            conn.Close();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtkoderuangan.Text == "")
                {
                    MessageBox.Show("Isi Data Dengan Lengkap", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn.Open();
                    string suci = "insert into ruangan values('" + txtkoderuangan.Text + "','" + txtnamaruangan.Text + "','" + txtbiaya.Text + "','" + combotype.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(suci, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("data berhasil di Simpan", "Pesan Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    tampil();
                    bersih();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtkoderuangan.Text == "")
                {
                    MessageBox.Show("Pilih Data Yang Akan Di Update", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn.Open();
                    string suci = "update ruangan set koderuangan='" + txtkoderuangan.Text + "',namaruangan='" + txtnamaruangan.Text + "',biayaruangan='" + txtbiaya.Text + "',typeruangan='" + combotype.SelectedItem.ToString() + "' where koderuangan='"+txtkoderuangan.Text+"'";
                    SqlCommand cmd = new SqlCommand(suci, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("data berhasil di Update", "Pesan Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    tampil();
                    bersih();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtkoderuangan.Text == "")
                {
                    MessageBox.Show("Pilih Data Yang Akan Di Hapus", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn.Open();
                    string suci = "delete from ruangan where koderuangan='" + txtkoderuangan.Text + "'";
                    SqlCommand cmd = new SqlCommand(suci, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("data berhasil di Update", "Pesan Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    tampil();
                    bersih();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            menu m = new menu();
            m.Show();
            this.Hide();
        }
    }
}
