using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    internal class Game
    {
        private Rules rules;

        private int computerMove;

        public Game(Rules rules)
        {
            this.rules = rules;
            Random random = new Random();
            int maxValue = rules.GetMoves().Count;
            computerMove = random.Next(0, maxValue);
        }

        public void ShowRules()
        {
            var moves = rules.GetMoves();
            Console.WriteLine("Available moves:");
            for (int i = 0; i < moves.Count; i++)
                Console.WriteLine($"{i + 1} - {moves[i]}");
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
        }

        public string GetComputerMove()
        {
            return rules.GetMoves()[computerMove];
        }

        public void PrintGameResult(string userMove, string computerMove)
        {
            string result = GetGameResult(userMove, computerMove, rules);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(result);
            Console.ResetColor();
        }

        public string GetGameResult(string userMove, string computerMove, Rules rules)
        {
            var winner = rules.GetWinningMove(userMove, computerMove);
            if (winner == userMove)
                return "You won!";
            else if (winner == computerMove)
                return "Computer won";
            else
                return "It's a draw";
        }

        public void Play()
        {
            bool gameOver = false;
            while (!gameOver)
            {
                PlayARound(ref gameOver);
            }
        }

        public void PlayARound(ref bool gameOver)
        {
            var userInput = InputValidation.GetCorrectMoveInput(rules);
            if (userInput == "?")
            {
                var rulesTable = new RulesTable(rules);
                rulesTable.Draw();
            }
            else if (userInput == "0")
                Environment.Exit(0);
            else
            {
                MakeAMove(userInput);
                gameOver = true;
            }
        }

        public void MakeAMove(string userInput)
        {
            var userMove = rules.GetMoves()[int.Parse(userInput) - 1];
            var computerMove = GetComputerMove();
            Console.WriteLine("Computer move: " + computerMove);
            PrintGameResult(userMove, computerMove);
        }
    }
}
