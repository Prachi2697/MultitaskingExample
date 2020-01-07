namespace MultitaskingDemo
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using EvaluationTest;
    public class Remover
    {
        public async void RemoverMethod()
        {
            if (Adder.Processing.Peek().job == 1)
            {
                Console.WriteLine(" processor Process" + Adder.Processing.Peek().process + " in running with job " + Adder.Processing.Peek().job);

                await Task.Run(() => Thread.Sleep(4000));
            }
            else if (Adder.Processing.Peek().job == 2)
            {
                Console.WriteLine(" processor Process" + Adder.Processing.Peek().process + " in running with job " + Adder.Processing.Peek().job);

                await Task.Run(() => Thread.Sleep(2000));
            }
            else if (Adder.Processing.Peek().job == 3)
            {
                Console.WriteLine(" processor Process" + Adder.Processing.Peek().process + " in running with job " + Adder.Processing.Peek().job);

                await Task.Run(() => Thread.Sleep(3000));
            }
            
            Console.WriteLine(" processor Process" + Adder.Processing.Peek().process + " in Completed with job " + Adder.Processing.Peek().job);
            Console.WriteLine("Process\t " + Adder.Processing.Peek().process + "\tis remove from queue.\n");
            Adder.Processing.Dequeue();
        }
    }
}
