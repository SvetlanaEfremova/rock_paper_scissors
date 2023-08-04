using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Macs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    internal class HashProvider
    {
        public static byte[] GenerateKey()
        {
            var generator = RandomNumberGenerator.Create();
            var key = new byte[32];
            generator.GetBytes(key);
            string keyString = string.Join("", key.Select(x => x.ToString("x2")));
            return Encoding.ASCII.GetBytes(keyString);
        }

        public static byte[] GetHMAC(byte[] key, string move)
        {
            var result = new byte[32];
            var hmac = new HMac(new Sha3Digest(256));
            hmac.Init(new KeyParameter(key));
            hmac.BlockUpdate(Encoding.UTF8.GetBytes(move), 0, Encoding.UTF8.GetBytes(move).Length);
            hmac.DoFinal(result, 0);
            return result;
        }
    }
}
