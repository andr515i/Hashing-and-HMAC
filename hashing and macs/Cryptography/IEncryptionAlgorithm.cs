using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hashing_and_macs.Cryptography
{
	public interface IEncryptionAlgorithm
	{
		public byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv);
		public string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv);
	}
}
