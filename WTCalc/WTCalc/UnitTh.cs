using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WTCalc
{
	public class UnitTh
	{
		public static UnitTh I;

		private object SYNCROOT = new object();
		private Thread Th;
		private bool DeadFlag;

		public UnitTh()
		{
			this.Start();
		}

		private void Start()
		{
			this.Th = new Thread((ThreadStart)delegate
			{
				try
				{
					this.MainTh();
				}
				catch
				{ }
			});

			this.Th.Start();
		}

		public void End()
		{
			this.DeadFlag = true;
			this.Th.Join();
			this.Th = null;
		}

		private void MainTh()
		{
			while(this.DeadFlag == false)
			{
				KeisanInfo ki;

				lock (this.SYNCROOT)
				{
					ki = this.Input;
					this.Input = null; // reset
				}
				if (ki == null)
				{
					Thread.Sleep(100);
					continue;
				}
				lock (this.SYNCROOT)
				{
					this.Output = "計算中...";
				}
				string ret = this.Keisan(ki);

				lock (this.SYNCROOT)
				{
					this.Output = ret;
				}
			}
		}

		public class KeisanInfo
		{
			public string Input;
			public int Basement;
			public string InputRateNumer;
			public string InputRateDenom;
			public string InputOrigin;
			public string OutputRateNumer;
			public string OutputRateDenom;
			public string OutputOrigin;
		}

		private string Keisan(KeisanInfo ki)
		{
			try
			{
				Calc calc = new Calc();
				string str = ki.Input;

				string denom = calc.DoCalc(ki.InputRateNumer, '*', ki.OutputRateDenom);

				str = calc.DoCalc(str, '-', ki.InputOrigin);
				str = calc.DoCalc(str, '*', ki.InputRateDenom);
				str = calc.DoCalc(str, '*', ki.OutputRateNumer);
				str = calc.DoCalc(str, '/', denom, ki.Basement);
				str = calc.DoCalc(str, '+', ki.OutputOrigin);

				return str;
			}
			catch (Exception e)
			{
				return "エラー：" + e.Message;
			}
		}

		private KeisanInfo Input;
		private string Output;

		public void SetKeisanInfo(KeisanInfo ki)
		{
			lock (this.SYNCROOT)
			{
				this.Input = ki;
			}
		}

		public string GetOutput()
		{
			lock (this.SYNCROOT)
			{
				string ret = this.Output;
				this.Output = null; // reset
				return ret;
			}
		}
	}
}
