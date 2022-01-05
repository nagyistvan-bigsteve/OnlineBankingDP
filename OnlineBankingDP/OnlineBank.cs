using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankingDP
{
    class OnlineBank : IBank
    {
        private List<IOnlineCard> cards = new List<IOnlineCard>();

        public bool CanPay(IOnlineCard card, long amount)
        {
            if (card.Amount >= amount)
                return true;
            Console.WriteLine($"You don't have enought money for paying {card.Amount} < {amount}");
            return false;
        }

        public bool CanTransfer(IOnlineCard card, long amount, IOnlineCard forcard)
        {
            if (card.Amount >= amount)
                return true;
            Console.WriteLine($"You don't have enought money for transfer {card.Amount} < {amount}");
            return false;
        }

        public bool CanWithdraw(IOnlineCard card, long amount)
        {
            if (card.Amount >= amount)
                return true;
            Console.WriteLine($"You don't have enought money for Withdraw {card.Amount} < {amount}");
            return false;
        }

        public void Pay(IOnlineCard card, long amount)
        {
            card.UpdateAmount(-amount);
            Console.WriteLine($"{card.Name} - Paying... -{amount} from {card.Amount+amount}");
        }

        public void Add(IOnlineCard card, long amount)
        {
            card.UpdateAmount(amount);
            Console.WriteLine($"{card.Name} - Adding... +{amount} on {card.Amount - amount}");
        }

        public void Register(IOnlineCard card)
        {
            if (!cards.Contains(card))
                cards.Add(card);
            card.ToString();
        }

        public void Transfer(IOnlineCard card, long amount, IOnlineCard forcard)
        {
            card.UpdateAmount(-amount);

            forcard.UpdateAmount(amount);

            Console.WriteLine($"{card.Name} - Transfer... -{amount} from {card.Amount+amount} ---- +{amount} for {forcard.Name}");
        }

        public void Withdraw(IOnlineCard card, long amount)
        {
            card.UpdateAmount(-amount);
            Console.WriteLine($"{card.Name} - Withdraw... -{amount} from {card.Amount+amount}");
        }
    }
}
