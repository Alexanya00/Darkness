using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
        }

        Play pl2 = new Play();
    

        private void TSMIState_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; //сворачиваем окно
        }

        private void TSMIExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void EditForm_Load(object sender, EventArgs e)
        {

            label1.Text = "РЕДАКТИРОВАНИЕ СПЕКТАКЛЯ";
            button2.Text = "изменить";
            textBox1.Text = Form1.pl[Form1.n].Name;
            textBox2.Text = Form1.pl[Form1.n].Theater;
            textBox3.Text = Form1.pl[Form1.n].Genre;
            textBox4.Text = Form1.pl[Form1.n].Actors;
            textBox5.Text = Form1.pl[Form1.n].Produser;
            textBox6.Text = Form1.pl[Form1.n].Desc;
            textBox7.Text = Form1.pl[Form1.n].Time.ToString();
            textBox8.Text = Form1.pl[Form1.n].picture;

            pl2 = Form1.pl[Form1.n];
            bindingSource1.DataSource = pl2.sess;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;

            bindingSource2.DataSource = pl2.sess[0].tic;
            dataGridView2.AutoGenerateColumns = true;

            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") MessageBox.Show("Введите название спектакля");
            else if (textBox2.Text == "") MessageBox.Show("Введите название театра");
            else if (textBox3.Text == "") MessageBox.Show("Введите жанр");
            else if (textBox4.Text == "") MessageBox.Show("Введите актеров");
            else if (textBox5.Text == "") MessageBox.Show("Введите режиссера");
            else if (textBox7.Text == "") MessageBox.Show("Введите количество часов");

            else
            {
                pl2.Name = textBox1.Text;
                pl2.Theater = textBox2.Text;
                pl2.Genre = textBox3.Text;
                pl2.Actors = textBox4.Text;
                pl2.Produser = textBox5.Text;
                pl2.Desc = textBox6.Text;
                pl2.Time = Convert.ToInt16(textBox7.Text);
                pl2.picture = textBox8.Text;
                Form1.pl[Form1.n] = pl2;
                Form1.save = false;

                Close();
            }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            pl2.sess[pl2.sess.Count - 1].tic = new List<places>();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return; // если щелкнули на заголовки, не реагируем
            bindingSource2.DataSource = pl2.sess[e.RowIndex].tic;
        }

        private void dataGridView2_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
             bindingSource1.ResetCurrentItem();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
