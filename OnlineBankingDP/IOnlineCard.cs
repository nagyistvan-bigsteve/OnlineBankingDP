using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankingDP
{
    interface IOnlineCard
    {
        bool Withdraw(long amount);
        bool Pay(long amount);
        bool Transfer(long amount, IOnlineCard card);
        bool Add(long amount);
        IOnlineCard UpdateAmount(long amount);
        string Name { get; }
        long Amount { get; set; }
    }
}
