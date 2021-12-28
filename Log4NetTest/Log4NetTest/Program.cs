using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Log4NetTest
{
    public abstract class Animal
    {
        public abstract string MakeSound();
    }

    public class Dog : Animal
    {
        public override sealed string MakeSound()
        {
            return this.Bark();
        }

        private string Bark()
        {
            return "bark";
        }
    }

    class Program
    {
        //Declare an instance for log4net
        private static readonly ILog Log =
              LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            Animal dog = new Dog ();
            Console.WriteLine(dog.MakeSound());

            //ImplementLoggingFuntion();
        }

        private static void ImplementLoggingFuntion()
        {
            /* We have 5 levels of log message. Let's test all.
             *  FATAL
                ERROR
                WARN
                INFO
                DEBUG
             */
            try
            {

            }
            finally
            {

            }
            var secs = 3;
            Log.Fatal("Start log FATAL...");
            Console.WriteLine("Start log FATAL...");
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs

            Log.Error("Start log ERROR...");
            Console.WriteLine("Start log ERROR...");
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs

            Log.Warn("Start log WARN...");
            Console.WriteLine("Start log WARN...");
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs

            Log.Info("Start log INFO...");
            Console.WriteLine("Start log INFO...");
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs

            Log.Debug("Start log DEBUG...");
            Console.WriteLine("Start log DEBUG...");
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs

            Console.WriteLine("Press any key to close the application");
            Console.ReadKey();
        }
    }
}
