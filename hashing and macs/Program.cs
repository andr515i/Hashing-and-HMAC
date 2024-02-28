using hashing_and_macs.Cryptography;
using hashing_and_macs.UI;
using System;

namespace hashing_and_macs
{
	internal class Program
	{
		static void Main(string[] args)
		{

			List<IEncryptionAlgorithm> algorithms = new List<IEncryptionAlgorithm>();
			algorithms.Add(new AES());
			algorithms.Add(new DESEncrypter());
			GUI ui = new GUI(algorithms);
			ui.Menu();

		}
	}
}
