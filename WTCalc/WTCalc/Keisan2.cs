using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WTCalc
{
	public class Keisan2
	{
		public bool Start(string operand1, string enzanshi, string operand2) // ret: ? 開始した。
		{
			if ((
				(ToFormat(operand1) == "9" && operand1.Length <= 9) ||
				(ToFormat(operand1) == "-9" && operand1.Length <= 10)
				) && (
				(ToFormat(operand2) == "9" && operand2.Length <= 9) ||
				(ToFormat(operand2) == "-9" && operand2.Length <= 10)
				))
			{
				long a = long.Parse(operand1);
				long b = long.Parse(operand2);
				long ans;

				switch (enzanshi[0])
				{
					case '+': ans = a + b; break;
					case '-': ans = a - b; break;
					case '*': ans = a * b; break;
					case '/':
						if (a % b != 0) return false;
						ans = a / b;
						break;

					default:
						return false;
				}
				this.SetAnswer("" + ans);
				return true;
			}
			return false;
		}

		private static string ToFormat(string str)
		{
			str = StringTools.ReplaceSet(str, StringTools.DIGIT, "9");

			for (int c = 0; c < 10; c++)
				str = str.Replace("99", "9");

			return str;
		}

		private string Answer = null;
		private bool AnswerEnabled = false;

		private void SetAnswer(string ans)
		{
			this.Answer = ans;
			this.AnswerEnabled = true;
		}

		public string GetAnswer()
		{
			if (this.AnswerEnabled)
			{
				this.AnswerEnabled = false;
				return this.Answer;
			}
			return null;
		}

		public void ForceExit()
		{
			// noop
		}

		public bool IsRunning()
		{
			return false;
		}

		public bool IsFinished(bool flagKeep = false)
		{
			if (this.AnswerEnabled)
			{
				this.AnswerEnabled = flagKeep;
				return true;
			}
			return false;
		}
	}
}
