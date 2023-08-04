using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    internal class InputValidation
    {
        public static bool CheckArgsLength(string[] args)
        {
            return args.Length >= 3 && args.Length % 2 == 1;
        }

        public static bool CheckArgsDuplicates(string[] args)
        {
            return args.Distinct().Count() == args.Length;
        }

        public static void ExitIfArgsNotOK(string[] args) {
            if (!CheckArgsLength(args) || !CheckArgsDuplicates(args))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                ReportInvalidArgs(args);
                Console.WriteLine("Please try again.");
                Console.ResetColor();
                Environment.Exit(0);
            }
        }

        public static void ReportInvalidArgs(string[] args)
        {
            if (!CheckArgsLength(args))
            {
                Console.WriteLine("The number of moves must be an odd number and no less than 3.");
            }
            if (!CheckArgsDuplicates(args))
            {
                Console.WriteLine("All the moves must be distinct.");
            }
        }

        public static string GetUserMove()
        {
            Console.Write("Enter your move: ");
            return Console.ReadLine();
        }

        public static int GetUserMoveNum(string userMove)
        {
            int.TryParse(userMove, out int userMoveNum);
            return userMoveNum;
        }

        public static bool CheckUserMove(string userMove, Rules rules)
        {
            int userMoveNum = GetUserMoveNum(userMove);
            bool userMoveNumOK = userMoveNum >= 1 && userMoveNum <= rules.GetMoves().Count;
            return userMove == "0" || userMove == "?" || userMoveNumOK;
        }

        public static string GetCorrectMoveInput(Rules rules)
        {
            string userMove = GetUserMove();
            while (!CheckUserMove(userMove,rules))
            {
                ReportInvalidUserMove(rules.GetMoves().Count);
                userMove = GetUserMove();
            }
            return userMove;
        }

        public static void ReportInvalidUserMove(int maxInputValue)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Wrong Input. Enter a number from 1 to {maxInputValue} to make a move " +
                    $"or \"?\" for help or \"0\" to exit");
            Console.ResetColor();
        }
    }
}
