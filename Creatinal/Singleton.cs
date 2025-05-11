using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDesignPatterns.Creatinal
{
    internal class Singleton
    {

    }

    internal class PrinterSpooler
    {
        private static readonly Lazy<PrinterSpooler> instance = new(() => new PrinterSpooler());
        private readonly Queue<string> _jobs =new ();

        private PrinterSpooler() { }

        public static PrinterSpooler Instance => instance.Value;
        

        public void AddJob(string jobName)
        {
            _jobs.Enqueue(jobName);
        }

        public void PrintNextJob()
        {
            if (_jobs.Count>0){
                Console.WriteLine(_jobs.Dequeue());
            }
            else
            {
                Console.WriteLine("No jobs in queue.");
            }

        }
    }
}
