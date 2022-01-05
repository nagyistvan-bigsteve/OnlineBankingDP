using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankingDP
{
    class Card : IOnlineCard
    {
        public string Name { get; set; }
        private IBank bank { get; set; }
        public long Amount { get; set; }

        public Card(string name, long amount, IBank bank)
        {
            Name = name;
            this.bank = bank;
            Amount = amount;
        }

        public IOnlineCard UpdateAmount(long amount)
        {
            Amount += amount;
            return this;
        }
        public bool Add(long amount)
        {
            bank.Add(this, amount);
            return true;
        }

        public bool Pay(long amount)
        {
            if(bank.CanPay(this, amount))
            {
                bank.Pay(this, amount);
                return true;
            }
            return false;
        }

        public bool Transfer(long amount, IOnlineCard card)
        {
            if (bank.CanTransfer(this, amount, card))
            {
                bank.Transfer(this, amount, card);
                return true;
            }
            return false;
        }

        public bool Withdraw(long amount)
        {
            if (bank.CanWithdraw(this, amount))
            {
                bank.Withdraw(this, amount);
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return $"{Name} --> {Amount}";
        }
    }
}
