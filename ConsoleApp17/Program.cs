using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    class RangeOfArray
    {
        private int lowerBound;
        private int upperBound;
        private int[] data;

        public RangeOfArray(int lower, int upper)
        {
            if (upper < lower)
                throw new ArgumentException("Upper bound cannot be less than lower bound.");

            lowerBound = lower;
            upperBound = upper;
            data = new int[upper - lower + 1];
        }

        public int this[int index]
        {
            get
            {
                if (index < lowerBound || index > upperBound)
                    throw new IndexOutOfRangeException("Index is out of range.");
                return data[index - lowerBound];
            }
            set
            {
                if (index < lowerBound || index > upperBound)
                    throw new IndexOutOfRangeException("Index is out of range.");
                data[index - lowerBound] = value;
            }
        }
    }

    internal class Program
    {
        static void task3()
        {
            try
            {
                double[] salesData = { 100, 120, 130, 145, 160 }; 
                double[] months = { 1, 2, 3, 4, 5 }; 

                if (salesData.Length != months.Length)
                {
                    Console.WriteLine("Ошибка: Данные продаж и месяцы должны иметь одинаковую длину.");
                    return;
                }

                int n = salesData.Length;

                
                double sumX = months.Sum();
                double sumY = salesData.Sum();
                double sumX2 = months.Select(x => x * x).Sum();
                double sumXY = months.Zip(salesData, (x, y) => x * y).Sum();

                // Расчет коэффициентов линейной функции
                double a = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);
                double b = (sumY - a * sumX) / n;

                
                double[] futureMonths = { 6, 7, 8 };
                double[] predictedSales = futureMonths.Select(x => a * x + b).ToArray();

                
                Console.WriteLine("Прогноз продаж на следующие три месяца:");
                for (int i = 0; i < futureMonths.Length; i++)
                {
                    Console.WriteLine($"Месяц {futureMonths[i]}: {predictedSales[i]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
        static void task2()
        {
            try
            {
                
                DateTime currentTime = DateTime.Now;

                DateTime discountStartTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 8, 0, 0);
                DateTime discountEndTime = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day, 12, 0, 0);

               
                if (currentTime >= discountStartTime && currentTime <= discountEndTime)
                {
                    Console.WriteLine("Продукты со скидкой 5%.");
                }
                else
                {
                    Console.WriteLine("Продукты без скидки.");
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
        static void Main(string[] args)
        {
            task3();
            Console.ReadKey();
        }
    }
}
