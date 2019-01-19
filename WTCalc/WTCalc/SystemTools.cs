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
			WriteLog("ログ出力を開始しました。");
		}

		public static void WL_End()
		{
			WL_Enabled = false;
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
					using (StreamWriter writer = new StreamWriter(GetLogFile(), WL_Count++ % 1000 != 0, StringTools.ENCODING_SJIS))
					{
						writer.WriteLine("[" + DateTime.Now + "." + WL_Count.ToString("D3") + "] " + e);
					}
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

		public static void AntiWindowsDefenderSmartScreen()
		{
			WriteLog("awdss_1");

			if (Gnd.I.Is初回起動())
			{
				WriteLog("awdss_2");

				foreach (string exeFile in Directory.GetFiles(BootTools.SelfDir, "*.exe", SearchOption.TopDirectoryOnly))
				{
					try
					{
						WriteLog("awdss_exeFile: " + exeFile);

						if (exeFile.ToLower() == BootTools.SelfFile.ToLower())
						{
							WriteLog("awdss_self_noop");
						}
						else
						{
							byte[] exeData = File.ReadAllBytes(exeFile);
							File.Delete(exeFile);
							File.WriteAllBytes(exeFile, exeData);
						}
						WriteLog("awdss_OK");
					}
					catch (Exception e)
					{
						WriteLog(e);
					}
				}
				WriteLog("awdss_3");
			}
			WriteLog("awdss_4");
		}

		public static void PostShown(Form f)
		{
			List<Control.ControlCollection> controlTable = new List<Control.ControlCollection>();

			controlTable.Add(f.Controls);

			for (int index = 0; index < controlTable.Count; index++)
			{
				foreach (Control control in controlTable[index])
				{
					GroupBox gb = control as GroupBox;

					if (gb != null)
					{
						controlTable.Add(gb.Controls);
					}
					TabControl tc = control as TabControl;

					if (tc != null)
					{
						foreach (TabPage tp in tc.TabPages)
						{
							controlTable.Add(tp.Controls);
						}
					}
					TextBox tb = control as TextBox;

					if (tb != null)
					{
						if (tb.ContextMenuStrip == null)
						{
							ToolStripMenuItem item = new ToolStripMenuItem();

							item.Text = "項目なし";
							item.Enabled = false;

							ContextMenuStrip menu = new ContextMenuStrip();

							menu.Items.Add(item);

							tb.ContextMenuStrip = menu;
						}
					}
				}
			}
		}
	}
}
