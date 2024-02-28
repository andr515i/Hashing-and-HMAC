using hashing_and_macs.Cryptography;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace hashing_and_macs.Cryptography
{
	internal class DESEncrypter : IEncryptionAlgorithm
	{
		// TURNS OUT DES IS NOT VERY SECURE, AND ONLY USES KEY AND IV BYTE SIZES OF 8... why. ;_;
		string IEncryptionAlgorithm.DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
		{

			string plaintext;
			using (DES des = DES.Create())
			{
				ICryptoTransform decryptor = des.CreateDecryptor(key, iv);
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


		// TURNS OUT DES IS NOT VERY SECURE, AND ONLY USES KEY AND IV BYTE SIZES OF 8... why
		byte[] IEncryptionAlgorithm.EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
		{
			byte[] encrypted;
			using (DES des = DES.Create())
			{
				ICryptoTransform encryptor = des.CreateEncryptor(key, iv);

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
	}
}
