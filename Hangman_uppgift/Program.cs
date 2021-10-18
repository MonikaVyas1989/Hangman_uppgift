using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Hangman_uppgift
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("********Welcome to Hangman********");
            //This is random variable...
            Random random = new Random();
            string[] str = { "pokeman", "superman", "hangman"};
            int index = random.Next(str.Length);
            string word = str[index];

            List<string> guess = new List<string>();
            List<string> matchguess = new List<string>();
            int usertry = 10;

            Console.WriteLine("Enter a letter or word to guess a word...");
            
            for (int i = 1; i <= usertry; i++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                string userInput = Console.ReadLine();

                


                if (userInput.Length==1)
                {
                    if (guess.Contains(userInput))
                    {

                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("Letter is already entered write another letter....\n");
                        i--;
                        continue;
                    }
                    guess.Add(userInput);

                    if (matchword1(word, guess))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(word);
                        Console.WriteLine("WellDone Your guess is rigth string");
                        Console.ResetColor();
                        break;
                    }
                    else if (word.Contains(userInput))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("The letter you entered is correct nice:");

                        char[] trueletter = guessletter(word, guess);
                        foreach (char ch in trueletter)
                        {
                            Console.Write(ch+" ");
                           
                        }

                        Console.WriteLine("\n"); 
                        Console.ResetColor();

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Oops, letter is not in my word");
                        StringBuilder wrongletter = new StringBuilder();
                        Console.ResetColor();
                        wrongletter = notletter(word, guess);
                        Console.Write(wrongletter  + "\n");
                    }
                   
                }
               if(userInput.Length  > 1)
                {

                   matchguess.Add(userInput);
                  
                    
                    if(matchword (word,matchguess))
                    {
                       
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(word);
                        Console.WriteLine("WellDone Your guess is right string");
                        Console.ResetColor();
                        break;
                    }
                    else
                    {
                         Console.ForegroundColor = ConsoleColor.Red;
                         Console.WriteLine("Sorry it is not right.Enter your guess as a word again");
                         Console.ResetColor();
                    }
                     
                    
                }

                if (i == 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Oops the game of guessing is over... Well Tried!");
                    Console.ResetColor();
                    break;
                }
               
               
                               
            }
        }
        static char[] guessletter(string word, List<string> guess)
        {
            char[] matchletter =new char[word.Length];

            

            for(int i=0;i<word.Length;i++)
            {
                 string letter = Convert.ToString (word[i]);
               
                if (guess.Contains(letter))
                {

                    matchletter[i]= char.Parse (letter);

                }
               
                else
                {
                    matchletter[i] = '_';
                }

            }
            
            return matchletter;

        }
        static StringBuilder notletter(string word,List <string>guess)
        {
            StringBuilder  nomatchletter = new StringBuilder ();
            foreach(var i in guess)
            {
                string letter = Convert.ToString(i);
                if(word.Contains (letter))
                {
                    nomatchletter.Append(" ,");
                } 
                else
                {
                    nomatchletter.Append(letter);
                }
            }
            return nomatchletter;
        }
        static bool matchword(string word, List<string> matchguess)
        {
            bool wordmatch = false;

            
               if (word==matchguess[matchguess.Count -1])
                {
                    wordmatch = true;
                }
                else
                {
                    return wordmatch = false;
                }

            
            return wordmatch;
        }
        static bool matchword1(string word, List<string> guess)
        {
            bool wordmatch = false;

            for (int i = 0; i < word.Length; i++)
            {
                string letter = Convert.ToString(word[i]);

                if (guess.Contains(letter))
                {
                    wordmatch = true;
                }
                else
                {
                    return wordmatch = false;
                }

            }
            return wordmatch;
        }

        
    }
}
