using hashing_and_macs.NewFolder;
using System;
using System.Collections.Generic;

namespace hashing_and_macs.UI
{
	public class GUI
	{
		private Dictionary<ConsoleKey, string> algorithms = new Dictionary<ConsoleKey, string>
		{
			{ ConsoleKey.D1, "non hmac" },
			{ ConsoleKey.D2, "HMACSHA1" },
			{ ConsoleKey.D3, "HMACMD5" },
			{ ConsoleKey.D4, "HMACSHA256" },
			{ ConsoleKey.D5, "HMACSHA384" },
			{ ConsoleKey.D6, "HMACSHA512" },
		};

		public void ShowMessage(string key, string plainText, string macAscii, string macHex)
		{
			Console.Clear();
			Console.WriteLine("Hashing and MACs Application\n");
			Console.WriteLine($"Selected Algorithm: {key}\n");
			Console.WriteLine("Original Message:");
			Console.WriteLine(plainText);
			Console.WriteLine("\nMAC (ASCII):");
			Console.WriteLine(macAscii);
			Console.WriteLine("\nMAC (Hexadecimal):");
			Console.WriteLine(macHex);
			Console.WriteLine("\nPress any key to continue...");
			Console.ReadKey();
		}

		public void ChooseHashOrHMACAlgorithm()
		{
			Console.Clear();
			Console.WriteLine("Hashing and MACs Application\n");
			Console.WriteLine("Choose an algorithm:\n");
			foreach (var algorithm in algorithms)
			{
				Console.WriteLine($"{algorithm.Key}) {algorithm.Value}");
			}

			ConsoleKeyInfo inputKey = Console.ReadKey();
			Console.Clear();

			try
			{
				string selectedAlgorithm = algorithms[inputKey.Key];
				Console.WriteLine($"You chose: {selectedAlgorithm}\n");

				// Get user input for message and key
				Console.WriteLine("Enter the message to be hashed:");
				string inputMessage = Console.ReadLine()!;
				Console.WriteLine("Enter the key for hashing:");
				string inputKeyString = Console.ReadLine()!;

				// Compute MAC and display
				MacHandler mc = new MacHandler(selectedAlgorithm);
				byte[] mac = mc.ComputeMac(inputMessage, inputKeyString);
				string macAscii = BitConverter.ToString(mac);
				string macHex = BitConverter.ToString(mac).Replace("-", "");

				ShowMessage(selectedAlgorithm, inputMessage, macAscii, macHex);
			}
			catch (KeyNotFoundException)
			{
				Console.WriteLine("Invalid selection. Please try again.");
				Console.ReadKey();
			}
		}

		public void Menu()
		{
			bool exit = false;

			while (!exit)
			{
				Console.Clear();
				Console.WriteLine("Hashing and MACs Application\n");
				Console.WriteLine("Menu:\n");
				Console.WriteLine("1) Hash a message.");
				Console.WriteLine("2) Verify a message.");
				Console.WriteLine("Type 'exit' to quit.\n");

				string input = Console.ReadLine()!;

				switch (input.ToLower())
				{
					case "1":
						ChooseHashOrHMACAlgorithm();
						break;
					case "2":
						VerifyHash();
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

		public void VerifyHash()
		{
			// Implement verification logic here
			Console.WriteLine("Verification feature is under development.");
			Console.ReadKey();
		}
	}
}
