using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class Program
    {
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

            public static explicit operator String (wDate Datathis)
            {
                return " Число: " + Datathis.data.Day + " Месяц: " + Datathis.data.Month + " Год: " + Datathis.data.Year;
            }

            public static explicit operator wDate(String str)
            {
                
                wDate Data = new wDate(str);
                return Data;
            }

        }

        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите дату в формает дд.мм.гггг: ");
                wDate date = new wDate(Console.ReadLine());

                Console.WriteLine("Дата предыдущего дня: {0}", date.priviousDay());

                Console.WriteLine("Дата следующего дня: {0}", date.nextDay());
                Console.WriteLine("Количество дней до конца месяца: {0}", date.remainDays());
                Console.WriteLine("Текущая дата: " + date.Data.ToShortDateString());
                Console.Write("Вы хотите изменить дату? ");
                string answer = Console.ReadLine();
                if (answer == "Да" || answer == "да")
                {
                    Console.Write("Введите дату в формате дд.мм.гггг: ");
                    string[] n = Console.ReadLine().Split('.');
                    DateTime newdate = new DateTime(Convert.ToInt32(n[2]), Convert.ToInt32(n[1]), Convert.ToInt32(n[0]));
                    date.Data = newdate;
                }


                Console.WriteLine("Является ли год выскокосным? {0}", date.IsLeap);
                Console.Write("Введите индекс: ");
                int index = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Дата {0}-того по счету дня относительно установленной даты - {1}", index, date[index].ToShortDateString());
                Console.Write("Является ли указанная дата последним днем месяца? ");
                if (!date) Console.WriteLine("Нет");
                else Console.WriteLine("Да");
                Console.Write("Является ли указанная дата началом года? ");
                if (date) Console.WriteLine("Да");
                else Console.WriteLine("Нет");

                Console.Write("Введите 2-ую дату в формате дд.мм.гггг: ");
                wDate date2 = (wDate)Console.ReadLine();
                Console.Write("Две даты ");
                if (date & date2) Console.WriteLine("равны");
                else Console.WriteLine("не равны");
                Console.WriteLine("Преобразовать в строку: "+(string)date);
            }
            catch
            {
                Console.WriteLine("Некорректный ввод данных!!!");
            }
            Console.ReadKey();


        }
    }
}
