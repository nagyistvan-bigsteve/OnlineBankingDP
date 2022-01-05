using System;
using System.Collections.Generic;

namespace OnlineBankingDP
{
    class Program
    {
        static void Main(string[] args)
        {
            //I use command and mediator design patterns.

            var bank = new OnlineBank();

            var card1 = new Card("Peti",1500,bank);
            var card2 = new Card("Sanyi", 905, bank);

            Console.WriteLine(card1);
            Console.WriteLine(card2);


            //Its executed automatically, because it is just an individual command

            var flow1 = new TransactionFlow(new CompleteCommand(card2,5,Operation.Withdraw));

            Console.WriteLine(card1);
            Console.WriteLine(card2);

            List<CompleteCommand> batch = new List<CompleteCommand>();

            var command1 = new CompleteCommand(card1, 250, Operation.Withdraw);
            var command2 = new CompleteCommand(card1, 1200, card2);

            batch.Add(command1);
            batch.Add(command2);

            var flow2 = new TransactionFlow(batch);
            
            var command3 = new CompleteCommand(card1, 5, Operation.Add);
            var command4 = new CompleteCommand(card1, 55, Operation.Pay);
            var command5 = new CompleteCommand(card1, 1, Operation.Pay);


            flow2.AddTransaction(command3);
            flow2.AddTransaction(command4);
            flow2.AddTransaction(command5);

            flow2.ExecuteBatch();

            Console.WriteLine(card1);
            Console.WriteLine(card2);

        }
    }
}
