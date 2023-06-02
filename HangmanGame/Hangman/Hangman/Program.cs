using System;
using System.Collections.Generic;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordList = { "dog", "screwdriver", "justice", "bus", "cafe", "necklace", "endurance" };

            Random random = new Random();
            int index = random.Next(0, wordList.Length);
            string word = wordList[index];

            char[] letters = new char[word.Length];
            List<char> wrongLetters = new List<char>();
            List<char> correctLetters = new List<char>();

            for (int i = 0; i < word.Length; i++)
            {
                letters[i] = '_';
            }

            int attemptsLeft = 10;

            while (attemptsLeft > 0)
            {
                Console.Clear();
                Console.WriteLine(string.Join(" ", letters));
                Console.WriteLine("Attempts left: {0}", attemptsLeft);
                Console.Write("Wrong letters: ");
                Console.WriteLine(string.Join(" ", wrongLetters));
                Console.Write("Correct letters: ");
                Console.WriteLine(string.Join(" ", correctLetters));

                if (attemptsLeft == 0)
                {
                    Console.WriteLine("You lose");
                    Console.WriteLine("The correct word was {0}", word);
                    break;
                }

                Console.Write("Enter a letter: ");
                char letter;
                try
                {
                    letter = char.ToLower(Console.ReadLine()[0]);
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("No letter entered. Please try again.");
                    continue;
                }

                if (!char.IsLetter(letter))
                {
                    Console.WriteLine("Invalid character entered. Please try again.");
                    continue;
                }

                if (wrongLetters.Contains(letter) || correctLetters.Contains(letter))
                {
                    Console.WriteLine("You've already guessed that letter. Please try again.");
                    continue;
                }

                bool letterInWord = false;
                bool win = true;

                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == letter)
                    {
                        letters[i] = letter;
                        letterInWord = true;
                        correctLetters.Add(letter);
                    }

                    if (letters[i] == '_')
                    {
                        win = false;
                    }
                }

                if (win)
                {
                    Console.Clear();
                    Console.WriteLine(string.Join(" ", letters));
                    Console.WriteLine("Attempts left: {0}", attemptsLeft);
                    Console.Write("Wrong letters: ");
                    Console.WriteLine(string.Join(" ", wrongLetters));
                    Console.Write("Correct letters: ");
                    Console.WriteLine(string.Join(" ", correctLetters));
                    Console.WriteLine("You win!");
                    break;
                }

                if (!letterInWord)
                {
                    wrongLetters.Add(letter);
                    attemptsLeft--;
                }
            }

            if (attemptsLeft == 0 && !string.IsNullOrEmpty(word))
            {
                Console.WriteLine("You lose");
                Console.WriteLine("The correct word was {0}", word);
            }

            Console.ReadLine();
        }
    }
}
