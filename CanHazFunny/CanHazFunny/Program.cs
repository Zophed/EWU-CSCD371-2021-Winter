namespace CanHazFunny
{
    class Program
    {
        static void Main(string[] args)
        {
            //Feel free to use your own setup here - this is just provided as an example
            Jester joke = new Jester(new JokeOutputService(), new JokeService());
            joke.TellJoke();
        }
    }
}
