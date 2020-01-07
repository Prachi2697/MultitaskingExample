namespace EvaluationTest
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MultitaskingDemo;

    public class Program
    {
        public static JobAssign JobAssign = new JobAssign();
        public static Adder Add = new Adder();
        public static Remover Remove = new Remover();

        private static int empty = 10;
        private static int mutex = 1;
        private static int full = 0;

        public static ConsoleKeyInfo key = Console.ReadKey();

        public static void Main(string[] args)
        {

            Task producer = new Task(Producer);
            Task consumer = new Task(Consumer);

            producer.Start();
            consumer.Start();
            consumer.Wait();
        }

        //Producer Job
        public static void Producer()
        {
            key = Console.ReadKey();
            while (key.Key == ConsoleKey.OemPlus || key.Key == ConsoleKey.Escape)
            {
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else
                {
                    if (empty > 0)
                    {
                        empty--;
                        mutex--;
                        Add.AdderMethod();
                        mutex++;
                        full++;
                    }
                    else
                    {
                        Console.WriteLine("Processor is busy!");
                    }
                }
                key = Console.ReadKey();
            }
        }

        //Consumer Job 
        public static void Consumer()
        {
            while (key.Key != ConsoleKey.Escape)
            {
                if (full > 0 && mutex == 1)
                {
                    full --;
                    mutex--;
                    Remove.RemoverMethod();
                    mutex ++;
                    empty ++;
                }
            }
        }
    }
}




