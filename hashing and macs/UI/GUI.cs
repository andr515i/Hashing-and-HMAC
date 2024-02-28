using hashing_and_macs.Cryptography;
using System;

namespace hashing_and_macs.UI
{
	public class GUI
	{
		private readonly List<IEncryptionAlgorithm> algorithms;

		public GUI(List<IEncryptionAlgorithm> encrypter)
		{
			algorithms = encrypter;
		}

		public void EncryptAndDecrypt()
		{
			byte[] keyBytes;
			byte[] ivBytes;
			Console.WriteLine("Enter the message to be encrypted:");
			string inputMessage = Console.ReadLine();
			Console.WriteLine("Choose the encryption algorithm:");
			for (int i = 0; i < algorithms.Count(); i++)
			{
				Console.WriteLine($"{i + 1}. {algorithms[i].GetType().Name}");
			}

			int choice = int.Parse(Console.ReadLine());
			if (choice < 1 || choice > algorithms.Count())
			{
				Console.WriteLine("Invalid choice.");
				return;
			}
			else
			{
				int keyChoice;
				if (choice == 1) // if aes...
				{
					Console.WriteLine("Choose the key size:");
					Console.WriteLine("1. 128-bit key (16 bytes)");
					Console.WriteLine("2. 192-bit key (24 bytes)");
					Console.WriteLine("3. 256-bit key (32 bytes)");
					keyChoice = int.Parse(Console.ReadLine());
					keyBytes = KeyGenerator.GenerateKey(keyChoice);

				}
				else
				{
					keyChoice = 4;
					keyBytes = KeyGenerator.GenerateDESKey(); 
				}

				if (keyChoice == 1)
				{
					ivBytes = KeyGenerator.GenerateIV(16);
				}
				else if (keyChoice == 2 || keyChoice == 3)
				{
					ivBytes = KeyGenerator.GenerateIV((keyChoice == 2) ? (24) : (32));
				}
				else
				{
					ivBytes = KeyGenerator.GenerateDESIV();
				}

				IEncryptionAlgorithm selectedAlgorithm = algorithms[choice - 1];

				byte[] encryptedBytes = selectedAlgorithm.EncryptStringToBytes(inputMessage, keyBytes, ivBytes);

				Console.WriteLine("\nEncrypted message:");
				Console.WriteLine(Convert.ToBase64String(encryptedBytes));

				string decryptedMessage = selectedAlgorithm.DecryptStringFromBytes(encryptedBytes, keyBytes, ivBytes);

				Console.WriteLine("\nDecrypted message:");
				Console.WriteLine(decryptedMessage);

				Console.WriteLine($"\nKey: {BitConverter.ToString(keyBytes).Replace("-", "")}\n\nIV: {BitConverter.ToString(ivBytes).Replace("-", "")}");
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
