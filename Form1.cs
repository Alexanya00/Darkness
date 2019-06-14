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


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static List<Play> pl = new List<Play>();
        public static List<session> ses;
        public static List<places> plac;
        public static int n; //текущая позиция 
        public static string name_file;
        public static bool save = true; //проверка на сохранение
        public bool datab = true; //отслеживание сброса даты
        public string datas = "0"; //сама дата
        public string datas2 = "0"; //сама дата
        FileStream fs;
        XmlSerializer xs;
        private void Form1_Load(object sender, EventArgs e)
        {
            helpProvider1.HelpNamespace = "F1.chm";
            helpProvider1.SetHelpNavigator(this, HelpNavigator.Topic);
            helpProvider1.SetShowHelp(this, true);

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            playBindingSource.DataSource = pl;

            //---------------------------------------------------------------------ПРИВОДИМ В КРАСИВЫЙ ВИД--------------------------------------

            dataGridView1.Columns[2].Visible = false; //скрываем лишние ячейки
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            //рейтинг и цена еще дожны быть тута

            textBox1.Text = "спектакль,актер,режиссер";
            textBox1.ForeColor = Color.Gray;

            
                fs = new FileStream("хорошая база.xml", FileMode.Open);
                xs = new XmlSerializer(typeof(List<Play>));
                pl = (List<Play>)xs.Deserialize(fs);
                name_file = "хорошая база.xml";
                fs.Close();

                beauty();
            


            

        }

      

        private void TSMIExit_Click(object sender, EventArgs e)
        {

            
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) //переход на окно с сеансами
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)//проверка на нажатие на названия колонок
            {
                return;
            } 
            Form2 formS = new Form2();
            n = dataGridView1.CurrentCell.RowIndex; //находим номер строки нашей ячейки
            formS.sessionBindingSource.DataSource = pl[n].sess; //выводим пренадлежащее ей из класса session
            formS.label1.Text = dataGridView1.Rows[n].Cells[0].Value.ToString(); //выводим название спектакля
            if (dataGridView1.Rows[n].Cells[7].Value.ToString()!="") formS.pictureBox1.Image = Image.FromFile(dataGridView1.Rows[n].Cells[7].Value.ToString());//выводим картинку
            formS.textBox1.Text = dataGridView1.Rows[n].Cells[5].Value.ToString(); // вывод описания
            formS.textBox2.Text = dataGridView1.Rows[n].Cells[3].Value.ToString(); // вывод ролей
            formS.label7.Text = dataGridView1.Rows[n].Cells[2].Value.ToString(); // вывод жанра
            formS.label8.Text = dataGridView1.Rows[n].Cells[1].Value.ToString(); // вывод театра
            formS.label9.Text = dataGridView1.Rows[n].Cells[4].Value.ToString(); // вывод режиссёра
            formS.label10.Text = dataGridView1.Rows[n].Cells[6].Value.ToString(); // вывод время
            formS.ShowDialog();
            playBindingSource.ResetCurrentItem();//обновление данных(если что-то купили вдруг)


            if (pl[n].sess.Count != 0) 
            {
                int t = pl[n].sess[0].tic.Count();
            
            }
               
            
            
        }

        private void TSMIState_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; //сворачиваем окно
        }


        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();

            OPF.Filter = "Файлы xml|*.xml";
            OPF.InitialDirectory = Environment.CurrentDirectory;
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                fs = new FileStream(OPF.FileName, FileMode.Open);
                xs = new XmlSerializer(typeof(List<Play>));
                pl = (List<Play>)xs.Deserialize(fs);
                name_file = OPF.FileName;
                fs.Close();

                beauty();
            }

           
     
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Dialog d = new Dialog();
                d.ShowDialog();

                if (d.file_name != null) 
                { 
                    fs = new FileStream(d.file_name + ".xml", FileMode.Create); 
                    XmlSerializer xs = new XmlSerializer(typeof(List<Play>));
                    xs.Serialize(fs, pl);
                    fs.Close();
                    name_file = d.file_name + ".xml";

                    pl = new List<Play>();

                    MessageBox.Show("Файл создан");

                    beauty();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            save = true;


            // СЕРИАЛИЗУЕМ (сохраним в файле).
            fs = new FileStream(name_file, FileMode.Create);
            XmlSerializer xs = new XmlSerializer(typeof(List<Play>));
            // Сохраним список в XML-файле
            xs.Serialize(fs, pl);
            fs.Close();
            MessageBox.Show("Файл сохранен");
            



        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AddFormcs new_pl = new AddFormcs();
            new_pl.ShowDialog();
            playBindingSource.ResetBindings(false);
            combobox();
            
        }

        public void combobox()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Выберете театр");
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.Clear();
            comboBox2.Items.Add("Выберете жанр");
            comboBox2.SelectedIndex = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)//отображаем жанры и театры
            {
                if (comboBox1.FindString(dataGridView1.Rows[i].Cells[1].Value.ToString()) == -1) comboBox1.Items.Add(dataGridView1.Rows[i].Cells[1].Value.ToString()); //проверка, чтоб без повтора

                if (comboBox2.FindString(dataGridView1.Rows[i].Cells[2].Value.ToString()) == -1) comboBox2.Items.Add(dataGridView1.Rows[i].Cells[2].Value.ToString()); //проверка, чтоб без повтора

            }
        }

       
        private void button4_Click(object sender, EventArgs e)
        {
            if (pl.Count != 0) //проверка, есть ли данные, которые нужно объявлять
            {

                EditForm new_pl = new EditForm();
                new_pl.ShowDialog();
                playBindingSource.ResetBindings(false);
                combobox();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)//проверка на нажатие на названия колонок
            {
                return;
            }
            n = dataGridView1.CurrentCell.RowIndex; //находим номер строки нашей ячейки
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index); //удаление
                save = false;
                button8.Enabled = true;
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления.", "Ошибка");
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (save) button8.Enabled = false;
            else button8.Enabled = true;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            choice_min_ob();


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            choice_min_ob();


        }



        public void choice_min_ob()
        {
            if (dataGridView1.Rows.Count != 0) //проверка, есть ли данные
            {

                for (int i = 0; i < pl.Count; i++)
                {
                    for (int j = 0; j < pl[i].sess.Count; j++)
                    {
                        datas2 = pl[i].sess[j].date;
                        if (choice_min(dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), datas, datas2, dataGridView1.Rows[i].Cells[0].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString(), dataGridView1.Rows[i].Cells[4].Value.ToString()))

                        {
                            dataGridView1.Rows[i].Visible = true;
                            break;
                        }

                        else
                        {
                            dataGridView1.CurrentCell = null;
                            dataGridView1.Rows[i].Visible = false;
                        }
                    }
                }

            }
        }

        public bool choice_min(string s, string s2,string d, string d2, string name, string act, string res) //отбор по выпадающим спискам
        {
            

            if (comboBox1.Text != "Выберете театр" && s != comboBox1.Text) return false;

            if (comboBox2.Text != "Выберете жанр" && s2 != comboBox2.Text) return false;

            if (d != "0" && d2 != d)
            {
                return false;
            }

            if (textBox1.Text != "спектакль,актер,режиссер" && (name != textBox1.Text && res != textBox1.Text)) 
            {

                if (act.IndexOf(textBox1.Text) < 0)
                { 
                    
                    return false; }
              
            } 

                return true;

        }
        
        public void beauty()
        {
            playBindingSource.DataSource = pl;
            
            combobox();

            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

                datas = Convert.ToDateTime(e.Start.ToLongDateString()).ToString("d");

            choice_min_ob();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            monthCalendar1.SelectionStart = DateTime.Now;
            monthCalendar1.SelectionEnd = DateTime.Now;
            datas = "0";
            choice_min_ob();

                

        }


        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "спектакль,актер,режиссер") 
            {

                textBox1.Clear();
                textBox1.ForeColor = Color.Black;
            }


            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) 
            {
                textBox1.Text = "спектакль,актер,режиссер";
                textBox1.ForeColor = Color.Gray;
            }
            choice_min_ob();

            
        }


        private void Form1_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            if (dataGridView1.Rows.Count == 0) return;
            

            switch (dataGridView1.Columns[e.ColumnIndex].Name)
            {
                case "nameDataGridViewTextBoxColumn":
                    pl.Sort((a11, a22) => a11.Name.CompareTo(a22.Name));
                    choice_min_ob();
                    break;

                case "theaterDataGridViewTextBoxColumn":
                    pl.Sort((a11, a22) => a11.Theater.CompareTo(a22.Theater));
                    choice_min_ob();
                    break;

                case "priDataGridViewTextBoxColumn":
                    pl.Sort((a11, a22) => a11.Pri.CompareTo(a22.Pri));
                    choice_min_ob();
                    break;

                default: // По другим столбцам сортировки не будет.
                    return;
            }
            playBindingSource.ResetBindings(false);
            choice_min_ob();
        }

        private void TSMIHelp_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider1.HelpNamespace, "Spravka.htm");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}



