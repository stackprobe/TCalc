using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace WTCalc
{
	public class TCalc : TCalcBase
	{
		private string TempDir;
		private string Operand1File;
		private string Operand2File;
		private string AnswerFile;
		private string ProgFile;

		public TCalc()
		{
			this.TempDir = Path.Combine(Path.GetTempPath(), Gnd.I.APP_UUID.ToUpper());
			this.Operand1File = Path.Combine(this.TempDir, "1.txt");
			this.Operand2File = Path.Combine(this.TempDir, "2.txt");
			this.AnswerFile = Path.Combine(this.TempDir, "3.txt");
			this.ProgFile = "TCalc.exe";

			if (File.Exists(this.ProgFile) == false)
				this.ProgFile = "..\\..\\..\\..\\TCalc\\Release\\TCalc.exe";
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

			Directory.CreateDirectory(this.TempDir);
			File.WriteAllText(this.Operand1File, operand1, Encoding.ASCII);
			File.WriteAllText(this.Operand2File, operand2, Encoding.ASCII);

			if (File.Exists(this.AnswerFile))
				FileTools.DeleteFile(this.AnswerFile);

			ProcessStartInfo psi = new ProcessStartInfo();

			psi.FileName = this.ProgFile;
			psi.Arguments =
				"/A \"" + this.AnswerFile + "\"" +
				" /R " + Gnd.I.Radix +
				" /B " + Gnd.I.Basement +
				" /E:01 " + Gnd.I.OPERAND_LENMAX +
				" \"@" + this.Operand1File + "\"" +
				" " + enzanshi +
				" \"@" + this.Operand2File + "\"";
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
			FileTools.DeleteFile(this.Operand1File);
			FileTools.DeleteFile(this.Operand2File);
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
			catch
			{ }

			this.Proc = null;
			this.Cleanup();
		}

		public override string GetAnswer()
		{
			if (this.IsFinished() == false)
				return null;

			string answer;

			if (File.Exists(this.AnswerFile))
				answer = string.Join("", FileTools.TryReadAllLines(this.AnswerFile, Encoding.ASCII));
			else
				answer = Gnd.I.INVALID_ANSWER;

			this.Cleanup();
			return answer;
		}
	}
}
