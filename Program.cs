using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace MyDelegate
{
    public delegate void MyDelegat(int[] obj);
    public delegate void MyDelegatTime();
    class Program
    {
        /*Задание 1
Создайте набор методов для работы с массивами:
■ Метод для получения всех четных чисел в массиве;
■ Метод для получения всех нечетных чисел в массиве;
■ Метод для получения всех простых чисел в массиве;
■ Метод для получения всех чисел Фибоначчи в массиве.
Используйте механизмы делегатов.*/
        public static void EvenNumbers(  int []obj )
    {
        Console.WriteLine("Все четные чила масива:");
            int a;
            foreach (var i in obj)
            {
                a = i % 2;
                if(a==0)
                {
                    Console.WriteLine(" - " +i);
                }
            }

    }
        public static void OddNumbers(int[] obj)
        {
            Console.WriteLine("Все нечетные чила масива:");
            int a;
            foreach (var i in obj)
            {
                a = i % 2;
                if (a != 0)
                {
                    Console.WriteLine(" - " + i);
                }
            }

        }
        public static void Numbers(int[] obj)
        {
            Console.WriteLine("Все натуральные чила масива:");
            int a;
            foreach (var i in obj)
            {
                for (var j = 2; j < i; j++)
                {
                    a = i % j;
                    if (a == 0)
                    {

                        break;
                    }
                    if (j == (i - 1))
                    {
                        Console.WriteLine(" - " + i);
                    }
                }


            }
        }
            public static void Fib_Numbers(int[] obj)
            {
                Console.WriteLine("Все чила фибоначи полученые с масива:");
            
            int a;
                foreach (var i in obj)
                {
                Console.WriteLine();
                Console.Write("От числа " +i+":: - 0 - 1");
                for (var j = 1; j < i; j++)
                    {
                        a = j + (j-1);
                       
                        
                            Console.Write(" - " + a);
                        
                    }


                }

            }
        /*Создайте набор методов:
■ Метод для отображения текущего времени;
■ Метод для отображения текущей даты;
■ Метод для отображения текущего дня недели;
■ Метод для подсчёта площади треугольника;
■ Метод для подсчёта площади прямоугольника.
Для реализации проекта используйте делегаты Action,
Predicate, Func*/
        public static void Time()
        {
            DateTime a=DateTime.Now;
            Console.WriteLine("текущее время: " + a.ToShortTimeString());
        }
        public static void Date()
        {
            DateTime a = DateTime.Now;
            Console.WriteLine("текущая дата: " + a.ToShortDateString()) ;
        }
        public static void Day()
        {
            DateTime a = DateTime.Now;
            Console.WriteLine("текущая дата: " + a.DayOfWeek);
        }

        public static int AreaOfRectangle(AB a)
        {
            return a.a * a.b;
        }
        public static void AreaOfTriangle(AB a)
        {
            Console.WriteLine("Площадь треугольника: "+(a.a * a.b) /2);
        }
  
        public struct AB
        {
            public int a;
            public int b;
             public AB(int ap, int bp)
            {
                a = ap;
                b = bp;
            }
        }
/*
        Создайте класс «Кредитная карточка». Класс должен
содержать:
■ Номер карты;
        ДОМАШНЕЕ ЗАДАНИЕ
1
■ ФИО владельца;
■ Срок действия карты;
■ PIN;
■ Кредитный лимит;
■ Сумма денег.
Создайте необходимый набор методов класса. Реализуйте события для следующих ситуаций:
■ Пополнение счёта;
■ Расход денег со счёта;
■ Старт использования кредитных денег;
■ Достижение заданной суммы денег;
■ Смена PIN.*/

        public class CartcrediеСard
        {
            public long Number { get; set; }
            public DateTime Validity { get; set; }
            public int PIN { get; set; }
            public int Limit { get; set; }
            public int AmountMoney { get; set; }
            public CartcrediеСard()
            {
                Number = 555555555;
                Validity.AddMonths(5);
                Validity.AddYears(2024);
                PIN = 1111;
                Limit = 10000;
                AmountMoney = 11000;
            }

            public void AddAmountMoney(int money)
            {
                AmountMoney += money;
                Console.WriteLine("На вашем счету после пополнения: " + AmountMoney);
            }
            public void SpendAmountMoney(int money)
            {
                AmountMoney -= money;
                Console.WriteLine("На вашем счету после списания: " + AmountMoney);
            }
            public void StarSpendCredietMoney(int money)
            {
               int a = AmountMoney - money;
                if (a < 0)
                {
                    Console.WriteLine("ВЫ используэте кредитные средства ");
                }
            }
            public  void LimitMoney(int money)
            {
                
                Limit -= money;
                if (Limit <0)
                {
                    Console.WriteLine(" Достижение заданной суммы денег для снятия в день! ");
                }
            }
            public void EditPin(int p)
            {
                PIN = p;
                Console.WriteLine(" Пин код изменен!!!");
            }
            
        }
      
        public delegate void MoneyDelegat(int money_p);
        public static event MoneyDelegat MoveAddMoney;
        public static event MoneyDelegat MoveSpendMoney;
        public static event MoneyDelegat EditPin;
        static void Main(string[] args)
        {
            int[] d = { 5, 6, 3, 6, 7, 2, 11, 22, 12, 13, 14, 54 };// new int[12];

            // EvenNumbers(d);
            MyDelegat MyDel = new MyDelegat(EvenNumbers);
            MyDel += OddNumbers;
            // MyDel(d);
            MyDel += Numbers;
            //MyDel(d);
            MyDel += Fib_Numbers;
            MyDel(d);
            Console.WriteLine();
            Console.ReadLine();
            Console.Clear();

            MyDelegatTime time = new MyDelegatTime(Time);
            time += Date;
            time += Day;
            time();
            AB ab = new AB(5, 6);
            List<AB> obj = new List<AB> { new AB(16, 6), new AB(3, 5), new AB(5, 6), new AB(15, 6) };
            obj.ForEach(AreaOfTriangle);
            IEnumerable<int> newobj = obj.Select(AreaOfRectangle);
            foreach (var i in newobj)
            {
                Console.WriteLine("площадь прямоугольника: " + i);
            }


            /*
        Создайте класс «Кредитная карточка». Класс должен
содержать:
■ Номер карты;
        ДОМАШНЕЕ ЗАДАНИЕ
1
■ ФИО владельца;
■ Срок действия карты;
■ PIN;
■ Кредитный лимит;
■ Сумма денег.
Создайте необходимый набор методов класса. Реализуйте события для следующих ситуаций:
■ Пополнение счёта;
■ Расход денег со счёта;
■ Старт использования кредитных денег;
■ Достижение заданной суммы денег;
■ Смена PIN.*/
            CartcrediеСard Test = new CartcrediеСard();
                MoveAddMoney += Test.AddAmountMoney;
            MoveSpendMoney += Test.SpendAmountMoney;
            MoveSpendMoney += Test.StarSpendCredietMoney;
            MoveSpendMoney += Test.LimitMoney;
            EditPin += Test.EditPin;
            Console.ReadLine();
            Console.Clear();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Для пополнения счета нажмите 1, ");
                Console.WriteLine(" - для списания 2,");
                Console.WriteLine(" - для списания 3. ");
                int a;
                int c;
                a = System.Int32.Parse(Console.ReadLine());
               
                switch (a)
                {
                    case 1:
                        {
                            a = System.Int32.Parse(Console.ReadLine());
                            Console.WriteLine("укажите суму: ");
                            c = System.Int32.Parse(Console.ReadLine());
                            MoveAddMoney(c);
                            break;
                        }
                    case 2:
                        {
                            a = System.Int32.Parse(Console.ReadLine());
                            Console.WriteLine("укажите суму: ");
                            c = System.Int32.Parse(Console.ReadLine());
                            MoveSpendMoney(c);
                            break;
                        }
                    case 3:
                        {
                            int test;
                            Console.WriteLine("Введите новий Пин-код ");
                              test = System.Int32.Parse(Console.ReadLine());
                            EditPin(test);
                            Console.ReadLine();
                            break;
                        }
                }
            }
            
        }
    }
}
