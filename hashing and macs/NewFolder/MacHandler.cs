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
				case "HMACSHA1":
					MAC = new HMACSHA1();
					break;
				case "HMACMD5":
					MAC = new HMACMD5();
					break;
				case "HMACSHA256":
					MAC = new HMACSHA256();
					break;
				case "HMACSHA384":
					MAC = new HMACSHA384();
					break;
				case "HMACSHA512":
					MAC = new HMACSHA512();
					break;
				default:
					break;
			}
		}


		/// <summary>
		/// generates the MAC value for the message baseed on the provided key.
		/// </summary>
		/// <param name="mes"></param>
		/// <param name="key"></param>
		/// <returns>messages hashed into MAC as byte[]</returns>
		public byte[] ComputeMac(string message, string key)
		{
			byte[] mes = Encoding.UTF8.GetBytes(message);
			byte[] keyBytes = Encoding.UTF8.GetBytes(key);
			MAC.Key = keyBytes;
			return MAC.ComputeHash(mes);
		}


		/// <summary>
		/// check to see if the new message is the same as the existing message (hashed). this method hashes the new message and checks the hashe
		/// to see if they are the same.
		/// </summary>
		/// <param name="mes"></param>
		/// <param name="mac"></param>
		/// <param name="key"></param>
		/// <returns>true if the 2 message's MAC's are the same.</returns>
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
		/// <returns>true if both message MAC's are the same</returns>
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
