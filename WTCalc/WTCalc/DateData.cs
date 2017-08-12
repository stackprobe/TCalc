using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WTCalc
{
	public class DateData
	{
		private Calc _calc;
		private CalcOperand _day;

		public DateData(Calc calc)
		{
			_calc = calc;
			_day = calc.FromInt(0);
		}

		public DateData(Calc calc, CalcOperand day)
		{
			_calc = calc;
			_day = day;
		}

		public DateData(Calc calc, CalcOperand y, CalcOperand m, CalcOperand d)
		{
			_calc = calc;
			_day = Date2Day(calc, y, m, d);
		}

		public Calc GetCalc()
		{
			return _calc;
		}

		public CalcOperand GetDay()
		{
			return _day;
		}

		public int GetWeekDay()
		{
			return int.Parse(_calc.Mod(_day, _calc.FromInt(7)).ToString()); // FIXME
		}

		public string GetJWeekDay()
		{
			return new string[] { "月", "火", "水", "木", "金", "土", "日" }[this.GetWeekDay()];
		}

		private CalcOperand[] _date = null;

		public CalcOperand[] GetDate()
		{
			if (_date == null)
				_date = Day2Date(_calc, _day);

			return _date;
		}

		public DateData Add(CalcOperand y = null, CalcOperand m = null, CalcOperand d = null)
		{
			if (y == null) y = _calc.FromInt(0);
			if (m == null) m = _calc.FromInt(0);
			if (d == null) d = _calc.FromInt(0);

			if (_calc.LT(y, _calc.FromInt(0))) throw new Exception("y < 0");
			if (_calc.LT(m, _calc.FromInt(0))) throw new Exception("m < 0");
			if (_calc.LT(d, _calc.FromInt(0))) throw new Exception("d < 0");

			return new DateData(
				_calc,
				_calc.Add(this.GetDate()[0], y),
				_calc.Add(this.GetDate()[1], m),
				_calc.Add(this.GetDate()[2], d)
				);
		}

		public DateData Sub(CalcOperand y = null, CalcOperand m = null, CalcOperand d = null)
		{
			if (y == null) y = _calc.FromInt(0);
			if (m == null) m = _calc.FromInt(0);
			if (d == null) d = _calc.FromInt(0);

			if (_calc.LT(y, _calc.FromInt(0))) throw new Exception("y < 0");
			if (_calc.LT(m, _calc.FromInt(0))) throw new Exception("m < 0");
			if (_calc.LT(d, _calc.FromInt(0))) throw new Exception("d < 0");

			// 13ヶ月以上 -> 12ヶ月以下
			{
				y = _calc.Add(y, _calc.Div(m, _calc.FromInt(12), 0));
				m = _calc.Mod(m, _calc.FromInt(12));
			}

			CalcOperand retY = this.GetDate()[0];
			CalcOperand retM = this.GetDate()[1];
			CalcOperand retD = this.GetDate()[2];

			if (y != null)
			{
				retY = _calc.Sub(retY, y);
			}
			if (m != null)
			{
				retM = _calc.Sub(retM, m);
			}
			if (_calc.LT(retM, _calc.FromInt(1)))
			{
				retY = _calc.Sub(retY, _calc.FromInt(1));
				retM = _calc.Add(retM, _calc.FromInt(12));
			}
			if (_calc.LT(retY, _calc.FromInt(1)))
				return null;

			CalcOperand retDay = _calc.Sub(new DateData(_calc, retY, retM, retD).GetDay(), d);

			if (_calc.LT(retDay, _calc.FromInt(0)))
				return null;

			return new DateData(_calc, retDay);
		}

		public static CalcOperand Date2Day(Calc calc, CalcOperand y, CalcOperand m, CalcOperand d)
		{
			if (
				calc.LT(y, calc.FromInt(1)) ||
				calc.LT(m, calc.FromInt(1)) ||
				calc.LT(d, calc.FromInt(1))
				)
				throw new Exception("日付に問題があります。");

			// 13月以上 -> 12月以下
			{
				m = calc.Sub(m, calc.FromInt(1));
				y = calc.Add(y, calc.Div(m, calc.FromInt(12), 0));
				m = calc.Mod(m, calc.FromInt(12));
				m = calc.Add(m, calc.FromInt(1));
			}

			if (calc.LE(m, calc.FromInt(2)))
				y = calc.Sub(y, calc.FromInt(1));

			CalcOperand day = calc.Div(y, calc.FromInt(400), 0);
			day = calc.Mul(day, calc.FromInt(365 * 400 + 97));

			y = calc.Mod(y, calc.FromInt(400));

			day = calc.Add(day, calc.Mul(y, calc.FromInt(365)));
			day = calc.Add(day, calc.Div(y, calc.FromInt(4), 0));
			day = calc.Sub(day, calc.Div(y, calc.FromInt(100), 0));

			if (calc.LT(calc.FromInt(2), m))
			{
				day = calc.Sub(day, calc.FromInt(31 * 10 - 4));
				m = calc.Sub(m, calc.FromInt(3));
				day = calc.Add(day, calc.Mul(calc.Div(m, calc.FromInt(5), 0), calc.FromInt(31 * 5 - 2)));
				m = calc.Mod(m, calc.FromInt(5));
				day = calc.Add(day, calc.Mul(calc.Div(m, calc.FromInt(2), 0), calc.FromInt(31 * 2 - 1)));
				m = calc.Mod(m, calc.FromInt(2));
				day = calc.Add(day, calc.Mul(m, calc.FromInt(31)));
			}
			else
				day = calc.Add(day, calc.Mul(calc.Sub(m, calc.FromInt(1)), calc.FromInt(31)));

			day = calc.Add(day, calc.Sub(d, calc.FromInt(1)));
			return day;
		}

		public static CalcOperand[] Day2Date(Calc calc, CalcOperand day)
		{
			CalcOperand yBit = calc.FromInt(256);
			CalcOperand y = calc.Add(
				calc.Mul(
					calc.Div(day, calc.FromInt(365 * 400 + 97), 0),
					calc.FromInt(400)
					),
				calc.FromInt(1)
				);

			for (; yBit.IsZero() == false; yBit = calc.Div(yBit, calc.FromInt(2), 0))
			{
				CalcOperand yTry = calc.Add(y, yBit);

				if (calc.LE(Date2Day(calc, yTry, calc.FromInt(1), calc.FromInt(1)), day))
					y = yTry;
			}
			CalcOperand m = calc.FromInt(0);

			for (CalcOperand mBit = calc.FromInt(8); mBit.IsZero() == false; mBit = calc.Div(mBit, calc.FromInt(2), 0))
			{
				CalcOperand mTry = calc.Add(m, mBit);

				if (calc.LE(mTry, calc.FromInt(12)) && calc.LE(Date2Day(calc, y, mTry, calc.FromInt(1)), day))
					m = mTry;
			}
			day = calc.Sub(day, Date2Day(calc, y, m, calc.FromInt(1)));
			day = calc.Add(day, calc.FromInt(1));

			return new CalcOperand[] { y, m, day };
		}

		public static CalcOperand[] GetDiff(Calc calc, DateData bgn, DateData end) // ret: { 年, 月, 週, 日 }
		{
			if (calc.LT(end.GetDay(), bgn.GetDay()))
				throw new Exception("end < bgn");

			CalcOperand y = calc.Sub(end.GetDate()[0], bgn.GetDate()[0]);

			if (calc.LT(end.GetDay(), bgn.Add(y).GetDay()))
				y = calc.Sub(y, calc.FromInt(1));

			int m = 0;

			while (calc.LE(bgn.Add(y, calc.FromInt(m + 1)).GetDay(), end.GetDay()))
				m++;

			int d = 0;

			while (calc.LE(bgn.Add(y, calc.FromInt(m), calc.FromInt(d + 1)).GetDay(), end.GetDay()))
				d++;

			int w = d / 7;
			d %= 7;
			return new CalcOperand[] { y, calc.FromInt(m), calc.FromInt(w), calc.FromInt(d) };
		}
	}
}
