using System;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProg_Thread
{
    
    internal class Program
    {
        public int Count { get; set; }
        private Object obj1 = new Object(); 
        private Object obj2 = new Object();
        static async void Main(string[] args)
        {


            //Thread thrd1 = new Thread(Loop1);
            ////Thread thrd2 = new Thread(Loop2);
            //thrd1.Start();
            //thrd2.Start();
            //thrd1.Join();
            //thrd2.Join();

            //Console.WriteLine("Console ishledi");

            ////Loop1();
            ////Loop2();
            //Program p = new Program();
            //Thread th1 = new Thread(p.Increase);
            //Thread th2 = new Thread(p.Decrease);
            //th1.Start();
            //th2.Start();
            //th1.Join();
            //th2.Join();
            //p.Increase();
            //p.Decrease();
            //Console.WriteLine(p.Count);

           await Sum();
        } 

        static void Loop1()
        {
            for (int i = 0; i <= 100; i++)
            {
                Console.WriteLine("Loop1 "+i);
            }
        }
        static void Loop2()
        {
            for (int i = 101; i <= 200; i++)
            {
                Console.WriteLine("Loop2 "+i);
            }
        }

        void Increase()
        {
            for (int i = 0; i < 1000000; i++)
            {
                lock(obj1){
                    lock (obj2)
                    {
                        Count++;
                    }
                }
            }
        }
        void Decrease()
        {
            for (int i = 0; i < 1000000; i++)
            {
                lock (obj2)
                {
                    lock (obj1)
                    {
                        Count--;    
                    }
                }
            }
        }
       public static async Task<int> Sum()
        {
            int result = 0;
            var task = Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    result += 1;
                }
                
            }); 
            await task;
            return result;
        }
    }
}
