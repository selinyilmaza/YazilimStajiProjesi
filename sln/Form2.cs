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
    public partial class Form2 : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-DKI7TIC; Initial Catalog=SLN; Integrated Security=TRUE");
        public Form2()
        {
            InitializeComponent();
        }
        bool move;
        int mouse_x;
        int mouse_y;
        
        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {

            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }
        private void FormGetir(Form frm)
        {
            panel2.Controls.Clear();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            panel2.Controls.Add(frm);
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            müsteriesg ekle = new müsteriesg();
            FormGetir(ekle);

           
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            tablo1 tablo1 = new tablo1();
            FormGetir(tablo1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            tablo2 tablo2 = new tablo2();
            FormGetir(tablo2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            tablo3 tablo3 = new tablo3();
            FormGetir(tablo3);
        }
    }
}
