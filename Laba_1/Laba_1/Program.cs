using System;

namespace Laba_1
{
	class Program
	{
		static void Main(String[] args)
		{
			Double nachOtresk = 0, epsilon = 0.00001, konc = epsilon * 100000;
			Combo combo = new();
			combo.ComboMethod(nachOtresk, epsilon, konc);
		}
	}
}