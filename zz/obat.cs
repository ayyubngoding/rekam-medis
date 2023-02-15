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
    public partial class obat : Form
    {
        public obat()
        {
            InitializeComponent();
            tampil();
            label4.Text = menu.username;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0R16R5N\AYYUB;Initial Catalog=rekammedis;Integrated Security=True");
        void tampil()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from obat", conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "obat");
            dgvobat.DataSource = ds;
            dgvobat.DataMember = "obat";
            conn.Close();
        }
        void bersih()
        {
            txtkodeobat.Text = "";
            txtnamaobat.Text = "";
            txtdosis.Text = "";
            txthargaobat.Text = "";
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtkodeobat.Text = dgvobat.SelectedRows[0].Cells[0].Value.ToString();
            txtnamaobat.Text = dgvobat.SelectedRows[0].Cells[1].Value.ToString();
            txtdosis.Text = dgvobat.SelectedRows[0].Cells[2].Value.ToString();
            txthargaobat.Text = dgvobat.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            bersih();
        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from obat where namaobat like'%" + bunifuTextbox1.text + "'", conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "obat");
            dgvobat.DataSource = ds;
            dgvobat.DataMember = "obat";
            conn.Close();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            conn.Open();
            string suci = "insert into  obat values('" + txtkodeobat.Text + "','" + txtnamaobat.Text + "','" + txtdosis.Text + "','" + txthargaobat.Text + "')";
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
                if (txtkodeobat.Text=="")
                {
                      MessageBox.Show("Pilih Data Terlebih Dahulu", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn.Open();
                    string suci = "update obat set kodeobat='" + txtkodeobat.Text + "',namaobat='" + txtnamaobat.Text + "',dosis='" + txtdosis.Text + "',hargaobat='" + txthargaobat.Text + "' where kodeobat='" + txtkodeobat.Text + "'";
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
                if (txtkodeobat.Text == "")
                {
                    MessageBox.Show("Pilih Data Terlebih Dahulu", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn.Open();
                    string suci = "delete from obat where kodeobat='" + txtkodeobat.Text + "'";
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

        private void obat_Load(object sender, EventArgs e)
        {

        }
    }
}
