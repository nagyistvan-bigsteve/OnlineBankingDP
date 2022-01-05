using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankingDP
{
    class CompleteCommand : Command
    {
        public IOnlineCard card { get; set; }
        public long amount { get; set; }

        public Operation op { get; set; }
        public IOnlineCard forcard { get; set; } = null;
        public bool isExecuted { get; set; }

        public CompleteCommand(IOnlineCard card, long amount, Operation op)
        {
            this.card = card;
            this.amount = amount;
            this.op = op;
            isExecuted = false;
        }
        public CompleteCommand(IOnlineCard card, long amount, IOnlineCard forcard)
        {
            this.card = card;
            this.amount = amount;
            op = Operation.Transfer;
            this.forcard = forcard;
            isExecuted = false;
        }
        public CompleteCommand toCard(IOnlineCard card)
        {
            forcard = card;
            return this;
        }
        public override void Execute()
        {
            switch (op)
            {
                case Operation.Add:
                    isExecuted = card.Add(amount);
                    break;
                case Operation.Pay:
                    isExecuted = card.Pay(amount);
                    break;
                case Operation.Transfer:
                    isExecuted = card.Transfer(amount,forcard);
                    break;
                case Operation.Withdraw:
                    isExecuted = card.Withdraw(amount);
                    break;
            }
        }

        public override void UnExecute()
        {   
        if(isExecuted)
            switch (op)
            {
                case Operation.Transfer:
                    card.Add(amount);
                    forcard.Pay(amount);
                    break;
                case Operation.Add:
                    card.Pay(amount);
                    break;
                default:
                    card.Add(amount);
                    break;
            }
        }
    }
}
