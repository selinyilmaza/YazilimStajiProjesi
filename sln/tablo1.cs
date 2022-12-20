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

namespace sln
{
    public partial class tablo1 : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        public tablo1()
        {
            InitializeComponent();
        }

        void giriscikis()
        { 

            baglanti = new SqlConnection("Data Source=DESKTOP-DKI7TIC; Initial Catalog=SLN; Integrated Security=TRUE");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT * FROM [SLN].[dbo].[giris_cikis]", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void tablo1_Load(object sender, EventArgs e)
        {
            giriscikis();
        }
    }
}
