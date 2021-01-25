using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class Jester
    {
        private IJokeOutput outputService;
        private IJokeService jokeService;
        public IJokeOutput JokeOutputService { get => outputService; set => outputService = value; }
        public IJokeService JokeService { get => jokeService; set => jokeService = value; }

        public Jester(IJokeOutput outputService, IJokeService jokeService)
        {
            if (outputService != null && jokeService != null)
            {
                this.JokeOutputService = outputService;
                this.JokeService = jokeService;
            }
            else
            {
                throw new ArgumentNullException(nameof(outputService));
            }
        }

        public void TellJoke()
        {
            string joke = this.JokeService.GetJoke();
            while(joke.Contains("Chuck") || joke.Contains("Norris"))
                joke = this.JokeService.GetJoke();
            this.JokeOutputService.PrintJoke(joke);
        }
    }
}
