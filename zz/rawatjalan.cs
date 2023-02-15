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
    public partial class rawatjalan : Form
    {
        public rawatjalan()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0R16R5N\AYYUB;Initial Catalog=rekammedis;Integrated Security=True");
        void tampil()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from rawatjalan", conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "rawatjalan");
            dgvrawatjalan.DataSource = ds;
            dgvrawatjalan.DataMember = "rawatjalan";
            conn.Close();
        }
        void bersih()
        {
            txtkdrawatjalan.Text = "";
            cbkdpasien.Text = "";
            txtnamapasien.Text = "";
            cbkddokter.Text = "";
            txtnamadokter.Text = "";
            txtbiayadokter.Text = "";
            txtspesialis.Text = "";
            cbkdobat.Text = "";
            txtnamaobat.Text = "";
            txthargaobat.Text = "";
            tglperiksa.Text = "";
        }
        void kodedokter()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from pemeriksaan where  hasil='" + "Rawat Jalan" + "'", conn);
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
                txtbiayadokter.Text = suci["biaya"].ToString();
                txtspesialis.Text = suci["spesialis"].ToString();
            }
            conn.Close();
        }
        void kodepasien()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from pemeriksaan where  hasil='" + "Rawat Jalan" + "'", conn);
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("kodepasien", typeof(string));
            dt.Load(rd);
            cbkdpasien.ValueMember = "kodepasien";
            cbkdpasien.DataSource = dt;
            conn.Close();
        }
        void namapasien()
        {
            conn.Open();
            var ayubku = "select * from pemeriksaan  where kodepasien ='" + cbkdpasien.SelectedValue.ToString() + "'";
            SqlDataAdapter da = new SqlDataAdapter(ayubku, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow suci in dt.Rows)
            {
                txtnamapasien.Text = suci["namapasien"].ToString();
            }
            conn.Close();
        }
        void kodeobat()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select kodeobat from obat", conn);
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("kodeobat", typeof(string));
            dt.Load(rd);
            cbkdobat.ValueMember = "kodeobat";
            cbkdobat.DataSource = dt;
            conn.Close();
        }
        void namaobat()
        {
            conn.Open();
            var ayubku = "select * from obat  where kodeobat ='" + cbkdobat.SelectedValue.ToString() + "'";
            SqlDataAdapter da = new SqlDataAdapter(ayubku, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow suci in dt.Rows)
            {
                txtnamaobat.Text = suci["namaobat"].ToString();
                txthargaobat.Text = suci["hargaobat"].ToString();
            }
            conn.Close();
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
        private void rawatjalan_Load(object sender, EventArgs e)
        {
            label12.Text = menu.username;
            tampil();
            kodedokter();
            kodeobat();
            kodepasien();
            kodepetugas();
        }

        private void cbkdpasien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            namapasien();
        }

        private void cbkddokter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            namadokter();
        }

        private void cbkdobat_SelectionChangeCommitted(object sender, EventArgs e)
        {
            namaobat();
        }

        private void dgvrawatjalan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtkdrawatjalan.Text = dgvrawatjalan.SelectedRows[0].Cells[0].Value.ToString();
            cbkdpasien.Text = dgvrawatjalan.SelectedRows[0].Cells[1].Value.ToString();
            txtnamapasien.Text = dgvrawatjalan.SelectedRows[0].Cells[2].Value.ToString();
            cbkddokter.Text = dgvrawatjalan.SelectedRows[0].Cells[3].Value.ToString();
            txtnamadokter.Text = dgvrawatjalan.SelectedRows[0].Cells[4].Value.ToString();
            txtbiayadokter.Text = dgvrawatjalan.SelectedRows[0].Cells[5].Value.ToString();
            txtspesialis.Text = dgvrawatjalan.SelectedRows[0].Cells[6].Value.ToString();
            cbkdobat.Text = dgvrawatjalan.SelectedRows[0].Cells[7].Value.ToString();
            txtnamaobat.Text = dgvrawatjalan.SelectedRows[0].Cells[8].Value.ToString();
            txthargaobat.Text = dgvrawatjalan.SelectedRows[0].Cells[9].Value.ToString();
            tglperiksa.Text = dgvrawatjalan.SelectedRows[0].Cells[10].Value.ToString();
        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from rawatjalan where namapasien like'%" + bunifuTextbox1.text + "%'", conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "rawatjalan");
            dgvrawatjalan.DataSource = ds;
            dgvrawatjalan.DataMember = "rawatjalan";
            conn.Close();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtkdrawatjalan.Text == "")
                {
                    MessageBox.Show("Isi Data Dengan Lengkap", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn.Open();
                    string suci = "insert into rawatjalan values('" + txtkdrawatjalan.Text + "','" + cbkdpasien.SelectedValue.ToString() + "','" + txtnamapasien.Text + "','" + cbkddokter.SelectedValue.ToString() + "','" + txtnamadokter.Text + "','" + txtbiayadokter.Text + "','" + txtspesialis.Text + "','" + cbkdobat.SelectedValue.ToString() + "','" + txtnamaobat.Text + "','" + txthargaobat.Text + "','" + tglperiksa.Value.Date.ToString("yyyy-MM-dd") + "','"+cbpetugas.SelectedValue.ToString()+"')";
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
                if (txtkdrawatjalan.Text == "")
                {
                    MessageBox.Show("Pilih Data Yang Akan Di Update", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn.Open();
                    string suci = "update rawatjalan set koderawatjalan='" + txtkdrawatjalan.Text + "',kodepasien='" + cbkdpasien.SelectedValue.ToString() + "',namapasien='" + txtnamapasien.Text + "',kodedokter='" + cbkddokter.SelectedValue.ToString() + "',namadokter='" + txtnamadokter.Text + "',biayadokter='" + txtbiayadokter.Text + "',spesialis='" + txtspesialis.Text + "',kodeobat='" + cbkdobat.SelectedValue.ToString() + "',namaobat='" + txtnamaobat.Text + "',hargaobat='" + txthargaobat.Text + "',tglperiksa='" + tglperiksa.Value.Date.ToString("yyyy-MM-dd") + "',iduser='" + cbpetugas.SelectedValue.ToString() + "' where koderawatjalan='" + txtkdrawatjalan.Text + "'";
                    SqlCommand cmd = new SqlCommand(suci, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil di Update", "Pesan Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (txtkdrawatjalan.Text == "")
                {
                    MessageBox.Show("Pilih Data Yang Akan Di Hapus", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn.Open();
                    string suci = "delete from rawatjalan where koderawatjalan='" + txtkdrawatjalan.Text + "'";
                    SqlCommand cmd = new SqlCommand(suci, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil di Hapus", "Pesan Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
