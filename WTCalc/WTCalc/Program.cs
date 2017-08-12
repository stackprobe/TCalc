using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Text;
using Charlotte;

namespace WTCalc
{
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			BootTools.OnBoot();

			Application.ThreadException += new ThreadExceptionEventHandler(ThreadException);
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);

			Mutex procMtx = new Mutex(false, "{4e8539c7-cb87-4f29-9528-a9d9498535ce}");

			if (procMtx.WaitOne(0) && GlobalProcMtx.Create("{260ee0b4-40f0-4abb-bbf5-7ce2e1f921cc}", APP_TITLE))
			{
				CheckSelfDir();
				CheckCopiedExe();

				SystemTools.WL_Start();

#if false // test
				SystemTools.WriteLog("LOG_TEST_01");
				SystemTools.WriteLog("LOG_TEST_02");
				SystemTools.WriteLog("LOG_TEST_03");
#endif

				Gnd.I.Load();

				// orig >

				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainWin());

				// < orig

				// ログオフ・シャットダウン時ここまで来ない！

				Gnd.I.CP.ForceExit();
				Gnd.I.KP.ForceExit();
				Gnd.I.K2.ForceExit();

				Gnd.I.Save();

				GlobalProcMtx.Release();
				procMtx.ReleaseMutex();
			}
			procMtx.Close();
		}

		private static void ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			try
			{
				UnhandledError(e.Exception, "ThreadException");
			}
			catch
			{ }

			Environment.Exit(1);
		}

		private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			try
			{
				UnhandledError(e.ExceptionObject, "UnhandledException");
			}
			catch
			{ }

			Environment.Exit(2);
		}

		private static void UnhandledError(object message, string reason)
		{
			message = "[" + reason + "] " + message;

			SystemTools.WriteLog(message);
			//SystemTools.ShowError(message); // アプリの性質から考えて予期しないエラーは黙って落ちた方がいいだろう。ログオフ・シャットダウン時とか...

			/*
			 * 2014.11.28
			 * 実行中のログオフ・シャットダウン対応について -> 設計上考慮しない。
			 * その上で、実行中のログオフ・シャットダウンに対応する。-> UnhandledError でログでも吐いて黙って Exit する。
			 * 対応しない。-> (従来どおり) UnhandledError でメッセージダイアログを表示して Exit する。
			 * という結論に至った。
			 */
		}

		public const string APP_TITLE = "TCalc";

		private static void CheckSelfDir()
		{
			string dir = BootTools.SelfDir;
			Encoding SJIS = Encoding.GetEncoding(932);

			if (dir != SJIS.GetString(SJIS.GetBytes(dir)))
			{
				MessageBox.Show(
					"Shift_JIS に変換出来ない文字を含むパスからは実行できません。",
					APP_TITLE + " / エラー",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
					);

				Environment.Exit(4);
			}
			if (dir.StartsWith("\\\\"))
			{
				MessageBox.Show(
					"ネットワークフォルダからは実行できません。",
					APP_TITLE + " / エラー",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
					);

				Environment.Exit(5);
			}
		}

		private static void CheckCopiedExe()
		{
			if (File.Exists("TCalc.exe")) // リリースに含まれるファイル
				return;

			if (Directory.Exists(@"..\Debug")) // ? devenv
				return;

			MessageBox.Show(
				"WHY AM I ALONE ?",
				"",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error
				);

			Environment.Exit(6);
		}
	}
}
