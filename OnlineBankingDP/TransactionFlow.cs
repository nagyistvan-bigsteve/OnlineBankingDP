using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankingDP
{
    class TransactionFlow
    {
        private CompleteCommand comm {get;set;}
        private List<CompleteCommand> batch { get; set; } = null;
        public TransactionFlow()
        {
            batch = new List<CompleteCommand>();
        }
        public TransactionFlow(CompleteCommand comm)
        {
            this.comm = comm;
            Console.WriteLine("----Executing----");
            this.comm.Execute();
            Console.WriteLine("--------------");

        }
        
        public TransactionFlow(List<CompleteCommand> batch)
        {
            this.batch = batch;
        }
        public void AddTransaction(CompleteCommand comm)
        {
            batch.Add(comm);
        }
        public void ExecuteBatch()
        {
            if (batch != null)
            {
                Console.WriteLine("-----Executing tha batch-----");
                bool failed = false;

                foreach (CompleteCommand comm in batch)
                {
                    comm.Execute();
                    if (!comm.isExecuted)
                    {
                        Console.WriteLine("!!!!Error -- Undo proces!!!!");
                        failed = true;
                        break;
                    }
                }
                if (failed)
                    foreach (CompleteCommand comm in batch)
                    {
                        if (comm.isExecuted)
                            comm.UnExecute();
                    }
                if (!failed)
                    Console.WriteLine("-------Success-------");
                else
                    Console.WriteLine("-------Failed-------");
            }
        }
    }
}
