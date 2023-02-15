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
    public partial class dokter : Form
    {
        public dokter()
        {
            InitializeComponent();
            label8.Text = menu.username;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0R16R5N\AYYUB;Initial Catalog=rekammedis;Integrated Security=True");
        void tampil()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from dokter", conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "dokter");
            dgvdokter.DataSource = ds;
            dgvdokter.DataMember = "dokter";
            conn.Close();
        }
        void bersih()
        {
            txtkodedokter.Text = "";
            txtnamadokter.Text = "";
            txttelepon.Text = "";
            combojenis.Text = "";
            txtalamat.Text = "";
            txtspesialis.Text = "";
            txtbiaya.Text = "";
        }
        private void dokter_Load(object sender, EventArgs e)
        {
            tampil();
        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from dokter where NamaDokter like'%"+bunifuTextbox1.text+"'", conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "dokter");
            dgvdokter.DataSource = ds;
            dgvdokter.DataMember = "dokter";
            conn.Close();
        }

        private void dgvdokter_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtkodedokter.Text = dgvdokter.SelectedRows[0].Cells[0].Value.ToString();
            txtnamadokter.Text = dgvdokter.SelectedRows[0].Cells[1].Value.ToString();
            txttelepon.Text = dgvdokter.SelectedRows[0].Cells[2].Value.ToString();
            combojenis.Text = dgvdokter.SelectedRows[0].Cells[3].Value.ToString();
            txtalamat.Text = dgvdokter.SelectedRows[0].Cells[4].Value.ToString();
            txtspesialis.Text = dgvdokter.SelectedRows[0].Cells[5].Value.ToString();
            txtbiaya.Text = dgvdokter.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string suci = "insert into  dokter values('" + txtkodedokter.Text + "','" + txtnamadokter.Text + "','" + txttelepon.Text + "','" + combojenis.SelectedItem.ToString() + "','" + txtalamat.Text + "','" + txtspesialis.Text + "','" + txtbiaya.Text + "')";
            SqlCommand cmd = new SqlCommand(suci, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("data berhasil disimpan","Pesan Informasi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            conn.Close();
            tampil();
            bersih();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtkodedokter.Text=="")
                {
                     MessageBox.Show("Pilih Data Yang akan DI Update", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn.Open();
                    string suci = "update   dokter set namadokter='" + txtnamadokter.Text + "',telepon='" + txttelepon.Text + "',jeniskelamin='" + combojenis.SelectedItem.ToString() + "',alamat='" + txtalamat.Text + "',spesialis='" + txtspesialis.Text + "',biaya='" + txtbiaya.Text + "' where kodedokter='" + txtkodedokter.Text + "'";
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
                if (txtkodedokter.Text=="")
                {
                     MessageBox.Show("Pilih Data Yang akan DI Hapus", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn.Open();
                    string suci = "delete from dokter where kodedokter='" + txtkodedokter.Text + "'";
                    SqlCommand cmd = new SqlCommand(suci, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("data berhasil di Hapus", "Pesan Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
