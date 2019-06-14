using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace WindowsFormsApplication1
{
    public partial class Dialog : Form
    {
        public Dialog()
        {
            InitializeComponent();
        }

        public string file_name;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                file_name = textBox1.Text;
                Close();
            }
            else MessageBox.Show("Введите название файла' ", "Ошибка");

        }

        private void Dialog_Load(object sender, EventArgs e)
        {
        }
    }
}
