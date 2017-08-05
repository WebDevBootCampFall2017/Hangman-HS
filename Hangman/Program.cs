using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Guess a Word!";

            string[] wordBank = { "monitor", "motherboard", "public", "git", "asus" };
            Random rnd_word = new Random();
            string wordToGuess = wordBank[(int)(rnd_word.NextDouble() * wordBank.Length)];
            string wordUpperCase = wordToGuess.ToUpper();

            StringBuilder textDisplay = new StringBuilder(wordToGuess.Length);

            for (int i = 0; i < wordToGuess.Length; i++) 
                textDisplay.Append("_");

            List<char> corrects = new List<char>();
            List<char> incorrects = new List<char>();

            int chances = 7;
            bool win = false;
            int charDisplayed = 0;

            string inputLetter;
            char guess;

            while (!win && chances > 0)
            {
                
                Console.Write("Guess a letter: ");

                inputLetter = Console.ReadLine().ToUpper();
                guess = inputLetter[0];

                if (corrects.Contains(guess) || incorrects.Contains(guess))
                {
                    Console.WriteLine("You have tried \"{0}\".", wordToGuess);
                }
                
                if (wordUpperCase.Contains(guess))
                {
                    corrects.Add(guess);
                    for (int i = 0; i <wordToGuess.Length; i++)
                    {
                        if (wordUpperCase[i]==guess)
                        {
                            textDisplay[i] = wordToGuess[i];
                            charDisplayed++;
                        }
                    }

                    if (charDisplayed == wordToGuess.Length)
                        win = true;
                }

                else
                {
                    incorrects.Add(guess);
                    Console.WriteLine("There's no \"{0}\"", guess);
                    chances--;
                }
                Console.WriteLine(textDisplay.ToString());
            }

            Console.Clear();
            if (win)
                Console.WriteLine("Good Job! You've Got It!");
            else
                Console.WriteLine("Aww.. better luck next time.", wordToGuess);

            
            Console.WriteLine("the word is \n  => {0}.\n Please wait for 2 seconds.", wordToGuess);
            System.Threading.Thread.Sleep(3000);
            Environment.Exit(0);
            
        }
    }
}
