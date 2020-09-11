using System;
using System.Collections.Generic;
using System.Text;

namespace OOPMonsters
{
	public static class Des
	{
		private static Random random = new Random();

		public static int LanceDe()
		{
			return random.Next(1, 7);
		}

		public static int LanceDe(int valeur)
		{
			return random.Next(1, valeur);
		}
	}
}
