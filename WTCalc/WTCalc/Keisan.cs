using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace WTCalc
{
	public class Keisan : TCalcBase
	{
		private string TempDir;
		private string ParamsFile;
		private string AnswerFile;
		private string ProgFile;

		public Keisan()
		{
			this.TempDir = Path.Combine(Path.GetTempPath(), Gnd.I.KEISAN_UUID.ToUpper());
			this.ParamsFile = Path.Combine(this.TempDir, "1.txt");
			this.AnswerFile = Path.Combine(this.TempDir, "2.txt");
			this.ProgFile = "Keisan.exe";

			if (File.Exists(this.ProgFile) == false)
				this.ProgFile = "C:\\Factory\\Program\\TCalc\\Keisan.exe";
		}

		private Process Proc;

		public override bool Start(string operand1, string enzanshi, string operand2)
		{
			if (this.IsRunning())
				return false;

			if (
				string.IsNullOrEmpty(operand1) ||
				string.IsNullOrEmpty(enzanshi) ||
				string.IsNullOrEmpty(operand2)
				)
				return false;

			// べき乗も Keisan.exe の方が速いみたいだけど、TCalc.exe は桁数オーバーフローの処理が入ってるので、P は TCalc でやる！

			if (enzanshi != "R")
				return false;

			Directory.CreateDirectory(this.TempDir);
			File.WriteAllLines(
				this.ParamsFile,
				new string[]
				{
					"/R " + Gnd.I.Radix,
					"/B " + Gnd.I.Basement,
					operand1,
					enzanshi,
					operand2,
				},
				Encoding.ASCII
				);

			if (File.Exists(this.AnswerFile))
				FileTools.DeleteFile(this.AnswerFile);

			ProcessStartInfo psi = new ProcessStartInfo();

			psi.FileName = this.ProgFile;
			psi.Arguments = "//F \"" + this.ParamsFile + "\" //O \"" + this.AnswerFile + "\"";
			psi.CreateNoWindow = true;
			psi.UseShellExecute = false;

			this.Proc = Process.Start(psi);

			return true;
		}

		private bool FinishedFlag;

		public override bool IsRunning()
		{
			if (this.Proc != null)
			{
				if (this.Proc.HasExited)
				{
					this.FinishedFlag = true;
					this.Proc = null;
				}
			}
			return this.Proc != null;
		}

		public override bool IsFinished(bool flagKeep = false)
		{
			if (this.IsRunning() == false && this.FinishedFlag)
			{
				this.FinishedFlag = flagKeep;
				return true;
			}
			return false;
		}

		private void Cleanup()
		{
			FileTools.DeleteFile(this.ParamsFile);
			FileTools.DeleteFile(this.AnswerFile);
			Directory.Delete(this.TempDir);
		}

		public override void ForceExit()
		{
			if (this.IsRunning() == false)
				return;

			try
			{
				//this.Proc.CloseMainWindow(); // 止まらなかったorz
				this.Proc.Kill();
			}
			catch (Exception e)
			{
				SystemTools.WriteLog(e);
			}
			this.Proc = null;
			this.Cleanup();
		}

		public override string GetAnswer()
		{
			if (this.IsFinished() == false)
				return null;

			string answer = null;

			try
			{
				string[] lines = FileTools.TryReadAllLines(this.AnswerFile, Encoding.ASCII);

				answer = lines[lines.Length - 1];

				if (StringTools.IsCharOnly(answer, "-.0123456789abcdef") == false)
					throw new Exception("answerに問題があります。: " + answer);
			}
			catch (Exception e)
			{
				SystemTools.WriteLog(e);
				answer = Gnd.I.INVALID_ANSWER;
			}
			this.Cleanup();
			return answer;
		}
	}
}
