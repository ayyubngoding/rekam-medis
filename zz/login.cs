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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        public static string nama;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0R16R5N\AYYUB;Initial Catalog=rekammedis;Integrated Security=True");
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(" select count(*) from tabeluser where Username='" + bunifuMaterialTextbox1.Text + "' and Password='" +bunifuMaterialTextbox2.Text+ "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                nama = bunifuMaterialTextbox1.Text;
                menu m = new menu();
                m.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("salah");
            }
            conn.Close();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
