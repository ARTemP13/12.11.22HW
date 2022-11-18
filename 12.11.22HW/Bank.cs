using _12._11._22HW;
using System;
using System.Collections.Generic;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace Tumakov26._11
{
    public class Bank
    {
        public int Id { get; set; }
        public double Balance { get; set; }
        public string Type { get; set; }
        private Queue<double> TrancM = new Queue<double>();
        private Queue<DateTime> TrancD = new Queue<DateTime>();

        public Bank(double balance)
        {
            Balance = balance;
            Id = ID();
        }
        public Bank(string type)
        {
            Type = type;
            Id = ID();
        }
        public Bank(double balance, string type)
        {
            Balance = balance;
            Type = type;
            Id = ID();
        }
        List<int> list = new List<int>();
        int j = 0;
        private int ID()
        {
            Random random = new Random();
            int h = random.Next(10000000, 99999999);
            j++;
            for(int i = 0; i < list.Count; i++)
            {
                if(h == list[i])
                {
                    i = -1;
                    h = random.Next(10000000, 99999999);
                    continue;
                }
            }
            list.Add(h);
            return h;
        }

        public int Transfer(ref Bank bank, double a)
        {
            double b = bank.Balance;
            if (bank.Balance >= a)
            {
                bank.Balance = bank.Balance - a;
                Console.WriteLine($"Счет до операции: {b}$\nТекущий счет: {bank.Balance}$");
                BankTransaction transaction = new BankTransaction(a);
                TrancM.Enqueue(transaction.money);
                TrancD.Enqueue(transaction.date);
            }
            else
            {
                Console.WriteLine("На вашем счету недостаточно средств!!!");
            }
            return 0;
        }
        public void ReplenishmentBalance(ref Bank bank, int summa)
        {
            bank.Balance += summa;
            Console.WriteLine($"Баланс успешно пополнен!\nТекущий баланс: {bank.Balance}$");
            BankTransaction transaction = new BankTransaction(summa);
            TrancM.Enqueue(transaction.money);
            TrancD.Enqueue(transaction.date);
        }
        public void Dispose()
        {
            
            while (TrancM.Count > 0)
            {
                string path = "C:/Users/apers/source/repos/12.11.22HW/12.11.22HW/Операции.txt";
                string[] str = new string[2];
                str[0] = TrancD.Dequeue().ToString();
                str[1] = TrancM.Dequeue().ToString();
                string str2 = string.Join(null, str);
                File.WriteAllText(path, str2);
            }
            GC.SuppressFinalize(this);
        }


    }
}
