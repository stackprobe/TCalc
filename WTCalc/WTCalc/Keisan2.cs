using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WTCalc
{
	public class Keisan2
	{
		private Thread _th = null;

		public bool Start(string operand1, string enzanshi, string operand2) // ret: ? 開始した。
		{
			return false; // TODO
		}

		public string GetAnswer()
		{
			if (this.IsFinished() == false)
				return null;

			return "1"; // TODO
		}

		public void ForceExit()
		{
			if (_th != null)
			{
				_th.Join(); // TODO
				_th = null;
			}
		}

		private bool FinishedFlag;

		public bool IsRunning()
		{
			if (_th != null)
			{
				if (_th.Join(0))
				{
					this.FinishedFlag = true;
					_th = null;
				}
			}
			return _th != null;
		}

		public bool IsFinished(bool flagKeep = false)
		{
			if (this.IsRunning() == false && this.FinishedFlag)
			{
				this.FinishedFlag = flagKeep;
				return true;
			}
			return false;
		}
	}
}
