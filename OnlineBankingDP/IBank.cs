using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankingDP
{
    interface IBank
    {
        void Register(IOnlineCard card);
        bool CanWithdraw(IOnlineCard card, long amount);
        bool CanPay(IOnlineCard card, long amount);
        bool CanTransfer(IOnlineCard card, long amount, IOnlineCard forcard);

        void Withdraw(IOnlineCard card, long amount);
        void Pay(IOnlineCard card, long amount);
        void Transfer(IOnlineCard card, long amount, IOnlineCard forcard);
        void Add(IOnlineCard card, long amount);

    }
}
