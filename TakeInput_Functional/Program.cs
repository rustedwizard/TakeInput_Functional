using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace TakeInput_Functional
{
    class Program
    {
        //This simple program shows how to take various input (read from console, for example) in a functional
        //way. As showing in this example, there no variable used.

        //Let user decide what function should be used to take input
        static IEnumerable<string> Take(Func<string> function)
        {
            //Keep taking user input.
            //let user decide when to stop
            while (true)
            {
                //apply user specified function and yield return
                yield return function();
            }
            // ReSharper disable once IteratorNeverReturns
        }

        static IEnumerable<string> TakeInput([NotNull]Func<string> inputSource, [NotNull]Func<string, bool> stop)
        {
            return Take(inputSource).TakeWhile(stop);
        }

        static void Main()
        {
            //in this case use Console.ReadLine function
            //TakeWhile enable the specification of function which determines when to stop taking input
            //in this case when input is an empty line, program should stop taking input
            //in this case all taken input will be convert to list.
            var list = TakeInput(Console.ReadLine, x=>!x.Trim().Equals("")).ToList();
            foreach(var e in list)
            {
                Console.WriteLine($"You entered: {e}");
            }
        }
    }
}
