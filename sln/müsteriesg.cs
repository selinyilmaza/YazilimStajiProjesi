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
    
    public partial class müsteriesg : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-DKI7TIC; Initial Catalog=SLN; Integrated Security=TRUE");
        SqlCommand komut;
        DataTable table= new DataTable();
        SqlDataAdapter da;
        public müsteriesg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new SqlCommand("INSERT INTO kisiler(isim,soyisim,bolumid,tel) VALUES ('" + textBox1.Text + "','" +textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new SqlCommand("DELETE FROM kisiler WHERE id='" + textBox5.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new SqlCommand("UPDATE kisiler SET isim='" + textBox1.Text + "',soyisim='" + textBox2.Text + "',bolumid='" + textBox3.Text + "',tel='" + textBox4.Text + "' WHERE id='" + textBox5.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "AD")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "AD";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "SOYAD")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "SOYAD";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "BOLUM ID")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "BOLUM ID";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "TEL")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "TEL";
                textBox4.ForeColor = Color.Black;
            }
        }
        private void listele()
        {
            table.Clear();
            baglanti.Open();
            komut = new SqlCommand("SELECT * FROM[SLN].[dbo].[kisiler]", baglanti);
            da = new SqlDataAdapter(komut);
            da.Fill(table);
            dataGridView1.DataSource = table;
            baglanti.Close();


        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "ID")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "ID";
                textBox5.ForeColor = Color.Black;
            }
        }
    }
}
