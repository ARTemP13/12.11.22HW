using System;

namespace _12._11._22HW
{
    public class BankTransaction
    {
        public readonly DateTime date;
        public readonly double money;
        public BankTransaction(double money)
        {
            this.money = money;
            this.date = DateTime.UtcNow;
        }

    }
}
