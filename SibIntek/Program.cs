using System;

namespace SibIntek
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = Console.ReadLine();

			var changer = new Changer();

			var output = changer.ChangeFirstNumber(input);

			Console.WriteLine(output);

			Console.ReadLine();
		}
	}
}
