using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace hashing_and_macs.Cryptograpgy
{
	internal class KeyGenerator
	{
		public static byte[] GenerateKey(int keySize)
		{
			byte[] key;
			switch (keySize)
			{
				case 1: // 128-bit key (16 bytes)
					key = new byte[16];
					break;
				case 2: // 192-bit key (24 bytes)
					key = new byte[24];
					break;
				case 3: // 256-bit key (32 bytes)
					key = new byte[32];
					break;
				default:
					throw new ArgumentException("Invalid key size choice.");
			}

			RandomNumberGenerator.Fill(key);
            return key;
		}
	}
}
