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
    public partial class pasien : Form
    {
        public pasien()
        {
            InitializeComponent();
            tampil();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0R16R5N\AYYUB;Initial Catalog=rekammedis;Integrated Security=True");
        void tampil()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from pasien", conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "pasien");
            dgvpasien.DataSource = ds;
            dgvpasien.DataMember = "pasien";
            conn.Close();
        }
        void bersih()
        {
            txidpasien.Text = "";
            txtnamapasien.Text = "";
            txtumue.Text = "";
            combojenis.Text = "";
            txtalamat.Text = "";
        }
        private void dgvpasien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txidpasien.Text = dgvpasien.SelectedRows[0].Cells[0].Value.ToString();
            txtnamapasien.Text = dgvpasien.SelectedRows[0].Cells[1].Value.ToString();
            txtumue.Text = dgvpasien.SelectedRows[0].Cells[2].Value.ToString();
            combojenis.Text = dgvpasien.SelectedRows[0].Cells[3].Value.ToString();
            txtalamat.Text = dgvpasien.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string suci = "insert into PASIEN values('" + txidpasien.Text + "','" + txtnamapasien.Text + "','" + txtumue.Text + "','" + combojenis.SelectedItem.ToString() + "','"+txtalamat.Text+"')";
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
                if (txidpasien.Text == "")
                {
                    MessageBox.Show("Pilih Data Terlebih Dahulu", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn.Open();
                    string suci = "update pasien set KodePasien='" + txidpasien.Text + "',namapasien='" + txtnamapasien.Text + "',umur='" + txtumue.Text + "',jeniskelamin='" + combojenis.SelectedItem.ToString() + "',alamat='" + txtalamat.Text + "' where KodePasien='"+txidpasien.Text+"'";
                    SqlCommand cmd = new SqlCommand(suci, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("data berhasil diupdate", "Pesan Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (txidpasien.Text == "")
                {
                    MessageBox.Show("Pilih Data Terlebih Dahulu", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn.Open();
                    string suci = "delete from pasien where KodePasien='" + txidpasien.Text + "'";
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

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from pasien where namapasien like'%" + bunifuTextbox1.text + "%'", conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "pasien");
            dgvpasien.DataSource = ds;
            dgvpasien.DataMember = "pasien";
            conn.Close();
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

        private void pasien_Load(object sender, EventArgs e)
        {
            label6.Text = menu.username;
        }
    }
}
