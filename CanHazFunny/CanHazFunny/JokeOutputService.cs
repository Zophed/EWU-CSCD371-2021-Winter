using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class JokeOutputService : IJokeOutput
    {
        public void PrintJoke(string joke)
        {
            Console.WriteLine(joke);
        }
    }
}
