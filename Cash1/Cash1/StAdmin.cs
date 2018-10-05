using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cash1
{
	struct Admin
	{
		//создание админа - по умолчаню єто первій пользователь  в массиве
		public Admin(stUsers[] stU)
		{
			stU[0].setStUsers("admin", "admin", 0.0, true, false, false);
		}

		//Вівод информации о пользователях
		public void voidInfoUsers(stUsers[] stU)
		{
			if (stU.Length > 0)
			{
				for (int i = 1; i < stU.Length; i++)
				{
					Console.WriteLine($"{i}: Usernam: {stU[i].User}; Password: {stU[i].Password}; Cash balance: {stU[i].Cashbalance}; Lock flag: {stU[i].Flag_block}; Flag first entry: {stU[i].Flag_first_entry}");
				}
			}
		}

		/// <summary>
		/// Добавлеям новог пользователя
		/// </summary>
		/// <param name="stU">указатель на массив структурі пользователей банкомата</param>
		public void addUser(ref stUsers[] stU, string user, double cash_balance)
		{
			int num = stU.Length;
			Array.Resize(ref stU, stU.Length + 1);
			stU[num].setStUsers(user, user, cash_balance, false, false, true);
		}

		/// <summary>
		/// Метод блокировка пользователя
		/// </summary>
		/// <param name="stU">указатель на массив структурі пользователей банкомата</param>
		/// <param name="num">номер пользователя</param>
		public void blockUsers(ref stUsers[] stU, int num)
		{
			stU[num].blockusers();
		}

		/// <summary>
		/// Метод блокировка пользователя
		/// </summary>
		/// <param name="stU">указатель на массив структурі пользователей банкомата</param>
		/// <param name="num">номер пользователя</param>
		public void unblockUsers(ref stUsers[] stU, int num)
		{
			stU[num].unblockusers();
		}

		public void deleteUser(ref stUsers[] stU, int num, string name)
		{
			stUsers[] stUdel;

			if (name != "ALL")
			{
				stUdel = new stUsers[stU.Length - 1];

				stU[num].setStUsers(null, null, 0, false, false, false);

				for (int i = 0, j = 0; i < stU.Length - 1 && j < stU.Length; i++, j++)
				{
					if (stU[j].User != null)
					{
						stUdel[i] = stU[j];
					}
					else
					{
						i--;
					}
				}
			}
			else
			{
				stUdel = new stUsers[1];
				stUdel[0] = stU[0];
			}
			stU = stUdel;
		}
	}
}
