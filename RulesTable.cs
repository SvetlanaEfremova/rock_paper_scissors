using BetterConsoleTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    internal class RulesTable
    {
        private Table rulesTable;

        public RulesTable(Rules rules)
        {
            var headers = GetTableHeaders(rules);
            rulesTable = new Table(headers);
            FillRulesTable(rules);
        }

        public ColumnHeader[] GetTableHeaders(Rules rules)
        {
            var moves = rules.GetMoves();
            var headers = new ColumnHeader[moves.Count + 1];
            headers[0] = new ColumnHeader("↓ PC move \\ User move →", Alignment.Center, Alignment.Center);
            for (int i = 0; i < moves.Count; i++)
            {
                headers[i + 1] = new ColumnHeader(moves[i], Alignment.Center, Alignment.Center);
            }
            return headers;
        }

        private void FillRulesTable(Rules rules)
        {
            var moves = rules.GetMoves();
            for (int i = 0; i < moves.Count; i++)
            {
                var row = GetTableRow(moves[i], rules);
                rulesTable.AddRow(row);
            }
        }

        public string[] GetTableRow(string computerMove, Rules rules)
        {
            var moves = rules.GetMoves();
            var row = new string[moves.Count + 1];
            row[0] = computerMove;
            for (int j = 0; j < moves.Count; j++)
            {
                row[j + 1] = GetGameResult(moves[j], computerMove, rules);   
            }
            return row;
        }

        public string GetGameResult(string userMove, string computerMove, Rules rules)
        {
            string result;
            if (rules.GetWinningMove(userMove, computerMove) == "Draw")
                result = "Draw";
            else
                result = rules.GetWinningMove(userMove, computerMove) == userMove ? "Win" : "Lose";
            return result;
        }

        public void Draw()
        {
            Console.WriteLine("\nThe rules table:");
            rulesTable.Config = TableConfiguration.Unicode();
            Console.Write(rulesTable.ToString());
        }
    }
}
