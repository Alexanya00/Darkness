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
using System.Xml;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public int i;
        public Form3()
        {
            InitializeComponent();
        }
        FileStream fs;
        XmlSerializer xs;


        private void TSMIExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TSMIState_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            /*int l = dataGridView3.CurrentCell.RowIndex; *///находим номер строки нашей ячейки
            for (int i = 0; i < dataGridView3.Rows.Count; i++)//отображаем имена мест
            {
                if (comboBox2.FindString(dataGridView3.Rows[i].Cells[1].Value.ToString()) == -1) comboBox2.Items.Add(dataGridView3.Rows[i].Cells[0].Value.ToString()); //проверка, чтоб без повтора

            }
            comboBox2.SelectedIndex = 0;
            label10.Text = dataGridView3.Rows[0].Cells[1].Value.ToString();
            if (textBox1.Text != "") label12.Text = (Int32.Parse(textBox1.Text) * Convert.ToInt16(dataGridView3.Rows[comboBox2.SelectedIndex].Cells[2].Value)).ToString();


            label2.BackColor = System.Drawing.Color.Transparent;
            label3.BackColor = System.Drawing.Color.Transparent;
            label1.BackColor = System.Drawing.Color.Transparent;
            label4.BackColor = System.Drawing.Color.Transparent;
            label5.BackColor = System.Drawing.Color.Transparent;
            label6.BackColor = System.Drawing.Color.Transparent;
            label7.BackColor = System.Drawing.Color.Transparent;
            label8.BackColor = System.Drawing.Color.Transparent;

            label9.BackColor = System.Drawing.Color.Transparent;
            label10.BackColor = System.Drawing.Color.Transparent;
            label11.BackColor = System.Drawing.Color.Transparent;


            label12.BackColor = System.Drawing.Color.Transparent;
            label13.BackColor = System.Drawing.Color.Transparent;
            label14.BackColor = System.Drawing.Color.Transparent;

            Font fn = new Font("Courier New", 13, FontStyle.Italic);
            textBox2.Font = fn;
            textBox2.Text = "введите ФИО";
            textBox2.ForeColor = Color.Gray;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(label10.Text) < 0) MessageBox.Show( "К сожалению, данного количества билетов нет в наличии","Не выполнено");
            else if (Int32.Parse(textBox1.Text) == 0) MessageBox.Show("Введите нужное количество билетов", "Не выполнено");
            else if (textBox2.Text == "" || textBox2.Text == "введите ФИО") MessageBox.Show("Введите ФИО");
            else if (maskedTextBox1.Text == "(   )    -") MessageBox.Show("Введите телефон");
            else
            {

                Form1.pl[Form1.n].sess[Form2.m].tic[comboBox2.SelectedIndex].quantity = Form1.pl[Form1.n].sess[Form2.m].tic[comboBox2.SelectedIndex].quantity - Int16.Parse(textBox1.Text);
                MessageBox.Show("Бронь оформлена");
                placesBindingSource.ResetCurrentItem();
                Form1.save = false;

                string a;
                a = Form1.name_file.Substring(0, Form1.name_file.Length - 4);
                a = a +"_список_клиентов.txt";
              
                System.IO.File.AppendAllText(a, "Театр: "+ Form1.pl[Form1.n].Theater + Environment.NewLine + "Спектакль: " + Form1.pl[Form1.n].Name + Environment.NewLine + "Сеанс: "+ label9.Text+" "+ label13.Text + Environment.NewLine + "ФИО клиента: "+textBox2.Text+ Environment.NewLine+"Телефон: " +maskedTextBox1.Text+ Environment.NewLine+ "Места: "+ comboBox2.Text+" - "+ textBox1.Text +"шт."+ Environment.NewLine+ "Итоговая сумма: "+ label12.Text+ Environment.NewLine +"__________________________________"+ Environment.NewLine);

                // СЕРИАЛИЗУЕМ (сохраним в файле).
                fs = new FileStream(Form1.name_file, FileMode.Create);
                XmlSerializer xs = new XmlSerializer(typeof(List<Play>));
                // Сохраним список в XML-файле
                xs.Serialize(fs, Form1.pl);
                fs.Close();

                Close();
                //при оформлении брони нужно в файл выписывать, из какой именно базы эти данные. Может даже название равное данной брони. Подумаю.
            } 
            
        }

       

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label10.Text = dataGridView3.Rows[comboBox2.SelectedIndex].Cells[1].Value.ToString();

            if (textBox1.Text != "") label12.Text = (Int32.Parse(textBox1.Text) * Convert.ToInt16(dataGridView3.Rows[comboBox2.SelectedIndex].Cells[2].Value)).ToString();
            label10.Text = (Convert.ToInt16(dataGridView3.Rows[comboBox2.SelectedIndex].Cells[1].Value) - Int32.Parse(textBox1.Text)).ToString();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            { 
                label12.Text = (Int32.Parse(textBox1.Text) * Convert.ToInt16(dataGridView3.Rows[comboBox2.SelectedIndex].Cells[2].Value)).ToString();

                label10.Text = (Convert.ToInt16(dataGridView3.Rows[comboBox2.SelectedIndex].Cells[1].Value)-Int32.Parse(textBox1.Text)).ToString();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //разрешить ввод только цифр
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) // цифры и клавиша BackSpace
            {
                e.Handled = true;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "введите ФИО")
            {

                textBox2.Clear();
                Font fn = new Font("Courier New", 14);
                textBox2.Font = fn;
                textBox2.ForeColor = Color.Black;
               
                
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                Font fn = new Font("Courier New", 13, FontStyle.Italic );
                textBox2.Font = fn;
                textBox2.Text = "введите ФИО";
                textBox2.ForeColor = Color.Gray;
            }
        }
    }
}
