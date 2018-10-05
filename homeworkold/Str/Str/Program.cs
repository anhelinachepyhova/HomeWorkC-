using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Str
{
	class Program
	{

		static void Main(string[] args)
		{
			int num = 0;

			Console.WriteLine("Hello gues!");
			Console.Write("Please, input string with numbers - ");
			string str = Console.ReadLine();

			string[] mas1 = new string[1];

			Console.WriteLine("Numbers - ");
			for (int n = 0; n < str.Length; n++)
			{
				if (Char.IsNumber(str[n]))
				{
					mas1[num] = mas1[num] + str[n];
				}

				if ((!(Char.IsNumber(str[n]))) & (mas1[num] != null))
				{
					Array.Resize(ref mas1, mas1.Length + 1);
					num++;
				}
			}
			num = 0;

			for (int n = 0; n < mas1.Length; n++)
			{			
					Console.WriteLine($" {n} element array -  {mas1[n]}");
					num = num + Convert.ToInt32(mas1[n]);
			}

			Console.WriteLine();
			Console.WriteLine($"Result = {num}");
			Console.ReadLine();
		}
	}
}
