using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1_Timer;

namespace TimerTestConsoleApplication
{
    class Program
    {
        public class TimerSubscriber1
        {
            public void Subscribe(Timer timer)
            {
                timer.TimerTick += Print;
            }

            public void Describe(Timer timer)
            {
                timer.TimerTick -= Print;
            }

            public void Print(object sender, TimerEventArgs e)
            {
                Console.WriteLine($"Subscriber1 {e.Message} in {e.TimeOut}");
            }
        }

        public class TimerSubscriber2
        {
            public void Subscribe(Timer timer)
            {
                timer.TimerTick += Print;
            }

            public void Describe(Timer timer)
            {
                timer.TimerTick -= Print;
            }

            public void Print(object sender, TimerEventArgs e)
            {
                Console.WriteLine($"Subscriber2 {e.Message} in {e.TimeOut}");
            }
        }

        static void Main(string[] args)
        {
            Timer timer = new Timer();
            TimerSubscriber1 ts1 = new TimerSubscriber1();
            TimerSubscriber2 ts2 = new TimerSubscriber2();
            for (int i = 0; i < 10; i++)
            {
                ts1.Subscribe(timer);
                ts2.Subscribe(timer);
                timer.SetTimer(1000);
                ts2.Describe(timer);
                timer.SetTimer(2000);
                ts2.Subscribe(timer);
                timer.SetTimer(3000);
            }
        }
    }
}
