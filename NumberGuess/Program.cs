using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Number Guess App");
            string player1 = GetPlayerName(1);
            string player2 = GetPlayerName(2);
            bool player1goesfirst = true;
            while (true)
            {
                //Console.WriteLine(player1);
                //Console.WriteLine(player2);
                //Console.ReadKey();

                if(player1goesfirst)
                {
                    PlayGame(player1, player2);
                } else
                {
                    PlayGame(player2, player1);
                }
                //Console.WriteLine("Your number is: {0}",num1);
                //Console.ReadKey();
                Console.WriteLine("Type Y to play again, anything else to exit: ");
                string replay = Console.ReadLine();

                if(replay.ToLower() == "y")
                {
                    if(player1goesfirst == true)
                    {
                        player1goesfirst = false;
                    } else
                    {
                        player1goesfirst = true;
                    }
                    continue;
                } else
                {
                    Console.WriteLine("Thank you for playing! Goodbye {0} and {1}.", player1, player2);
                    Console.ReadKey();
                    break;
                }

                //Console.ReadKey();
            }
        }

        /// <summary>
        /// This function gets the name of each player. 
        /// </summary>
        /// <param name="playerNumber"></param>
        /// <returns>string containing player name</returns>
        private static string GetPlayerName(int playerNumber)
        {
            string playerName = "";

            while(String.IsNullOrEmpty(playerName)) {
                Console.Write("Player {0}: What's your name? ", playerNumber);
                playerName = Console.ReadLine();
            }
          
            return playerName;
        }

        /// <summary>
        /// This function will get the number that is to be guessed or the number that is the guess. 
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="message"></param>
        /// <returns>A number that is converted from a string</returns>
        private static int GetNumber(string playerName, string message)
        {
            const int minimumValue = 1;
            const int maximumValue = 100;

            Console.Write("{0}: {1}", playerName, message);
            string input = Console.ReadLine();

            bool flag = true;
            int number;

            while(flag)
            {
                if (int.TryParse(input, out number))
                {
                    if(number < minimumValue || number > maximumValue)
                    {
                        Console.Write("Sorry this number is invalid, make sure it is between 1 and 100: ");
                        input = Console.ReadLine();
                    } else
                    {
                        flag = false;
                        return number;
                    }   
                }
                else
                {
                    Console.Write("We ran into a problem getting your number, try again: ");
                    input = Console.ReadLine();
                }
            }
            return 0;
            
        }

        /// <summary>
        /// This is the function that actually plays the game. Player 1 will enter their number 
        /// and player 2 will guess their number. Player 2 has 10 attempts to guess player 1's number
        /// and will be given hints and how many guesses they have remaining. This code will exit if
        /// player 2 runs out of attempts or if they correctly guess player 1's number.
        /// </summary>
        /// <param name="player1Name"></param>
        /// <param name="player2Name"></param>
        private static void PlayGame(string player1Name, string player2Name)
        {
            int numbertoGuess = GetNumber(player1Name, "What's your number? ");
            //Console.WriteLine(numbertoGuess);
            //Console.ReadKey();
            Console.Clear();
            //Console.ReadKey();

            const int maxGuesses = 10;
            int incorrectGuesses = 0;

            while (incorrectGuesses < maxGuesses) 
            {
                int guess = GetNumber(player2Name, "What's your guess? ");

                if (guess == numbertoGuess)
                {
                    Console.WriteLine("-> Congrats {0}, you have guessed correct!", player2Name);
                    break;
                } 
                else
                {
                    incorrectGuesses++;
                    Console.WriteLine("-> Incorrect guess, you have {0} guesses remaining.", 10 - incorrectGuesses);
                    if (guess < numbertoGuess)
                    {
                        Console.WriteLine("-> HINT: Your guess was too low!!");
                    } else
                    {
                        Console.WriteLine("-> HINT: Your guess was too high!!");
                    }
                    if (incorrectGuesses == maxGuesses)
                    {
                        Console.WriteLine("-> Sorry, you have used all your guesses. Better luck next time!");
                        break;
                    }
                }
            }
        }
    }
}

