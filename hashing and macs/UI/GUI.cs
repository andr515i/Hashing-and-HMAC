using hashing_and_macs.Cryptograpgy;
using System.Security.Cryptography;
using System;

namespace hashing_and_macs.UI
{
	public class GUI
	{
		private readonly IEncryptionAlgorithm[] encryptionAlgorithms;

		public GUI(IEncryptionAlgorithm[] encryptionAlgorithms)
		{
			this.encryptionAlgorithms = encryptionAlgorithms;
		}

		public void EncryptAndDecrypt()
		{
			Console.WriteLine("Enter the message to be encrypted:");
			string inputMessage = Console.ReadLine();

			Console.WriteLine("Choose the encryption algorithm:");
			for (int i = 0; i < encryptionAlgorithms.Length; i++)
			{
				Console.WriteLine($"{i + 1}. {encryptionAlgorithms[i].GetType().Name}");
			}

			int choice = int.Parse(Console.ReadLine());
			if (choice < 1 || choice > encryptionAlgorithms.Length)
			{
				Console.WriteLine("Invalid choice.");
				return;
			}

			Console.WriteLine("Choose the key size:");
			Console.WriteLine("1. 128-bit key (16 bytes)");
			Console.WriteLine("2. 192-bit key (24 bytes)");
			Console.WriteLine("3. 256-bit key (32 bytes)");
			int keyChoice = int.Parse(Console.ReadLine());

			byte[] keyBytes = KeyGenerator.GenerateKey(keyChoice);
			using (AesManaged aes = new AesManaged())
			{


				IEncryptionAlgorithm selectedAlgorithm = encryptionAlgorithms[choice - 1];

				byte[] encryptedBytes = selectedAlgorithm.EncryptStringToBytes(inputMessage, keyBytes, aes.IV);

				Console.WriteLine("\nEncrypted message:");
				Console.WriteLine(Convert.ToBase64String(encryptedBytes));

				string decryptedMessage = selectedAlgorithm.DecryptStringFromBytes(encryptedBytes, keyBytes, aes.IV);

				Console.WriteLine("\nDecrypted message:");
				Console.WriteLine(decryptedMessage);
			}
			Console.Read();



		}

		public void Menu()
		{
			bool exit = false;

			while (!exit)
			{
				Console.Clear();
				Console.WriteLine("Hashing and MACs Application\n");
				Console.WriteLine("Menu:\n");
				Console.WriteLine("1) Encrypt and Decrypt a message.");
				Console.WriteLine("Type 'exit' to quit.\n");

				string input = Console.ReadLine();

				switch (input.ToLower())
				{
					case "1":
						EncryptAndDecrypt();
						break;
					case "exit":
						exit = true;
						break;
					default:
						Console.WriteLine("\nInvalid selection. Please try again.");
						Console.ReadKey();
						break;
				}
			}
		}
	}
}
