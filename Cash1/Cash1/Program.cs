using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cash1
{
	class Program
	{
		public enum menuAdm
			{View_users = 1, Blocked_users = 2, UnBlocked_users = 3, Add_User = 4, Delet_user = 5, Exit = 6}

		public enum menuUsr {View_balans = 1, Cash_Out = 2, Cash_In = 3, Change_password = 4, Exit = 5}

		//Меню админа
		static void menuAdmin(string user, ref stUsers[] stU, Admin admn)
		{
			menuAdm adm = new menuAdm();
			bool exit = false;
			int numMenu, num;
			string name;

			do
			{
				Console.Clear();

				Console.WriteLine($"Добро пожаловать {user}");

				foreach (menuAdm values in Enum.GetValues(typeof(menuAdm)))
				{
					Console.WriteLine($"{values} - {(int)values}");
				}

				numMenu = Hellper.isnumber(Console.ReadLine());

				switch (numMenu)
				{
					case 1:
						{
							Console.Clear();  

							Console.WriteLine("Показіваем польователей!");
							if (stU.Length > 1)
							{
								admn.voidInfoUsers(stU);
							}
							else
							{
								Console.WriteLine("Пользователей в текущем списке нет!");
							};
							Console.ReadLine();
							break;
						}
					case 2:
						{
							Console.Clear();
							Console.WriteLine("Блокируем пользователя!");

							name = Hellper.outputdial("Введите имя пользователя для блокировки");

							num = stUsers.searcUsers(stU, name);

							if ((num != -1) && (name != "admin"))
							{
								admn.blockUsers(ref stU, num);
								Console.WriteLine($"Пользователь с именем {name} - заблокирован");
							}
							else
							{
								Console.WriteLine("Текущего пользователя в списке нет!");
							}

							Console.ReadLine();
							break;
						}
					case 3:
						{
							Console.Clear();
							Console.WriteLine("Разблокируем пользователя!");

							name = Hellper.outputdial("Введите имя пользователя для разблокировки");

							num = stUsers.searcUsers(stU, name);

							if (num != -1)
							{
								admn.unblockUsers(ref stU, num);
								Console.WriteLine($"Пользователь с именем {name} - разблокирован");
							}
							else
							{
								Console.WriteLine($"Пользователь с именем {name} в текущем списке нет!");
							}

							Console.ReadLine();
							break;
						}
					case 4:
						{
							Console.Clear();
							Console.WriteLine("Добавить пользователя!");

							Console.WriteLine();
							name = Hellper.outputdial("Имя нового пользователя");

							num = stUsers.searcUsers(stU, name);

							if (num == -1)
							{
								double cash;
								do
								{
									cash = Hellper.isdouble(Hellper.outputdial("Баланс нового пользователя"));
								} while (cash == -0);

								admn.addUser(ref stU, name, cash);

								Console.WriteLine($"Пользователь {name} - добавлен");
								Console.ReadLine();
							}
							else
							{
								Console.WriteLine($"Пользователь с именем {name} в текущем списке есть!");
								Console.ReadLine();
							}

							break;
						}
					case 5:
						{
							Console.Clear();
							Console.WriteLine("Удалить пользователя!");

							if (stU.Length > 1)
							{
								Console.WriteLine();
								name = Hellper.outputdial("Имя пользователя для удаления");

								num = stUsers.searcUsers(stU, name);

								if (((num != -1) || (name == "ALL")) && (name != "admin"))
								{

									admn.deleteUser(ref stU, num, name);

									Console.WriteLine($"Пользователь {name} - удален");
								}
								else
								{
									Console.WriteLine($"Пользователь с именем {name} в текущем списке нет!");
								}
							}
							else
							{
								Console.WriteLine("Пользователей в текущем списке нет!");
							};
							Console.ReadLine();
							break;
						}
					case 6:
						{
							Console.Clear();
							Console.WriteLine("Спасибо за визит! До следующих встречь!");
							exit = true;
							//Console.ReadLine();
							break;
						}
				};
			} while (!(exit == true));
		}

		//Меню пользователя
		static void menuUser(string user, ref stUsers[] stU)
		{
			menuUsr usr = new menuUsr();
			bool exit = false;
			int numMenu, num;

			num = stUsers.searcUsers(stU, user);

			do
			{
				Console.Clear();

				Console.WriteLine($"Добро пожаловать {user}");

				do
				{
					if (stU[num].Flag_first_entry == true)
					{
						stU[num].changepassword(Hellper.outputdial("Необходимо сменить пароль. Введите новій пароль"));
						stU[num].setfirstexit();
					}
				} while (stU[num].Flag_first_entry == true);

				foreach (menuUsr values in Enum.GetValues(typeof(menuUsr)))
				{
					Console.WriteLine($"{values} - {(int)values}");
				}

				numMenu =  Hellper.isnumber(Console.ReadLine());

				switch (numMenu)
				{
					case 1:
						{
							Console.Clear();
							Console.Write($"Баланс пользователя {user} = {stU[num].Cashbalance}");
							Console.ReadLine();
							break;
						}
					case 2:
						{
							Console.Clear();
							double cash;

							do
							{
								cash = Hellper.isdouble(Hellper.outputdial("Введите сумму, для пополнения"));
							} while (cash == -0);

							stU[num].cashboutalnce(cash);
							Console.ReadLine();
							break;
						}
					case 3:
						{
							Console.Clear();
							double cash;

							do
							{
								cash = Hellper.isdouble(Hellper.outputdial("Введите сумму для снятия"));
							} while (cash == -0);

							if (stU[num].cashinbalnce(cash))
							{
								Console.WriteLine("Снятие прошло успешно");
							}
							else
							{
								Console.WriteLine("Не достаточно средств");
							};
							Console.ReadLine();
							break;
						}
					case 4:
						{
							Console.Clear();
							Console.WriteLine("Сменить пароль");
							stU[stUsers.searcUsers(stU, user)].changepassword(Hellper.outputdial("Введите новій пароль"));
							Console.WriteLine("Смена пароля прошла успешно!");
							Console.ReadLine();
							break;
						}
					case 5:
						{
							Console.Clear();
							Console.WriteLine("Спасибо за визит! До следующих встречь!");
							exit = true;
							break;
						}
				};
			} while (!(exit == true));
		}

		static void Main(string[] args)
		{
			string user, user_ex = "", password;
			int num, par_err = 1;
		
			//При запуске приложения инизиализируем первого пользователя- єто admin
			stUsers[] stU = new stUsers[1];
			Admin admn = new Admin(stU);

			do
			{
				Console.Clear();

				//Блок аутификации пользователя
				Console.WriteLine("ATM!");
				user = Hellper.outputdial("Username");
				password = Hellper.outputdial("Password");

				num = stUsers.searcUsers(stU, user);

				if ((num >= 0)
					&& (stU[num].User.Equals(user))
					&& (stU[num].Password.Equals(password))
					&& (stU[num].Flag_block == false))
				{
					if (user.Equals("admin"))
					{
						menuAdmin(user, ref stU, admn);
					}
					else
					{
						menuUser(user, ref stU);
					}
				}
				else if ((num > 1) && (stU[num].User.Equals(user)) && (stU[num].Flag_block == true))
				{
					Console.WriteLine($"Пользователь {user} Заблокирован.");
				}
				else
				{
					Console.WriteLine("Username или password не правильній");

					if (user_ex.Equals(user))
					{
						par_err++;
						if ((par_err == 3) && (stU[num].User.Equals(user)))
						{
							stU[num].blockusers();
							Console.WriteLine($"Пользователь {user} Заблокирован.");
						}
					}
					else
					{
						par_err = 1;
					}
					user_ex = user;
				}
			}
			while (Console.ReadKey().Key != ConsoleKey.Escape);
		}
	}
}
