using System;

namespace Laba_2
{
	public class Iterative
	{
		public void Iterracii()
		{
			Double nachOtresk = 0.1, konecOtresk = 0.9, epsilon = 0.00001, phi = -0.20599, y1, y2;
			Int32 n;

			Double Dfotphi(Double x)
			{
				return 1 + (phi * (-(1 / (x * x))));
			}

			Double Ddfotphi(Double x)
			{
				return x + (phi * (2 * x + Math.Log10(x) + 0.5));
			}


			Console.WriteLine("Корень ровнения 2*x+Log10(x)+0.5=0 , при диапозоне [0;0,9]");
			Console.WriteLine("Ф(x)=x-(x+Log10(x)+0.5) ");
			Console.WriteLine("Ф*(a)= " + Dfotphi(nachOtresk) + " Ф*(b)= " + Dfotphi(konecOtresk));
			Double endOstanova = epsilon;
			if ((Dfotphi(nachOtresk) < 0) & (Dfotphi(konecOtresk) < 0))
			{
				Console.WriteLine("Двусторонняя, критерии останова " + Math.Abs(epsilon));
			}
			else
			{
				endOstanova = (1 - Math.Max(Math.Abs(Dfotphi(nachOtresk)), Math.Abs(Dfotphi(konecOtresk)))) *
				              epsilon;
				Console.WriteLine("Монотонная, критерии останова " + Math.Abs(endOstanova));
			}

			Double y = nachOtresk;
			y1 = konecOtresk;
			n = 0;
			while (Math.Abs(y1 - y) > Math.Abs(endOstanova))
			{
				n++;
				if (n == 1)
				{
					y = 0;
				}
				else
				{
					y = y1;
					y1 = Ddfotphi(y);
				}

				Console.WriteLine("n " + n);
				Console.WriteLine("Xn " + y1);
				Console.WriteLine(Math.Abs(y1 - y) <= (endOstanova) ? "|Xn-Xn+1|<=e - Да" : "|Xn-Xn+1|<=e - Нет");

				y2 = Math.Abs(y1 - y);
				Console.WriteLine("|xn-xn+1|" + y2);
			}

			Console.WriteLine("Ответ: " + y1);
		}
	}
}