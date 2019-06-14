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
    public partial class Form2 : Form
    {
       

        public Form2()
        {
            InitializeComponent();
        }

        public static int m;
        private void TSMIState_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void TSMIExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
            {
                return;
            }
            Form3 formP = new Form3();
            m = dataGridView2.CurrentCell.RowIndex; //находим номер строки нашей ячейки
            formP.placesBindingSource.DataSource = Form1.pl[Form1.n].sess[m].tic; //загружаем сеансы в третью форму
            formP.label9.Text = dataGridView2.Rows[m].Cells[0].Value.ToString();//дата проведения
            formP.label13.Text = dataGridView2.Rows[m].Cells[1].Value.ToString();//время
            formP.ShowDialog();
            sessionBindingSource.ResetCurrentItem();//обновление данных(если что-то купили вдруг)


        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
