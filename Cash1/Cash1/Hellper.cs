using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cash1
{
	public static class Hellper
	{

		public static string outputdial(string dialog)
		{
			Console.Write($"{dialog}:");
			return Console.ReadLine();
		}

		public static int isnumber(string param)
		{
			if (int.TryParse(param, out int result))
			{
				return result;
			}
			return -0;
		}

		public  static double isdouble(string param)
		{
			if (double.TryParse(param, out double result))
			{
				return result;
			}
			return -0;
		}
	}
}
