using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Spaceman
{
    public class Game
    {
        // properties
        public string codeWord { get; set; }
        public string currentWord { get; set; }
        public int maxGuesses { get; set; }
        public int currentGuesses { get; set; }

        string[] codewordArray = new string[] { "galaxy", "nebula", "starship", "motherload", "andromeda" };
        List<string> previousGuesses = new List<string>();

        // Instance of UFO Class
        UFO u = new UFO();

        // Methods
        public void Greet()
        {
            Console.WriteLine("        Welcome to Spaceman!");
            Console.WriteLine("        ====================");
            Console.WriteLine("        ====================");
        }

        public bool DidWin()
        {
            return codeWord.Equals(currentWord);
        }

        public bool DidLose()
        {
            if (currentGuesses >= maxGuesses)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }

        public void Display ()
        {
            // Prints UFO and currentword
            Console.WriteLine(u.Stringify());
            Console.WriteLine("");
            Console.WriteLine($"Your current word is: {currentWord}.");

            // Prints remaining guesses
            int remainingGuesses = maxGuesses - currentGuesses;
            Console.WriteLine("");
            Console.WriteLine($"Your current number of gueses remaining is {remainingGuesses}.");
        }

        public void Ask()
        {
            // Asks user for a letter and captures input
            Console.WriteLine("Please select a letter.");
            Console.WriteLine("");
            string userInput = Console.ReadLine();



            // Checks to see if input is 1 character, if not then breaks out of the method
            if (userInput.Length > 1)
            {
                Console.WriteLine("Please enter in only one letter at a time.");
                Console.WriteLine("Try again.");
                return;
            }

            // Checks to see if input is a number
            int y;
            bool userNum = int.TryParse(userInput, out y);

            if (userNum == true)
            {
                Console.WriteLine("Please enter in a valid letter.");
                return;
            }

            // Checks to see if userInput is already on the list
            bool alreadyExists = previousGuesses.Contains(userInput);
            if (alreadyExists == true)
            {
                Console.WriteLine($"You've already guessed {userInput}, try again.");
                return;
            }
            else
            {
                previousGuesses.Add(userInput);
            }

            // Check if codeward contains the guess
            bool doesContain = codeWord.Contains(userInput);
            char[] charArray = codeWord.ToCharArray(); 
            char inputChar = userInput.ToCharArray()[0];

            if (doesContain == true)
            {
                Console.WriteLine("");
                Console.WriteLine("Yes that is a correct guess!");
                for (int index = 0; index < charArray.Length; index++)
                {
                    if (charArray[index] == inputChar)
                    {
                        currentWord = currentWord.Remove(index, 1).Insert(index, userInput);
                    }
                }
            } else
            {
                Console.WriteLine("");
                Console.WriteLine("Incorrect guess, please try again.");
                currentGuesses += 1;
                u.AddPart();
            }


        }

        // Constructor
        public Game()
        {
            // Generates random number from array length
            Random rand = new Random();
            int index = rand.Next(codewordArray.Length);

            // Selects codeWord based on number generation
            codeWord = codewordArray[index];

            maxGuesses = 5;
            currentGuesses = 0;

            // Sets current word to a string of underscores to the same length as the codeWord
            for (int i = 0; i < codeWord.Length; i++)
            {
                currentWord += "_";
            }
        }
    }
}
