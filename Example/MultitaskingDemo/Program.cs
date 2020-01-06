namespace EvaluationTest
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    //object of this class will assign to Queue 
    public class JobsAssign
    {
        public string process { get; set; }
        // Random Number between 1-3 assign to process
        public int job { get; set; }
    }

    //Main Class
    public class Program
    {
        public static Queue<JobsAssign> Processing = new Queue<JobsAssign>();

        static int i = 1;
        //Number of free spaces available in queue.
        static int Empty = 10;
        //Variable which takes care of one action woring in queue at a time.
        static int mutex = 1;
        //Number of Process available in queue.
        static int Full = 0;
        public static ConsoleKeyInfo key = Console.ReadKey();

        public static void Main(string[] args)
        {

            Task Producer = new Task(Job1);
            Task consumer = new Task(Job2);

            Producer.Start();
            consumer.Start();
            Producer.Wait();
        }

        //Producer Job
        public static void Job1()
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
                    if (Empty > 0)
                    {
                        Empty--;
                        //Using the resources
                        mutex--;

                        var jobsAssign = new JobsAssign
                        {
                            process = "P" + i,
                            job = RandomNumber(1, 4)
                        };

                        Processing.Enqueue(jobsAssign);
                        Console.WriteLine("\nProcess" + jobsAssign.process + "is Entered in a queue with Job" + jobsAssign.job);
                        //Release the resources
                        mutex++;
                        Full++;
                        i++;
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
        public static void Job2()
        {

            while (key.Key != ConsoleKey.Escape)
            {
                if (Full > 0 && mutex == 1)
                {
                    Full --;
                    //Using the resources
                    mutex--; 
                    Console.WriteLine(" processor Process" + Processing.Peek().process + " in running with job " + Processing.Peek().job);

                    if (Processing.Peek().job == 1)
                    {
                        Thread.Sleep(1000);
                    }
                    else if (Processing.Peek().job == 2)
                    {
                        Thread.Sleep(3000);

                    }
                    else if (Processing.Peek().job == 3)
                    {
                        Thread.Sleep(5000);
                    }

                    Console.WriteLine(" processor Process" + Processing.Peek().process + " in Completed with job " + Processing.Peek().job);
                    string peek = Processing.Peek().process;
                    Processing.Dequeue();
                    Console.WriteLine("Process\t " + peek + "\tis remove from queue.\n");
                    //Release the ressources
                    mutex ++;
                    Empty ++;
                }
            }
        }

        //Random Number generator
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}




