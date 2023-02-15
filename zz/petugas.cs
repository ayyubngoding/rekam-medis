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
    public partial class petugas : Form
    {
        public petugas()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0R16R5N\AYYUB;Initial Catalog=rekammedis;Integrated Security=True");
        void tampil()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tabeluser", conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tabeluser");
            dgvuser.DataSource = ds;
            dgvuser.DataMember = "tabeluser";
            conn.Close();
        }
        void bersih()
        {
            txtiduser.Text = "";
            txtnama.Text = "";
            txtalamat.Text = "";
            txtusername.Text = "";
            txtpassword.Text = "";
        }
        private void petugas_Load(object sender, EventArgs e)
        {
            tampil();
            label6.Text = menu.username;
        }

        private void dgvuser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtiduser.Text = dgvuser.SelectedRows[0].Cells[0].Value.ToString();
            txtnama.Text = dgvuser.SelectedRows[0].Cells[1].Value.ToString();
            txtalamat.Text = dgvuser.SelectedRows[0].Cells[2].Value.ToString();
            txtusername.Text = dgvuser.SelectedRows[0].Cells[3].Value.ToString();
            txtpassword.Text = dgvuser.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtiduser.Text == "")
                {
                    MessageBox.Show("Isi Data Dengan Lengkap", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn.Open();
                    string suci = "insert into tabeluser values('" + txtiduser.Text + "','" + txtnama.Text + "','" + txtalamat.Text + "','" + txtusername.Text + "','"+txtpassword.Text+"')";
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
                if (txtiduser.Text == "")
                {
                    MessageBox.Show("pilih data yang akan update", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn.Open();
                    string suci = "update tabeluser set iduser='" + txtiduser.Text + "',namauser='" + txtnama.Text + "',alamat='" + txtalamat.Text + "',username='" + txtusername.Text + "',password='" + txtpassword.Text + "' where iduser='"+txtiduser.Text+"'";
                    SqlCommand cmd = new SqlCommand(suci, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("data berhasil di update", "Pesan Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (txtiduser.Text == "")
                {
                    MessageBox.Show("pilih data yang akan dihapus", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn.Open();
                    string suci = "deletefrom tabeluser where iduser='" + txtiduser.Text + "'";
                    SqlCommand cmd = new SqlCommand(suci, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("data berhasil di hapus", "Pesan Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            SqlCommand cmd = new SqlCommand("select * from tabeluser where namauser like'%" + bunifuTextbox1.text + "%'", conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "tabeluser");
            dgvuser.DataSource = ds;
            dgvuser.DataMember = "tabeluser";
            conn.Close();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            menu m = new menu();
            m.Show();
            this.Hide();
        }
    }
}
