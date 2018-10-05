using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cash1
{
	//структура пользователей
	public struct stUsers
	{
		string user, password;
		double cashbalance;
		bool flag_admin, flag_block, flag_first_entry;

		public string User
		{
			private set
			{
				user = value;
			}
			get
			{
				return user;
			}
		}

		public string Password
		{
			private set
			{
				password = value;
			}
			get
			{
				return password;
			}
		}

		public double Cashbalance
		{
			private set
			{
				cashbalance = value;
			}
			get
			{
				return cashbalance;
			}
		}

		public bool Flag_admin
		{
			private set
			{
				flag_admin = value;
			}
			get
			{
				return flag_admin;
			}
		}

		public bool Flag_block
		 {
			private set
			{
				flag_block = value;
			}
			get
			{
				return flag_block;
			}
		}

		public bool Flag_first_entry
		{
			private set
			{
				flag_first_entry = value;
			}
			get
			{
				return flag_first_entry;
			}
		}

		public void setStUsers(string puser, string ppassword, double pcashbalance, bool pflag_admin, bool pflag_block, bool pflag_first_entry)
		{
			User = puser;
			Password = ppassword;
			Cashbalance = pcashbalance;
			Flag_admin = pflag_admin;
			Flag_block = pflag_block;
			Flag_first_entry = pflag_first_entry;
		}

		//поиск пользователя
		public static int searcUsers(stUsers[] stU, string user)
		{
			for (int i = 0; i < stU.Length; i++)
			{
				if (stU[i].user.Equals(user))
				{
					return i;
				}
			}
			return -1;
		}

		//снятие денег с карточки
		public bool cashinbalnce(double sum)
		{
			if (Cashbalance >= sum)
			{
				Cashbalance = Cashbalance - sum;
				return true;
			}
			return false;
		}

		//пополнить денег с карточки
		public void cashboutalnce( double sum)
		{
			Cashbalance = Cashbalance + sum;
		}

		public void setfirstexit()
		{
			Flag_first_entry = false;
		}

		//смена пароля
		public void changepassword(string password)
		{
			Password = password;
		}

		public void blockusers()
		{
			Flag_block = true;
		}

		public void unblockusers()
		{
			flag_block = false;
		}
	}
}
