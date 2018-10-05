using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specter
{
	class Program
	{
		static int chocenumcolr(int rang1, int rang2, int numar, int cntc)
		{
			int num = -1;
			do
			{
					num++;
			}
			while (!((numar <= (rang2 * ((double)(cntc - num) / cntc))) & ((numar >= (rang2 * ((double)(cntc - num -1) / cntc ))))));
		
			return num;
		}
		static void Main(string[] args)
		{

			int num1, num2;
			int rand1, rand2;

			int color = 0;

			Random rnd = new Random();
			
			Console.WriteLine("Hello!");

			String[] Colors = {"DarkRed", "DarkMagenta", "Magenta", "Red", "Blue", "Green", "DarkYellow", "Yellow", "Gray", "White"};
			
			do
			{
				Console.Write("Enter the first part of a two-dimensioal array: ");
			} while (!(Int32.TryParse(Console.ReadLine(), out num1)));

			do
			{
				Console.Write("Enter the second part of a two-dimensioal array: ");
			} while (!(Int32.TryParse(Console.ReadLine(), out num2)));

			do
			{
				Console.Write("Enter the minimum value of the array: ");
			} while (!(Int32.TryParse(Console.ReadLine(), out rand1)));

			do
			{
				Console.Write("Enter the maxsimum value of the array: ");
			} while (!(Int32.TryParse(Console.ReadLine(), out rand2)));

			int[,] qmas = new int[num1, num2];

			for (int i = 0; i < num1; i++)
			{
				for (int j = 0; j < num2; j++)
				{
					qmas[i, j] = rnd.Next(rand1, rand2);
					Console.Write($"mas[{i},{j}] = {qmas[i,j]}; ");
				}
				Console.WriteLine();
			}

			do
			{
				Console.Write("Enter number or colors: ");
			} while ((!(Int32.TryParse(Console.ReadLine(), out color))) &  (color == 0));

			for (int i = 0; i < num1; i++)
			{
				for (int j = 0; j < num2; j++)
				{			
					ConsoleColor c1;
					Enum.TryParse<ConsoleColor>(Colors[chocenumcolr(rand1, rand2, qmas[i, j], color)], out c1);
					Console.BackgroundColor = c1; 
					Console.Write("    ");
				}
				Console.WriteLine();
			}

			
			Console.ReadLine();


		}
	}
}
