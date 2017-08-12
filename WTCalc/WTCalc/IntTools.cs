using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WTCalc
{
	public class IntTools
	{
		public const int IMAX = 1000000000;

		public static bool IsRange(int value, int minval, int maxval)
		{
			return minval <= value && value <= maxval;
		}

		public static int ToRange(int value, int minval, int maxval)
		{
			if (value < minval)
				value = minval;
			else if (maxval < value)
				value = maxval;

			return value;
		}
	}
}
