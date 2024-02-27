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
				using (MemoryStream ms = new MemoryStream(messageBytes))
				{
					using (CryptoStream cs = new CryptoStream(ms, sha256, CryptoStreamMode.Read))
					{
						cs.CopyTo(Stream.Null);
					}
				}
				hashValue = sha256.Hash!;
			}

			return hashValue;
		}



		public byte[] HashHMACSHA256Message(string message, string secretKey) {

			byte[] messageBytes = Encoding.UTF8.GetBytes(message);

			byte[] key = Encoding.UTF8.GetBytes(secretKey); //key for hmac

			byte[] hmacValue;

			using (HMACSHA256 hmac = new HMACSHA256(key))
			{
				using (MemoryStream ms = new MemoryStream(messageBytes))
				{
					using (CryptoStream cs = new CryptoStream(ms, hmac, CryptoStreamMode.Read))
					{

						cs.CopyTo(Stream.Null);
					}
				}
				hmacValue = hmac.Hash!;
			}
			return hmacValue;
		}
	}
}
