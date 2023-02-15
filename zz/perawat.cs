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
    public partial class perawat : Form
    {
        public perawat()
        {
            InitializeComponent();
            tampil();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0R16R5N\AYYUB;Initial Catalog=rekammedis;Integrated Security=True");
        void tampil()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from perawat", conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "perawat");
            dgvperawat.DataSource = ds;
            dgvperawat.DataMember = "perawat";
            conn.Close();
        }
        void bersih()
        {
            txtkodeperawat.Text = "";
            txtnamaperawat.Text = "";
            txttelepon.Text = "";
            combojk.Text = "";
            txtalamat.Text = "";
        }
        private void dgvperawat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtkodeperawat.Text = dgvperawat.SelectedRows[0].Cells[0].Value.ToString();
            txtnamaperawat.Text = dgvperawat.SelectedRows[0].Cells[1].Value.ToString();
            txttelepon.Text = dgvperawat.SelectedRows[0].Cells[2].Value.ToString();
            combojk.Text = dgvperawat.SelectedRows[0].Cells[3].Value.ToString();
            txtalamat.Text = dgvperawat.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string suci = "insert into perawat values('" + txtkodeperawat.Text + "','" + txtnamaperawat.Text + "','" + txttelepon.Text + "','" + combojk.SelectedItem.ToString() + "','" + txtalamat.Text + "')";
            SqlCommand cmd = new SqlCommand(suci, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("data berhasil disimpan", "Pesan Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
            tampil();
            bersih();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtkodeperawat.Text=="")
                {
                    MessageBox.Show("Pilih Data Yang Akan di Update", "Pesan Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn.Open();
                    string suci = "update perawat set kodeperawat='" + txtkodeperawat.Text + "',namaperawat='" + txtnamaperawat.Text + "',telepon='" + txttelepon.Text + "',jeniskelamin='" + combojk.SelectedItem.ToString() + "',alamat='" + txtalamat.Text + "' where kodeperawat='"+txtkodeperawat.Text+"'";
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
                if (txtkodeperawat.Text=="")
                {
                    MessageBox.Show("Pilih Data Yang Akan Di Hapus", "Pesan Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn.Open();
                    string suci = "delete from perawat where kodeperawat='" + txtkodeperawat.Text + "'";
                    SqlCommand cmd = new SqlCommand(suci, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("data berhasil dihapus", "Pesan Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from perawat where namaperawat like'%" + bunifuTextbox1.text + "'", conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "perawat");
            dgvperawat.DataSource = ds;
            dgvperawat.DataMember = "perawat";
            conn.Close();
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

        private void perawat_Load(object sender, EventArgs e)
        {
            label6.Text = menu.username;
        }
    }
}
