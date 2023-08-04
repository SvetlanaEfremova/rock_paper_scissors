using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    internal class Rules
    {
        public List<string> moves;

        public Rules(string[] moves)
        {
            this.moves = new List<string>();
            for (int i = 0; i < moves.Length; i++)
            {
                this.moves.Add(moves[i]);
            }
        }

        public List<string> GetMoves() { return moves; }

        public List<string> GetLosingMoves(string move)
        {
            var losingMoves = new List<string>();
            for (int i = 0; i < moves.Count / 2; i++)
            {
                int losingMoveIndex = moves.IndexOf(move) + i + 1 < moves.Count ? moves.IndexOf(move) + i + 1 
                    : moves.IndexOf(move) + i + 1 - moves.Count;
                losingMoves.Add(moves[losingMoveIndex]);
            }
            return losingMoves;
        }
        
        public string GetWinningMove(string move1, string move2)
        {
            if (GetLosingMoves(move1).Contains(move2))
                return move2;
            else if (GetLosingMoves(move2).Contains(move1))
                return move1;
            else
                return "Draw";
        }
    }
}
