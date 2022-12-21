using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class wDate
        {
            private DateTime data;

            public wDate(string dt)
            {
                string[] n = dt.Split('.');
                data = new DateTime(Convert.ToInt32(n[2]), Convert.ToInt32(n[1]), Convert.ToInt32(n[0]));
            }
            public wDate()
            {
                data = new DateTime(2009, 01, 01);
            }
            public string priviousDay()
            {
                return data.AddDays(-1).ToShortDateString();
            }
            public string nextDay()
            {
                return data.AddDays(1).ToShortDateString();
            }
            public int remainDays()
            {

                int month = data.Month + 1;
                int year = data.Year;
                if (month == 13)
                {
                    month = 1;
                    year = data.Year + 1;
                }

                DateTime border = new DateTime(year, month, 01);
                border = border.AddDays(-1);
                return border.Day - data.Day;
            }


            public DateTime Data
            {
                set { data = value; }
                get { return data; }
            }


            public string IsLeap
            {
                get
                {
                    Boolean dt = DateTime.IsLeapYear(data.Year);
                    string res = "Нет";
                    if (dt) res = "Да";
                    return res;
                }
            }

            public DateTime this[int index]
            {
                get
                {
                    return data.AddDays(index);
                }
            }

            public static bool operator !(wDate Datathis)
            {
                return Datathis.data.Day != DateTime.DaysInMonth(Datathis.data.Year, Datathis.data.Month);
            }

            public static bool operator true(wDate Datathis)
            {
                return Datathis.data.Day == 1 && Datathis.data.Month == 1;
            }

            public static bool operator false(wDate Datathis)
            {
                return Datathis.data.Day != 1 || Datathis.data.Month != 1;
            }

            public static bool operator &(wDate Data1, wDate Data2)
            {
                return Data1.data.Equals(Data2.data);
            }

            public static explicit operator String(wDate Datathis)
            {
                return " Число: " + Datathis.data.Day + " Месяц: " + Datathis.data.Month + " Год: " + Datathis.data.Year;
            }

            public static explicit operator wDate(String str)
            {
                string[] a = str.Split('.');
                if (a[2].Length == 1)
                {
                    a[2] = "200" + a[2];
                }
                if (a[2].Length == 2) {
                    if (Convert.ToInt32(a[2]) > 50) a[2] = "19" + a[2];
                    else a[2] = "20" + a[2];
                }
                string b = a[0] + "."+a[1]+"."  + a[2];
                wDate res = new wDate(b);
                return res;
            }

        }

        wDate date;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                date = new wDate(textBox1.Text);
                MessageBox.Show("Данные сохранены");
            }
            catch { MessageBox.Show("Некорректный ввод данных!!!"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                wDate date2 = (wDate)textBox2.Text;
                textBox3.Text = "";
                textBox3.Text += "Две даты ";
                if (date & date2) textBox3.Text += "равны";
                else textBox3.Text += "не равны";
            }
            catch { MessageBox.Show("Некорректный ввод данных!!!"); }
            }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(textBox4.Text);
                textBox5.Text = "";
                textBox5.Text += "Дата" + index + "-того по счету дня относительно установленной даты - " + date[index].ToShortDateString();
            }
            catch { MessageBox.Show("Некорректный ввод данных!!!"); }
            
            }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                textBox6.Text = "";
                textBox6.Text += "Дата предыдущего дня: " + date.priviousDay() + Environment.NewLine;

                textBox6.Text += "Дата следующего дня: " + date.nextDay() + Environment.NewLine;
                textBox6.Text += "Количество дней до конца месяца: " + date.remainDays() + Environment.NewLine;
                textBox6.Text += "Текущая дата: " + date.Data.ToShortDateString() + Environment.NewLine;
                textBox6.Text += "Является ли год выскокосным? " + date.IsLeap + Environment.NewLine;
                textBox6.Text += "Является ли указанная дата последним днем месяца? ";
                if (!date) textBox6.Text += "Нет" + Environment.NewLine;
                else textBox6.Text += "Да" + Environment.NewLine;
                textBox6.Text += "Является ли указанная дата началом года? ";
                if (date) textBox6.Text += "Да" + Environment.NewLine;
                else textBox6.Text += "Нет" + Environment.NewLine;
            }
            catch { MessageBox.Show("Вы не сохранили дату"); }
        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
            string a = textBox7.Text;
            wDate b = new wDate(a);
            textBox8.Text += "Преобразование в строку: ";
            textBox8.Text += (string)b+Environment.NewLine;
          


        }

        private void button6_Click(object sender, EventArgs e)
        {
            wDate c = (wDate)textBox9.Text;
            textBox10.Text = "";
            textBox10.Text += "Преобразование в wDate: ";
            textBox10.Text += c.Data.ToShortDateString();
        }
    }
}
