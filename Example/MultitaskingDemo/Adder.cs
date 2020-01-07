namespace MultitaskingDemo
{
    using System;
    using System.Collections.Generic;
    using EvaluationTest;
    
    public class Adder
    {
        public int processCount = 1;
        public static Queue<JobAssign> Processing = new Queue<JobAssign>();

        public void AdderMethod()
        {
            var jobsAssign = new JobAssign
            {
                process = "P" + processCount,
                job = RandomNumber(1, 4)
            };
            Processing.Enqueue(jobsAssign);
            Console.WriteLine("\nProcess" + jobsAssign.process + "is Entered in a queue with Job" + jobsAssign.job + "\n");
            processCount++;
        }

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}