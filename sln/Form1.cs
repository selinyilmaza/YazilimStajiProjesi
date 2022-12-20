using System.Text;
using System.Data.SqlClient;
namespace sln
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-DKI7TIC; Initial Catalog=SLN; Integrated Security=TRUE");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool move;
        int mouse_x;
        int mouse_y;
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text=="Username") 
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "") 
            {
                textBox1.Text = "Username";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.White;
                textBox2.PasswordChar = '*';
            }
        }

        char? none = null;
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Password";
                textBox2.ForeColor = Color.Silver;
                textBox2.PasswordChar = Convert.ToChar(none);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
        bool isThere;
        private void button2_Click(object sender, EventArgs e)
        {
            string anametin = textBox2.Text;
            byte[] veridizim = ASCIIEncoding.ASCII.GetBytes(anametin);
            string sifrelimetin = Convert.ToBase64String(veridizim);
            textBox2.Text = sifrelimetin;
            string username = textBox1.Text;
            string password = textBox2.Text;
            



            connection.Open();
            SqlCommand command = new SqlCommand("Select* From sistemgiris", connection);
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                if (username == reader["Username"].ToString().TrimEnd() && password == reader["Password"].ToString().TrimEnd())
                {
                    isThere = true;
                    break;
                }

                else
                {
                    isThere = false;
                }
            }
            connection.Close();
            if(isThere)
            {
                MessageBox.Show("Başarılı giriş yapıldı!", "Program");
                Form2 fr = new Form2();
                fr.ShowDialog();
            }
            else
            {
                MessageBox.Show("Giriş yapamadınız!", "Program");
            }
        }
    }
}