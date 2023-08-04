using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace task3
{
    internal class Program
    {
        static void Play(string[] moves)
        {
            var key = HashProvider.GenerateKey();
            var rules = new Rules(moves);
            var game = new Game(rules);
            var hmac = HashProvider.GetHMAC(key, game.GetComputerMove());
            Console.WriteLine("HMAC: " + string.Join("", hmac.Select(x => x.ToString("x2"))));
            game.ShowRules();
            game.Play();
            Console.WriteLine("HMAC Key: " + Encoding.ASCII.GetString(key));
        }

        static void Main(string[] args)
        {
            InputValidation.ExitIfArgsNotOK(args);
            Play(args);
        }
    }
}
