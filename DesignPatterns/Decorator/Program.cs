using Decorator.Component;
using Decorator.ConcreteComponent;
using Decorator.ConcreteDecorator;
using Decorator.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            ICar car = new Suzuki();
            CarDecorator decorator = new OfferPrice(car);
            Console.WriteLine(string.Format("Make :{0}  Price:{1} DiscountPrice : {2}"
                , decorator.Make
                , decorator.GetPrice().ToString()
                , decorator.GetDiscountedPrice().ToString()));
            Console.ReadLine();


            var tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            Task.Run()

            var task = Task.Factory.StartNew(() =>
                {
                    token.ThrowIfCancellationRequested();

                    bool moreToDo = true;
                    while (moreToDo)
                    {
                        if (token.IsCancellationRequested)
                        {
                            token.ThrowIfCancellationRequested();
                        }
                    }
                }, tokenSource.Token
            );

            tokenSource.Cancel();

            try
            {
                task.Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var v in ex.InnerExceptions)
                {
                    Console.WriteLine(ex.Message + " " + v.Message);
                }
            }
            finally
            {
                task.Dispose();
            }

            Console.ReadKey();
        }
    }
}
