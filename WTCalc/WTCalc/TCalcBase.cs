using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WTCalc
{
	public abstract class TCalcBase
	{
		public abstract bool Start(string operand1, string enzanshi, string operand2);
		public abstract bool IsRunning();
		public abstract bool IsFinished(bool flagKeep = false);
		public abstract void ForceExit();
		public abstract string GetAnswer();
	}
}
