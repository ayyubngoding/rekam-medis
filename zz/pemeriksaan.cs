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
    public partial class pemeriksaan : Form
    {
        public pemeriksaan()
        {
            InitializeComponent();
            tampil();
            kodedokter();
            kodepasien();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0R16R5N\AYYUB;Initial Catalog=rekammedis;Integrated Security=True");
        void tampil()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from pemeriksaan", conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "pemeriksaan");
            dgvpemeriksaan.DataSource = ds;
            dgvpemeriksaan.DataMember = "pemeriksaan";
            conn.Close();
        }
        void bersih()
        {
            txtkodeperiksa.Text = "";
            cbkddokter.Text = "";
            txtnamadokter.Text = "";
            cbkdpasien.Text = "";
            txtnamapasien.Text = "";
            cbdiagnosa.Text = "";
            tglperiksa.Text = "";
            txthasil.Text = "";
        }
        void kodedokter()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select kodedokter from dokter", conn);
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("kodedokter", typeof(string));
            dt.Load(rd);
            cbkddokter.ValueMember = "kodedokter";
            cbkddokter.DataSource = dt;
            conn.Close();
        }
        void namadokter()
        {
            conn.Open();
            var ayubku = "select * from dokter where kodedokter ='" + cbkddokter.SelectedValue.ToString() + "'";
            SqlDataAdapter da = new SqlDataAdapter(ayubku, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow suci in dt.Rows)
            {
               txtnamadokter.Text = suci["namadokter"].ToString();
            }
            conn.Close();
        }
        void kodepasien()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select KodePasien from pasien", conn);
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("KodePasien", typeof(string));
            dt.Load(rd);
            cbkdpasien.ValueMember = "KodePasien";
            cbkdpasien.DataSource = dt;
            conn.Close();
        }
        void namapasien()
        {
            conn.Open();
            var ayubku = "select * from pasien where KodePasien ='" + cbkdpasien.SelectedValue.ToString() + "'";
            SqlDataAdapter da = new SqlDataAdapter(ayubku, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow suci in dt.Rows)
            {
                txtnamapasien.Text = suci["namapasien"].ToString();
            }
            conn.Close();
        }
        private void dgvpemeriksaan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtkodeperiksa.Text = dgvpemeriksaan.SelectedRows[0].Cells[0].Value.ToString();
            cbkddokter.Text = dgvpemeriksaan.SelectedRows[0].Cells[1].Value.ToString();
            txtnamadokter.Text = dgvpemeriksaan.SelectedRows[0].Cells[2].Value.ToString();
            cbkdpasien.Text = dgvpemeriksaan.SelectedRows[0].Cells[3].Value.ToString();
            txtnamapasien.Text = dgvpemeriksaan.SelectedRows[0].Cells[4].Value.ToString();
            cbdiagnosa.Text = dgvpemeriksaan.SelectedRows[0].Cells[5].Value.ToString();
            tglperiksa.Text = dgvpemeriksaan.SelectedRows[0].Cells[6].Value.ToString();
            txthasil.Text = dgvpemeriksaan.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void cbkddokter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            namadokter();
        }

        private void cbkdpasien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            namapasien();
        }
        void diagnosa()
        {
            if (cbdiagnosa.Text == "Berat")
            {
                txthasil.Text = "Rawat Inap";
            }
            else if (cbdiagnosa.Text == "Ringan")
            {
                txthasil.Text = "Rawat Jalan";
            }
        }

        void kodepetugas()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select iduser from tabeluser", conn);
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("iduser", typeof(string));
            dt.Load(rd);
            cbpetugas.ValueMember = "iduser";
            cbpetugas.DataSource = dt;
            conn.Close();
        }
        private void pemeriksaan_Load(object sender, EventArgs e)
        {
            label9.Text = menu.username;
            kodepetugas();
        }

        private void cbdiagnosa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            diagnosa();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtkodeperiksa.Text == "")
                {
                    MessageBox.Show("Isi Data Dengan Lengkap", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn.Open();
                    string suci = "insert into pemeriksaan values('" + txtkodeperiksa.Text + "','" + cbkddokter.SelectedValue.ToString() + "','" + txtnamadokter.Text + "','" + cbkdpasien.SelectedValue.ToString() + "','" + txtnamapasien.Text + "','" + cbdiagnosa.SelectedItem.ToString() + "','" + tglperiksa.Value.Date.ToString("yyyy-MM-dd") + "','" + txthasil.Text + "','" + cbpetugas.SelectedValue.ToString() + "')";
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
                if (txtkodeperiksa.Text == "")
                {
                    MessageBox.Show("Pilih Data Yang Akan Di Update", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn.Open();
                    string suci = "update pemeriksaan set kodepemeriksaan='" + txtkodeperiksa.Text + "',kodedokter='" + cbkddokter.SelectedValue.ToString() + "',namadokter='" + txtnamadokter.Text + "',kodepasien='" + cbkdpasien.SelectedValue.ToString() + "',namapasien='" + txtnamapasien.Text + "',diagnosa='" + cbdiagnosa.SelectedItem.ToString() + "',tanggalperiksa='" + tglperiksa.Value.Date.ToString("yyyy-MM-dd") + "',hasil='" + txthasil.Text + "',iduser='" + cbpetugas.SelectedValue.ToString() + "'  where kodepemeriksaan='" + txtkodeperiksa.Text + "'";
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
                if (txtkodeperiksa.Text == "")
                {
                    MessageBox.Show("Pilih Data Yang Akan Di Hapus", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn.Open();
                    string suci = "delete from pemeriksaan where kodepemeriksaan='" + txtkodeperiksa.Text + "'";
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
