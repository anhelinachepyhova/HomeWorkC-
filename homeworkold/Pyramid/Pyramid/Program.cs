using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid
{
	class Program
	{

		static void describePyramid(char sym1, char sym2, int dl, int h)
		{
			int cnt = 1;
			
			for (int i = 1; i <= h; i++)
			{
				for (int a = 1; a <= dl; a++)
				{
					Console.Write(sym1);

					if (a == (dl / 2 - i)+1)
					{
						for (int j = 1; j <= cnt; j++)
						{
							Console.Write(sym2);
						}
						a += cnt;
					}
				}
				cnt += 2;
				Console.WriteLine();
			}
		}

		static void Main(string[] args)
		{
			Console.WriteLine("Hello gues!");

			Console.Write("Input main symbol: ");
			char sym1 = Convert.ToChar(Console.ReadLine());

			Console.Write("Input additional symbol: ");
			char sym2 = Convert.ToChar(Console.ReadLine());

			Console.Write("Input arreay length: ");
			int dl = Convert.ToInt32(Console.ReadLine());

			Console.Write("Input arreay height: ");
			int h = Convert.ToInt32(Console.ReadLine());

			describePyramid(sym1, sym2, dl, h);

			Console.ReadLine();
		}

	}
}
