using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace hashing_and_macs.NewFolder
{
	public class Hasher
	{
		public byte[] HashSHA256Message(string message)
		{
			byte[] messageBytes = Encoding.UTF8.GetBytes(message);

			byte[] hashValue;

			using (SHA256 sha256 = SHA256.Create())
			{
				hashValue = sha256.ComputeHash(messageBytes);
			}

			return hashValue;
		}

		public bool VerifySHA256Message(string message, byte[] hashToCompare)
		{
			byte[] computedHash = HashSHA256Message(message);
            Console.WriteLine(message);
            Console.WriteLine("message: " + BitConverter.ToString(computedHash));
			Console.WriteLine("hashToCompare: " + BitConverter.ToString(hashToCompare));
			return CompareByteArray(computedHash, hashToCompare);
		}

		private bool CompareByteArray(byte[] array1, byte[] array2)
		{
			if (array1 == null || array2 == null || array1.Length != array2.Length)
				return false;

			for (int i = 0; i < array1.Length; i++)
			{
				if (array1[i] != array2[i])
					return false;
			}

			return true;
		}
	}
}
