using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;

namespace WTCalc
{
	public class SystemTools
	{
		public static void ShowOverflow()
		{
			try
			{
				MessageBox.Show(
					"桁数が大きすぎます。\nこれ以上数字を追加することは出来ません。",
					"被演算子のオーバーフロー",
					MessageBoxButtons.OK,
					MessageBoxIcon.Warning
					);
			}
			catch
			{ }
		}

#if false
		public static void ShowError(object message, string caption = "TCalc エラー")
		{
			try
			{
				MessageBox.Show(
					"" + message,
					"" + caption,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
					);
			}
			catch
			{ }
		}
#endif

		private static object SYNCROOT = new object();
		private static bool WL_Enabled = false;
		private static int WL_Count = 0;

		public static void WL_Start()
		{
			WL_Enabled = true;
			File.Delete(GetLogFile());
		}

		public static void WriteLog(object e)
		{
			try
			{
				if (WL_Enabled == false)
					return;

				lock (SYNCROOT)
				{
					if (1000 < WL_Count)
						return;

					using (StreamWriter sw = new StreamWriter(GetLogFile(), true, StringTools.ENCODING_SJIS))
					{
						sw.WriteLine("[" + DateTime.Now + "." + WL_Count + "] " + e);
					}
					WL_Count++;
				}
			}
			catch
			{ }
		}

		private static string GetLogFile()
		{
			return BootTools.SelfFile + ".log";
		}

		private static long CT_Count = 0;

		public static void CommonTimer()
		{
			try
			{
				if (CT_Count % 2000 == 20)
				{
					GC.Collect();
				}
			}
			finally
			{
				CT_Count++;
			}
		}
	}
}
