using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace hashing_and_macs.NewFolder
{


	/// <summary>
	/// 
	/// </summary>
	internal class MacHandler
	{
		private HMAC MAC;

		public MacHandler(string macName)
		{
			switch (macName.ToUpper())
			{
				case "SHA1":
					MAC = new HMACSHA1();
					break;
				case "MD5":
					MAC = new HMACMD5();
					break;
				case "RIPEMD":
					throw new Exception("Ripemd not found in cryptography namespace.");
				case "SHA256":
					MAC = new HMACSHA256();
					break;
				case "SHA384":
					MAC = new HMACSHA384();
					break;
				case "SHA512":
					MAC = new HMACSHA512();
					break;
				default:
					MAC = new Hasher();
					break;
			}
		}

		public byte[] ComputeMac(byte[] mes, byte[] key)
		{
			MAC.Key = key;
			return MAC.ComputeHash(mes);

		}


		/// <summary>
		/// check to see if the new message is the same as the existing message (hashed). this method hashes the new message and checks the hashe
		/// to see if they are the same.
		/// </summary>
		/// <param name="mes"></param>
		/// <param name="mac"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public bool CheckMessageAuthentication(byte[] mes, byte[] mac, byte[] key)
		{
			this.MAC.Key = key;

			if (CompareByteArray(MAC.ComputeHash(mes), mac, MAC.HashSize / 8))
			{
				return true;
			}
			return false;
		}




		/// <summary>
		/// compares the new message with an existing, already hashed message.
		/// </summary>
		/// <param name="incoming"></param>
		/// <param name="existing"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		private bool CompareByteArray(byte[] incoming, byte[] existing, int length)
		{

			for (int i = 0; i < length; i++)
			{
				if (incoming[i] != existing[i])
				{
					return false;
				}
			}
			return true;
		}
	}
}
