using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace hashing_and_macs.Cryptography
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

		public static byte[] GenerateIV(int byteSize)
		{
            Console.WriteLine("byte size for iv: " + byteSize);
            byte[] key = new byte[byteSize];
			RandomNumberGenerator.Fill(key);
			return key;
		}


		public static byte[] GenerateDESKey()
		{
			byte[] key = new byte[8];
			RandomNumberGenerator.Fill(key);
			return key;
		}

		public static byte[] GenerateDESIV()
		{
			byte[] key = new byte[8];
			RandomNumberGenerator.Fill(key);
			return key;
		}
	}
}
