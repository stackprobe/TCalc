using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WTCalc
{
	public class Enzanshi
	{
		public Enzanshi()
		{ }

		/// <summary>
		/// "" == 未入力
		/// "+" == add
		/// "-" == reduce
		/// "*" == mulriple
		/// "/" == divide
		/// "P" == power
		/// "R" == root power
		/// other == unknown
		/// </summary>
		private string Value = "";

		public void Clear()
		{
			this.Value = "";
		}

		public void SetValue(string value)
		{
			this.Value = value;
		}

		public string GetValue()
		{
			return this.Value;
		}

		public string GetValueForUi()
		{
			string te = this.Value;

			if (te == "P")
				te = "Power";

			if (te == "R")
				te = "Root";

			return te;
		}

		public bool IsEmpty()
		{
			return this.Value == "";
		}
	}
}
