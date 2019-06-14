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
    public partial class AddFormcs : Form
    {
        public AddFormcs()
        {
            InitializeComponent();
        }
        

        private void TSMIExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TSMIState_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; //сворачиваем окно
        }

        private void AddFormcs_Load(object sender, EventArgs e)
        {
                Form1.ses = new List<session>();
                sessionBindingSource.DataSource = Form1.ses;

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

                Form1.pl.Add(new Play(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text,
                   textBox6.Text, Convert.ToInt16(textBox7.Text), textBox8.Text, Form1.ses));

                Form1.save = false;
                Close();
            }



                
            
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            
                if (Form1.ses.Count == 1) placesBindingSource.DataSource = Form1.ses[0].tic; //привязываемся к автору


                Form1.ses[Form1.ses.Count - 1].tic = new List<places>();//создание списка для пустой строки
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                if (e.ColumnIndex == -1 || e.RowIndex == -1) return; // если щелкнули на заголовки, не реагируем

                placesBindingSource.DataSource = Form1.ses[e.RowIndex].tic; //привязываемся к автору

        }

        private void dataGridView2_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
           sessionBindingSource.ResetCurrentItem();
        }


        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            //разрешить ввод только цифр
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
