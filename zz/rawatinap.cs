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
    public partial class rawatinap : Form
    {
        public rawatinap()
        {
            InitializeComponent();
            
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0R16R5N\AYYUB;Initial Catalog=rekammedis;Integrated Security=True");
        void tampil()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from rawatinap", conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "rawatinap");
            dgvrawatinap.DataSource = ds;
            dgvrawatinap.DataMember = "rawatinap";
            conn.Close();
        }
        void bersih()
        {
            txtkoderawatinap.Text = "";
            cbkdpasien.Text = "";
            txtnamapasien.Text = "";
            cbkaddokter.Text = "";
            txtnamadokter.Text = "";
            txtbiayadokter.Text = "";
            txtspesialis.Text = "";
            cbkdruangan.Text = "";
            txtnamaruangan.Text = "";
            txtbiayaruangan.Text = "";
            cbkdperawat.Text = "";
            txtnamaperawat.Text = "";
            tglmasuk.Text = "";
            tglkeluar.Text = "";
            txtlama.Text = "";
            txttotal.Text = "";
        }
        void kodedokter()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from pemeriksaan where  hasil='"+"Rawat Inap"+"'", conn);
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("kodedokter", typeof(string));
            dt.Load(rd);
            cbkaddokter.ValueMember = "kodedokter";
            cbkaddokter.DataSource = dt;
            conn.Close();
        }
        void namadokter()
        {
            conn.Open();
            var ayubku = "select * from dokter where kodedokter ='" + cbkaddokter.SelectedValue.ToString() + "'";
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
            SqlCommand cmd = new SqlCommand("select * from pemeriksaan where  hasil='"+"Rawat Inap"+"'", conn);
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
        void kodeperawat()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select kodeperawat from perawat", conn);
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("kodeperawat", typeof(string));
            dt.Load(rd);
            cbkdperawat.ValueMember = "kodeperawat";
            cbkdperawat.DataSource = dt;
            conn.Close();
        }
        void namaperawat()
        {
            conn.Open();
            var ayubku = "select * from perawat where kodeperawat ='" + cbkdperawat.SelectedValue.ToString() + "'";
            SqlDataAdapter da = new SqlDataAdapter(ayubku, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow suci in dt.Rows)
            {
                txtnamaperawat.Text = suci["namaperawat"].ToString();
            }
            conn.Close();
        }
        void koderuangan()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select koderuangan from ruangan", conn);
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("koderuangan", typeof(string));
            dt.Load(rd);
            cbkdruangan.ValueMember = "koderuangan";
            cbkdruangan.DataSource = dt;
            conn.Close();
        }
        void namaruangan()
        {
            conn.Open();
            var ayubku = "select * from ruangan where koderuangan ='" + cbkdruangan.SelectedValue.ToString() + "'";
            SqlDataAdapter da = new SqlDataAdapter(ayubku, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow suci in dt.Rows)
            {
                txtnamaruangan.Text = suci["namaruangan"].ToString();
                txtbiayaruangan.Text = suci["biayaruangan"].ToString();
               
            }
            conn.Close();
        }
        void totalotomatis()
        {
            DateTime tanggalkeluar;
            DateTime tglmasukk;
            TimeSpan tambahhari;
            int total;
            int biayadokter, biayaruangan,biayaperawatan;

            tanggalkeluar = tglkeluar.Value;
            tglmasukk = tglmasuk.Value;
            tambahhari = tanggalkeluar.Subtract(tglmasukk);
            biayadokter = int.Parse(txtbiayadokter.Text);
            biayaruangan =int.Parse( txtbiayaruangan.Text);
           

            total = Convert.ToInt32(tambahhari.Days);
            biayaperawatan = 200000 * total;

            if (total > 0)
            {
                txtlama.Text = total.ToString() + "Hari";
               
                txttotal.Text = (biayadokter + biayaperawatan + biayaruangan + biayaperawatan * total).ToString();
            }
            else if (total <= 0)
            {
                txttotal.Text = "0";
                txtlama.Text = "Tidak";
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
        private void rawatinap_Load(object sender, EventArgs e)
        {
            tglmasuk.Value = DateTime.Now;
            tglkeluar.Value = DateTime.Now;
            tampil();
            kodedokter();
            kodepasien();
            kodeperawat();
            label17.Text = menu.username;
            koderuangan();
            kodepetugas();
        }

        private void dgvrawatinap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtkoderawatinap.Text = dgvrawatinap.SelectedRows[0].Cells[0].Value.ToString();
            cbkdpasien.Text = dgvrawatinap.SelectedRows[0].Cells[1].Value.ToString();
            txtnamapasien.Text = dgvrawatinap.SelectedRows[0].Cells[2].Value.ToString();
            cbkaddokter.Text = dgvrawatinap.SelectedRows[0].Cells[3].Value.ToString();
            txtnamadokter.Text = dgvrawatinap.SelectedRows[0].Cells[4].Value.ToString();
            txtbiayadokter.Text = dgvrawatinap.SelectedRows[0].Cells[5].Value.ToString();
            txtspesialis.Text = dgvrawatinap.SelectedRows[0].Cells[6].Value.ToString();
            cbkdruangan.Text = dgvrawatinap.SelectedRows[0].Cells[7].Value.ToString();
            txtnamaruangan.Text = dgvrawatinap.SelectedRows[0].Cells[8].Value.ToString();
            txtbiayaruangan.Text = dgvrawatinap.SelectedRows[0].Cells[9].Value.ToString();
            cbkdperawat.Text = dgvrawatinap.SelectedRows[0].Cells[10].Value.ToString();
            txtnamaperawat.Text = dgvrawatinap.SelectedRows[0].Cells[11].Value.ToString();
            tglmasuk.Text = dgvrawatinap.SelectedRows[0].Cells[12].Value.ToString();
            tglkeluar.Text = dgvrawatinap.SelectedRows[0].Cells[13].Value.ToString();
            txtlama.Text = dgvrawatinap.SelectedRows[0].Cells[14].Value.ToString();
            txttotal.Text = dgvrawatinap.SelectedRows[0].Cells[15].Value.ToString();
        }

        private void bunifuTextbox1_OnTextChange(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from rawatinap where namapasien like'%" + bunifuTextbox1.text + "%'", conn);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "rawatinap");
            dgvrawatinap.DataSource = ds;
            dgvrawatinap.DataMember = "rawatinap";
            conn.Close();
        }

        private void cbkdpasien_SelectionChangeCommitted(object sender, EventArgs e)
        {
            namapasien();
        }

        private void cbkaddokter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            namadokter();
        }

        private void cbkdruangan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            namaruangan();
        }

        private void cbkdperawat_SelectionChangeCommitted(object sender, EventArgs e)
        {
            namaperawat();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtkoderawatinap.Text == "")
                {
                    MessageBox.Show("Isi Data Dengan Lengkap", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn.Open();
                    string suci = "insert into rawatinap values('" + txtkoderawatinap.Text + "','" + cbkdpasien.SelectedValue.ToString() + "','" + txtnamapasien.Text + "','" + cbkaddokter.SelectedValue.ToString() + "','" + txtnamadokter.Text + "','" + txtbiayadokter.Text + "','" + txtspesialis.Text + "','" + cbkdruangan.SelectedValue.ToString() + "','" + txtnamaruangan.Text + "','" + txtbiayaruangan.Text + "','" + cbkdperawat.SelectedValue.ToString() + "','" + txtnamaperawat.Text + "','" + tglmasuk.Value.Date.ToString("yyyy-MM-dd") + "','" + tglkeluar.Value.Date.ToString("yyyy-MM-dd") + "','" + txtlama.Text + "','" + txttotal.Text + "','" + cbpetugas.SelectedValue.ToString() + "')";
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
        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            totalotomatis();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtkoderawatinap.Text == "")
                {
                    MessageBox.Show("Pilih Data Yang Akan Di Update", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn.Open();
                    string suci = "update rawatinap set koderawatinap='" + txtkoderawatinap.Text + "',kodepasien='" + cbkdpasien.SelectedValue.ToString() + "',namapasien='" + txtnamapasien.Text + "',kodedokter='" + cbkaddokter.SelectedValue.ToString() + "',namadokter='" + txtnamadokter.Text + "',biayadokter='" + txtbiayadokter.Text + "',spesialis='" + txtspesialis.Text + "',koderuangan='" + cbkdruangan.SelectedValue.ToString() + "',namaruangan='" + txtnamaruangan.Text + "',biayaruangan='" + txtbiayaruangan.Text + "',kodeperawat='" + cbkdperawat.SelectedValue.ToString() + "',namaperawat='" + txtnamaperawat.Text + "',tglmasuk='" + tglmasuk.Value.Date.ToString("yyyy-MM-dd") + "',tglkeluar='" + tglkeluar.Value.Date.ToString("yyyy-MM-dd") + "',lamamenginap='" + txtlama.Text + "',totalbiaya='" + txttotal.Text + "',iduser='" + cbpetugas.SelectedValue.ToString() + "'  where koderawatinap='" + txtkoderawatinap.Text + "'";
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
                if (txtkoderawatinap.Text == "")
                {
                    MessageBox.Show("Pilih Data Yang Akan Di Hapus", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn.Open();
                    string suci = "delete from rawatinap where koderawatinap='" + txtkoderawatinap.Text + "'";
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

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            menu m = new menu();
            m.Show();
            this.Hide();
        }
    }
}
