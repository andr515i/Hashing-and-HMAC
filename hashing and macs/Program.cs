using hashing_and_macs.NewFolder;
using System.Text;

namespace hashing_and_macs
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Hasher hasher = new Hasher();
			MacHandler mh = new MacHandler("SHA256");
			bool qwe = mh.CheckMessageAuthentication(Encoding.UTF8.GetBytes("test"), hasher.HashHMACSHA256Message("test", "test"), Encoding.UTF8.GetBytes("test"));
            Console.WriteLine(qwe);

            Console.Read();
		}
	}
}
