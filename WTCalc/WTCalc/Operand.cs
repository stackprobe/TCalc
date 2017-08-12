using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WTCalc
{
	public class Operand
	{
		private static readonly string INT_LBRACKET = "(";
		private static readonly string INT_RBRACKET = ")";

		private static readonly string DIGITS = "0123456789abcdef";

		public Operand()
		{ }

		private string Value = "";

		public bool IsEmpty()
		{
			return this.Value == "";
		}

		public void Clear() // Int の場合、クリアされることに注意！
		{
			this.Value = "";
		}

		public string GetValue()
		{
			return this.Value;
		}

		public string GetValueForUi()
		{
			if (this.IsInt())
			{
				return this.IntFltr(this.Value);
			}
			//return Tools.ThousandComma(this.Value);
			return this.Value;
		}

		private string IntFltr(string operand)
		{
			operand = operand.Substring(1, operand.Length - 2);

			if (operand == "0" && Gnd.I.Answer.IsEmpty())
				return "";

			if(Gnd.I.Radix != 10)
				operand += Gnd.I.INT_OPERAND_SUFFIX;

			return operand;
		}

		public string GetOperandForCalc()
		{
			if (this.IsInt())
			{
				return "" + this.GetInt();
			}
			return this.Value;
		}

		public void SetOperand(string newOperand)
		{
			this.Value = newOperand;
		}

		public int IntRangeMin = int.MinValue;
		public int IntRangeMax = int.MaxValue;

		public void SetIntRange(int minValue = int.MinValue, int maxValue = int.MaxValue)
		{
			this.IntRangeMin = minValue;
			this.IntRangeMax = maxValue;
		}

		public void SetInt(int newRadix)
		{
			newRadix = Math.Max(newRadix, this.IntRangeMin);
			newRadix = Math.Min(newRadix, this.IntRangeMax);

			this.Value = INT_LBRACKET + newRadix + INT_RBRACKET;
		}

		public bool IsInt()
		{
			return this.Value.StartsWith(INT_LBRACKET);
		}

		public int GetInt()
		{
			if(this.IsInt())
			{
				try
				{
					return int.Parse(this.Value.Substring(1, this.Value.Length - 2));
				}
				catch(Exception e)
				{
					SystemTools.WriteLog(e);
				}
			}
			return 0;
		}

		public void Normalize()
		{
			if (this.Value.IndexOf('.') != -1)
				while (this.Value.EndsWith("0"))
					this.Value = this.Value.Remove(this.Value.Length - 1);

			if (this.Value.EndsWith("."))
				this.Value = this.Value.Remove(this.Value.Length - 1);
		}

		// Input >

		public void InputFigure(int value)
		{
			if (this.IsInt())
			{
				if (value < 10)
				{
					int iValue = this.GetInt();
					int iSign = iValue < 0 ? -1 : 1;
					iValue *= iSign;
					iValue *= 10;
					iValue += value;
					iValue *= iSign;
					this.SetInt(iValue);
				}
				return;
			}
			if (Gnd.I.OPERAND_LENMAX < this.Value.Length)
			{
				SystemTools.ShowOverflow();
				return;
			}
			if (
				this.Value == "0" ||
				this.Value == "-0"
				)
				this.Value = this.Value.Remove(this.Value.Length - 1);

			this.Value += DIGITS[value];
		}

		public void InputDecimalPoint()
		{
			if (this.IsInt())
				return;

			if (this.IsEmpty())
				this.Value = "0";

			if (this.Value.IndexOf('.') != -1)
				return;

			this.Value += ".";
		}

		public void BackSpace()
		{
			if (this.IsInt())
			{
				int iValue = this.GetInt();
				iValue /= 10;
				this.SetInt(iValue);
				return;
			}
			if (this.IsEmpty())
				return;

			this.Value = this.Value.Remove(this.Value.Length - 1);

			if (this.Value == "-")
				this.Value = "";
		}

		public void ChangeSign()
		{
			if (this.IsInt())
			{
				int iValue = this.GetInt();
				iValue *= -1;
				this.SetInt(iValue);
				return;
			}
			if (this.IsEmpty())
				this.Value = "0";

			if (this.Value[0] == '-')
				this.Value = this.Value.Remove(0, 1);
			else
				this.Value = "-" + this.Value;
		}

		// < Input

		public bool IsNegative()
		{
			return
				this.IsEmpty() == false &&
				this.Value[0] == '-';
		}
	}
}
