using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class Jester:IJokeService,IJokeOutput
    {
        private JokeOutputService outputService;
        private JokeService jokeService;
        public JokeOutputService OutputService { get => outputService; set => outputService = value; }
        public JokeService JokeService { get => jokeService; set => jokeService = value; }

        public Jester(JokeOutputService outputService, JokeService jokeService)
        {
            if (outputService != null && jokeService != null)
            {
                this.OutputService = outputService;
                this.JokeService = jokeService;
            }
            else
            {
                throw new ArgumentNullException(nameof(outputService));
            }
        }

        public void TellJoke()
        {
            string joke = JokeService.GetJoke();
            while(joke.Contains("Chuck") || joke.Contains("Norris"))
                joke = JokeService.GetJoke();
            OutputService.PrintJoke(joke);
        }

        public string GetJoke()
        {
            return JokeService.GetJoke();
        }

        public void PrintJoke(string joke)
        {
            OutputService.PrintJoke(joke);
        }
    }
}
