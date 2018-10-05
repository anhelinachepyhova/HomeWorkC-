using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
	class Program
	{
		static void Main(string[] args)
		{
			Random r = new Random();
			int leng;
			bool flag = true;

			do
			{
				Console.WriteLine("Hello gues!");
				Console.Write("Please, Input length array - ");

				flag = Int32.TryParse(Console.ReadLine(), out leng);

				if (flag == false)
				{
					Console.WriteLine("O no, It isn't number. Try again!");
					Console.ReadLine();
					Console.Clear();
				}
			} while (flag == false);

			int[] mas1 = new int[leng];
			Console.WriteLine("Old variant of the arrray : ");
			for (int i = 0; i <leng; i++)
			{
				mas1[i] = r.Next(-128, 127);
				Console.WriteLine($"{i} := {mas1[i]};");
			}

			int test;

			for (int i = 0 ; i < leng; i++)
			{
				for (int j = i ; j < leng; j++)
				{
					if (mas1[i] >= mas1[j])
						{
						test = mas1[i];
						mas1[i] = mas1[j];
						mas1[j] = test;
						}

				}
			}

			Console.WriteLine();
			Console.WriteLine("New variant of the arrray");
			for (int i = 0; i < leng; i++)
			{
				Console.WriteLine($"{i} := {mas1[i]};");
			}

			Console.ReadLine();
		}
	}
}
