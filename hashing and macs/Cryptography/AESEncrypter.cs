using hashing_and_macs.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace hashing_and_macs.Cryptography
{
	public class AES : IEncryptionAlgorithm
	{
		public byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
		{
			byte[] encrypted;
			using (AesManaged aes = new AesManaged())
			{
				ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);

				using (MemoryStream ms = new MemoryStream())
				{
					using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter sw = new StreamWriter(cs))
						{
							sw.Write(plainText);
						}
						encrypted = ms.ToArray();
					}
				}
			}
			return encrypted;
		}


		public string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
		{
			string plaintext;
			using (AesManaged aes = new())
			{
				ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);
				using (MemoryStream ms = new MemoryStream(cipherText))
				{
					using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
					{
						using (StreamReader sr = new StreamReader(cs))
						{
							plaintext = sr.ReadToEnd();
						}
					}

				}
			}
			return plaintext;
		}

	}
}

