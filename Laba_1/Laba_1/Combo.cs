using System;

namespace Laba_1
{
	public class Combo
	{
		private Double _y, _y1, _y2, _y3;
		private Int32 _n;
		
		public void ComboMethod(Double nachOtresk, Double epsilon, Double konc)
		{
			Double F(Double x)
			{
				return 2 * x + Math.Log10(x) + 0.5;
			}

			Double Df(Double x)
			{
				return 2 + (1 / x);
			}

			Double Ddf(Double x)
			{
				return -(1 / (x * x));
			}

			Double IntervalNach(Double x, Double a)
			{
				while (F(x) * F(x + a) > 0)
				{
					x = x + a;
				}

				return x;
			}

			Double Hord(Double xn, Double xi)
			{
				return xi - F(xi) * (xi - xn) / (F(xi) - F(xn));
			}

			Double Kasateln(Double x)
			{
				return x - (F(x) / Df(x));
			}


			Console.WriteLine("Корень уровнения 2*x+Log10(x)+0.5=0 , при диапозоне [0;0,9]");
			Double intervBeg = IntervalNach(nachOtresk, konc);
			Double intervEnd = intervBeg + konc;
			Console.WriteLine($"Уточненный интервал [ {intervBeg}, {intervEnd}]" +
			                  $"\nf(a)={F(intervBeg)}" +
			                  $"\nf*(a)={Df(intervBeg)}" +
			                  $"\nf**(a)={Ddf(intervBeg)}" +
			                  $"\nf(b)={F(intervEnd)}" +
			                  $"\nf*(b)={Df(intervEnd)}" +
			                  $"\nf**(b)={Ddf(intervEnd)}");

			if ((F(intervBeg) < 0 & (Ddf(intervBeg) < 0)) | ((F(intervBeg) >= 0) & (Ddf(intervBeg) >= 0)))
			{
				_y1 = intervBeg;
				_y = intervEnd;
				Console.WriteLine("Знаки совпадают у границы [a.a] - точка неподвижна");
			}
			else
			{
				_y1 = intervEnd;
				_y = intervBeg;
				Console.WriteLine("Знаки совпадают у границы [b.b] - точка неподвижна");
			}

			_n = 0;
			Console.WriteLine("n " + " Xan " + " F(Xan) " + " Xbn " + " F(Xbn) " + " razn xn-xn2 ");
			while (Math.Abs(_y1 - _y) >= epsilon)
			{
				_n++;

				_y2 = _y;
				_y3 = _y1;
				_y1 = Kasateln(_y3);
				_y = Hord(_y3, _y2);
				String yout = _y1.ToString() + "00000000000000";
				if (_n != 1 & _n < 8)
				{
					Console.WriteLine(_n + " " + _y1 + " " + F(_y1) + " " + _y + " " + F(_y) + " " + (_y1 - _y));
				}

				if (_n == 1)
				{
					Console.WriteLine(_n + " " + yout + " " + F(_y1) + " " + _y + " " + F(_y) + " " + (_y1 - _y));
				}

				if (F(_y) == 0)
				{
					Console.WriteLine(_n + " " + _y1 + " " + F(_y1) + " " + _y + " " + F(_y) + " " + (_y1 - _y));
				}
			}

			if (Math.Abs(F(_y1)) < Math.Abs(F(_y)))
			{
				Console.WriteLine($"Ответ: {_y1}");
			}
			else
			{
				Console.WriteLine($"Ответ: {_y1}");
			}
		}
	}
}